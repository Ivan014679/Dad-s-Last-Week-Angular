import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HttpClient } from '@angular/common/Http';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { JugadorComponent } from './jugador/jugador.component';
import { RegistroJugadorComponent } from './jugador/registro/registro.component';
import { JugadorService } from './jugador/jugador.service';
import { AuthGuard } from './auth/auth.guard';
import { DecisionComponent } from './decision/decision.component';
import { EstadisticaComponent } from './estadistica/estadistica.component';

const appRoutes: Routes = [
  {
    path: '',
    component: HomeComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'player/login',
    component: JugadorComponent,
    data: {
      title: 'Iniciar sesión'
    }
  },
  {
    path: 'player/register',
    component: RegistroJugadorComponent,
    data: {
      title: 'Crear cuenta'
    }
  },
  {
    path: 'game',
    component: DecisionComponent,
    canActivate: [AuthGuard],
    data: {
      title: 'Juego'
    }
  },
  {
    path: 'estadisticas',
    component: EstadisticaComponent,
    canActivate: [AuthGuard],
    data: {
      title: 'Estadísticas'
    }
  }
]

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    JugadorComponent,
    RegistroJugadorComponent,
    DecisionComponent,
    EstadisticaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [JugadorService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
