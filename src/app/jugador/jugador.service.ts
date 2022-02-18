import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Jugador } from './jugador';

@Injectable({
  providedIn: 'root'
})
export class JugadorService {

  constructor(private http: HttpClient) { }

  autenticarJugador(NombreUsuario: string, Contrasena: string): Observable<Jugador> {  
    return this.http.get<Jugador>('http://localhost:57654/Api/Jugador/Login/' + NombreUsuario + '-' + Contrasena);  
  }

  registrarJugador(jugador:Jugador): Observable<Jugador>{
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.post<Jugador>('http://localhost:57654/Api/Jugador/Set', jugador, httpOptions);
  }
}
