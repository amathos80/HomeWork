import { Project } from '../models/Project';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { Inject, Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
  })
export class ProjectService {

    baseApiUrl:string = "https://localhost:44361/api/projects"

constructor(private http:HttpClient) {
    
}
    add(project: Project) {
        return this.http.post<Project>(this.baseApiUrl, project).pipe(
            tap((newProject: Project) => console.log(`added project w/ id=${newProject.id}`)),
            catchError(this.handleError<Project>('addProject'))
          );
    }
    getAll() {
        return this.http.get<Project[]>(`${this.baseApiUrl}`)
          .pipe(
            catchError(this.handleError('getProjects', []))
          );
      }
    
      get(id: string | number) {
        const url = `${this.baseApiUrl}/GetProject/${id}`;
        return this.http.get<Project>(url).pipe(
          tap(_ => console.log(`fetched project id=${id}`)),
          catchError(this.handleError<Project>(`getProject id=${id}`))
        );
      }
    
      update(project: Project) {
        const url = `${this.baseApiUrl}/UpdateProject`;
        return this.http.post(url, project).pipe(
          tap(_ => console.log(`updated project id=${project.id}`)),
          catchError(this.handleError<any>('updateProject'))
        );
      }

    private handleError<T> (operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {
          console.error(error);
          console.log(`${operation} failed: ${error.message}`);
          return of(result as T);
        };
      }
}


