using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc
{
    class Program
    {
        static void Main(string[] args)
        {         
            //Initalise values for dividing up the equation
            string[] leftOperators = new string[args.Length];
            string[] leftOperants = new string[args.Length];
            string[] rightOperators = new string[args.Length];
            string[] rightOperants = new string[args.Length];
            string[] equalsSign = new string[args.Length];
            Boolean checkEquals = false;

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
                            if (leftOperators[input] == null)
                            {
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
                            if (leftOperants[input] == null)
                            {
                                leftOperants[input] = args[i];
                                completed = true;
                            }
                            input++;
                        }
                    }
                }
                else if (checkEquals == true)       //RIGHT SIDE
                {
                    if (args[i] == "=")     //store the = sign in variable
                    {
                        int input = 0;
                        equalsSign[input] = args[i];
                    }
                    if (operatorConfirmation(args[i]) == true)     //+-*/%^2
                    {
                        Boolean completed = false;
                        int input = 0;
                        while (completed == false)
                        {
                            if (rightOperators[input] == null)
                            {
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
                            if (rightOperants[input] == null)
                            {
                                rightOperants[input] = args[i];
                                completed = true;
                            }
                            input++;
                        }
                    }
                }
            }
            equationCalculations(/*leftOperators, leftOperants,*/ rightOperators, rightOperants);      //check which side of '=' contains 'X'         
            #region TEST DATA
            Console.WriteLine("Left Operators:");
            checkArray(leftOperators);
            Console.WriteLine("Left Operants:");
            checkArray(leftOperants);
            Console.WriteLine("Right Operators:");
            checkArray(rightOperators);
            Console.WriteLine("Right Operants:");
            checkArray(rightOperants);
            Console.WriteLine("Equals:");
            checkArray(equalsSign);
            #endregion
        }

        static void equationCalculations(/*string[] leftOperators, string[] leftOperants,*/ string[] rightOperators, string[] rightOperants)
        {   //EG (test data): "X = 5 + 22 * 3

            //maybe do something to find the amount of values in the equation on right side, because number > op > number > op > number..
            //change the first value will be a negative number eg: X = -6 + 3

            int equation_Result = 0;
            for (int i = 0; i < rightOperators.Length; i++)
            {
                if (rightOperators[i] == "+")
                {                    
                    for (int j = 0; j < rightOperants.Length; j++)
                    {
                        equation_Result += Convert.ToInt32(rightOperants[j]);
                    }
                }
                else if (rightOperators[i] == "-")
                {
                    for (int j = 0; j < rightOperants.Length; j++)
                    {
                        //equation_Result += Convert.ToInt32(rightOperants[j]);
                        //equation_Result = Convert.ToInt32(rightOperants[0]) - Convert.ToInt32(rightOperants[1]);
                    }
                }
            }
            Console.WriteLine("Result: X = " + equation_Result);
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
    }
}
