import { Injectable } from '@angular/core';
import { Http } from '@angular/http'
import { User } from '../login/user';
import { httpFactory } from '@angular/http/src/http_module';

@Injectable()
export class UserService {

  url = "http://staging.tangent.tngnt.co";

  constructor(private http: Http) {
   }

   login(user: User){
    return this.http.post(this.url + "/api-auth/login/", user);
   }

   getEmployees(){
     return this.http.get(this.url + "/api/employee/");
   }
}   
