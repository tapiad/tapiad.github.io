---
title: Daniel
layout: default
---

Visit my GitHub [here](https://github.com/tapiad).

Visit my [Portfolio](https://tapiad.github.io).

Link to Homework 3 [assignment](http://www.wou.edu/~morses/classes/cs46x/assignments/HW3.html).

### Homework 3

Homework 3 we are going to learn C#. We are first going to install Visual Studio and continue to work with Git. We are to use Visual Studio 2017 only! We are given a Java version on a program in which we will be translating it to C#. All our C# code must be commented with XML comments. We are not allowed to use Git commands from within Visual Studio only from the command line.


### Step 1: Installing Visual Studio 2017

Since I am using a MacBook Air mid 2013, I had to upgrade my macOS. The macOS I was using was OS X Yosemite. I had to upgrade to macOS High Sierra. After an hour of upgrading my macOS, I finally downloaded [Visual Studio for Mac](https://www.visualstudio.com/vs/visual-studio-mac/).


### Step 2: Feature Branch & Working with C#

Before starting we start working remember to create a new feature branch. I called my feature branch `hw3-branch`.

```bash
git branch hw3-branch
git checkout hw3-branch
```    

All work for this homework will be adding, committing, and pushing through this feature branch.

```bash
git add File
git commit -m "modified File"
git push origin hw3-branch
```

We are given a Java program that we will need to make replicate of but in C#. We are not to copy and paste the code and then try to fix the errors. The point is to learn the Visual Studio IDE style of development.

After reviewing the Java code I opened up Visual Studio. I opened up a C# console application and started working on creating a mimic of the Java program. The first thing I learned about C# is how to get an input from the user. `Console.ReadLine()` takes the input of the user. I put the user input into a class called `Scanner` in which I found online([The Scanner Class](https://stackoverflow.com/questions/722270/is-there-an-equivalent-to-the-scanner-class-in-c-sharp-for-strings)). With this class I was able the class Scanner as Java's Scanner class.

```cs
private Scanner scin = new Scanner( Console.ReadLine() );
```

When working with C#, their types are sometimes lowercase. Ex: `bool` for boolean, `string` for String, and `object` for Object

Methods are to be uppercase. 

```cs
private bool DoCalculation()
```

Interface typenames are to start with I, like `IStackADT`

```cs
private IStackADT IStack = new LinkedStack();
```

I learned how to throw an exception and how to write out a message for the user using `Console.WriteLine("Message here!")`

```cs
try
{
    if (input == null || input.Equals(""))
    {
        throw (new Exception("Null or the empty string are " +
                            "not valid postfix expressions."));
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

There was a part where I got stuck where the error message would display this: *inaccessible due to its protection level*. It ended up to be an easy fix because I only needed to make that class *public*.

```cs
public object data;
public Node next;
```


I have also learned comment using XML comments. 

```cs
//*********************************************************************************
/// <summary>
/// Command line postfix calculator.  
/// </summary>
/// <creator> Daniel Tapia </creator>
/// <date> 10.31.17 </date>
//*********************************************************************************
```







