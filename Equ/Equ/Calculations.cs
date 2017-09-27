using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Equ
{
    class Calculations
    {
        public static void rightEquationCalculations(ref string[] rightEquation, ref string[] rightOperators)
        {
            foreach (string s in rightOperators)
            {
                Int64 equationResult = 0;
                string value1, value2;
                string tempString = string.Join("", rightEquation);
                Match matchDivision = Regex.Match(tempString, @"(\d+)\/(\d+)"); // /
                Match matchMultiplication = Regex.Match(tempString, @"(\d+)\*(\d+)");  // *
                Match matchAddition = Regex.Match(tempString, @"(\d+)\+(\d+)"); // +
                Match matchSubtraction = Regex.Match(tempString, @"(\d+)\-(\d+)");  // -
                Match matchDoubleAddition = Regex.Match(tempString, @"(\d+)\-\-(\d+)"); // - -
                Match matchDoubleSubtraction = Regex.Match(tempString, @"(\d+)\+\+(\d+)");  // + +

                if (matchDivision.Success == true)
                {
                    value1 = matchDivision.Groups[1].Value;
                    value2 = matchDivision.Groups[2].Value;
                    try
                    {
                        int counter = 0;
                        if (rightEquation[counter] == "-" + value1)
                        {
                            equationResult = ((Convert.ToInt64(value1)) * -1) / Convert.ToInt64(value2);
                        }
                        else
                        {
                            equationResult = Convert.ToInt64(value1) / Convert.ToInt64(value2);
                        }
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }   //finds the index of the current MATCH [NUMBER > OPERATOR > NUMBER]                    
                    int indexOperator = Array.IndexOf(rightEquation, "/");
                    int indexNum1 = indexOperator - 1;
                    int indexNum2 = indexOperator + 1;
                    //sets new values for equation
                    rightEquation.SetValue(equationResult.ToString(), indexNum1);
                    rightEquation.SetValue("", indexOperator);
                    rightEquation.SetValue("", indexNum2);

                    Checks.ClearWhiteSpace(ref rightEquation);  //clear whitespaces 
                    continue;
                }
                else if (matchMultiplication.Success == true)
                {
                    value1 = matchMultiplication.Groups[1].Value;
                    value2 = matchMultiplication.Groups[2].Value;
                    int counter = 0;
                    if (rightEquation[counter] == "-" + value1)
                    {
                        equationResult = ((Convert.ToInt64(value1)) * -1) * Convert.ToInt64(value2);
                    }
                    else
                    {
                        equationResult = Convert.ToInt64(value1) * Convert.ToInt64(value2);
                    }   //finds the index of the current MATCH [NUMBER > OPERATOR > NUMBER]                    
                    int indexOperator = Array.IndexOf(rightEquation, "*");
                    int indexNum1 = indexOperator - 1;
                    int indexNum2 = indexOperator + 1;
                    //sets new values for equation
                    rightEquation.SetValue(equationResult.ToString(), indexNum1);
                    rightEquation.SetValue("", indexOperator);
                    rightEquation.SetValue("", indexNum2);

                    Checks.ClearWhiteSpace(ref rightEquation);     //clear whitespaces 
                    continue;
                }
                else if (matchSubtraction.Success == true)
                {
                    value1 = matchSubtraction.Groups[1].Value;
                    value2 = matchSubtraction.Groups[2].Value;
                    int counter = 0;
                    if (rightEquation[counter] == "-" + value1)
                    {
                        equationResult = ((Convert.ToInt64(value1)) * -1) - Convert.ToInt64(value2);
                    }
                    else
                    {
                        equationResult = Convert.ToInt64(value1) - Convert.ToInt64(value2);
                    }   //finds the index of the current MATCH [NUMBER > OPERATOR > NUMBER]                    
                    int indexOperator = Array.IndexOf(rightEquation, "-");
                    int indexNum1 = indexOperator - 1;
                    int indexNum2 = indexOperator + 1;
                    //sets new values for equation
                    rightEquation.SetValue(equationResult.ToString(), indexNum1);
                    rightEquation.SetValue("", indexOperator);
                    rightEquation.SetValue("", indexNum2);

                    Checks.ClearWhiteSpace(ref rightEquation);     //clear whitespaces
                    continue;
                }
                else if (matchAddition.Success == true)
                {
                    value1 = matchAddition.Groups[1].Value;
                    value2 = matchAddition.Groups[2].Value;
                    int counter = 0;
                    if (rightEquation[counter] == "-" + value1)
                    {
                        equationResult = ((Convert.ToInt64(value1)) * -1) + Convert.ToInt64(value2);
                    }
                    else
                    {
                        equationResult = Convert.ToInt64(value1) + Convert.ToInt64(value2);
                    }   //finds the index of the current MATCH [NUMBER > OPERATOR > NUMBER]                    
                    int indexOperator = Array.IndexOf(rightEquation, "+");
                    int indexNum1 = indexOperator - 1;
                    int indexNum2 = indexOperator + 1;
                    //sets new values for equation
                    rightEquation.SetValue(equationResult.ToString(), indexNum1);
                    rightEquation.SetValue("", indexOperator);
                    rightEquation.SetValue("", indexNum2);

                    Checks.ClearWhiteSpace(ref rightEquation);     //clear whitespaces
                    continue;
                }
                else if (matchDoubleSubtraction.Success == true)
                {
                    value1 = matchDoubleSubtraction.Groups[1].Value;
                    value2 = matchDoubleSubtraction.Groups[2].Value;
                    int counter = 0;
                    if (rightEquation[counter] == "-" + value1)
                    {
                        equationResult = ((Convert.ToInt64(value1)) * -1) - Convert.ToInt64(value2);
                    }
                    else
                    {
                        equationResult = Convert.ToInt64(value1) - Convert.ToInt64(value2);
                    }
                    int indexOperator2 = 0;
                    for (int j = 0; j < rightEquation.Length; j++)
                    {
                        if (rightEquation[j] == "+")
                        {
                            indexOperator2++;
                        }
                    }
                    int indexNum1 = indexOperator2 - 2;
                    int indexOperator1 = indexOperator2 - 1;
                    int indexNum2 = indexOperator2 + 1;
                    //sets new values for equation
                    rightEquation.SetValue(equationResult.ToString(), indexNum1);
                    rightEquation.SetValue("", indexOperator2);
                    rightEquation.SetValue("", indexOperator1);
                    rightEquation.SetValue("", indexNum2);

                    Checks.ClearWhiteSpace(ref rightEquation);     //clear whitespaces    
                    continue;
                }
                else if (matchDoubleAddition.Success == true)
                {
                    value1 = matchDoubleAddition.Groups[1].Value;
                    value2 = matchDoubleAddition.Groups[2].Value;
                    int counter = 0;
                    if (rightEquation[counter] == "-" + value1)
                    {
                        equationResult = ((Convert.ToInt64(value1)) * -1) + Convert.ToInt64(value2);
                    }
                    else
                    {
                        equationResult = Convert.ToInt64(value1) + Convert.ToInt64(value2);
                    }
                    int indexOperator2 = 0;
                    for (int j = 0; j < rightEquation.Length; j++)
                    {
                        if (rightEquation[j] == "-")
                        {
                            indexOperator2++;
                            break;
                        }
                    }
                    int indexNum1 = indexOperator2 - 2;
                    int indexOperator1 = indexOperator2 - 1;
                    int indexNum2 = indexOperator2 + 1;
                    //sets new values for equation
                    rightEquation.SetValue(equationResult.ToString(), indexNum1);
                    rightEquation.SetValue("", indexOperator2);
                    rightEquation.SetValue("", indexOperator1);
                    rightEquation.SetValue("", indexNum2);

                    Checks.ClearWhiteSpace(ref rightEquation);     //clear whitespaces 
                    continue;
                }
            }
        }
    }
}
