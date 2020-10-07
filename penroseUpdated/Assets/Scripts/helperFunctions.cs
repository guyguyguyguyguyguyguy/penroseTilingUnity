using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace helperFunctions
{
    public class helperFunctionsClass
    {
        public static readonly float GOLDENRATIO = (1 + Mathf.Sqrt(5))/2; 

        public static float redBase = 1/(GOLDENRATIO * GOLDENRATIO * GOLDENRATIO * GOLDENRATIO);
        public static float redSides = GOLDENRATIO/ (GOLDENRATIO * GOLDENRATIO * GOLDENRATIO * GOLDENRATIO);
        public static float redHieght = helperFunctionsClass.heronsFormula(redSides, redBase, redSides);

        public static float blueBase = (GOLDENRATIO * GOLDENRATIO)/ (GOLDENRATIO * GOLDENRATIO * GOLDENRATIO * GOLDENRATIO);
        public static float blueSides = GOLDENRATIO/ (GOLDENRATIO * GOLDENRATIO * GOLDENRATIO * GOLDENRATIO);
        public static float blueHeight = helperFunctionsClass.heronsFormula(blueSides, blueBase, blueSides);

        
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
            translatedVerticies[0] = pivotVertex - new Vector3(redBase/2, redHieght); 
            translatedVerticies[1] = pivotVertex + new Vector3(redBase/2, - redHieght); 

            return translatedVerticies;

        }

        public static Vector3[] redToBlue(Vector3 pivotVertex)
        {
            Vector3[] translatedVerticies = new Vector3[3];
            translatedVerticies[2] = pivotVertex;
            translatedVerticies[0] = pivotVertex - new Vector3(blueBase/2, blueHeight);
            translatedVerticies[1] = pivotVertex + new Vector3(blueBase/2,  - blueHeight);

            return translatedVerticies;
        }

        public static void addToArray<T>(ref T[] vec, T[] addingVec)
        {   
            // Debug.Log("I am in addToArray, helperfuncclass");
            // Debug.Log(vec);
            // Debug.Log(addingVec);

            if(vec is null)
            {
                vec = addingVec;
            }

            else
            {
                var newVec = new T[vec.Length + addingVec.Length];
                vec.CopyTo(newVec, 0);
                addingVec.CopyTo(newVec, vec.Length);
                vec = newVec;
            }
        }

        public static Vector3 rotatedVector(Vector3 pivot, Vector3 originalVec, float angle)
        {   
            angle = angle * (Mathf.PI/180);

            float x = originalVec[0];
            float y = originalVec[1];

            float pivotx = pivot[0];
            float pivoty = pivot[1];

            float newx = (x - pivotx) * Mathf.Cos(angle) - (y - pivoty) * Mathf.Sin(angle) + pivotx;
            float newy = (y - pivoty) * Mathf.Cos(angle) + (x - pivotx) * Mathf.Sin(angle) + pivoty;


            return new Vector3(newx, newy, -10f);
        }   

    }
}