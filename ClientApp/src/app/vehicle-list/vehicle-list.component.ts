import { Vehicle, KeyValuePair } from './../models/vehicle';
import { VehicleService } from './../Services/vehicle.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {
 
  //For Client side filter: allVehicles: Vehicle[];
  vehicles: Vehicle[];
  makes : KeyValuePair[];
  query: any = {}
 

  constructor(private vehicleService: VehicleService,
              ) { }

  ngOnInit() {

    this.populateVehicles();
    
    //Client Side Filtering
    //.subscribe(vehicles => this.vehicles = this.allVehicles = vehicles);

    this.vehicleService.getMakes()
    .subscribe(makes => this.makes = makes);

  }


  private populateVehicles() {

    this.vehicleService.getVehicles(this.query)
    .subscribe(vehicles => this.vehicles = vehicles);
  }

  onFilterChange() {

    this.populateVehicles();


    //client side filtering
    // var vehicles = this.allVehicles;

    // if (this.filter.makeId)
    // vehicles = vehicles.filter(v => v.make.id == this.filter.makeId)

    // if (this.filter.modelId)
    // vehicles = vehicles.filter(v => v.model.id == this.filter.modelId)

    // this.vehicles = vehicles;

  }

  sortBy(columnName) {
    
    if (this.query.sortBy == columnName) {
      this.query.isSortAscending = false;
    } else {
      this.query.sortBy = columnName;
      this.query.isSortAscending = true;
    }

    this.populateVehicles();


  }

  resetFilter() {

    this.query ={};
    this.onFilterChange();

  }

}
