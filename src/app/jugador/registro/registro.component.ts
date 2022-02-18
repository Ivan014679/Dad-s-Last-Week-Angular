import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { JugadorService } from '../jugador.service';
import { Jugador } from '../jugador';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroJugadorComponent implements OnInit {
  dataSaved = false;
  jugadoresForm: any;
  message = null;
  constructor(private formbuilder: FormBuilder,
    private jugadorServices: JugadorService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.jugadoresForm = this.formbuilder.group({
      NombreUsuario: ['', [Validators.required, Validators.maxLength(30), Validators.minLength(1)]],
      Contrasena: ['', [Validators.required, Validators.maxLength(20), Validators.minLength(1)]],
    });
  }

  onFormSubmit(){
    this.dataSaved = false;  
    const jugador = this.jugadoresForm.value;
    this.registrar(jugador);  
    this.jugadoresForm.reset();
    this.jugadorServices.registrarJugador(this.jugadoresForm);
  }

  registrar(jugador: Jugador) {  
      this.jugadorServices.registrarJugador(jugador).subscribe(  
        () => {  
          this.dataSaved = true;  
          this.message = 'Registro exitoso';    
          this.jugadoresForm.reset();  
        }
      );
  }
}
