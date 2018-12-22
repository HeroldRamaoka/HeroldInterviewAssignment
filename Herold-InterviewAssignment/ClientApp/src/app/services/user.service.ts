import { Injectable } from '@angular/core';
import { User } from '../login/user';
import { HttpHeaders, HttpParams, HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';

@Injectable()
export class UserService {

  url = "http://staging.tangent.tngnt.co";

   httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'my-auth-token'
    })
  };

  constructor(private http: HttpClient) {
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
   }

   getEmployees(){
     return this.http.get(this.url + "/api/employee/");
   }
}   
