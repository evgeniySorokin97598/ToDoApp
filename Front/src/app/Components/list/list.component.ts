import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToDo } from 'src/app/Entities/ToDo';
import { ServerService } from 'src/app/Services/ServerService';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  public  ToDoList:ToDo[] = [] ;
  displayedColumns: string[] = ['Text', 'Task', 'Description'];
  constructor( private service:ServerService,private router: Router) { 
      
  }

  async ngOnInit(): Promise<void> {
     
     let result = await this.service.GetToDoListAsync();
     console.log("Ok");
     this.ToDoList = result;
  }
  OpenTask(id:any) {
    this.router.navigate(['/Task/' + id]);
  }
}
