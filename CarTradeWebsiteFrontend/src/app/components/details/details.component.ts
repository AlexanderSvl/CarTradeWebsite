import { Component, Inject, OnInit } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { CarResponseModel } from 'src/app/models/carResponseModel';
import { CarPostService } from 'src/app/services/CarPostService';
import { OptionResponseModel } from 'src/app/models/optionResponseModel';
import { ImageResponseModel } from 'src/app/models/imageResponseModel';
import { NgToastService } from 'ng-angular-popup';

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

  constructor(@Inject(DOCUMENT) private document: Document, private postService: CarPostService, private toast: NgToastService) {
    this.href = this.document.location.href;
    this.currentId = this.href.substring(this.href.lastIndexOf('/') + 1);
  }

  ngOnInit(): void {
    this.postService.getPostById(this.currentId).subscribe((res: any) => {
      this.currentCar = res;
      this.currentCarImages.push(
        new ImageResponseModel("1", this.currentCar.coverImageURL)
      )
      this.currentCarOptions = this.currentCar.options;
      this.currentCarImages = this.currentCar.carImages;
    });

  }

  changePictures(id: any){
    let element = document.getElementById(id) as HTMLImageElement;
    let main = document.getElementById("main") as HTMLImageElement;

    main.src = element.src;
  }

  numberWithCommas(number: any, spacer: string) {
    return number.toString().replace(/\B(?=(\d{3})+(?!\d))/g, spacer);
  }

  buy(){
    this.toast.success({detail:"SUCCESS",summary:'The seller will be notified!',duration:4000, position: "tl"});
  }
}
