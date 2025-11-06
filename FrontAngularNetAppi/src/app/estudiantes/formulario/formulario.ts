import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';


@Component({
  selector: 'app-formulario',
  standalone: true,
  templateUrl: './formulario.html',
  styleUrls: ['./formulario.css'],
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
  ]
})
export class FormularioComponent {
  estudiante = {
    nombre: '',
    correo: ''
  };

  enviarFormulario() {
    if (this.estudiante.nombre && this.estudiante.correo) {
      console.log('Datos enviados:', this.estudiante);
      // Aquí normalmente llamarías a tu servicio para guardar los datos
      alert(`Estudiante ${this.estudiante.nombre} agregado correctamente`);
      this.estudiante = { nombre: '', correo: '' }; // Limpiar formulario
    } else {
      alert('Por favor completa todos los campos');
    }
  }
}

export class Formulario {

}

