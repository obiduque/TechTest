import { HttpClient, HttpEvent, HttpRequest, HttpResponse } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Observable, catchError, filter, map, throwError } from "rxjs";
import { environment } from "src/environments/environment";
import { Response } from "../dtos/Response";
import { User } from "../dtos/Users";
import { Task } from "../dtos/Task";
import { TaskFilter } from "../dtos/TaskFilter";
import { TaskApiResponse } from "../dtos/TaskApiResponse";

@Injectable({
  providedIn: 'root' // Disponible de forma global en toda la aplicación
})
export class TaskService {
    private http = inject(HttpClient);
    private readonly apiUrl = `${environment.apiUrl}/tasks`;

    obtenerTareas(): Observable<Task[]> {
        return this.http.get<{data:Task[]}>(this.apiUrl).pipe(
        map(res=>res.data)
        );
    }

    guardarTarea(task: Task){
        return this.http.post<Response>(this.apiUrl, task).pipe(
        catchError(this.handleError)
        );
    }

    actualizarEstado(id: number){
        return this.http.put<Response>(this.apiUrl+"/"+id+"/status",null).pipe(
        catchError(this.handleError)
        );
    }
    
    private handleError(error: any) {
        console.error('Ocurrió un error en la petición HTTP:', error);
        return throwError(() => new Error('Error en la comunicación con el servidor. Intente más tarde.'));
    }
}