import { Directive } from '@angular/core';
import { AbstractControl, Validator, ValidationErrors, AsyncValidator, NG_ASYNC_VALIDATORS } from '@angular/forms';
import { Project } from '../models/Project';
import { ProjectService } from '../services/project.service';
import { Observable } from 'rxjs';
import { ProjectValidators } from '../validators/ProjectValidators';

@Directive({
   
    selector: '[uniqueNameValidatorValidator][formControlName],[uniqueNameValidator][formControl],[uniqueNameValidator][ngModel]',
  providers: [{provide: NG_ASYNC_VALIDATORS, useExisting: UniqueNameValidatorDirective, multi: true}]
})
export class UniqueNameValidatorDirective implements AsyncValidator {
    constructor(private service:ProjectService) {}
    validate(control: AbstractControl): Promise<ValidationErrors> | Observable<ValidationErrors> {
    return ProjectValidators.uniqueName(this.service)(control);
            
    }
     
    

    
}