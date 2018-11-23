import 'package:flutter/material.dart';
import 'package:Taskinator/model/task.dart';
import 'package:Taskinator/widgets/task_list_tile.dart';
import 'package:Taskinator/widgets/task_list_tile_dismissable.dart';

class TaskList extends StatelessWidget {
  final List<Task> tasks;
  final void Function(int) onListItemTap;
  final void Function(int) onListItemDismissed;

  TaskList(this.tasks, this.onListItemTap, this.onListItemDismissed);

  @override
  Widget build(BuildContext context) {
    return ListView.builder(
      itemCount: this.tasks.length,
      itemBuilder: (context, index) {
        final task = this.tasks[index];
        final taskTile = TaskListTile(task, this.onListItemTap);
        final taskListTileDismissable = TaskListTileDismissable(task.id, taskTile, onListItemDismissed);

        return taskListTileDismissable;
      },
    );
  }
}
