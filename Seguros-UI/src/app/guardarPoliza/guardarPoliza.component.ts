import { Component, OnInit } from '@angular/core';
import { PolizaService } from '../Services/poliza.service';
import { AlertifyService } from '../Services/alertify.service';
import { ifError } from 'assert';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-guardarPoliza',
  templateUrl: './guardarPoliza.component.html',
  styleUrls: ['./guardarPoliza.component.css']
})
export class GuardarPolizaComponent implements OnInit {
 model: any = {};
 getmodel: any;
 id: any;
 edit = false;

  constructor(private polizaService: PolizaService,
              private alertify: AlertifyService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    console.log(this.id);
    if (this.id != null) {
      this.edit = true;
      this.polizaService.obtenerPolizaPorId(this.id).subscribe(
        result => {
          if (result.code !== 200) {
            this.model = result;
         }
        },
        error => {
          console.log(error);
        }
      );
    }
  }

guardar() {
  if (!this.edit) {
    this.polizaService.guardarPoliza(this.model).subscribe(
    result => {
        this.alertify.success('Poliza Creada');
        this.router.navigate(['/Poliza']);
    },
    error => {
      this.alertify.error(error.error);
    }
  );
  } else {
    this.polizaService.editarPoliza(this.id, this.model).subscribe(
      result => {
        if (result)  {
          this.alertify.success('Poliza editada');
          this.router.navigate(['/Poliza']);
        }
      }
    );
  }
 
}

}
