import 'package:flutter/material.dart';
import 'package:Taskinator/model/task_manager.dart';
import 'package:Taskinator/widgets/task_add_dialog.dart';
import 'package:Taskinator/widgets/task_list.dart';

class ShowTasksPage extends StatefulWidget {
  final String pageTitle = "Tasks";

  @override
  _ShowTasksPageState createState() => _ShowTasksPageState();
}

class _ShowTasksPageState extends State<ShowTasksPage> {
  final TaskManager _taskManager = new TaskManager();

  void _showAddNewTaskDialog() {
    final addDialog = TaskAddDialog(_addNewTask);

    showDialog(
        context: context,
        builder: (BuildContext context) {
          return addDialog;
        });
  }

  void _addNewTask(String title, String description) {
    setState(() {
      _taskManager.addNewTask(title, description);
    });
  }

  void _removeExistingTask(int taskId) {
    setState(() {
      _taskManager.removeExistingTask(taskId);
    });
  }

  void _invertTaskIsCompleted(int taskId) {
    setState(() {
      _taskManager.invertTaskIsCompleted(taskId);
    });
  }

  @override
  Widget build(BuildContext context) {
    final appBar = AppBar(title: Text(widget.pageTitle));

    final taskList = TaskList(
        _taskManager.getTasks(),
        _invertTaskIsCompleted, 
        _removeExistingTask);

    final fab = FloatingActionButton(
      key: Key('AddTaskFAB'),
      onPressed: _showAddNewTaskDialog,
      child: Icon(Icons.add, color: Colors.white),
    );

    return Scaffold(
      appBar: appBar,
       body: taskList,
       floatingActionButton: fab);
  }
}
