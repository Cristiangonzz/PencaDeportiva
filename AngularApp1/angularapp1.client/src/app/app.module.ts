import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IndexComponent } from './presentation/home/index/index.component';
import { NavbarComponent } from './presentation/share/navbar/navbar.component';
import { SidebarComponent } from './presentation/share/sidebar/sidebar.component';
import { SigninComponent } from './presentation/login/signin/signin.component';
import { FooterComponent } from './presentation/share/footer/footer.component';
import { ListAllComponent } from './presentation/equipo/list-all/list-all.component';
import { SearchComponent } from './presentation/share/shearch/search.component';
import { InfraestructureModule } from './intraestructure/infraestructure.module';

@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    NavbarComponent,
    SidebarComponent,
    SigninComponent,
    FooterComponent,
    ListAllComponent,
    SearchComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, InfraestructureModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
