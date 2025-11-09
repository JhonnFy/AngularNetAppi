import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Nota {
  id: number;
  nombre: string;
  idProfesor: number;
  idEstudiante: number;
  valor: number;
}

@Injectable({
  providedIn: 'root'
})

export class NotaService {
    private baseUrl = 'http://localhost:5261/api/nota';

    constructor(private http: HttpClient) {}

getNotas(): Observable<Nota[]> {
    return this.http.get<Nota[]>(this.baseUrl);
}
    
getNotaPorId(id: number): Observable<Nota> {
 return this.http.get<Nota>(`${this.baseUrl}/${id}`);
}

actualizarNota(nota: Nota): Observable<Nota> {
    return this.http.put<Nota>(`${this.baseUrl}/${nota.id}`, nota);
}




}