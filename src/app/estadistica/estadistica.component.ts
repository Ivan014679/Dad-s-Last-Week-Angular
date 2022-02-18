import { Component, OnInit } from '@angular/core';
import { EstadisticaService } from './estadistica.service';
import { Observable } from 'rxjs';
import { Estadistica } from './estadistica';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';

@Component({
  selector: 'app-estadistica',
  templateUrl: './estadistica.component.html',
  styleUrls: ['./estadistica.component.css']
})
export class EstadisticaComponent implements OnInit {
  estadisticas: Observable<Estadistica[]>;
  title: string;
  strqueary :string;
  constructor(private estadisticaService:EstadisticaService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.obtenerEstadisticas();
  }

  obtenerEstadisticas = () => {
    this.estadisticas=this.estadisticaService.obtenerEstadisticas();
  }

}
