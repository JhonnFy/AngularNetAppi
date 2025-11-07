// src/app/app.routes.ts
import { Routes } from '@angular/router';
import { EstudianteComponent } from './estudiante/estudiante';

export const routes: Routes = [
  { path: '', redirectTo: '/estudiantes', pathMatch: 'full' },
  { path: 'estudiantes', component: EstudianteComponent }
];
