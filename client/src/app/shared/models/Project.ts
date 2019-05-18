import { ProjectTask } from './ProjectTask';

export interface Project
{
    id:number,
    name:string,
    description:string,
    startDate:Date,
    endDate?:Date,
    priority: 'low' | 'medium' | 'high',
    completed:boolean,
    spentedHours:number,
    projectTasks:ProjectTask[]
}