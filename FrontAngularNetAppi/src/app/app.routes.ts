import { Routes } from '@angular/router';
import { EstudianteComponent } from './estudiante/estudiante';
import { Dashboard } from './dashboard/dashboard';
import { ProfesorComponent } from './profesor/profesor';
import { NotaService } from './nota/services/services';
import { NotaComponent } from './nota/nota';

export const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: Dashboard },
  { path: 'estudiantes', component: EstudianteComponent },
  { path: 'profesores', component: ProfesorComponent},
  { path: 'notas', component:NotaComponent}
];



