import 'package:flutter/material.dart';
import 'package:Taskinator/model/task.dart';

class TaskListTile extends StatelessWidget {
  final Task task;
  final void Function(int) onTap;

  TaskListTile(this.task, this.onTap);

  @override
  Widget build(BuildContext context) {
    final isCompletedIcon =
        task.isCompleted ? Icons.check_box : Icons.check_box_outline_blank;

    return ListTile(
      title: Text(task.title, key: Key('TaskListTileTitle' + task.id.toString())),
      subtitle: Text(task.description),
      leading: Icon(isCompletedIcon),
      onTap: () => this.onTap(task.id),
    );
  }
}
