import 'package:test/test.dart';
import 'package:Taskinator/model/task_manager.dart';

void main() {
  TaskManager _testee;

  setUp(() {
    _testee = TaskManager();
  });

  group('TaskManager', () {
    test('addNewTask() adds tasks with unique IDs', () {
      // act
      _testee.addNewTask('Task 1', 'Desc 1');
      _testee.addNewTask('Task 2', 'Desc 2');

      // assert
      expect(_testee.getTasks().length, equals(2));

      final task1 = _testee.getTasks()[0];
      expect(task1.id, equals(1));
      expect(task1.title, equals('Task 1'));
      expect(task1.description, equals('Desc 1'));
      expect(task1.isCompleted, equals(false));

      final task2 = _testee.getTasks()[1];
      expect(task2.id, equals(2));
      expect(task2.title, equals('Task 2'));
      expect(task2.description, equals('Desc 2'));
      expect(task2.isCompleted, equals(false));
    });

    test('removeExistingTask() removes task with corresponding id', () {
      // arrange
      _testee.addNewTask('T1', '');
      _testee.addNewTask('T2', '');

      // act
      _testee.removeExistingTask(1);

      // assert
      expect(_testee.getTasks().length, equals(1));

      final task1 = _testee.getTasks()[0];
      expect(task1.id, equals(2));
      expect(task1.title, equals('T2'));
    });

    test('invertTaskIsCompleted() inverts task with corresponding id', () {
      // arrange
      _testee.addNewTask('T1', '');
      _testee.addNewTask('T2', '');

      // act
      _testee.invertTaskIsCompleted(2);

      // assert
      expect(_testee.getTasks()[0].isCompleted, equals(false));
      expect(_testee.getTasks()[1].isCompleted, equals(true));
    });
  });
}