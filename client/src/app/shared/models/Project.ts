import { ProjectTask } from './ProjectTask';

export class Project
{
    id:number;
    name:string;
    description:string;
    startDate?:Date;
    endDate?:Date;
    priority: 'low' | 'medium' | 'high';
    completed:boolean;
    spentHours:number;
    projectTasks:ProjectTask[]
}