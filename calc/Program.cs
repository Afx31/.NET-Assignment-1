using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;       //Regex Library

namespace calc
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] leftEquation = new string[args.Length];
            string[] leftOperators = new string[args.Length];
            string[] rightEquation = new string[args.Length];
            string[] rightOperators = new string[args.Length];
            string[] equalsSign = new string[args.Length];
            Boolean checkEquals = false;

            #region ARGS INPUT SEPERATION
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "=")     //check for =
                {
                    checkEquals = true;
                }
                if (checkEquals == false)       //LEFT SIDE
                {
                    if (operatorConfirmation(args[i]) == true)      //+-*/%^2
                    {
                        Boolean completed = false;
                        int input = 0;
                        while (completed == false)
                        {
                            if (leftEquation[input] == null)
                            {
                                leftEquation[input] = args[i];
                                leftOperators[input] = args[i];
                                completed = true;
                            }
                            input++;
                        }
                    }
                    else if (operantsConfirmation(args[i]) == true)     //X & Numbers
                    {
                        Boolean completed = false;
                        int input = 0;
                        while (completed == false)
                        {
                            if (leftEquation[input] == null)
                            {
                                leftEquation[input] = args[i];
                                completed = true;
                            }
                            input++;
                        }
                    }
                }
                if (checkEquals == true)       //RIGHT SIDE
                {
                    if (args[i] == "=")
                    {
                        int input = 0;
                        equalsSign[input] = args[i];
                    }
                    if (operatorConfirmation(args[i]) == true)      //+-*/%^2
                    {
                        Boolean completed = false;
                        int input = 0;
                        while (completed == false)
                        {
                            if (rightEquation[input] == null)
                            {
                                rightEquation[input] = args[i];
                                rightOperators[input] = args[i];
                                completed = true;
                            }
                            input++;
                        }
                    }
                    else if (operantsConfirmation(args[i]) == true)     //X & Numbers
                    {
                        Boolean completed = false;
                        int input = 0;
                        while (completed == false)
                        {
                            if (rightEquation[input] == null)
                            {
                                rightEquation[input] = args[i];
                                completed = true;
                            }
                            input++;
                        }
                    }
                }
            }
            #endregion

            rightEquationCalculations(rightEquation, rightOperators);
            Console.WriteLine("new answer = ");
            checkArray(rightEquation);

            #region ARGS INPUT TEST DATA            
            Console.WriteLine("Left Equation: ");
            checkArray(leftEquation);
            Console.WriteLine("Right Equation:");
            checkArray(rightEquation);
            #endregion
        }

        static void rightEquationCalculations(string[] rightEquation, string[] rightOperators)
        {
            int equationResult = 0;
            string tempString = string.Join("", rightEquation);
            Match matchMultiplication = Regex.Match(tempString, @"(\d+)\*(\d+)");  
            Match matchAddition = Regex.Match(tempString, @"(\d+)\+(\d+)");
            Match matchSubtraction = Regex.Match(tempString, @"(\d+)\-(\d+)");

            string testest = matchMultiplication.ToString();
            string[] bs = new string[] { testest };

            for (int i = 0; i < rightOperators.Length; i++)
            {
                string value1;
                string value2;
                if (matchMultiplication.Success == true)
                {
                    value1 = matchMultiplication.Groups[1].Value;
                    value2 = matchMultiplication.Groups[2].Value;
                    equationResult = Convert.ToInt32(value1) * Convert.ToInt32(value2);     //carries out the multiplication, stores in equationResult
                    string[] tempArray = new string[] { equationResult.ToString() };        //converts equationResult into an array

                    //finds the index of the current MATCH [NUMBER > OPERATOR > NUMBER]                    
                    var indexOperator = Array.IndexOf(rightEquation, "*");
                    var indexNum1 = indexOperator - 1;
                    var indexNum2 = indexOperator + 1;

                    //check the MATCH is correct
                    Console.WriteLine("ceeebs: " + indexNum1);
                    Console.WriteLine("ceeebs: " + indexOperator);
                    Console.WriteLine("ceeebs: " + indexNum2);

                    //now remove from ARRAY, after converting to LIST
                    var tempList = rightEquation.ToList();
                    tempList.RemoveAt(indexNum2);
                    tempList.RemoveAt(indexOperator);
                    tempList.RemoveAt(indexNum1);

                    //convert LIST back to ARRAY
                    string[] tempFinalArray = (string[])tempList.ToArray();
                    
                    for (int j = 0; j < rightEquation.Length; j++)
                    {
                        rightEquation[j] = null;
                    }
                    for (int k = 0; k < rightEquation.Length; k++)
                    {
                        rightEquation[k] = tempFinalArray[k];
                    }

                    foreach (var item in rightEquation)
                    {
                        Console.WriteLine("hopefully correct array: " + item);
                    }
                    break;
                }
                else if (matchAddition.Success == true)
                {
                    
                }
                else if (matchSubtraction.Success == true)
                {
                    
                }
            }
             Console.WriteLine("Result = " + equationResult);
        }

        #region ARRAY/OPERATOR/OPERANT CHECKS
        static void checkArray(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("arg " + i + " = " + array[i]);
            }
        }
        static Boolean operatorConfirmation(string value)
        {
            switch (value)
            {
                case "+":
                    return true;
                case "-":
                    return true;
                case "*":
                    return true;
                case "/":
                    return true;
                case "%":
                    return true;
                case "^2":
                    return true;
                default:
                    return false;
            }
        }
        static Boolean operantsConfirmation(string value)
        {
            int result;
            Boolean valueCheck = false;
            if (value == "X" || int.TryParse(value, out result))
            {
                valueCheck = true;
            }
            return valueCheck;
        }
        #endregion
    }
}
