import { Component, OnInit } from '@angular/core';
import { CarModel } from 'src/app/models/carModel';
import { ImageModel } from 'src/app/models/imageModel';
import { OptionModel } from 'src/app/models/optionModel';
import { CarPostService } from 'src/app/services/CarPostService';
import { Router } from '@angular/router';
import { Validation } from 'src/app/constants/validations';

@Component({
  selector: 'app-add-listing',
  templateUrl: './add-listing.component.html',
  styleUrls: ['./add-listing.component.scss']
})
export class AddListingComponent{

  images: ImageModel[] = [];
  options: OptionModel[] = [];
  car = new CarModel("", this.images, "", "", "", "", "", null, null, "", "", "", "", "", null, this.options, new Date);
  isInputValid = false;

  constructor(private postService: CarPostService, private router: Router){}

  onSubmit(){
    this.addImagesAndOptions();
    this.car.dateOfCreation = new Date;
    this.car.coverImageURL = this.images.find(x=>x!==undefined).URL;
    

    if(this.checkValidation()){
      this.createPost();
    }
    else {
      alert("Invalid form! Check your infomation.")
    }
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
    this.postService.createPost(jsonRequest).subscribe(x => {
      alert("Success!")
      this.router.navigate(['home'])
    }, err => {
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

  checkValidation(): boolean{
    let listingTitleElement = document.getElementById('title') as HTMLElement;
    let listingDescriptionElement = document.getElementById('description') as HTMLElement;
    let listingCarMakeElement = document.getElementById('carMake') as HTMLElement;
    let listingCarModelElement = document.getElementById('carModel') as HTMLElement;
    let listingEngineDisplacementElement = document.getElementById('engineDisplacement') as HTMLElement;
    let listingLocationElement = document.getElementById('location') as HTMLElement;
    let listingColorElement = document.getElementById('color') as HTMLElement;
    let listingEngineLayoutElement = document.getElementById('engineLayout') as HTMLElement;

    let titleCheck = false;
    let descriptionCheck = false;
    let carMakeCheck = false;
    let carModelCheck = false;
    let engineDisplacementCheck = false;
    let locationCheck = false;
    let colorCheck = false;
    let engineLayoutCheck = false;

    if(Validation.listingValidations.listingTitleValidation.test(this.car.title)){
      titleCheck = true;
      listingTitleElement.style.borderBottomColor = 'green';
      listingTitleElement.style.borderBottom = '3px solid green'
    }
    else{
      titleCheck = false;
      listingTitleElement.style.borderBottomColor = 'red';
      listingTitleElement.style.borderBottom = '3px solid red'
    }

    /////

    if(Validation.listingValidations.listingDescriptionValidation.test(this.car.description)){
      descriptionCheck = true;
      listingDescriptionElement.style.borderBottomColor = 'green';
      listingDescriptionElement.style.borderBottom = '3px solid green'
    }
    else{
      descriptionCheck = false;
      listingDescriptionElement.style.borderBottomColor = 'red';
      listingDescriptionElement.style.borderBottom = '3px solid red'
    }
    
    /////

    if(Validation.listingValidations.carMakeModelColorValidation.test(this.car.carMake)){
      carMakeCheck = true;
      listingCarMakeElement.style.borderBottomColor = 'green';
      listingCarMakeElement.style.borderBottom = '3px solid green'
    }
    else{
      carMakeCheck = false;
      listingCarMakeElement.style.borderBottomColor = 'red';
      listingCarMakeElement.style.borderBottom = '3px solid red'
    }

    /////

    if(Validation.listingValidations.carMakeModelColorValidation.test(this.car.carModel)){
      carModelCheck = true;
      listingCarModelElement.style.borderBottomColor = 'green';
      listingCarModelElement.style.borderBottom = '3px solid green'
    }
    else{
      carModelCheck = false;
      listingCarModelElement.style.borderBottomColor = 'red';
      listingCarModelElement.style.borderBottom = '3px solid red'
    }

    /////

    if(Validation.listingValidations.listingEngineDisplacementValidation.test(this.car.engineDisplacement)){
      engineDisplacementCheck = true;
      listingEngineDisplacementElement.style.borderBottomColor = 'green';
      listingEngineDisplacementElement.style.borderBottom = '3px solid green'
    }
    else{
      engineDisplacementCheck = false;
      listingEngineDisplacementElement.style.borderBottomColor = 'red';
      listingEngineDisplacementElement.style.borderBottom = '3px solid red'
    }

    /////

    if(Validation.listingValidations.listingLocationValidation.test(this.car.location)){
      locationCheck = true;
      listingLocationElement.style.borderBottomColor = 'green';
      listingLocationElement.style.borderBottom = '3px solid green'
    }
    else{
      locationCheck = false;
      listingLocationElement.style.borderBottomColor = 'red';
      listingLocationElement.style.borderBottom = '3px solid red'
    }

    /////

    if(Validation.listingValidations.carMakeModelColorValidation.test(this.car.color)){
      colorCheck = true;
      listingColorElement.style.borderBottomColor = 'green';
      listingColorElement.style.borderBottom = '3px solid green'
    }
    else{
      colorCheck = false;
      listingColorElement.style.borderBottomColor = 'red';
      listingColorElement.style.borderBottom = '3px solid red'
    }

     /////

    if(Validation.listingValidations.listingEngineLayoutValidation.test(this.car.engineLayout)){
      engineLayoutCheck = true;
      listingEngineLayoutElement.style.borderBottomColor = 'green';
      listingEngineLayoutElement.style.borderBottom = '3px solid green'
    }
    else{
      engineLayoutCheck = false;
      listingEngineLayoutElement.style.borderBottomColor = 'red';
      listingEngineLayoutElement.style.borderBottom = '3px solid red'
    }

    if(titleCheck && descriptionCheck && carMakeCheck && carModelCheck && engineDisplacementCheck && locationCheck && colorCheck){
      this.isInputValid = true;
      return true;
    }

    return false;
  }
}
