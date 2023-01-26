import { OptionModel } from './optionModel'; 
import { ImageModel } from './imageModel';
import { ImageResponseModel } from './imageResponseModel';
import { OptionResponseModel } from './optionResponseModel';

export class CarResponseModel {
    constructor(
    public id: string,
    public title: string,
    public carImages: ImageResponseModel[],
    public coverImageURL: string,
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
    public options: OptionResponseModel[],
    public dateOfCreation: Date
    ){}
}