import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SearchService } from 'src/app/services/SearchService';
import { CarResponseModel } from 'src/app/models/carResponseModel';
import { CarModel } from 'src/app/models/carModel';
import { SearchModel } from 'src/app/models/searchModel';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent {
  cars: CarResponseModel[] = [];
  searchParameters = new SearchModel(null, null, null, null, "", "", null, null, null, null, null, null, null, null, null,  null, null);
  options: string = "";

  constructor(private http: HttpClient, public searchService: SearchService, private router: Router, private toast: NgToastService) { }

  onSubmit(){
    this.searchParameters.options = this.options.split(", "). join(",").split(",");
    this.searchService.search(this.searchParameters).subscribe((res: any) => {
      for (let i = 0; i < res.length; i++) {
        this.cars.push(res[i]);
      }

      localStorage.setItem("cars", (JSON.stringify(this.cars)));
      this.router.navigate(['searchResults']);
    }, error => {
      this.cars = [];
      localStorage.removeItem("cars");
      this.toast.warning({detail:"WARNING",summary:'No cars match your requirements!',duration:4000, position: "tl"});
    });
  }

  numberWithCommas(number: any, spacer: string) {
    return number.toString().replace(/\B(?=(\d{3})+(?!\d))/g, spacer);
  }
}
