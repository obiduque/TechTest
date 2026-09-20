import { Pipe, PipeTransform } from "@angular/core";
import { User } from "src/app/demo/dtos/Users";

@Pipe({
  name: 'buscarPorId',
  standalone: true // Standalone para componentes modernos de Angular
})
export class BuscarPorIdPipe implements PipeTransform {
  transform(usuarios: User[] | null | undefined, id: number | string | null | undefined): User | undefined {
    if (!usuarios || id === null || id === undefined || id === '') {
      return undefined;
    }
    return usuarios.find(usuario => String(usuario.id) === String(id));
  }
}