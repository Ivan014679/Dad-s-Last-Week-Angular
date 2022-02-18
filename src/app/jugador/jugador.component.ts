import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { JugadorService } from './jugador.service';
import { Observable, throwError } from 'rxjs';
import { Jugador } from './jugador';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';

@Component({
  selector: 'app-jugador',
  templateUrl: './jugador.component.html',
  styleUrls: ['./jugador.component.css']
})
export class JugadorComponent implements OnInit {
  jugador: Observable<Jugador>;
  message: string;
  Id: number;
  NombreUsuario: string;
  Contrasena: string;
  Decision: string;
  jugadorForm: any;
  title: string;
  strqueary :string;
  constructor(private formbuilder: FormBuilder,
    private jugadorService:JugadorService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.jugadorForm = this.formbuilder.group({
      NombreUsuario: ['', [Validators.required, Validators.maxLength(30), Validators.minLength(1)]],
      Contrasena: ['', [Validators.required, Validators.maxLength(20), Validators.minLength(1)]],
    });
    this.route.paramMap.subscribe(
      (params: ParamMap)=>{
        this.Id=parseInt(params.get('Id'));
        if(this.NombreUsuario != null && this.Contrasena != null){
          this.obtenerJugador(this.NombreUsuario, this.Contrasena);
        }
      }
    );
  }

  onFormSubmit(NombreUsuario: string, Contrasena: string){
    const autenticacion = this.jugadorForm.value;
    this.autenticacion(autenticacion);
    this.jugadorForm.reset();
    this.jugadorService.autenticarJugador(this.NombreUsuario, this.Contrasena);
    
  }

  obtenerJugador = (NombreUsuario: string, Contrasena: string) => {
    this.jugadorService.autenticarJugador(NombreUsuario, Contrasena).subscribe(
      d => {
        if(d != null){
          this.Id = d.Id;
          this.Decision = d.Decision;
        }else{
          alert("Nombre de usuario o contraseña incorrectos");
        }
      }
    );    
  }
  
  autenticacion = (jugador: Jugador) => {
    this.jugadorService.autenticarJugador(jugador.NombreUsuario, jugador.Contrasena).subscribe(
      d => {
        if(d != null){
          this.Id = d.Id;
          this.NombreUsuario = d.NombreUsuario;
          this.Contrasena = d.Contrasena;
          this.Decision = d.Decision;
          this.jugadorForm.reset();
          localStorage.setItem('userToken', this.Id.toString());
          localStorage.setItem('decisionToken', this.Decision);
          this.router.navigate(['']);
        }else{
          alert("Nombre de usuario o contraseña incorrectos");
        }
      }
    );
  }
}
