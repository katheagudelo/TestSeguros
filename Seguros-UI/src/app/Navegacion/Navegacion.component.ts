import { Component, OnInit } from '@angular/core';
import { AutenticacionServiceService } from '../Services/AutenticacionService.service';
import { AlertifyService } from '../Services/alertify.service';

@Component({
  selector: 'app-Navegacion',
  templateUrl: './Navegacion.component.html',
  styleUrls: ['./Navegacion.component.css']
})
export class NavegacionComponent implements OnInit {
model: any = {};

  constructor(private AuService: AutenticacionServiceService, private alertify: AlertifyService ) { }

  ngOnInit() {
  }

  login() {
    this.AuService.login(this.model).subscribe(next => {
      this.alertify.success('logged in succesfully');
    }, error => {
      this.alertify.error(error);
    });
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.message('logged out');
   }
}
