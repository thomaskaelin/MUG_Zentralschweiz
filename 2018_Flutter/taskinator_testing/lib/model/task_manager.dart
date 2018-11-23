import 'package:Taskinator/model/task.dart';

class TaskManager {
  int _nextTaskId = 1;
  List<Task> _tasks = new List<Task>();

  List<Task> getTasks() {
    return _tasks;
  }

  void addNewTask(String title, String description) {
    _tasks.add(Task(_nextTaskId, title, description, false));

    _nextTaskId++;
  }

  void removeExistingTask(int taskId) {
    final matchingTask = _findTask(taskId);
    _tasks.remove(matchingTask);
  }

  void invertTaskIsCompleted(int taskId) {
    final matchingTask = _findTask(taskId);
    matchingTask.isCompleted = !matchingTask.isCompleted;
  }

  Task _findTask(int taskId) {
    return _tasks.firstWhere((t) => t.id == taskId);
  }
}
