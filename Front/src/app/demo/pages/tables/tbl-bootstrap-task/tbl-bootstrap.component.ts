import { Component, inject, OnInit, signal } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Task } from 'src/app/demo/dtos/Task';
import { TaskFilter } from 'src/app/demo/dtos/TaskFilter';
import { User } from 'src/app/demo/dtos/Users';
import { TaskService } from 'src/app/demo/services/task_service';
import { UserService } from 'src/app/demo/services/user_service';
import { BuscarPorIdPipe } from 'src/app/theme/shared/components/BuscarPorIdPipe';
import { SharedModule } from 'src/app/theme/shared/shared.module';

@Component({
  selector: 'app-tbl-bootstrap',
  imports: [SharedModule, BuscarPorIdPipe],
  templateUrl: './tbl-bootstrap.component.html',
  styleUrls: ['./tbl-bootstrap.component.scss']
})
export class TblBootstrapComponent implements OnInit {
  public task = signal<Task[]>([]);
  tempTask: Task[] =[];
  public users: User[] = [];
  public message= signal<string>("");
  public showCreate = false;
  private fb = inject(FormBuilder);
  taskForm!: FormGroup;
  filterForm!: FormGroup;

  constructor(private userService: UserService, private taskService: TaskService){
  }

  ngOnInit(){
    this.getUsers();
    this.getTasks();
    this.initFilterForm();
  }

  initTaskForm(){
    this.taskForm = this.fb.group({
      titulo: ['', [Validators.required]],
      usuario: ['', [Validators.required]]
    });
  }

  initFilterForm(){
    this.filterForm = this.fb.group({
      idUser: ['', [Validators.min(0)]],
      state: ['', []],
      metaKey: ['', []],
      metaData: ['', []],
    });
  }

  getUsers(){
    this.userService.obtenerUsuarios().subscribe({
      next: (datos)=> (this.users =datos),
      error: (err)=>(console.error(err))
    });
  }

  getTasks(){
    this.taskService.obtenerTareas().subscribe({
      next: (datos)=> {this.task.set(datos);this.tempTask=datos;},
      error: (err)=> (console.error(err))
    });
  }

  filtrarTareas(event: Event): void {
    const inputElement = event.target as HTMLInputElement;
    const valor = inputElement.value;

    this.task.set(valor === 'Todos' ? this.tempTask : 
      this.tempTask.filter(tarea => tarea.estado === valor)
    );
  }

  updateTaskState(id:number){
    this.taskService.actualizarEstado(id).subscribe({
      next: (rta)=> (this.getTasks()),
      error: (err)=> (console.error(err))
    });
  }

  saveTask(){
    const task: Task = new Task();
    task.titulo = this.taskForm.get("titulo").value;
    task.usuarioId = this.users.find(user=>user.nombre===this.taskForm.get("usuario").value).id;
    task.estado = 'Pending';
    this.taskService.guardarTarea(task).subscribe({
      next: (rta)=> (this.message.set(rta.message)),
      error: (err)=> (this.message.set(err))
    });
  }

  showCreateBox(mostrar: boolean){
    this.showCreate = mostrar;
    if(!mostrar){
      this.getTasks();
      this.message.set('');
      this.taskForm.reset();
    }else{
      this.initTaskForm();
    }
  }
}
