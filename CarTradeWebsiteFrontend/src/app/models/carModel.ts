import { OptionModel } from './optionModel'; 
import { ImageModel } from './imageModel';
import { DecimalPipe } from '@angular/common';

export class CarModel {
    constructor(
    public title: string,
    public images: ImageModel[],
    public carMake: string,
    public carModel: string,
    public fuelType: string,
    public engineLayout: string,
    public mileage: number,
    public yearOfProduction: number,
    public color: string,
    public engineDisplacement: string,
    public transmissionType: string,
    public description: string,
    public location: string,
    public price: number,
    public options: OptionModel[],
    public dateOfCreation: Date
    ){}
}