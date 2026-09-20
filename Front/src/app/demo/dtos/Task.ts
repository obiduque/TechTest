export class Task{
    id: number | null;
    titulo: string | null;
    estado: string | null;
    fechaCreacion: Date | null;
    metadata: JSON | null;
    usuarioId: number | null;
}