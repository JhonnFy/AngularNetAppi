import { Routes } from '@angular/router';
import { EstudianteComponent } from './estudiante/estudiante';
import { Dashboard } from './dashboard/dashboard'; // tu dashboard
import { ProfesorComponent } from './profesor/profesor';

export const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: Dashboard },
  { path: 'estudiantes', component: EstudianteComponent },
  { path: 'profesores', component: ProfesorComponent}
];



