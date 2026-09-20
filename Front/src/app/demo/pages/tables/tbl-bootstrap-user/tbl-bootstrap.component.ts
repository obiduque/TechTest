import { Component, inject, OnInit, signal } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/demo/dtos/Users';
import { UserService } from 'src/app/demo/services/user_service';
import { SharedModule } from 'src/app/theme/shared/shared.module';

@Component({
  selector: 'app-tbl-bootstrap',
  imports: [SharedModule],
  templateUrl: './tbl-bootstrap.component.html',
  styleUrls: ['./tbl-bootstrap.component.scss']
})
export class TblBootstrapComponent implements OnInit {
  public users = signal<User[]>([]);
  public message= signal<string>("");
  public showCreate = false;
  private fb = inject(FormBuilder);
  userForm!: FormGroup;

  constructor(private userService: UserService){
  }

  ngOnInit(){
    this.getUsers();
    this.initForm();
  }

  initForm(){
    this.userForm = this.fb.group({
      nombre: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  getUsers(){
    this.userService.obtenerUsuarios().subscribe({
      next: (datos)=> (this.users.set(datos)),
      error: (err)=>(console.error(err))
    });
  }

  saveUser(){
    const user: User = new User();
    user.nombre = this.userForm.get("nombre").value;
    user.correo = this.userForm.get("email").value;
    this.userService.guardarUsuario(user).subscribe({
      next: (rta)=> (this.message.set(rta.message)),
      error: (err)=> (this.message.set(err))
    });
  }

  showCreateBox(mostrar: boolean){
    this.showCreate = mostrar;
    if(!mostrar){
      this.getUsers();
      this.message.set('');
      this.userForm.reset();
    }
  }
}
