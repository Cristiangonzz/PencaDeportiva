import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { IndexComponent } from './index/index.component';


const routes: Routes = [
  {
    path: 'index',
    children: [
      { path: `index`, component: IndexComponent/*, canActivate: [BackGuard]*/, },
      { path: `**`, redirectTo: 'index' },
    ]
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class RoutingHomeModule { }
