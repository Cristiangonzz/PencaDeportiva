import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { equipoUseCaseProviders } from './delegate/delegate-equipo/delegateEquipo';
import { EquipoService } from '../domain/services/EquipoService';
import { EquipoImplentationService } from './services/service-equipo/service-equipo.service';



@NgModule({
  declarations: [],
  imports: [CommonModule, HttpClientModule],
  providers: [
    ...Object.values(equipoUseCaseProviders),
    { provide: EquipoService, useClass: EquipoImplentationService }
   ]
})
export class InfraestructureModule { }
