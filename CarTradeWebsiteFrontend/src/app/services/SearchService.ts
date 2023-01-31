import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../constants/enviroment'
import { Observable } from '../../../node_modules/rxjs/dist/types/index'; 
import { CarResponseModel } from '../models/carResponseModel';

@Injectable({
  providedIn: 'root'
})

export class CarPostService {
    constructor(private http: HttpClient){}

    searchTitle(): Observable<CarResponseModel> {
        return this.http.get<CarResponseModel>(`${environment.baseUrl}/search/title`);
    }

    searchDescription(): Observable<CarResponseModel> {
        return this.http.get<CarResponseModel>(`${environment.baseUrl}/search/description`);
    }

    searchCarMake(): Observable<CarResponseModel> {
        return this.http.get<CarResponseModel>(`${environment.baseUrl}/search/carMake`);
    }

    searchModel(): Observable<CarResponseModel> {
        return this.http.get<CarResponseModel>(`${environment.baseUrl}/search/carModel`);
    }

    searchFuelType(): Observable<CarResponseModel> {
        return this.http.get<CarResponseModel>(`${environment.baseUrl}/search/fuelType`);
    }

    searchEngineDisplacement(): Observable<CarResponseModel> {
        return this.http.get<CarResponseModel>(`${environment.baseUrl}/search/engineDisplacement`);
    }

    searchTransmissionType(): Observable<CarResponseModel> {
        return this.http.get<CarResponseModel>(`${environment.baseUrl}/search/transmissionType`);
    }

    searchYearOfProduction(startYear: number, endYear: number): Observable<CarResponseModel> {
        return this.http.get<CarResponseModel>(`${environment.baseUrl}/search/yearOfProduction`);
    }
}