import { ToastrService} from 'ngx-toastr';
import { ErrorHandler, Injectable, Injector, NgZone } from '@angular/core';
import {Router} from '@angular/router';




@Injectable()
export class AppErrorHandler implements ErrorHandler {
    
    constructor( private ngZone: NgZone,
        private inject: Injector){}

    handleError(error: any): void {

        if (error.status == "404") {
            
            console.log("ERROR NOT FOUND: " + error)
            const router = this.inject.get(Router);
            router.navigate(['']);

            throw error;

        }
        //Zone is added to run it in the same instance as async submit function
        this.ngZone.run(() =>{
        const toaster = this.inject.get(ToastrService);
        toaster.error("An Unexpected error occured!", "Error");
        })

        throw error;
        
        
     

    }






}