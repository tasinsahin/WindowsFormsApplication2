using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication2.Operation;

namespace WindowsFormsApplication2
{
    class control
    {
        static public bool integerControl(string controlVariable)
        {
            bool isInteger=true;
            char[] controlVariableArray;
            
            controlVariableArray= controlVariable.ToCharArray();

            for (int i = 0; i < controlVariableArray.Length; i++)
            {
                if (48<=controlVariableArray[i] && controlVariableArray[i]<=57)
                {
                    isInteger = true;
                }
                else
                {
                    isInteger = false;
                    break;
                }
            }
            return isInteger;
            
        }
    }
}
