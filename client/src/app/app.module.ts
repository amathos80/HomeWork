import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProjectListComponent } from './project-list/project-list.component';
 
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { ProjectDetailComponent } from './project-detail/project-detail.component';
import { ProjectUpdateComponent } from './project-update/project-update.component';
import { ProjectAddComponent } from './project-add/project-add.component';
import { NavbarComponent } from './shared/components/navigationbar/navbar.component';
import { HeaderComponent } from './shared/components/header/header.component';
import { UniqueNameValidatorDirective } from './shared/directives/ProjectDirectives';

@NgModule({
  declarations: [
    AppComponent,
    ProjectListComponent,
    ProjectDetailComponent,
    ProjectUpdateComponent,
    ProjectAddComponent,
    NavbarComponent,
    HeaderComponent,
    UniqueNameValidatorDirective
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
