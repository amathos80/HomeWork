import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
 
import { ProjectListComponent } from './project-list/project-list.component';
 

const routes: Routes = [
  { path: 'projects', component: ProjectListComponent },
  { path: '', redirectTo:'/projects',  pathMatch: 'full'  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
