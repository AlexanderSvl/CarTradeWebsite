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
  cars: CarResponseModel[] = [];

  constructor(private http: HttpClient, public searchService: SearchService) {}

  onSelect(value: string){
  }

  onSubmit(){
    
  }
}
