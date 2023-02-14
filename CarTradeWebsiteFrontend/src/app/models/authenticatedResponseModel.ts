import { OptionModel } from './optionModel'; 
import { ImageModel } from './imageModel';
import { DecimalPipe } from '@angular/common';

export class AuthenticatedResponseModel {
    constructor(
    public token: string
    ){}
}