import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AutenticacionServiceService } from '../Services/AutenticacionService.service';
import { AlertifyService } from '../Services/alertify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
@Output() cancelRegister = new EventEmitter();

  constructor(private auservice: AutenticacionServiceService, private alertify: AlertifyService) { }
model: any = {};
  ngOnInit() {
  }

  register() {
    this.auservice.registrar(this.model).subscribe(() => {
      this.alertify.success('registro exitoso');
    }, error => {
      this.alertify.error(error.error);
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
