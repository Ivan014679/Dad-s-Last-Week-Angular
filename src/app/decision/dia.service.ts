import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Dia } from './dia';

@Injectable({
  providedIn: 'root'
})
export class DiaService {

  constructor(private http: HttpClient) { }

  obtenerDia(DiaDecision: string): Observable<Dia> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.post<Dia>('http://localhost:57654/Api/Juego/Dia/' + DiaDecision, httpOptions);  
  }
}
