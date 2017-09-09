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
                if (checkEquals == false)
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
                else if (checkEquals == true)
                {
                    if (args[i] == "=")     //store the = sign in variable
                    {
                        int input = 0;
                        equalsSign[input] = args[i];
                    }
                    if (operatorConfirmation(args[i]) == true)     //+-*/%^2
                    {
                        //int input = 0;
                        //rightOperators[input] = args[i];
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
                        //int input = 0;
                        //rightOperants[input] = args[i];
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
        {       //taking equations with X on left of = sign, by itself
            //EG (test data): "X = 5 + 22 * 3
            for (int i = 0; i < rightOperators.Length; i++)
            {
                if (rightOperators[i] == "*")
                {
                    int rightOperants_Result = 0;
                    for (int j = 0; j < rightOperators.Length; j++)
                    {
                        rightOperants_Result -= Convert.ToInt32(rightOperators[j]);
                    }
                    for (int j = 0; j < rightOperators.Length; j++)
                    {
                        rightOperants_Result -= Convert.ToInt32(rightOperants[j]);
                    }

                }
                else if (rightOperators[i] == "-")
                {

                }
                else if (rightOperators[i] == "+")
                {

                }
                else if (rightOperators[i] == "/")
                {

                }
            }
        }

        static void leftOperantCalc(string[] array)
        {

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
