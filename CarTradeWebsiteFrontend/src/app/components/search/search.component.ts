import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SearchService } from 'src/app/services/SearchService';
import { CarResponseModel } from 'src/app/models/carResponseModel';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent {
  startYear = '';
  endYear = '';
  selectedOption = "";
  searchTerms = "";
  cars: CarResponseModel[] = [];

  constructor(private http: HttpClient, public searchService: SearchService) {}

  onSelect(value: string){
    this.selectedOption = value;
  }

  onSubmit(){
    if(this.startYear != "" && this.endYear != ""){
      this.searchService.searchYearOfProduction(this.startYear, this.endYear).subscribe((data: any) => {
        for (let i = 0; i < data.length; i++) {
          this.cars.push(data[i]);
        }

        if(this.selectedOption = "Title"){
          this.searchService.searchTitle(this.searchTerms).subscribe((res: any) => {

          })
        }
        else if(this.selectedOption = "Description"){
          this.searchService.searchDescription(this.searchTerms).subscribe((res: any) => {
            
          })
        }
        else if(this.selectedOption = "Car Make"){
          this.searchService.searchCarMake(this.searchTerms).subscribe((res: any) => {
            
          })
        }
        else if(this.selectedOption = "Car Model"){
          this.searchService.searchCarModel(this.searchTerms).subscribe((res: any) => {
            
          })
        }
        else if(this.selectedOption = "Engine Displacement"){
          this.searchService.searchEngineDisplacement(this.searchTerms).subscribe((res: any) => {
            
          })
        }
        else if(this.selectedOption = "TransmissionType"){
          this.searchService.searchTransmissionType(this.searchTerms).subscribe((res: any) => {
            
          })
        }

      });
    }

    console.log(this.cars)
  }
}
