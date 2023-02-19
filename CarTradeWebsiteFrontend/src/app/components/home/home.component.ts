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

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  cars: CarResponseModel[] = [];
  
  constructor(private http: HttpClient, private router: Router, private postService: CarPostService){}

  ngOnInit() {  
    this.postService.getPosts().subscribe((res: any) => {
      for (let i = 0; i < res.length; i++) {
        this.cars.push(res[i]);
      }
    });

    window.setTimeout(() => {
      document.getElementById("odometer")!.innerHTML = "234";
    })
  }

  numberWithCommas(x: any) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, " ");
  }
}