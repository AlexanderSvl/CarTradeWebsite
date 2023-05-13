import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SearchService } from 'src/app/services/SearchService';
import { CarResponseModel } from 'src/app/models/carResponseModel';
import { CarModel } from 'src/app/models/carModel';
import { SearchModel } from 'src/app/models/searchModel';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent {
  cars: CarResponseModel[] = [];
  searchParameters = new SearchModel(null, null, null, null, "", "", null, null, null, null, null, null, null, null, null,  null, null);
  options: string = "";

  constructor(private http: HttpClient, public searchService: SearchService) {}

  onSubmit(){
    this.searchParameters.options = this.options.split(", "). join(",").split(",");
    this.searchService.search(this.searchParameters).subscribe((res: any) => {
      console.log(res);
    });
  }
}
