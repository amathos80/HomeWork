import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ProjectService } from '../shared/services/project.service';

import { Router } from '@angular/router';
import { Project } from '../shared/models/Project';

@Component({
  selector: 'hw-project-add',
  templateUrl: './project-add.component.html',
  styleUrls: ['./project-add.component.css']
})
export class ProjectAddComponent implements OnInit {
project:Project;
  constructor(private projectService:ProjectService,private router:Router) {
    this.project= new Project();
   }

  ngOnInit() {
  }
  submitProjectForm() {
    this.project.completed=false;
    this.project.projectTasks=[];
    this.projectService.add(this.project).subscribe(id => {
        this.router.navigate(['projects', 'detail', id]);
      },error=>{
        console.log(`Si è verificato un errore: ${error}`)
      });
  }
}
