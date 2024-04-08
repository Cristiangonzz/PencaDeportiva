import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListAllComponent } from './list-all/list-all.component';
import { RoutingEquipoModule } from './routing-equipo.module';



@NgModule({
  declarations: [ListAllComponent],
  imports: [
    CommonModule,
    RoutingEquipoModule,
  ],
  exports: [ListAllComponent]
})
export class EquipoModule { }
