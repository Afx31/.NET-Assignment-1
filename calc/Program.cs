﻿using System;
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

            #region ARGS INPUT TEST DATA            
            Console.WriteLine("Left Equation: ");
            checkArray(leftEquation);
            Console.WriteLine("Right Equation:");
            checkArray(rightEquation);
            Console.WriteLine("Equals:");
            checkArray(equalsSign);
            #endregion
        }

        static void rightEquationCalculations(string[] rightEquation, string[] rightOperators)
        {       //test data - X = 5 + 5 * 6            
            for (int i = 0; i < rightOperators.Length; i++)
            {
                //Console.WriteLine("arg ops " + i + " = " + rightOperators[i]);
                if (rightOperators[i] == "*")
                {
                    for (int j = rightEquation.Length; j > 0; j--)
                    {
                        string tempString = string.Join("", rightEquation);
                        Match m = Regex.Match(tempString, @"(\d+)\*(\d+)");
                        string value1 = m.Groups[1].Value;
                        string value2 = m.Groups[2].Value;
                        //Console.WriteLine("a: " + value1);
                        //Console.WriteLine("b: " + value2);
                    }
                }
                else if (rightOperators[i] == "+")
                {
                    string tempString = string.Join("", rightEquation);
                    Match m = Regex.Match(tempString, @"(\d+)\+(\d+)");
                    string value1 = m.Groups[1].Value;
                    string value2 = m.Groups[2].Value;
                }
                else if (rightOperators[i] == "-")
                {
                    string tempString = string.Join("", rightEquation);
                    Match m = Regex.Match(tempString, @"(\d+)\-(\d+)");
                    string value1 = m.Groups[1].Value;
                    string value2 = m.Groups[2].Value;
                }
            }
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
