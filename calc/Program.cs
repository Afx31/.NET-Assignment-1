using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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

            for(int o = 0; o < rightEquation.Length; o++)
            {
                Console.WriteLine("X = " + rightEquation[o]);
                //break;
            }

            #region ARGS INPUT TEST DATA 
            Console.WriteLine("Left Equation: ");
            checkArray(leftEquation);
            Console.WriteLine("Right Equation:");
            checkArray(rightEquation);
            #endregion
        }

        static void rightEquationCalculations(string[] rightEquation, string[] rightOperators)
        {
            //for (int i = 0; i < rightOperators.Length; i++)
            //if (rightEquation != null)
            foreach (string s in rightOperators)
            {
                Int64 equationResult = 0;
                string value1, value2;
                string tempString = string.Join("", rightEquation);
                Match matchMultiplication = Regex.Match(tempString, @"(\d+)\*(\d+)");
                Match matchAddition = Regex.Match(tempString, @"(\d+)\+(\d+)");
                Match matchSubtraction = Regex.Match(tempString, @"(\d+)\-(\d+)");
                
                if (matchMultiplication.Success == true)
                {
                    value1 = matchMultiplication.Groups[1].Value;
                    value2 = matchMultiplication.Groups[2].Value;
                    equationResult = Convert.ToInt64(value1) * Convert.ToInt64(value2);

                    //finds the index of the current MATCH [NUMBER > OPERATOR > NUMBER]                    
                    int indexOperator = Array.IndexOf(rightEquation, "*");
                    int indexNum1 = indexOperator - 1;
                    int indexNum2 = indexOperator + 1;

                    Console.WriteLine("testing num1:*: " + indexNum1);
                    Console.WriteLine("testing opertaor:*: " + indexOperator);
                    Console.WriteLine("testing num2:*: " + indexNum2);

                    //sets new values for equation
                    rightEquation.SetValue(equationResult.ToString(), indexNum1);
                    rightEquation.SetValue("", indexOperator);
                    rightEquation.SetValue("", indexNum2);
                    //continue;
                } 
                else if (matchSubtraction.Success == true)
                {
                    value1 = matchSubtraction.Groups[1].Value;
                    value2 = matchSubtraction.Groups[2].Value;
                    equationResult = Convert.ToInt64(value1) - Convert.ToInt64(value2);
                    if (equationResult < 0) //removes the - sign from the number
                    {
                        equationResult = equationResult * (-1);
                    }

                    //finds the index of the current MATCH [NUMBER > OPERATOR > NUMBER]                    
                    int indexOperator = Array.IndexOf(rightEquation, "-");
                    int indexNum1 = indexOperator - 1;
                    int indexNum2 = indexOperator + 1;

                    Console.WriteLine("testing num1:-: " + indexNum1);
                    Console.WriteLine("testing opertaor:-: " + indexOperator);
                    Console.WriteLine("testing num2:-: " + indexNum2);

                    //sets new values for equation
                    rightEquation.SetValue("-", indexNum1);
                    rightEquation.SetValue(equationResult.ToString(), indexOperator);
                    rightEquation.SetValue("", indexNum2);
                    //continue;
                }
                else if (matchAddition.Success == true)
                {
                    value1 = matchAddition.Groups[1].Value;
                    value2 = matchAddition.Groups[2].Value;
                    equationResult = Convert.ToInt64(value1) + Convert.ToInt64(value2);

                    //finds the index of the current MATCH [NUMBER > OPERATOR > NUMBER]                    
                    int indexOperator = Array.IndexOf(rightEquation, "+");
                    int indexNum1 = indexOperator - 1;
                    int indexNum2 = indexOperator + 1;

                    Console.WriteLine("testing num1:+: " + indexNum1);
                    Console.WriteLine("testing opertaor:+: " + indexOperator);
                    Console.WriteLine("testing num2:+: " + indexNum2);

                    //sets new values for equation
                    rightEquation.SetValue(equationResult.ToString(), indexNum1);
                    rightEquation.SetValue("", indexOperator);
                    rightEquation.SetValue("", indexNum2);
                    //continue;
                }
            }
        }

        
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


        /*static Boolean parseString(string[] args, out Int64 result)
        {
            result = 0;

            if (args.Length != 1) return false;
            {
                return (Int64.TryParse(args[0], out result) && result > 0);
            }
        }*/
    }
}
