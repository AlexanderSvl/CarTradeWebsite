import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../constants/enviroment'
import { Observable } from '../../../node_modules/rxjs/dist/types/index'; 
import { CarResponseModel } from '../models/carResponseModel';

@Injectable({
  providedIn: 'root'
})

export class SearchService {
    constructor(private http: HttpClient){}

    searchTitle(keywords: string): Observable<CarResponseModel> {
        return this.http.get<CarResponseModel>(`${environment.baseUrl}/search/title?titleKeywords=${keywords}`);
    }

    searchDescription(keywords: string): Observable<CarResponseModel> {
        return this.http.get<CarResponseModel>(`${environment.baseUrl}/search/description?descriptionKeywords=${keywords}`);
    }

    searchCarMake(keywords: string): Observable<CarResponseModel> {
        return this.http.get<CarResponseModel>(`${environment.baseUrl}/search/carMake?carMake=${keywords}`);
    }

    searchCarModel(keywords: string): Observable<CarResponseModel> {
        return this.http.get<CarResponseModel>(`${environment.baseUrl}/search/carModel?carModel=${keywords}`);
    }

    searchFuelType(keywords: string): Observable<CarResponseModel> {
        return this.http.get<CarResponseModel>(`${environment.baseUrl}/search/fuelType?fuelType=${keywords}`);
    }

    searchEngineDisplacement(keywords: string): Observable<CarResponseModel> {
        return this.http.get<CarResponseModel>(`${environment.baseUrl}/search/engineDisplacement?engineDisplacement=${keywords}`);
    }

    searchTransmissionType(keywords: string): Observable<CarResponseModel> {
        return this.http.get<CarResponseModel>(`${environment.baseUrl}/search/transmissionType?transmissionType=${keywords}`);
    }

    searchYearOfProduction(start: string, end: string): Observable<CarResponseModel> {
        return this.http.get<CarResponseModel>(`${environment.baseUrl}/search/yearOfProduction?start=${start}&end=${end}`);
    }
}