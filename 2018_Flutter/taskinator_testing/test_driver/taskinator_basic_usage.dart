import 'package:flutter/material.dart';
import 'package:flutter_driver/driver_extension.dart';
import 'package:Taskinator/widgets/taskinator_app.dart';

void main() {
  enableFlutterDriverExtension();
  runApp(TaskinatorApp("Taskinator", Colors.lightBlue));
} 