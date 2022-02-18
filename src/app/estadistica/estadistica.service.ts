import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Estadistica } from './estadistica';

@Injectable({
  providedIn: 'root'
})
export class EstadisticaService {

  constructor(private http: HttpClient) { }

  obtenerEstadisticas(): Observable<Estadistica[]>{
    return this.http.get<Estadistica[]>('http://localhost:57654/Api/Estadisticas/Get');
  }
}
