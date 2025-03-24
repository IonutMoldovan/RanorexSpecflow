RanorexSpecflow
this is a ranorex specflow project which runs some tests versus the windows desktop calculator app

in order to run the automated tests you would need to run them using command prompt ( or it may work also inside a visual studio)

in command prompt use this command to run but replace the path with youre path NUnit.ConsoleRunner.3.15.2\nunit3-console.exe "C:\Users\40772\Documents\Ranorex\RanorexStudio Projects\CalculatorMinus\CalculatorMinus\bin\Debug\CalculatorMinus.dll"

after you run the automated test you will get a TestResult.xml , this result can be converted online into a html report.

see the stepDefinitions implementation here : https://github.com/IonutMoldovan/RanorexSpecflow/blob/master/CalculatorMinus/StepDefinitionCalculatorExer.cs
feature file here :  https://github.com/IonutMoldovan/RanorexSpecflow/blob/master/CalculatorMinus/CalculatorExer.feature

