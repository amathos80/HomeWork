import { Component, OnInit } from '@angular/core';
import { Project } from '../shared/models/Project';
import { Observable } from 'rxjs/internal/Observable';
import { ProjectService } from '../shared/services/project.service';

@Component({
  selector: 'hw-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.css']
})
export class ProjectListComponent implements OnInit {
  projects$: Observable<Project[]>;

  constructor(private projectService:ProjectService) { }

  ngOnInit() {
    this.projects$ = this.projectService.getAll();
  }

}
