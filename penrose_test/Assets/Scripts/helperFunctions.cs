using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace helperFunctions
{
    public class helperFunctionsClass
    {
        public static float heronsFormula(float a, float b, float c)
        {
            float A = 0.25f * Mathf.Sqrt(4*(a*a)*(b*b) -(((a*a) + (b*b) - (c*c))*((a*a) + (b*b) - (c*c))));

            float height = 2 * (A/b);

            return height;
        }
    }
}