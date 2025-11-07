import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

interface Estudiante {
  id: number;
  nombre: string;
}

@Component({
  selector: 'app-estudiante',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './estudiante.html',
  styleUrls: ['./estudiante.scss']
})
export class EstudianteComponent implements OnInit {
  estudiantes: Estudiante[] = [];
  log: string[] = [];

  private apiUrl = 'http://localhost:5261/api/estudiante';

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.cargarEstudiantes();
  }

  cargarEstudiantes() {
    this.http.get<Estudiante[]>(this.apiUrl).subscribe({
      next: (data) => {
        this.estudiantes = data;
        this.log.push(`✅ ${data.length} estudiantes cargados.`);
      },
      error: (err) => {
        this.log.push(`❌ Error cargando estudiantes: ${err.message || err}`);
      }
    });
  }
}
