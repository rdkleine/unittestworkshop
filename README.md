Uitwerken:
- Vooraf mensen de workshop locaal laten clonen
  - mkdir d:\workshop\unittesting
  - d:
  - cd d:\workshop\unittesting
  - git clone https://github.com/rdkleine/unittestworkshop.git
- Vooraf mensen de benodigde software laten installeren
- Vooraf mensen Google Forms vragenlijst laten invoeren
 - Kennisniveau Geen / Beginner / Gevorderde 
 - Welke verachtingen heb je van de workshop
 - Wat zijn onderwerpen die je graag behandeld zou willen zien
 - Ben je aanwezig bij beide sessies

Code coverage FineCodeCoverage
- https://marketplace.visualstudio.com/items?itemName=FortuneNgwenya.FineCodeCoverage2022

Code coverage zonder VSCode
- dotnet tool install -g dotnet-reportgenerator-globaltool
- d:
- cd d:\workshop\unittesting\unittestworkshop
- dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura
- TODO Onderdeel van Visual Studio dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura
- reportgenerator
    -reports:"d:\workshop\unittesting\TestResults\{guid}\coverage.cobertura.xml"
    -targetdir:"coveragereport"
    -reporttypes:Html

ref: https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-code-coverage?tabs=linux#code-coverage-tooling

Wat is een "Unit"
-> Een unit is een stukje code dat onafhankelijk van andere code kan worden getest
-> Een unit kan een methode zijn, een klasse, een module, een component, een service, etc.
Waarom zijn Unit Tests
-> Catch bugs early
-> Safety net for developers
-> Improve code quality
-> Improve maintainability
Hoe schrijf je een Unit Test
-> Arrange Act Assert
-> Test for expected results, not for implementation details
-> Keep tests small and focused
Wat is een Mock object en waarom is het nodig?
-> Een Mock object is een nep object dat de werking van een echt object nabootst
-> Het is nodig om de werking van een echt object te kunnen testen zonder dat het echt object aanwezig is
Code coverage wordt vaak genoemd maar waarom is het belangrijk?
-> Code coverage geeft aan welk percentage van de code door de Unit Tests wordt gedekt
-> Het is belangrijk om te weten of de Unit Tests alle code dekken
-> Het is belangrijk om te weten of de Unit Tests alle mogelijke paden door de code dekken
-> Het is belangrijk om te weten of de Unit Tests alle mogelijke scenario's dekken
-> Het is belangrijk om te weten of de Unit Tests alle mogelijke fouten dekken



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