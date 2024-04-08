import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './index/index.component';
import { RoutingHomeModule } from './routing-home.module';



@NgModule({
  declarations: [IndexComponent],
  imports: [
    CommonModule,
    RoutingHomeModule,
  ],
  exports: [IndexComponent]
})
export class HomeModule { }
