import { Component, OnInit, Input } from '@angular/core';
import { PolizaService } from '../Services/poliza.service';
import { AlertifyService } from '../Services/alertify.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-Poliza',
  templateUrl: './Poliza.component.html',
  styleUrls: ['./Poliza.component.css']
})

export class PolizaComponent implements OnInit {
polizas: any;

  constructor(private poliza: PolizaService, private alertify: AlertifyService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
     this.poliza.obtenerPolizas().subscribe(
       result => {
         if (result.code !== 200) {
          this.polizas = result;
        }
       },
       error => {
         console.log(error);
       }
     );
  }

  eliminar(id: any) {
    this.poliza.eliminarPoliza(id).subscribe(
      result => {
        if (result) {
          this.alertify.success('Registro eliminado');
        }
      },
      error => {
        console.log(error);
      }
      );
    this.router.navigate(['/Poliza']);
    }
}
