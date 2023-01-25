import { Component, Inject, OnInit } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { CarResponseModel } from 'src/app/models/carResponseModel';
import { CarPostService } from 'src/app/services/CarPostService';
import { Observable } from 'rxjs';
import { OptionResponseModel } from 'src/app/models/optionResponseModel';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit{
  href: String;
  currentId: String;
  currentCar!: CarResponseModel;
  currentCarOptions: OptionResponseModel[] = [];

  constructor(@Inject(DOCUMENT) private document: Document, private postService: CarPostService) {
    this.href = this.document.location.href;
    this.currentId = this.href.substring(this.href.lastIndexOf('/') + 1);
  }

  ngOnInit(): void {
    this.postService.getPostById(this.currentId).subscribe((res: any) => {
      this.currentCar = res;
      this.currentCarOptions = this.currentCar.options;
    });
  }
}
