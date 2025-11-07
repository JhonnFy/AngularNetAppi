// src/app/app.routes.ts
import { Routes } from '@angular/router';
import { Dashboard } from './dashboard/dashboard';

export const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: Dashboard },
  {
    path: 'estudiante',
    loadComponent: () =>
      import('./estudiante/estudiante').then(m => m.EstudianteComponent)
  },
  {
    path: 'nota',
    loadComponent: () =>
      import('./nota/nota').then(m => m.NotaComponent)
  },
  {
    path: 'profesor',
    loadComponent: () =>
      import('./profesor/profesor').then(m => m.ProfesorComponent)
  },
  { path: '**', redirectTo: '/dashboard' }
];
