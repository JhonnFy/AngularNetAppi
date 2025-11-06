// src/app/app.routes.ts
import { Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard';
import { EstudianteComponent } from './estudiante/estudiante';
import { NotaComponent } from './nota/nota';
import { ProfesorComponent } from './profesor/profesor';

export const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'estudiante', component: EstudianteComponent },
  { path: 'nota', component: NotaComponent },
  { path: 'profesor', component: ProfesorComponent },
  { path: '**', redirectTo: '/dashboard' }
];
