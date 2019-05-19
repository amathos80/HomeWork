import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
 
import { ProjectListComponent } from './project-list/project-list.component';
import { ProjectDetailComponent } from './project-detail/project-detail.component';
import { ProjectUpdateComponent } from './project-update/project-update.component';
import { ProjectAddComponent } from './project-add/project-add.component';
 

const routes: Routes = [
  { path: 'projects/detail/:id', component: ProjectDetailComponent },
  { path: 'projects/update/:id', component: ProjectUpdateComponent },
   { path: 'projects/add', component: ProjectAddComponent },
  { path: 'projects', component: ProjectListComponent },
  { path: '', redirectTo:'/projects',  pathMatch: 'full'  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
