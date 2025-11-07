import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms'; // <-- esto es clave

@Component({
  selector: 'app-estudiante',
  standalone: true,
  imports: [FormsModule], // <-- necesario para [(ngModel)]
  templateUrl: './estudiante.html',
  styleUrls: ['./estudiante.scss']
})
export class EstudianteComponent {
  estudiante = {
    id: '',
    nombre: ''
  };

  constructor(private router: Router) {}

  limpiarFormulario() {
    this.estudiante.id = '';
    this.estudiante.nombre = '';
  }

  regresarMenu() {
    this.router.navigate(['/dashboard']);
  }

  guardarEstudiante() {
    console.log('Estudiante registrado:', this.estudiante);
    this.limpiarFormulario();
  }
}
