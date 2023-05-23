import { Component, OnInit } from '@angular/core';
import { CarResponseModel } from 'src/app/models/carResponseModel';

@Component({
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.scss']
})
export class SearchResultsComponent implements OnInit{
  itemsPerPage: number = 5;
  page: number = 1;
  cars: CarResponseModel[] = [];

  ngOnInit(): void {
    let obj = JSON.parse(localStorage.getItem("cars"))
      
      obj.forEach(element => {
        this.cars.push(element as CarResponseModel);
      });
  }

  numberWithCommas(number: any, spacer: string) {
    return number.toString().replace(/\B(?=(\d{3})+(?!\d))/g, spacer);
  }
}
