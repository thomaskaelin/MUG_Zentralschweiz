import { Component } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';
import { Task } from '../../model/task';
import { TaskProvider } from '../../providers/task/task';

@Component({
  selector: 'page-details',
  templateUrl: 'details.html'
})
export class DetailsPage {
  public task: Task;
  
  constructor(
    public navCtrl: NavController, 
	public navParams: NavParams,
	private taskProvider: TaskProvider) {
	  let taskId = navParams.get("taskId");
	  this.task = this.taskProvider.getTask(taskId);
	}
}