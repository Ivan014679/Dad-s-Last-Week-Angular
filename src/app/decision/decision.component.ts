import { Component, OnInit } from '@angular/core';
import { DecisionService } from './decision.service';
import { DiaService } from './dia.service';
import { Observable, throwError } from 'rxjs';
import { Decision } from './decision';
import { Dia } from './dia';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';

@Component({
  selector: 'app-decision',
  templateUrl: './decision.component.html',
  styleUrls: ['./decision.component.css']
})
export class DecisionComponent implements OnInit {
  continuar: string;
  decision: Decision;
  Id: number;
  Decision: string;
  dia: Dia;
  texto: string;
  left: string;
  right: string;
  siguiente: string;
  title: string;
  strqueary :string;
  constructor(private decisionService:DecisionService,
    private diaService:DiaService,
    private route: ActivatedRoute,
    private router: Router) {
      
    }

  ngOnInit() {
    this.Id = parseInt(localStorage.getItem('userToken'));
    this.Decision = localStorage.getItem('decisionToken');
    console.log(this.Decision);
    this.obtenerDia();
  }

  obtenerDecision = () => {
    this.decisionService.continuarJuego(this.Id, this.Decision).subscribe(val => {
    this.decision = val;
      if (this.decision.Left == null) {
        this.left = "Finalizar juego";
        this.right = null;
      }
      else {
        switch (this.decision.Id_Decision) {
          case "A002":
            this.left = "Bosque";
            this.right = "Camino";
            break;
          case "A003":
            this.left = "No hacer nada";
            this.right = "Tratar herida";
            break;
          case "A006":
            this.left = "Pelear";
            this.right = "Huir";
            break;
          case "A018":
            this.left = "Ayudarlo";
            this.right = "Seguir";
            break;
          case "A021":
            this.left = "Ir por el arroyo";
            this.right = "Robar caballo";
            break;
          case "A027":
            this.left = "Aceptar";
            this.right = "Rechazar";
            break;
          case "A034":
            this.left = "Montaña";
            this.right = "Lago";
            break;
          default:
            this.left = "Continuar";
            this.right = null;
            break;
        }
      }
    });
  }

  obtenerDia = () => {
    this.diaService.obtenerDia(this.Decision).subscribe(val => {this.dia = val;
      this.obtenerDecision();});
  }

  Left(d: string) {
    if(d != null){
      localStorage.setItem('decisionToken', d);
      this.Decision = d;
      location.reload();
    }else{
      localStorage.setItem('decisionToken', "A000");
      this.router.navigate(['']);
    }
  }

  Right(d: string) {
    localStorage.setItem('decisionToken', d);
    this.Decision = d;
    location.reload();
  }
}
