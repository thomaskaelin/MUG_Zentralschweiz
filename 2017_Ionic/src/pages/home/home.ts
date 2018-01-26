import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { Task } from '../../model/task';
import { TaskProvider } from '../../providers/task/task';
import { DetailsPage } from '../details/details';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  public tasks : Array<Task>;

  constructor(public navCtrl: NavController, private taskProvider: TaskProvider) {
    this.tasks = this.taskProvider.getTasks();
  }

  public taskSelected(selectedTask: Task) {
	  this.navCtrl.push(DetailsPage, { "taskId": selectedTask.id });
  }
  
}