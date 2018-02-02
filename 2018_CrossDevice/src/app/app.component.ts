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

  newTask: Task = new Task;
  constructor(private taskDataService: TaskDataService) {

  }

  addTask() {
    this.taskDataService.addTask(this.newTask);
    this.newTask = new Task;
  }

  get tasks() {
    return this.taskDataService.getTasks();
  }

}

