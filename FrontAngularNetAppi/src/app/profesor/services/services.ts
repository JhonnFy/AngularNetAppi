import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


export interface Profesor {
  id: number;
  nombre: string;
}

@Injectable({
  providedIn: 'root'
})
export class ProfesorService {
  private baseUrl = 'http://localhost:5261/api/profesor';

  constructor(private http: HttpClient) {}

  getProfesores(): Observable<Profesor[]> {
    return this.http.get<Profesor[]>(this.baseUrl);
  }

  getProfesorPorId(id: number): Observable<Profesor> {
    return this.http.get<Profesor>(`${this.baseUrl}/${id}`);
  }

  eliminarProfesor(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }

  ProfesoresConNotas(): Observable<number[]>{
    return this.http.get<number[]>(`${this.baseUrl}/ProfesoresConNotas`);
  }

  ProfesoresSinNotas(): Observable<number[]>{
    return this.http.get<number[]>(`${this.baseUrl}/ProfesoresSinNotas`);
  }

  actualizarProfesor(Profesor: Profesor): Observable<Profesor> {
    return this.http.put<Profesor>(`${this.baseUrl}/${Profesor.id}`, Profesor);
  }

  registrarProfesor(Profesor: Profesor): Observable<Profesor> {
    return this.http.post<Profesor>(`${this.baseUrl}`, Profesor);
}



  // Otros métodos que ya tengas: crearProfesor, actualizarProfesor...
}
