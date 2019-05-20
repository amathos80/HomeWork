import { AbstractControl, ValidationErrors, AsyncValidatorFn } from '@angular/forms';
import { ProjectService } from '../services/project.service';


// export function  uniqueName(service:ProjectService,id?:number) : AsyncValidatorFn {
//     return (control:AbstractControl) : Promise<ValidationErrors | null> =>{
//          return new Promise((resolve,reject)=>
//  {
//  service.nameExist(control.value,id).subscribe(res=>
//     {
//         if(res)
//         resolve({'uniqueName':true})
//         else 
//             resolve(null);
//     })
// })
// }
// }

export class ProjectValidators{


static uniqueName(service:ProjectService,id?:number) : AsyncValidatorFn {
    return (control:AbstractControl) : Promise<ValidationErrors | null> =>{
         return new Promise((resolve,reject)=>
 {
 service.nameExist(control.value,id).subscribe(res=>
    {
        if(res)
        resolve({'uniqueName':true})
        else 
            resolve(null);
    })
})
}
}
}