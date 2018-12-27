import { Component, Injector, Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable()

export class JwtInterceptor implements HttpInterceptor {

    constructor(private router: Router){

    }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let currentUser = JSON.parse(localStorage.getItem('currentUser'));
        console.log(currentUser.token);
        if(currentUser & currentUser.token){
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${currentUser.token}`
                }
            });
            
            return next.handle(request)
            .do(
                succ => { },
                err => {
                    debugger;
                    if(err.status === 401){
                        this.router.navigate(["/login"]);
                    } 
                }
                
            )
        }
        else {
            this.router.navigate(["/login"]);
        }
    }
}