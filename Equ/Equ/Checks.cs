using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Equ
{
    class Checks
    {
        public static Boolean OperatorConfirmation(string tempString)
        {
            switch (tempString)
            {
                case "+": return true;
                case "-": return true;
                case "*": return true;
                case "/": return true;
                default: return false;
            }
        }
        public static Boolean OperantsConfirmation(string tempString)
        {
            Boolean valueCheck = int.TryParse(tempString, out int result);
            if ((tempString == "X") || (tempString == "x"))
            {
                valueCheck = true;
            }
            return valueCheck;
        }
        public static void ClearWhiteSpace(ref string[] tempArray)
        {
            var tempList = new List<string>();
            foreach (var v in tempArray)
            {
                if (!string.IsNullOrWhiteSpace(v))
                {
                    tempList.Add(v);
                }
            }
            tempArray = tempList.ToArray();
        }
    }
}
