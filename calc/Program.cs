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

            
            //Convert values in leftOpterators from string to int for calculation.
            int leftOperators_Result = 0;
            for (int i = 0; i < leftOperators.Length; i++)
            {
                leftOperators_Result += Convert.ToInt32(leftOperants[i]);
            }
            // -=
            // *=
            // /=
            //put it all througth a if or case statement dependig on the operator?




            //Test data
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
            Boolean numberCheck = int.TryParse(value, out result);
            if(value == "X")
            {
                numberCheck = true;
            }
            return numberCheck;
        }     
    }
}
