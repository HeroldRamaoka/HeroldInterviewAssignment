import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http'
import { User } from '../login/user';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class UserService {

  url = "http://staging.tangent.tngnt.co";

   httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'my-auth-token'
    })
  };

  constructor(private http: Http) {
   }

   login(user: User) {
     const payload = {
       'password': user.Password,
       'username': user.Username
     };

    return this.http.post("http://staging.tangent.tngnt.co/api-token-auth/", payload, {
      headers: new Headers({
        'Content-Type': 'application/json'
      })
    });
   }

   getEmployees(){
     return this.http.get(this.url + "/api/employee/");
   }
}   
