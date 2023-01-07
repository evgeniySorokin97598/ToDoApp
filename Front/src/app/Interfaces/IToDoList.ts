import { ToDo } from "../Entities/ToDo";

export interface IToDoList{
     GetToDoListAsync():Promise<ToDo[]>;
     GetTaskById(id:number):Promise<ToDo>;
     EditTask(task:ToDo):Promise<void>;
     AddNewTask(task:ToDo):Promise<void>;
     RemoveTask(id:number):Promise<void>;
     Init():void;
}