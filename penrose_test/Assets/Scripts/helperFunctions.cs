using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace helperFunctions
{
    public class helperFunctionsClass
    {
        private static float GOLDENRATIO = (1 + Mathf.Sqrt(5))/2; 

        private static float REDTRIANGLEHEIGHT = helperFunctionsClass.heronsFormula(1, 1/GOLDENRATIO, 1);
        private static float BLUETRIANGLEHEIGHT = helperFunctionsClass.heronsFormula(1, GOLDENRATIO, 1);
        
        
        public static float heronsFormula(float a, float b, float c)
        {
            float A = 0.25f * Mathf.Sqrt(4*(a*a)*(b*b) -(((a*a) + (b*b) - (c*c))*((a*a) + (b*b) - (c*c))));

            float height = 2 * (A/b);

            return height;
        }
        
        public static Vector3[] blueToRed(Vector3 pivotVertex)
        {
            Vector3[] translatedVerticies = new Vector3[3];

            translatedVerticies[2] = pivotVertex;

            translatedVerticies[0] = pivotVertex - new Vector3((1/GOLDENRATIO)/2, REDTRIANGLEHEIGHT); 

            translatedVerticies[1] = pivotVertex + new Vector3((1/GOLDENRATIO)/2, - REDTRIANGLEHEIGHT); 

            return translatedVerticies;

        }

        public static Vector3[] redToBlue(Vector3 pivotVertex)
        {
            Vector3[] translatedVerticies = new Vector3[3];

            translatedVerticies[2] = pivotVertex;

            translatedVerticies[0] = pivotVertex - new Vector3(GOLDENRATIO/2, BLUETRIANGLEHEIGHT);

            translatedVerticies[1] = pivotVertex + new Vector3(GOLDENRATIO/2,  -BLUETRIANGLEHEIGHT);

            return translatedVerticies;
        }
    }
}