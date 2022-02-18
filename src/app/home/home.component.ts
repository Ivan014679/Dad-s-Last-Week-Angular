import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DecisionService } from '../decision/decision.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  isA000 = false;
  constructor(private decisionService : DecisionService,
    private router : Router) { }

  ngOnInit() {
    if(localStorage.getItem('decisionToken') == "A000"){
      this.isA000 = true;
    }else{
      this.isA000 = false;
    }
  }

  juegoNuevo(){
    this.decisionService.nuevoJuego(parseInt(localStorage.getItem('userToken')));
    localStorage.setItem('decisionToken', "A001");
    this.router.navigate(['game']);
  }

  continuarJuego = () =>{
    //this.decisionService.continuarJuego(parseInt(localStorage.getItem('userToken')), localStorage.getItem('decisionToken'));
    this.router.navigate(['game']);
  }

  estadisticas(){
    this.router.navigate(['estadisticas']);
  }

  Logout(){
    localStorage.removeItem('userToken');
    localStorage.removeItem('decisionToken');
    this.router.navigate(['player/login']);
  }
}
