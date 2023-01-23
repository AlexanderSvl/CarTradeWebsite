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
    public motorDisplacement: string,
    public transmissionType: string,
    public description: string,
    public location: string,
    public price: number,
    public options: OptionModel[],
    public dateOfCreation: Date
    ){}
}