import { Injectable } from '@angular/core';
import { Task } from './task';


@Injectable()
export class TaskDataService {
  lastId = 0;
  tasks: Task[] = [];

  constructor() {
    const task = new Task();
    task.title = 'Test';
    this.addTask(task);
   }

  addTask(task: Task) {
    task.id = ++ this.lastId;
    this.lastId ++;
    this.tasks.push(task);
  }

  getTasks(): Task[] {
    return this.tasks;
  }

  getTask(id: number): Task {
    return this.tasks
    .filter(task => task.id === id)
    .pop();
  }

}
