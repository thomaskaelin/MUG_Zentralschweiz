import 'package:flutter/material.dart';

class TaskAddDialog extends StatelessWidget {
  final String _title = 'Add new task:';
  final String _taskTitleHint = 'Title of task';
  final String _taskDescriptionHint = 'Description of task';
  final String _taskAddButton = 'Add';
  final String _taskCancelButton = 'Cancel';
  final void Function(String, String) onTaskAdded;

  TaskAddDialog(this.onTaskAdded);

  @override
  Widget build(BuildContext context) {
    final titleInputController = TextEditingController();

    final titleInput = new TextField(
        key: Key('TitleTextField'),
        controller: titleInputController,
        decoration: InputDecoration(hintText: _taskTitleHint));

    final descriptionInputController = TextEditingController();

    final descriptionInput = new TextField(
        key: Key('DescriptionTextField'),
        controller: descriptionInputController,
        decoration: InputDecoration(hintText: _taskDescriptionHint));

    final contentWrap = Wrap(children: <Widget>[
      titleInput,
      descriptionInput,
    ]);

    final addButton = new FlatButton(
        key: Key('AddButton'),
        onPressed: () {
          onTaskAdded(titleInputController.text, descriptionInputController.text);
          Navigator.of(context).pop();
        },
        child: new Text(_taskAddButton));

    final cancelButton = new FlatButton(
        onPressed: () => Navigator.of(context).pop(),
        child: new Text(_taskCancelButton));

    return new AlertDialog(
      title: new Text(_title),
      content: contentWrap,
      actions: <Widget>[addButton, cancelButton],
    );
  }
}
