import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot} from '@angular/router';

@Injectable()

export class AuthGuard implements CanActivate {
    constructor(private router: Router){

    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot){
        if(localStorage.getItem('currentUser')){
            return true;
        }

        // redirect you to login if not logged in
        // this.router.navigate(["/login"], {queryParams: {returnUrl: state.url }});
        // return false;
    }
}