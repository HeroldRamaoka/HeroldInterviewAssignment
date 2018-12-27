import { Injectable } from '@angular/core';
import { User } from '../login/user';
import { HttpHeaders, HttpParams, HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';

@Injectable()
export class UserService {

  constructor(private http: HttpClient,
    private router: Router
    ) {
   }

   login(user: User) {
     const payload = {
       'password': user.Password,
       'username': user.Username
     };

    return this.http.post<any>("http://staging.tangent.tngnt.co/api-token-auth/", payload)
   }

   logout() {
     localStorage.removeItem('currentUser');
     this.router.navigate(["/login"]);
   }

   getEmployees(): Observable<any>{
     console.log(localStorage.getItem("currentUser"));
     const payload = {
       'password': 'pravin.gordhan',
       'username': 'pravin.gordhan'
     };

     return this.http.get("http://staging.tangent.tngnt.co/api/user/me/", {
       headers: new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem("currentUser")})
     });

   }
}   
