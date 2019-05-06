import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AutenticacionServiceService {
  baseUrl = 'http://localhost:5000/api/Autenticacion/';


constructor(private http: HttpClient) { }

login(model: any) {
  return this.http.post(this.baseUrl + 'login', model).pipe(
    map((response: any) => {
      const user = response;
      if (user) {
        localStorage.setItem('token' , user.token);
      }
    })
  );
}

registrar(model: any) {
  return  this.http.post(this.baseUrl + 'registrar', model);
}
}
