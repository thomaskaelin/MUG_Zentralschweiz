import 'package:flutter/material.dart';
import 'package:Taskinator/widgets/show_tasks_page.dart';

class TaskinatorApp extends StatelessWidget {
  final String title;
  final MaterialColor color;

  TaskinatorApp(this.title, this.color);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
        title: title,
        theme: ThemeData(
          primarySwatch: color,
        ),
        home: ShowTasksPage());
  }
}
