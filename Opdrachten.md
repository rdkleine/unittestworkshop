# Unittest workshop

## Opdracht A
Code: EmployeeService.cs methode Upsert.
- Voeg validatie op gegevens toe.
- Stuur mail naar de gebruiker dat zijn gegevens zijn aangepast.
- Geef een resultaat terug met een status en een eventuele foutmelding.

Probeer te werken vanuit de TDD gedachte. Schrijf eerst een test en maak dan de code.
Denk ook na hoe je de foutafhandeling terug geeft. Denk aan het niet kunnen opslaan van de gegevens, het niet kunnen versturen van de mail. 
Maakt het niet te complex het gaat uiteindelijk om testen te schrijven niet dit project te goldplaten.

Data:
- Probeer de Mock benadering waarbij de IDataService data ophaald en opslaat zonder gebruik van een context.
- Probeer de InMemory benadering waarbij de IDataService data ophaald en opslaat met gebruik van een context.

Kijk ook eens naar de code coverage hoe die je kan helpen.

## Opdracht B
Code: EmployeeService.cs methode Search.

- Beschrijf een nieuwe zoek functie om werknemers te vinden.
- Bijvoorbeeld om op naam, geboortedatum, werkgever te kunnen filteren.
- Gebruik de in memory dbContext om data toe te voegen waar op gefilterd kan worden.

Probeer te werken vanuit de TDD gedachte. Schrijf eerst een test en maak dan de code.

Denk ook na over verwijderde werknemers. 

