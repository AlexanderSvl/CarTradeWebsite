using CarTradeWebsite.Context;
using CarTradeWebsite.DataAccess.Repositories.Interfaces;
using CarTradeWebsite.Models;
using CarTradeWebsite.Models.Search;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace CarTradeWebsite.DataAccess.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private static DatabaseContext context = new DatabaseContext();

        public async Task<IEnumerable<PostModel>> SearchPosts(SearchParameters searchParameters)
        {
            var query = context.Posts.AsQueryable();

            if (IsEveryPropertyNull(searchParameters))
            {
                return Enumerable.Empty<PostModel>();
            }

            if (!string.IsNullOrEmpty(searchParameters.Title))
            {
                query = query.Where(post => post.Title.Contains(searchParameters.Title));
            }

            if (!string.IsNullOrEmpty(searchParameters.Description))
            {
                query = query.Where(post => post.Description.Contains(searchParameters.Description));
            }

            if (!string.IsNullOrEmpty(searchParameters.CarMake))
            {
                query = query.Where(post => post.CarMake.Contains(searchParameters.CarMake));
            }

            if (!string.IsNullOrEmpty(searchParameters.CarModel))
            {
                query = query.Where(post => post.CarModel.Contains(searchParameters.CarModel));
            }

            if (!string.IsNullOrEmpty(searchParameters.TransmissionType))
            {
                query = query.Where(post => post.TransmissionType.Contains(searchParameters.TransmissionType));
            }

            if (!string.IsNullOrEmpty(searchParameters.FuelType))
            {
                query = query.Where(post => post.FuelType == searchParameters.FuelType);
            }

            if (!string.IsNullOrEmpty(searchParameters.EngineDisplacement))
            {
                query = query.Where(post => post.EngineDisplacement.Contains(searchParameters.EngineDisplacement));
            }

            if (!string.IsNullOrEmpty(searchParameters.Color))
            {
                query = query.Where(post => post.Color.Contains(searchParameters.Color));
            }

            if ((searchParameters.StartYearOfProduction != null))
            {
                if (searchParameters.EndYearOfProduction != null)
                {
                    query = query.Where(post => post.YearOfProduction > searchParameters.StartYearOfProduction &&
                                            post.YearOfProduction < searchParameters.EndYearOfProduction);
                }

                query = query.Where(post => post.YearOfProduction > searchParameters.StartYearOfProduction);
            }
            else if ((searchParameters.EndYearOfProduction != null))
            {
                if (searchParameters.StartYearOfProduction != null)
                {
                    query = query.Where(post => post.YearOfProduction > searchParameters.StartYearOfProduction &&
                                            post.YearOfProduction < searchParameters.EndYearOfProduction);
                }

                query = query.Where(post => post.YearOfProduction < searchParameters.EndYearOfProduction);
            }

            if ((searchParameters.StartMileage != null))
            {
                if (searchParameters.EndMileage != null)
                {
                    query = query.Where(post => post.Mileage > searchParameters.StartMileage &&
                                            post.Mileage < searchParameters.EndMileage);
                }

                query = query.Where(post => post.Mileage > searchParameters.StartMileage);
            }
            else if ((searchParameters.EndMileage != null))
            {
                if (searchParameters.StartMileage != null)
                {
                    query = query.Where(post => post.Mileage > searchParameters.StartMileage &&
                                            post.Mileage < searchParameters.EndMileage);
                }

                query = query.Where(post => post.Mileage < searchParameters.EndMileage);
            }

            if (!string.IsNullOrEmpty(searchParameters.EngineLayout))
            {
                query = query.Where(post => post.EngineLayout.Contains(searchParameters.EngineLayout));
            }

            if (!string.IsNullOrEmpty(searchParameters.Location))
            {
                query = query.Where(post => post.Location.Contains(searchParameters.Location));
            }

            if (searchParameters.Options != null)
            {
                List<string> options = searchParameters.Options.ToList();
                bool bigMatch = false;

                List<PostModel> postsMatched = new List<PostModel>();

                int count = 0;

                foreach (PostModel post in query.Include(x => x.Options))
                {
                    foreach (OptionModel option in post.Options)
                    {
                        foreach (string optionName in options)
                        {
                            if(option.Name.ToLower() == optionName.ToLower())
                            {
                                count++;
                            }
                        }
                        
                        if (count == options.Count)
                        {
                            postsMatched.Add(post);
                        }
                    } 

                    count = 0;
                }

                if(postsMatched.Count > 0)
                {
                    query = query.Where(x => postsMatched.Contains(x));
                }
                else
                {
                    return Enumerable.Empty<PostModel>();
                }
            }

            if ((searchParameters.StartPrice != null))
            {
                if (searchParameters.EndPrice != null)
                {
                    query = query.Where(post => post.Price > searchParameters.StartPrice &&
                                            post.Price < searchParameters.EndPrice);
                }
                 
                query = query.Where(post => post.Price > searchParameters.StartPrice);
            }
            else if ((searchParameters.EndPrice != null))
            {
                if (searchParameters.StartPrice != null)
                {
                    query = query.Where(post => post.Price > searchParameters.StartPrice &&
                                            post.Price < searchParameters.EndPrice);
                }

                query = query.Where(post => post.Price < searchParameters.EndPrice);
            }

            return query
                .Include(post => post.CarImages)
                .Include(post => post.Options)
                .ToList();
        }

        public bool IsEveryPropertyNull(object searchParameters)
        {
            int nullPropertiesCounter = 0;

            foreach (PropertyInfo info in searchParameters.GetType().GetProperties())
            {
                if (info.PropertyType == typeof(decimal?))
                {
                    decimal? value = (decimal?)info.GetValue(searchParameters);

                    if (value == null)
                    {
                        nullPropertiesCounter++;
                    }
                }

                if (info.PropertyType == typeof(int?))
                {
                    int? value = (int?)info.GetValue(searchParameters);

                    if (value == null)
                    {
                        nullPropertiesCounter++;
                    }
                }

                if(info.PropertyType == typeof(string))
                {
                    string value = (string)info.GetValue(searchParameters);

                    if (string.IsNullOrEmpty(value))
                    {
                        nullPropertiesCounter++;
                    }
                }

                if (info.PropertyType == typeof(string[]))
                {
                    string[] value = (string[])info.GetValue(searchParameters);

                    if (value == null)
                    {
                        nullPropertiesCounter++;
                    }
                }
            }

            Console.WriteLine(nullPropertiesCounter);

            if (nullPropertiesCounter == searchParameters.GetType().GetProperties().Length)
            {
                return true;
            }
            else
            {
               return false;
            }
        }
    }
}
