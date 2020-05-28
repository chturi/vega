import { VehicleService } from '../Services/vehicle.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {

  features: any[];
  makes: any[];
  models: any[] = [{}];
  vehicle: any = {};

  constructor(
    private vehicleService: VehicleService,
    ) { }

  ngOnInit() {

    this.vehicleService.getMakes().subscribe(makes => this.makes= makes);

    this.vehicleService.getFeatures().subscribe (features => this.features = features);

  }


  onMakeChange() {
    console.log("Selected Make: ", this.makes) 
    console.log("Selected Make: ", this.vehicle)

    var selectedMake = this.makes.find(m => m.name == this.vehicle.make)
     
     console.log("Selected Make: ",selectedMake)
     this.models= selectedMake ? selectedMake.models: [];
  }





}
