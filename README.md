Documentatie voor eerste run
1. Stel connectionstring in voor de database (appsettings.development.json)
2. Wanneer je de applicatie start wordt er een nieuwe database aangemaakt.
3. Installeer de volgende tool voor Visual Studio gebruikers
   https://marketplace.visualstudio.com/items?itemName=FortuneNgwenya.FineCodeCoverage
4. Installeer de volgende tools voor VSCode gebruikers
   - Coverage Gutters
     - Pas de configuratie aan: 
       "dotnet-test-explorer.testArguments": "/p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./lcov.info",
   - .NET Core Test Explorer

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
