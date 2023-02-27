import { Component } from '@angular/core';
import { CarModel } from 'src/app/models/carModel';
import { ImageModel } from 'src/app/models/imageModel';
import { OptionModel } from 'src/app/models/optionModel';
import { CarPostService } from 'src/app/services/CarPostService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-listing',
  templateUrl: './add-listing.component.html',
  styleUrls: ['./add-listing.component.scss']
})
export class AddListingComponent {
  images: ImageModel[] = [];
  options: OptionModel[] = [];
  car = new CarModel("", this.images, "", "", "", "", "", 0, 0, "", "", "", "", "", 0, this.options, new Date);

  constructor(private postService: CarPostService, private router: Router){}

  onSubmit(){
    this.addImagesAndOptions();
    this.car.dateOfCreation = new Date;
    this.car.coverImageURL = this.images[0].URL;
    
    this.createPost();
  }

  createPost(){
    const data = {
      title: this.car.title,
      carImages: this.car.images,
      coverImageURL: this.car.coverImageURL,
      carMake: this.car.carMake,
      carModel: this.car.carModel,
      fuelType: this.car.fuelType,
      engineLayout: this.car.engineLayout,
      mileage: this.car.mileage,
      yearOfProduction: this.car.yearOfProduction,
      color: this.car.color,
      engineDisplacement: this.car.engineDisplacement,
      transmissionType: this.car.transmissionType,
      description: this.car.description,
      location: this.car.location,
      price: this.car.price,
      options: this.car.options,
      dateOfCreation: this.car.dateOfCreation
    }

    const jsonRequest = JSON.stringify(data);
    console.log(jsonRequest);
    this.postService.createPost(jsonRequest).subscribe(x => {
      alert("Success!")
      this.router.navigate(['home'])
    }, err => {
      console.log(err)
      alert("Incorrect email or password.")
    }); 
  }

  addImagesAndOptions(){
    let currentImages = (document.getElementById('images') as HTMLInputElement).value;
    let currentOptions = (document.getElementById('options') as HTMLInputElement).value;

    let imagesArr = currentImages.split(/[\s,]+/);

    imagesArr.forEach(element => {
      this.images.push({
        URL: element
      })
    });

    let optionsArr = currentOptions.split(/[\s,]+/);
    
    optionsArr.forEach(element => {
      this.options.push({
        name: element
      })
    });
  }
}
