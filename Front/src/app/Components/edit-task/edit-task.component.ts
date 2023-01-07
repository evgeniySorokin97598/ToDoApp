import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToDo } from 'src/app/Entities/ToDo';
import { ServerService } from 'src/app/Services/ServerService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-task',
  templateUrl: './edit-task.component.html',
  styleUrls: ['./edit-task.component.css']
})
export class EditTaskComponent implements OnInit {

  public Task :ToDo = new ToDo();
  public IsNewTask = false;

  constructor(private router: ActivatedRoute,private service:ServerService,private routerPage: Router) { 
    this.Task = new ToDo();
  }

  async ngOnInit(): Promise<void> {
      let s = this.router.snapshot.paramMap.get("id");
      
      
      
      if (s == "NewTask"){
        this.IsNewTask = true;

      }
      else{
        let id =  Number(s);
        let result = await this.service.GetTaskById(id);
        this.Task = result;
        this.IsNewTask = false;
      }

      
     
  }
  async Edit() :Promise<void>{
    if (this.IsNewTask == false){
      await this.service.EditTask(this.Task);
    }
    else{
      await this.service.Addtask(this.Task);
    }
    this.routerPage.navigate(['/ToDoList/']);
  }
  async Delete(){
    this.service.RemoveTask(this.Task.Id);
    this.routerPage.navigate(['/ToDoList/']);
  }

}
