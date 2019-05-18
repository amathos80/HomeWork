import { Component, OnInit } from '@angular/core';
import { Route, Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Project } from '../shared/models/Project';
import { ProjectService } from '../shared/services/project.service';

@Component({
  selector: 'hw-project-detail',
  templateUrl: './project-detail.component.html',
  styleUrls: ['./project-detail.component.css']
})
export class ProjectDetailComponent implements OnInit {
  project$: Observable<Project>;
  constructor(private activatedRoute:ActivatedRoute,private projectService:ProjectService) { }

  ngOnInit() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    this.project$ = this.projectService.get(id);
  }

}
