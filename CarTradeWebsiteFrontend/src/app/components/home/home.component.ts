import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { CarPostService } from 'src/app/services/CarPostService';
import { CarResponseModel } from 'src/app/models/carResponseModel';
import { OptionModel } from 'src/app/models/optionModel';
import { ImageModel } from 'src/app/models/imageModel';
import { json } from 'stream/consumers';
import { routePaths } from '../../constants/routes'
import { setTimeout } from 'timers/promises';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  itemsPerPage: number = 5;
  page: number = 1;
  cars: CarResponseModel[] = [];
  
  constructor(private http: HttpClient, private router: Router, private postService: CarPostService, private toast: NgToastService){}

  ngOnInit() {  

    this.postService.getPosts().subscribe((res: any) => {
      for (let i = 0; i < res.length; i++) {
        this.cars.push(res[i]);
      }
    });
  }

  numberWithCommas(number: any, spacer: string) {
    return number.toString().replace(/\B(?=(\d{3})+(?!\d))/g, spacer);
  }
}