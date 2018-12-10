import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
// import { Http, Response } from '@angular/http';

@Injectable()

export class CarService {
  private headers: HttpHeaders;
  private accessPointUrl = 'http://localhost:65416/api/Vehicles';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
   }

   public get() {
     return this.http.get(this.accessPointUrl, {headers: this.headers});
   }

   public getFromSearch(search) {
    return this.http.get('http://localhost:65416/api/Vehicles/search', {headers: this.headers });
    // params: new HttpParams().set('search', search) });
  }

   public update(payload) {
    return this.http.put(this.accessPointUrl + '/' + payload.id, payload, {headers: this.headers});
  }

   public add(payload) {
    return this.http.post(this.accessPointUrl, payload, {headers: this.headers});
   }

   public remove(payload) {
    return this.http.delete(this.accessPointUrl + '/' + payload.id, {headers: this.headers});
  }

}
