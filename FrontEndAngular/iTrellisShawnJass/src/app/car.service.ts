import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
// import { Http, Response } from '@angular/http';

@Injectable({
  providedIn: 'root'
})
export class CarService {
  private headers: HttpHeaders;
  private accessPointUrl = 'http://localhost:65416/api/Vehicles';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
   }

   public get() {
     return this.http.get(this.accessPointUrl, {headers: this.headers});
   }

   public add(payload) {
    return this.http.post(this.accessPointUrl, payload, {headers: this.headers});
  }
}
