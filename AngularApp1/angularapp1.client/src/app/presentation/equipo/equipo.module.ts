import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RoutingEquipoModule } from './routing-equipo.module';
import { ListAllComponent } from './list-all/list-all.component';
import { CreateEquipoComponent } from './create/create.component';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [ListAllComponent, CreateEquipoComponent],
  imports: [
    CommonModule,
    RoutingEquipoModule,
    ReactiveFormsModule,
  ],
  exports: [ListAllComponent, CreateEquipoComponent]
})
export class EquipoModule { }
