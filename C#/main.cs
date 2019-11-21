using System;
using System.Collections.Generic;

namespace com.queue
{
  class Queue {};
}

namespace com.task
{
  class Task {};
}

namespace com.event1
{
  class Event {};
}

class MainClass {
  // public static void test() {
  //   Queue q = new Queue();
	// 	// q.enqueue(1);
	// 	// q.enqueue(2);
	// 	// q.enqueue(3);
	// 	// Console.WriteLine(q.myList[1]==2);
	// 	// Console.WriteLine(q.dequeue()==1);
	// 	// Console.WriteLine(q.isEmpty()==false);
	// 	// Queue p = new Queue();
	// 	// Console.WriteLine(true==p.isEmpty());
  //   // List<string> assigned = new List<string>();
  //   // Task t = new Task(1,1,1,assigned);
  //   // Console.WriteLine(true==t.work());
  //   // Event e = new Event(1,1,"hello");
  //   // Console.WriteLine(e.work()==true);
  // }

  public static Tuple<int, int, int> isValidDate() {
    Console.WriteLine("Please Enter a date dd/mm/yyyy");
    string dateEntered = Console.ReadLine();
    String[] dateList = dateEntered.Split("/");
    int date = Convert.ToInt32(dateList[0]);
    int month = Convert.ToInt32(dateList[1]);
    int year = Convert.ToInt32(dateList[2]);
    return new Tuple <int, int, int>(date,month,year);
  }

  public static Tuple<int,int> isValidTime() {
    Console.WriteLine("Please Enter a start time hh:mm");
    string startTime = Console.ReadLine();
    String[] timeList = startTime.Split(":");
    int hour = Convert.ToInt32(timeList[0]);
    int minute = Convert.ToInt32(timeList[1]);
    return new Tuple <int,int>(hour, minute);
  }

  public static int isDuration() {
    Console.WriteLine("Please Enter the duration");
    while(true) {
      try {
        int duration = Convert.ToInt32(Console.ReadLine());
        return duration;
      }
      catch {
        Console.WriteLine("Please enter a duration");
      }
    }
  }

  public static Task taskSelected() {
    Tuple<int, int, int> date = isValidDate();
    Tuple<int,int> startTime = isValidTime();
    int duration = isDuration();
    Console.WriteLine("Please Enter the people assigned to this task, seperated my a comma ','");
    List<string> assignedTemp = new List<string>();
    // var assigned = Console.ReadLine();
    Task validTask = new Task(date,startTime,duration,assignedTemp);
    return validTask;
  }

  public static Event eventSelected() {
    Tuple<int, int, int> date = isValidDate();
    Tuple<int,int> startTime = isValidTime();
    string location = Console.ReadLine();
    Console.WriteLine("Please enter the location");
    Event validEvent = new Event(date,startTime,location);
    return validEvent;
  }
  public static void Main(){
    // test();
    Console.WriteLine("Hi there!");
    Console.WriteLine("Welcome to the To-Do-List manager.");

    bool matchToDo = false;
    while(!(matchToDo)) {
      Console.WriteLine("Would you like to enter an Event or a Task?");
      string userInput = Console.ReadLine().ToLower();
      if(userInput == "event"){
        Event theEvent = eventSelected();
        matchToDo = true;
      }
      else if (userInput == "task"){
        Task theTask = taskSelected();
        matchToDo = true;
      }
      else {
        Console.WriteLine("The input is invalid");
      }
    }
    Console.WriteLine("SUCCESS");
    System.Environment.Exit(1);
  }
}