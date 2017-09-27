using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Equ
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
            Boolean keywordCheck = false;
            Boolean checkEquals = false;

            #region ARGS INPUT SECTION
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "calc")
                {
                    keywordCheck = true;
                }
                if (keywordCheck == true)
                {
                    if (args[i] == "=")     //check for =
                    {
                        checkEquals = true;
                    }                    
                    if (checkEquals == false)       //LEFT SIDE
                    {
                        if (Checks.OperatorConfirmation(args[i]) == true)  //OPERATORS
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
                        else if (Checks.OperantsConfirmation(args[i]) == true)     //OPERANTS
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
                        if (Checks.OperatorConfirmation(args[i]) == true)  //OPERATORS
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
                        else if (Checks.OperantsConfirmation(args[i]) == true) //OPERANTS
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
                else
                {
                    Console.WriteLine("Please enter valid equation.");
                    break;
                }
            }
            #endregion

            if (checkEquals == false)
            {
                Console.WriteLine("Please enter valid equation.");
            }
            else if (checkEquals == true)
            {
                Calculations.rightEquationCalculations(ref rightEquation, ref rightOperators);
                
                string answer = string.Join("", rightEquation); //ANSWER OUTPUT              
                Console.WriteLine("X = " + answer);

            }
        }                
    }
}