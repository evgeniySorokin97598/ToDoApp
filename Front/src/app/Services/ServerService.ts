import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ToDo } from "../Entities/ToDo";
import { IToDoList } from "../Interfaces/IToDoList";
import { ToDoListWorker } from "../Workers/ToDoListWorker";

@Injectable()
export class ServerService{

    private _toDoListWorker:IToDoList;
    constructor(private http :HttpClient){
        this._toDoListWorker = new ToDoListWorker(http);

    }
    public async GetToDoListAsync():Promise<ToDo[]>{
     return await  this._toDoListWorker.GetToDoListAsync();
        
    }
    public async GetTaskById(id:number):Promise<ToDo>{
        return await this._toDoListWorker.GetTaskById(id);

    }

    public async EditTask(task:ToDo):Promise<void>{
        return await this._toDoListWorker.EditTask(task);

    }
    public async Addtask(task:ToDo):Promise<void>{
        return await this._toDoListWorker.AddNewTask(task);

    }
    public async RemoveTask(id:number){
        
        return await this._toDoListWorker.RemoveTask(id);
    }
}