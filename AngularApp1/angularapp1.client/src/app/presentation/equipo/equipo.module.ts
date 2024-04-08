import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RoutingEquipoModule } from './routing-equipo.module';
import { ListAllComponent } from './list-all/list-all.component';



@NgModule({
  declarations: [ListAllComponent],
  imports: [
    CommonModule,
    RoutingEquipoModule,
  ],
  exports: [ListAllComponent]
})
export class EquipoModule { }
