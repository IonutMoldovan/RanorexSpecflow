/*
 * Created by Ranorex
 * User: 40772
 * Date: 22.03.2025
 * Time: 17:42
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using TechTalk.SpecFlow;
using System.Diagnostics;
using Ranorex;
using Ranorex.Core.Testing;
using System.IO;

namespace CalculatorMinus
{
    [Binding]
    public class StepDefinitionCalculatorExer
    {
        private readonly ScenarioContext _scenarioContext;
        // Repository for Calculator elements
        private readonly CalculatorRepository _repo = CalculatorRepository.Instance; 


        public StepDefinitionCalculatorExer(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        
        [Given("I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredNumberIntoTheCalculator(int number)
        {
        	try
            {
                // Enter each digit of the number into the calculator
                foreach (char digit in number.ToString())
                {
                    string buttonId = $"num{digit}Button"; // Determine button ID for the digit
                    _repo.Button(buttonId).Click(); // Click the corresponding button
                    Console.WriteLine($"Clicked button: {digit}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error entering number '{number}': {ex.Message}");
                throw;
            }
        }
        
        [Given("I open the Windows calculator app")]
        public void WhenIOpenWindowsCalculatorApp()
        {
        	OpenApp();
        }
        
        [Then("I close the Windows calculator app")]
        public void ThenICloseWindowsCalculatorApp()
        {
        	CloseApp();
        }      
		
        [When("I press (.*)")]
        public void WhenIPressAdd(string operation)
        {
        	string operatorButtonId;
            try
            {
                 switch (operation.ToLower())
    			{
       			 case "add":
          		 	 operatorButtonId = "plusButton";
         		   break;

        		case "subtract":
          			  operatorButtonId = "minusButton";
         		   break;

       			 case "multiply":
         		   operatorButtonId = "multiplyButton";
          		  break;

       			 case "divide":
         		   operatorButtonId = "divideButton";
          		  break;

       			 default:
         			   throw new InvalidOperationException($"Unsupported operation: {operation}");
   				 }

                _repo.Button(operatorButtonId).Click();
                Console.WriteLine($"Clicked operator button: {operation}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error performing operation '{operation}': {ex.Message}");
                throw;
            }
    
        }
        
        [When("I hit the equals button")]
        public void WhenIhitTheEqualsButton()
        {
            try
            {
                _repo.Button("equalButton").Click(); // Click equals button
                Console.WriteLine($"Clicked '=' button.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to press equals button: {ex.Message}");
                throw;
            }
        }

        [Then("the result should be (.*) on the screen")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            try
            {
                // Validate the displayed result
                string rawResult = _repo.Result.TextValue; // Retrieve the displayed text
                string actualResult = rawResult.Replace("Display is", "").Trim(); // Clean up the result text

                if (actualResult == expectedResult.ToString())
                {
                	Console.WriteLine($"Result validation passed. Expected: {expectedResult}, Actual: {actualResult}");
                }
                else
                {
                    throw new Exception($"Validation failed. Expected: {expectedResult}, Actual: {actualResult}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error validating calculator result: {ex.Message}");
                throw;
            }
        }
        
        
        void OpenApp()
		{
			try{
        		Host.Local.RunApplication(Path.Combine(Directory.GetCurrentDirectory(),"calc.exe"));
				Console.WriteLine("calc has been open.");
			}
			catch (Exception ex){
				Console.WriteLine($"Failed to open calc.{ex.Message}");
			}
		}
		
        void CloseApp(){
        	// var recording = new CloseCalcualtorAppRecording();
        	TestModuleRunner.Run(new CloseCalcualtorAppRecording());
        	Console.WriteLine("Windows Calculator app has been closed");
        }
    }
}
