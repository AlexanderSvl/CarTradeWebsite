import { Component, Inject, OnInit } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { CarResponseModel } from 'src/app/models/carResponseModel';
import { CarPostService } from 'src/app/services/CarPostService';
import { Observable } from 'rxjs';
import { OptionResponseModel } from 'src/app/models/optionResponseModel';
import { ImageResponseModel } from 'src/app/models/imageResponseModel';

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
  currentCarImages: ImageResponseModel[] = [];

  constructor(@Inject(DOCUMENT) private document: Document, private postService: CarPostService) {
    this.href = this.document.location.href;
    this.currentId = this.href.substring(this.href.lastIndexOf('/') + 1);
  }

  ngOnInit(): void {
    this.postService.getPostById(this.currentId).subscribe((res: any) => {
      this.currentCar = res;
      this.currentCarOptions = this.currentCar.options;
      this.currentCarImages = this.currentCar.carImages;
    });
  }

  changePictures(id: any){
    for (let i = 0; i < this.currentCarImages.length; i++) {
      if(this.currentCarImages[i].id == id){
        this.currentCar.coverImageURL = this.currentCarImages[i].url;
      }
    }
  }
}
