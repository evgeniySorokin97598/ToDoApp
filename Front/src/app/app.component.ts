import { Component } from '@angular/core';
import { interval } from 'rxjs';
import { ConfigurationService } from './Services/ConfigService';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ToDoList';
  constructor(private configurationService: ConfigurationService) {
    
     
    

  }
}
