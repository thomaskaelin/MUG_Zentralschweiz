import 'package:flutter/material.dart';

class TaskListTileDismissable extends StatelessWidget {
  final int taskId;
  final Widget child;
  final void Function(int) onDismissed;

  TaskListTileDismissable(this.taskId, this.child, this.onDismissed);

  @override
  Widget build(BuildContext context) {
    return Dismissible(
      key: Key(taskId.toString()),
      child: this.child,
      background: Container(
          child: Center(
              child: Text('Task deleted',
                  style: TextStyle(
                      color: Colors.white,
                      fontWeight: FontWeight.bold))),
          color: Colors.red),
      onDismissed: (direction) => onDismissed(taskId),
    );
  }
}
