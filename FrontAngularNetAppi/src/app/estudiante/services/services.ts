import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Estudiante {
  id: number;
  nombre: string;
}

@Injectable({ providedIn: 'root' })
export class EstudianteService {
  private apiUrl = 'http://localhost:5261/api/estudiante';

  constructor(private http: HttpClient) {}

  getEstudiantes(): Observable<Estudiante[]> {
    return this.http.get<Estudiante[]>(this.apiUrl);
  }

  crearEstudiante(est: Estudiante): Observable<any> {
    return this.http.post(this.apiUrl, est);
  }

  actualizarEstudiante(est: Estudiante): Observable<any> {
    return this.http.put(`${this.apiUrl}/${est.id}`, est);
  }

  eliminarEstudiante(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
