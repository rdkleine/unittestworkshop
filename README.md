# Workshop Unit Testing

## Getting started with unit testing

### Clone the repository
git clone https://github.com/rdkleine/unittestworkshop.git


TODO Create slides

Slide 1: Introduction

Welcome to the Unit Testing in C# presentation
Today we'll learn what Unit Testing is and why it's important
Slide 2: What is a Unit Test?

A Unit Test is a type of software testing where individual units or components of a software application are tested in isolation
It involves writing test code that exercises the functionality of a specific unit or component of code
The goal is to ensure that the unit or component works as expected and meets its design specifications
Slide 3: Why Unit Test?

Unit Testing helps catch bugs early in the development cycle, when they are easier and less expensive to fix
It provides a safety net for developers when making changes to the codebase, ensuring that existing functionality is not inadvertently broken
It helps to improve the overall quality of the codebase and reduce technical debt
It helps to improve the maintainability of the codebase, making it easier to understand, modify and refactor
Slide 4: How to write a Unit Test

Identify the unit or component of code that needs to be tested
Write a test method that exercises the functionality of that unit or component
Use an Assertion to validate that the unit or component behaves as expected
Repeat for all relevant units or components of code
Slide 5: Example Unit Test in C#

Let's look at an example of a Unit Test in C#:
csharp
Copy code
// Test Method
public void TestAddition()
{
    // Arrange
    Calculator calculator = new Calculator();
    
    // Act
    int result = calculator.Add(2, 3);
    
    // Assert
    Assert.AreEqual(5, result);
}

// Code under test
public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }
}
Slide 6: Best Practices for Unit Testing

Write tests that are independent of one another
Test for expected results, not for implementation details
Keep tests small and focused on a specific aspect of the codebase
Use a consistent naming convention for test methods and classes
Use tools and frameworks to automate the testing process
Slide 7: Summary

Unit Testing is a type of software testing where individual units or components of a software application are tested in isolation
It helps catch bugs early, provides a safety net for developers, improves code quality and maintainability
Unit Tests involve writing test code that exercises the functionality of a specific unit or component of code
Best Practices for Unit Testing include writing independent tests, testing for expected results, keeping tests small and focused, using consistent naming conventions, and automating the testing process
Slide 8: Q&A

Any questions or comments?