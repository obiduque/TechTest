import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Observable, catchError, map, throwError } from "rxjs";
import { environment } from "src/environments/environment";
import { Response } from "../dtos/Response";
import { User } from "../dtos/Users";

@Injectable({
  providedIn: 'root' // Disponible de forma global en toda la aplicación
})
export class UserService {
    private http = inject(HttpClient);
    private readonly apiUrl = `${environment.apiUrl}/users`;

    obtenerUsuarios(): Observable<User[]> {
        return this.http.get<{data:User[]}>(this.apiUrl).pipe(
        map(res=>res.data)
        );
    }

    guardarUsuario(user: User){
        return this.http.post<Response>(this.apiUrl, user).pipe(
        catchError(this.handleError)
        );
    }
    
    private handleError(error: any) {
        console.error('Ocurrió un error en la petición HTTP:', error);
        return throwError(() => new Error('Error en la comunicación con el servidor. Intente más tarde.'));
    }
}