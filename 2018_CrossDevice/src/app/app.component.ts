import { Component } from '@angular/core';
import { TaskDataService } from './task-data.service';
import { Task } from './task';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [TaskDataService]
})
export class AppComponent {


  constructor(private taskDataService: TaskDataService) {

  }

  addTodo() {
    const newTask = new Task();
    this.taskDataService.addTask(newTask);
  }

  get tasks() {
    return this.taskDataService.getTasks();
  }

}

