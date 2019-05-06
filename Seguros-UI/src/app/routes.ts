import { Routes } from '@angular/router';
import { HomeComponent } from './Home/Home.component';
import { PolizaComponent } from './Poliza/Poliza.component';
import { GuardarPolizaComponent } from './guardarPoliza/guardarPoliza.component';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent},
    { path: 'Poliza', component: PolizaComponent},
    { path: 'nuevaPoliza', component: GuardarPolizaComponent},
    { path: 'nuevaPoliza/:id', component: GuardarPolizaComponent},
    { path: '**', redirectTo: 'home', pathMatch: 'full' },
]