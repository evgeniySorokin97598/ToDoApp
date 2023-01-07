import { HttpClient, HttpHeaders } from "@angular/common/http";
import { ToDo } from "../Entities/ToDo";
import { IToDoList } from "../Interfaces/IToDoList";

export class ToDoListWorker implements IToDoList{
    _url:string = "https://localhost:44386/";
 
    constructor (private http :HttpClient){
        
    }

    async GetToDoListAsync(): Promise<ToDo[]> {
        console.log("Запрос");
         return await this.GetRequest(this._url+"ToDo/GetToDoList")
    }

    async GetTaskById(id:number):Promise<ToDo>{
        return await this.GetRequest(this._url+"ToDo/GetTaskById/"+id)
    }
    async EditTask(task:ToDo):Promise<void>{
        return await this.PutRequest(this._url+"ToDo/Edit",task);
    }
    async AddNewTask(task:ToDo):Promise<void>{
        return await this.PostRequest(this._url+"ToDo/AddTask",task);
    }

    async RemoveTask(id:number):Promise<void>{
         
        await this.DeleteRequest(this._url+"ToDo/RemoveTask/" + id,null);
    }

    private async DeleteRequest(action:string,obj:any):Promise<any>{
        let p  = await Promise.resolve<any>(new Promise<any>((resolve, reject) => {
             
                
             let responce =   this.http.delete<any>(action);
             
             responce.subscribe(
            (data ) => {
             resolve(data);
            },
            (error) => {
                console.log(error);
              }
            );

        }));

        return await p;

    }

    private async PostRequest(action:string,obj:any):Promise<any>{
        let p  = await Promise.resolve<any>(new Promise<any>((resolve, reject) => {
            let rezult:any;

             let responce =   this.http.post<any>(action,obj);
             
             responce.subscribe(
            (data ) => {
             resolve(data);
            },
            (error) => {
                console.log(error);
              }
            );

        }));

        return await p;

    }
    private async PutRequest(action:string,obj:any):Promise<any>{

        let p  = await Promise.resolve<any>(new Promise<any>((resolve, reject) => {
            let rezult:any;

             let responce =   this.http.put<any>(action,obj);
             
             responce.subscribe(
            (data ) => {
             resolve(data);
            },
            (error) => {
                console.log(error);
              }
            );

        }));

        return await p;

    }

    private async GetRequest(action:string):Promise<any>{

        let p  = await Promise.resolve<any>(new Promise<any>((resolve, reject) => {
            let rezult:any;

             let responce =   this.http.get<any>(action );
             
             responce.subscribe(
            (data ) => {
             resolve(data);
            },
            (error) => {
                console.log(error);
              }
            );

        }));

        return await p;

    }
}