import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class CostService {
    url = "http://delivery-service.azurewebsites.net/api/cost/order/";
        

  constructor (private http: Http) {
  }

  public getCost(id: number): Observable<Response> {
      return this.http.get(this.url + id);      
  }
}