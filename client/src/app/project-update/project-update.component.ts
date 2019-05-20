import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProjectService } from '../shared/services/project.service';
import { Subscription } from 'rxjs';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { Project } from '../shared/models/Project';
import { DatePipe } from '@angular/common';
import { projection } from '@angular/core/src/render3';
import { ProjectValidators } from '../shared/validators/ProjectValidators';

@Component({
  selector: 'app-project-update',
  templateUrl: './project-update.component.html',
  styleUrls: ['./project-update.component.css']
})
export class ProjectUpdateComponent implements OnInit {
  projectSubscription: Subscription;
  project: Project;
  title:string;
  isEndDateNull:boolean=false;
  editProjectForm: FormGroup;
  constructor(private route: ActivatedRoute, private router: Router, private projectService: ProjectService) { }

  
    
  

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    this.projectSubscription = this.projectService.get(id).subscribe(project => {
      this.project = project;
      this.title=`Modifica progetto '${project.name}'`;
      this.initForm();
    });
  }

  initForm() {
    const datePipe = new DatePipe('en-US');

    const projectTasks = new FormArray([]);
    if (this.project.projectTasks) {
      for (const task of this.project.projectTasks) {
        projectTasks.push(
          new FormGroup({
            'name': new FormControl(task.name, Validators.required),
            'startDate': new FormControl(datePipe.transform(task.startDate, 'yyyy-MM-dd'), Validators.required),
            'duration': new FormControl(task.duration, Validators.required),
            'isBillable': new FormControl(task.isBillable)
          })
        );
      }
    }

    this.editProjectForm = new FormGroup({
      'name': new FormControl(this.project.name, Validators.required,ProjectValidators.uniqueName(this.projectService,this.project.id)),
      'description': new FormControl(this.project.description),
      'priority': new FormControl(this.project.priority, Validators.required),
      'startDate': new FormControl(datePipe.transform(this.project.startDate, 'yyyy-MM-dd'), Validators.required),
     
      'endDate': new FormControl(datePipe.transform(this.project.endDate, 'yyyy-MM-dd')),
      'projectTasks': projectTasks
    });

    // this.isEndDateNull = this.editProjectForm.get('endDate').value === null;
    // this.editProjectForm.get('endDate').valueChanges.subscribe(val => {
    //   this.isEndDateNull=val==="";
    // });
  }
  
 
  onAddTask() {
    const control = new FormControl(null, Validators.required);
    (<FormArray>this.editProjectForm.get('projectTasks')).push(
      new FormGroup({
        'name': new FormControl(null, Validators.required),
        'startDate': new FormControl(null, Validators.required),
        'duration': new FormControl(null,Validators.required),
        'isBillable': new FormControl(false)
      })
    );
  }

  clear()
  {const res= confirm("Sei sicuro di voler annullare le modifiche?");
  if (res)
    this.initForm();
  }
  onDeleteTask(index: number) {
   const res= confirm("Sei sicuro di voler eliminare il task?");
    if (res)
    (<FormArray>this.editProjectForm.get('projectTasks')).removeAt(index);
  }

  submitProjectForm() {
    const result: Project = Object.assign({},this.editProjectForm.value);
    result.id=this.project.id;
     
    this.projectService.update(result).subscribe((project) => {
      this.router.navigate(['projects', 'detail', this.project.id]);
    });
  }
}
