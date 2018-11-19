import 'package:flutter/material.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:Taskinator/model/task.dart';
import 'package:Taskinator/widgets/task_list_tile.dart';

void main() {
  TaskListTile _testee;
  Widget _wrappedTestee;
  Task _task;
  int _idOfTapCallback = 0;

  void _onTapCallback(int id) {
    _idOfTapCallback = id;
  }

  setUp(() {
    _task = Task(42,'My Task','Awesome description',true);
    _testee = TaskListTile(_task, _onTapCallback);
    _wrappedTestee = MaterialApp(home: Material(child: _testee));
  });

  group('TaskListTile', () {

    testWidgets('displays correct strings', (WidgetTester tester) async {
      // arrange
      await tester.pumpWidget(_wrappedTestee);

      // act & assert
      expect(find.text('My Task'), findsOneWidget);
      expect(find.text('Awesome description'), findsOneWidget);
    });

    testWidgets('displays correct icon when task is incomplete', (WidgetTester tester) async {
      // arrange
      _task.isCompleted = false;
      await tester.pumpWidget(_wrappedTestee);

      // act & assert
      expect(find.byIcon(Icons.check_box_outline_blank), findsOneWidget);
    });

    testWidgets('displays correct icon when task is completed', (WidgetTester tester) async {
      // arrange
      _task.isCompleted = true;
      await tester.pumpWidget(_wrappedTestee);

      // arrange & assert
      expect(find.byIcon(Icons.check_box), findsOneWidget);
    });

    testWidgets('calls callback when tapped', (WidgetTester tester) async {
      // arrange
      await tester.pumpWidget(_wrappedTestee);
      
      // act
      await tester.tap(find.text('My Task'));

      // assert
      expect(_idOfTapCallback, equals(42));
    });
  });
}
