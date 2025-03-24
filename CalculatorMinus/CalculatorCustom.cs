/*
 * Created by Ranorex
 * User: 40772
 * Date: 23.03.2025
 * Time: 21:52
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using Ranorex;

namespace CalculatorMinus // Match the namespace of the auto-generated code
{
    public partial class CalculatorRepository // Ensure this matches the auto-generated class name
    {
        // Example: Define a dynamic button locator
        public Button Button(string automationId)
        {
            return Host.Local.FindSingle<Button>($"/form[@title~'^Calculator$']//button[@automationid='{automationId}']");
        }

        // Example: Add result field locator
        public Text Result
        {
            get
            {
                return Host.Local.FindSingle<Text>("/form[@title~'^Calculator$']//text[@automationid='CalculatorResults']");
            }
        }
    }
}