import 'dart:async';
import 'package:flutter_driver/flutter_driver.dart';
import 'package:test/test.dart';

void main() {
  group('Taskinator integration test', () {
    FlutterDriver _driver;

    setUpAll(() async {
      _driver = await FlutterDriver.connect();
    });

    tearDownAll(() async {
      if (_driver == null)
        return;
      
      _driver.close();
    });

    Future<void> _addTask(String title, String description) async {
      await _driver.tap(find.byValueKey('AddTaskFAB'));

      await _driver.tap(find.byValueKey('TitleTextField'));
      await _driver.enterText(title);

      await _driver.tap(find.byValueKey('DescriptionTextField'));
      await _driver.enterText(description);

      await _driver.tap(find.byValueKey('AddButton'));
    }

    Future<void> _checkTask(int listItemId, String expectedTitle) async {
      final title = await _driver.getText(find.byValueKey('TaskListTileTitle' + listItemId.toString()));
      expect(title, equals(expectedTitle));
    }

    Future<void> _markTaskAsCompleted(int listItemId) async {
      await _driver.tap(find.byValueKey('TaskListTileTitle' + listItemId.toString()));
    }

    Future<void> _deleteTask(int listItemId) async {
      await _driver.scroll(find.byValueKey('TaskListTileTitle' + listItemId.toString()), 300, 0, Duration(milliseconds: 300));
    }

    test('prepare fancy party', () async {
      await _addTask('Beer', 'a lot of it, maybe 24 bottles');
      await _addTask('Whisky', 'only the good stuff from Scotland');
      await _addTask('Chips', '5 packs (everyone likes them)');

      await _checkTask(1, 'Beer');
      await _checkTask(2, 'Whisky');
      await _checkTask(3, 'Chips');

      await _markTaskAsCompleted(2);
      await _markTaskAsCompleted(3);
      
      await _deleteTask(3);
    });
  });
}
