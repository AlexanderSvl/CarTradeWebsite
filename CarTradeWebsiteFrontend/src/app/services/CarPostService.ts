import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CarModel } from '../models/carModel';
import { environment } from '../constants/enviroment'
import { Observable } from '../../../node_modules/rxjs/dist/types/index'; 
import { CarResponseModel } from '../models/carResponseModel';

@Injectable({
  providedIn: 'root'
})

export class CarPostService {
    constructor(private http: HttpClient){}

    getPosts(): Observable<CarResponseModel> {
        return this.http.get<CarResponseModel>(`${environment.baseUrl}/posts/get`);
    }

    getPostById(ID: String): Observable<CarResponseModel> {
        return this.http.get<CarResponseModel>(`${environment.baseUrl}/posts/get/${ID}`);
    }

    createPost(data: any): Observable<CarResponseModel> {
        return this.http.post<CarResponseModel>(`${environment.baseUrl}/posts/new`, data, {headers:{'Content-Type':'application/json'}});
    }
}