import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Decision } from './decision';

@Injectable({
  providedIn: 'root'
})
export class DecisionService {

  constructor(private http: HttpClient) { }

  nuevoJuego(Id: number): Observable<Decision> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.post<Decision>('http://localhost:57654/Api/Juego/' + Id, httpOptions);  
  }

  continuarJuego(Id: number, DecisionTomada: string): Observable<Decision> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
    return this.http.post<Decision>('http://localhost:57654/Api/Juego/' + Id + '-' + DecisionTomada, httpOptions);  
  }
}
