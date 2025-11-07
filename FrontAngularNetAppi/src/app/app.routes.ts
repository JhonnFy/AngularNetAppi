import { Routes } from '@angular/router';
import { EstudianteComponent } from './estudiante/estudiante';
import { Dashboard } from './dashboard/dashboard'; // tu dashboard

export const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: Dashboard },
  { path: 'estudiantes', component: EstudianteComponent } // ✅ solo estudiantes por ahora
];



