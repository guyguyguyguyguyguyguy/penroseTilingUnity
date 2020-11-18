using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace HelperFunctions
{
    public class HelperFunctionsClass
    {
        public static readonly float GOLDENRATIO = (1 + Mathf.Sqrt(5))/2; 

        public static float redBase = 1/(GOLDENRATIO * GOLDENRATIO * GOLDENRATIO * GOLDENRATIO);
        public static float redSides = GOLDENRATIO/ (GOLDENRATIO * GOLDENRATIO * GOLDENRATIO * GOLDENRATIO);
        public static float redHeight = HeronsFormula(redSides, redBase, redSides);

        public static float blueBase = (GOLDENRATIO * GOLDENRATIO)/ (GOLDENRATIO * GOLDENRATIO * GOLDENRATIO * GOLDENRATIO);
        public static float blueSides = GOLDENRATIO/ (GOLDENRATIO * GOLDENRATIO * GOLDENRATIO * GOLDENRATIO);
        public static float blueHeight = HeronsFormula(blueSides, blueBase, blueSides);

        
        public static float HeronsFormula(float a, float b, float c)
        {
            float A = 0.25f * Mathf.Sqrt(4*(a*a)*(b*b) -(((a*a) + (b*b) - (c*c))*((a*a) + (b*b) - (c*c))));
            float height = 2 * (A/b);

            return height;
        }

        
        public static Vector3[] BlueToRed(Vector3 pivotVertex)
        {
            Vector3[] translatedVerticies = new Vector3[3];
            translatedVerticies[2] = pivotVertex;
            translatedVerticies[0] = pivotVertex - new Vector3(redBase/2, redHeight); 
            translatedVerticies[1] = pivotVertex + new Vector3(redBase/2, - redHeight); 

            return translatedVerticies;

        }


        public static Vector3[] RedToBlue(Vector3 pivotVertex)
        {
            Vector3[] translatedVerticies = new Vector3[3];
            translatedVerticies[2] = pivotVertex;
            translatedVerticies[0] = pivotVertex - new Vector3(blueBase/2, blueHeight);
            translatedVerticies[1] = pivotVertex + new Vector3(blueBase/2,  - blueHeight);

            return translatedVerticies;
        }


        public static Vector3[] ThinToThick(Vector3 pivotVertex)
        {
            Vector3[] translatedVerticies = new Vector3[4];

            translatedVerticies[3] = pivotVertex;
            translatedVerticies[0] = pivotVertex + new Vector3( -05f * redBase, redHeight );
            translatedVerticies[1] = pivotVertex + new Vector3( 05f * redBase, redHeight );
            translatedVerticies[2] = pivotVertex + new Vector3( 0, 2f * redHeight );

            return translatedVerticies;
        }


        public static Vector3[] ThickToThin(Vector3 pivotVertex)
        {
            Vector3[] translatedVerticies = new Vector3[4];

            translatedVerticies[0] = pivotVertex;
            translatedVerticies[1] = pivotVertex + new Vector3( 0, blueBase );
            translatedVerticies[2] = pivotVertex + new Vector3( -blueHeight, 0.5f * blueBase );
            translatedVerticies[3] = pivotVertex + new Vector3( blueHeight, 0.5f * blueBase );

            return translatedVerticies;
        }


        public static void AddToArray<T>(ref T[] vec, T[] addingVec)
        {   
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


        public static Vector3 RotatedVector(Vector3 pivot, Vector3 originalVec, float angle)
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


        public static System.Tuple<float, float> BoundedBoxFunc(float hypotenuse, float angle)
        {

            float height = Mathf.Sin(angle * (Mathf.PI/180)) * hypotenuse;
            float width = Mathf.Cos(angle * (Mathf.PI/180)) * hypotenuse;

            return new System.Tuple<float, float>(height, width);
        }


        public static Vector3 EdgeCentre(Vector3[] edge)
        {
            Vector2 centre = new Vector3();
            
            foreach(Vector3 ver in edge)
            {
                Vector2 noZVer = new Vector2 (ver[0], ver[1]);
                centre += noZVer;
            }

            return centre/2;
        }


        public static Vector3 ThirdVer(Vector3 ver, float angle, float sideLen)
        {   
            float angleRad = angle * (Mathf.PI/ 180);

            float coorX = sideLen * Mathf.Cos(angleRad) + ver[0];
            float coorY = sideLen * Mathf.Sin(angleRad) + ver[1];

            return new Vector3 (coorX, coorY, -10);
        }



        public static Vector3 FourthVer(Vector3 ver1, Vector3 ver2, Vector3 ver3)
        {
            return -ver1 + ver2 + ver3;
        }

        
        public static bool ElementsInArray<T>(T[] array)
        {
            bool noOfElements = true;

            foreach (var x in array)
            {
                if (!(x is T))
                {
                    noOfElements = false;
                }
            }

            return noOfElements;
        }
        
        
        public static bool EqualEdges(Vector3[] e1, Vector3[] e2)
        {
            bool equal = false;

            // Needs to be invariet to order 

            Vector3[] e1Copy = new List<Vector3>(e1).ToArray();
            Vector3[] e2Copy = new List<Vector3>(e2).ToArray();

            for (int p = 0; p < 2; ++p)
            {
                for (int j = 0; j <3; ++j)
                {
                    e1Copy[p][j] = (float)Math.Round(e1Copy[p][j], 1);
                    e2Copy[p][j] = (float)Math.Round(e2Copy[p][j], 1);

                }
            }

            for (int i = 0; i < e1.Length; ++i)
            {
                if (e2Copy.Contains(e1Copy[i]))
                {
                    equal = true;
                }
                else
                {
                    equal = false;
                    return equal;
                }
            }
            
            return equal;
        }


        // Not right as it is important where the number is in the vector3, if it is x, y or z
        // public static bool ScrambledEquals<T>(IEnumerable<T> list1, IEnumerable<T> list2) 
        // {
        //     var cnt = new Dictionary<T, int>();
        //     foreach (T s in list1) 
        //     {
        //         if (cnt.ContainsKey(s)) 
        //         {
        //         cnt[s]++;
        //         } 

        //         else 
        //         {
        //         cnt.Add(s, 1);
        //         }
        //     }
            
        //     foreach (T s in list2) 
        //     {
        //         if (cnt.ContainsKey(s)) 
        //         {
        //         cnt[s]--;
        //         } 
                
        //         else 
        //         {
        //         return false;
        //         }
        //     }

        //     // return cnt.Values.All(c => c == 0);
        //     return true;
        // }

    }

}