import 'package:flutter/material.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:Taskinator/widgets/task_add_dialog.dart';

void main() {
  TaskAddDialog _testee;
  Widget _wrappedTestee;
  String _taskName = "";
  String _taskDescription = "";

  void _onTaskAddedCallback(String taskName, String taskDescription) {
    _taskName = taskName;
    _taskDescription = taskDescription;
  }

  setUp(() {
    _testee = TaskAddDialog(_onTaskAddedCallback);
    _wrappedTestee = MaterialApp(home: Material(child: _testee));
  });

  group('TaskAddDialog', () {

    testWidgets('is correctly initialized', (WidgetTester tester) async {
      // arrange
      await tester.pumpWidget(_wrappedTestee);

      // act & assert
      expect(find.text('Add new task:'), findsOneWidget);
      expect(find.text('Title of task'), findsOneWidget);
      expect(find.text('Description of task'), findsOneWidget);
      expect(find.text('Add'), findsOneWidget);
      expect(find.text('Cancel'), findsOneWidget);
    });

    testWidgets('calls callback when <Add> is tapped', (WidgetTester tester) async {
      // arrange
      await tester.pumpWidget(_wrappedTestee);

      await tester.enterText(find.byKey(Key('TitleTextField')), 'Buy beer');
      await tester.enterText(find.byKey(Key('DescriptionTextField')), 'at least 6 bottles');

      // act
      await tester.tap(find.text('Add'));

      // assert
      expect(_taskName, equals('Buy beer'));
      expect(_taskDescription, equals('at least 6 bottles'));
    });
  });
}
