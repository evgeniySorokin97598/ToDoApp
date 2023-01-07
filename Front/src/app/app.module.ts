import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatListModule} from '@angular/material/list';
import { ListComponent } from './Components/list/list.component';
 
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule} from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule, Routes } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ServerService } from './Services/ServerService';
import { HttpClientModule } from '@angular/common/http';
import { EditTaskComponent } from './Components/edit-task/edit-task.component';
import {MatInputModule} from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table'  

const routes: Routes = [
  {path: 'ToDoList', component:ListComponent},
  {path: 'Task/:id', component:EditTaskComponent}

]

@NgModule({
  declarations: [
      AppComponent,
      ListComponent,
      EditTaskComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatListModule,
    MatButtonModule,
    MatMenuModule,
    MatToolbarModule,
    MatIconModule,
    MatCardModule,
    RouterModule.forRoot(routes),
    NgbModule,
    HttpClientModule,
    MatInputModule,
    FormsModule,
    MatTableModule
  ],
  providers: [
    ServerService
  ],
  bootstrap: [AppComponent]
})

export class AppModule { 

  
}
