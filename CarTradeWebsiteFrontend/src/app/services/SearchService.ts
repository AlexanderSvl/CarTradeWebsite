import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../constants/enviroment'
import { Observable } from '../../../node_modules/rxjs/dist/types/index'; 
import { CarResponseModel } from '../models/carResponseModel';
import { stringify } from 'querystring';
import { SearchModel } from '../models/searchModel';

@Injectable({
  providedIn: 'root'
})

export class SearchService {
    constructor(private http: HttpClient){}

    search(searchParameters: SearchModel): Observable<CarResponseModel> {
        let data = "";
        let isAnyDataValid = false;

        Object.entries(searchParameters).forEach(
            ([key, value]) => { 
                if(value != null && value.length > 0) {
                    if(key == "transmissionType" || key == "fuelType"){
                        if(value.length > 0){
                            if(!isAnyDataValid){
                                data += "?";
                            }

                            data += (this.convertToRequest(key, value))
                            isAnyDataValid = true;
                        }
                    }
                    else if(key == "options"){
                        value.forEach(option => {
                            if(option.length > 0){
                                if(!isAnyDataValid){
                                    data += "?";
                                }

                                data += (this.convertToRequest(key, option))
                                isAnyDataValid = true;
                            }
                        });
                    }
                    else {
                        if(!isAnyDataValid){
                            data += "?";
                        }

                        data += (this.convertToRequest(key, value))
                        isAnyDataValid = true;
                    }
                } 
            }
        );
        
        if(data[data.length - 1] == "&"){
            data = data.substring(0, data.length - 2);
        }

        return this.http.get<CarResponseModel>(`${environment.baseUrl}/search` + data);
    }

    convertToRequest(key, value){
        return `${key.replace(/^./, key[0].toUpperCase())}=${value}&&`
    }
}