import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CarModel } from '../models/carModel';
import { environment } from '../constants/enviroment'
import { AuthenticatedResponseModel } from '../models/authenticatedResponseModel';
import { UserLoginModel } from '../models/userLoginModel';
import { Observable } from '../../../node_modules/rxjs/dist/types/index'; 

@Injectable({
  providedIn: 'root'
})

export class AuthenticationService {
    constructor(private http: HttpClient){}

    login(data: UserLoginModel): Observable<AuthenticatedResponseModel> {
        return this.http.post<AuthenticatedResponseModel>(`${environment.baseUrl}/login`, data);
    }
}