import { Injectable } from '@angular/core';
import { Task } from '../../model/task';

@Injectable()
export class TaskProvider {

    private tasks : Array<Task>;

    constructor() {
        this.tasks = [];
        
        this.addTask(1, "Install Node / NPM", "It is the base of everything", true);
        this.addTask(2, "Install Ionic", "Can be done through npm", true);
        this.addTask(3, "Learn Angular", "It is heavily used in Ionic 2", false);
        this.addTask(4, "Learn Ionic", "It will need some time, but resources are great", false);
    }
    
    public getTasks(): Array<Task> {
        return this.tasks;
    }

    public addTask(id: number, title: string, description: string, isCompleted: boolean) {
        let task = new Task(id, title, description, isCompleted);
        this.tasks.push(task);
    }
    
    public getTask(id: number): Task {
        return this.tasks.filter(task => task.id == id)[0];
    }
}