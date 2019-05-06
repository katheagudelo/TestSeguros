import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavegacionComponent } from './Navegacion/Navegacion.component';
import { HomeComponent } from './Home/Home.component';
import { HttpClientModule } from '@angular/common/http';
import { AutenticacionServiceService } from './Services/AutenticacionService.service';
import { AlertifyService } from './Services/alertify.service';
import { RegisterComponent } from './register/register.component';
import { PolizaComponent } from './Poliza/Poliza.component';
import { appRoutes } from './routes';
import { PolizaService } from './Services/poliza.service';
import { GuardarPolizaComponent } from './guardarPoliza/guardarPoliza.component';


@NgModule({
   declarations: [
      AppComponent,
      NavegacionComponent,
      HomeComponent,
      RegisterComponent,
      PolizaComponent,
      GuardarPolizaComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      AutenticacionServiceService,
      AlertifyService,
      PolizaService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
