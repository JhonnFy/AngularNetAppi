import { Routes } from '@angular/router';
import { Dashboard } from './dashboard/dashboard';
import { EstudianteComponent } from './estudiante/estudiante';

export const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: Dashboard },
  { path: 'estudiante', component: EstudianteComponent },
  { path: '**', redirectTo: '/dashboard' }
];
