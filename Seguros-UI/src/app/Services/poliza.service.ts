import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PolizaService {
  baseUrl = 'http://localhost:5000/api/Poliza/';


constructor(private http: HttpClient) { }

obtenerPolizas(): Observable<any> {

  return this.http.get(this.baseUrl + 'obtenerPolizas',
   {headers: new HttpHeaders().set('Authorization', 'Bearer ' + localStorage.getItem('token'))});
 }

 eliminarPoliza(id: any): Observable<any> {
   return this.http.delete(this.baseUrl + id,
     {headers: new HttpHeaders().set('Authorization', 'Bearer ' + localStorage.getItem('token'))});
 }

 guardarPoliza(model: any): Observable<any> {
  return this.http.post(this.baseUrl + 'create', model,
   {headers: new HttpHeaders().set('Authorization', 'Bearer ' + localStorage.getItem('token'))});
 }

 obtenerPolizaPorId(id: any): Observable<any> {
   return this.http.get(this.baseUrl  + id ,
    {headers: new HttpHeaders().set('Authorization', 'Bearer ' + localStorage.getItem('token'))});
 }

 editarPoliza(id: any, model: any): Observable<any> {
   return this.http.put(this.baseUrl + id, model,
    {headers: new HttpHeaders().set('Authorization', 'Bearer ' + localStorage.getItem('token'))});
 }

}
