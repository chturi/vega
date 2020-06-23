import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map'


@Injectable()
export class VehicleService {

  private readonly vehiclesEndpoint = '/api/vehicles';

  constructor(private http: Http) { }


  getMakes() {

    return this.http.get('/api/makes')
    .map(res => res.json())

  }

  getFeatures() {

    return this.http.get('/api/features')
    .map(res => res.json())

  }

  create(vehicle) {

    return this.http.post(this.vehiclesEndpoint, vehicle)
    .map(res => res.json());
  }

  getVehicle(id) {
    return this.http.get(this.vehiclesEndpoint + '/' +  id)
    .map(res => res.json());
  }

  delete(id) {

    return this.http.delete(this.vehiclesEndpoint + '/' + id)
    .map(res => res.json());

  }

  getVehicles(filter){

    
    console.log(this.toQueryString(filter));
    return this.http.get(this.vehiclesEndpoint + '?' + this.toQueryString(filter))
    .map(res => res.json());

  }

  toQueryString(obj) {
    
    var parts = [];
    for (var property in obj) {
      var value = obj[property];
      if (value != null && value != undefined) 
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
    }

      console.log("Parts: " + parts)
      return parts.join('&');

      }
  }

  

}
