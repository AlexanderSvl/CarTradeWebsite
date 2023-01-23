import { OptionModel } from './optionModel'; 
import { ImageModel } from './imageModel';

export class CarResponseModel {
    constructor(
    public id: string,
    public title: string,
    public images: ImageModel[],
    public coverImageURL: string,
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