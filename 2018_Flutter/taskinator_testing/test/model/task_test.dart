import 'package:test/test.dart';
import 'package:Taskinator/model/task.dart';

void main() {
  Task _testee;

  setUp(() {
    _testee = Task(42,'My Task','Awesome description',true);
  });

  group('Constructor initializes', () {
    
    test('id', () {
      expect(_testee.id, equals(42));
    });

    test('title', () {
      expect(_testee.title, equals('My Task'));
    });

    test('description', () {
      expect(_testee.description, equals('Awesome description'));
    });

    test('isCompleted', () {
      expect(_testee.isCompleted, equals(true));
    });
  });
}