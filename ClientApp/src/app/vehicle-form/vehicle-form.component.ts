import { FetchDataComponent } from './../fetch-data/fetch-data.component';
import { VehicleService } from '../Services/vehicle.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/forkJoin';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {

  features: any[];
  makes: any[];
  models: any[] = [{}];
  vehicle: any = {
    features: [],
    contact: {},
  };

  constructor(
    private vehicleService: VehicleService,
    private toastr: ToastrService,
    private  route: ActivatedRoute,
    private  router: Router
    ) { 

      // route.params.s

      // .snapshot(x => x.json())
      // .subscribe(p => this.vehicle.id = +p['id']);
      
      // this.route.snapshot.params

    }

  ngOnInit() {

    const routeParams = this.route.snapshot.params;
    this.vehicle.id = routeParams.id;

    var sources= [this.vehicleService.getMakes(),
                  this.vehicleService.getFeatures()
                 ]

    if (this.vehicle.id)
                 sources.push(this.vehicleService.getVehicle(this.vehicle.id));

    Observable.forkJoin(sources).subscribe (data => {

      this.makes = data[0];
      this.features = data[1];

      if (this.vehicle.id)
        this.setVehicle(data[2]);

    })
   
    //Without ForkJoin
    // this.vehicleService.getVehicle(this.vehicle.id).subscribe( vehicle => this.vehicle = vehicle )

    // this.vehicleService.getMakes().subscribe( makes => this.makes = makes);

    // this.vehicleService.getFeatures().subscribe ( features => this.features = features);

  }


  private setVehicle (v) {

    this.vehicle.id = v.id;
    this.vehicle.makeId = v.make.id;
    this.vehicle.modelId = v.model.id;


  }

  onMakeChange() {
    console.log("Selected Make: ", this.makes) 
    console.log("Selected Vehicle: ", this.vehicle)

    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId)
     
     console.log("Selected Make: ",selectedMake)
     this.models= selectedMake ? selectedMake.models: [];
  }

  onFeatureToggle(featureId, $event) {

    if ($event.target.checked)
      this.vehicle.features.push(featureId);
    else {
      var index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index,1);
    

    }

  }

  submit() {

    this.vehicleService.create(this.vehicle)
    .subscribe( x=> {
      this.toastr.success('Vehicle was successfully added to the Database', 'Success!');
      console.log(x);
    });

  }





}
