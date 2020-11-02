using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace forcedTiles 
{
    public class P3ForcedTiles 
    {

        public static string legalTilesAtEdge(int edgeNo, tile t)
        {
            if (t.name == "thickRhomb")
            {
                
                switch (edgeNo)
                {
                    case 1:

                        if (t.neighbours[1] is  tile && t.neighbours[1].name == "thickRhomb")
                        {
                            return "red";
                        }

                        else if (t.neighbours[3] is  tile && t.neighbours[3].name == "thickRhomb")
                        {
                            return "red or blue";
                        }

                        else if (t.neighbours[1] is  tile && t.neighbours[1].name == "thinRhomb")
                        {
                            return "blue";
                        }

                        else if (t.neighbours[3] is  tile && t.neighbours[3].name == "thinRhomb")
                        {
                            return "red or blue";
                        }

                        break;


                    case 2:

                        if (t.neighbours[0] is  tile && t.neighbours[0].name == "thickRhomb")
                        {
                            return "red";
                        }

                        else if (t.neighbours[2] is  tile && t.neighbours[2].name == "thickRhomb")
                        {
                            return "red or blue";
                        }

                        else if (t.neighbours[0] is  tile && t.neighbours[0].name == "thinRhomb")
                        {
                            return "blue";
                        }

                        else if (t.neighbours[2] is  tile && t.neighbours[2].name == "thinRhomb")
                        {
                            return "red or blue";
                        }

                        break;      


                    case 3:

                        if (t.neighbours[1] is  tile && t.neighbours[1].name == "thickRhomb")
                        {
                            return "red or blue";
                        }

                        else if (t.neighbours[3] is  tile && t.neighbours[3].name == "thickRhomb")
                        {
                            return "red";
                        }

                        else if (t.neighbours[1] is  tile && t.neighbours[1].name == "thinRhomb")
                        {
                            return "red or blue";
                        }

                        else if (t.neighbours[3] is  tile && t.neighbours[3].name == "thinRhomb")
                        {
                            return "blue";
                        }

                        break;     


                    case 4:

                        Debug.Log("case 4");
                        // Debug.Log(t.neighbours[2] is tile);

                        if (t.neighbours[0] is  tile && t.neighbours[0].name == "thickRhomb")
                        {
                            return "red or blue";
                        }

                        else if (t.neighbours[2] is  tile && t.neighbours[2].name == "thickRhomb")
                        {
                            Debug.Log("I am in the place I need");

                            return "red";
                        }

                        else if (t.neighbours[0] is  tile && t.neighbours[0].name == "thinRhomb")
                        {
                            return "red or blue";
                        }

                        else if (t.neighbours[2] is  tile && t.neighbours[2].name == "thinRhomb")
                        {
                            return "blue";
                        }

                        break;               

                }
            }       


            else if (t.name == "thinRhomb")
            {
                
                switch (edgeNo)
                {
                    case 1:

                        if (t.neighbours[1] is  tile && t.neighbours[1].name == "thickRhomb")
                        {
                            return "red or blue";
                        }

                        else if (t.neighbours[3] is  tile && t.neighbours[3].name == "thickRhomb")
                        {
                            return "red or blue";
                        }

                        else if (t.neighbours[1] is  tile && t.neighbours[1].name == "thinRhomb")
                        {
                            return "Illegal";
                        }

                        else if (t.neighbours[3] is  tile && t.neighbours[3].name == "thinRhomb")
                        {
                            return "blue";
                        }

                        break;


                    case 2:

                        if (t.neighbours[0] is  tile && t.neighbours[0].name == "thickRhomb")
                        {
                            return "blue";
                        }

                        else if (t.neighbours[2] is  tile && t.neighbours[2].name == "thickRhomb")
                        {
                            return "blue";
                        }

                        else if (t.neighbours[0] is  tile && t.neighbours[0].name == "thinRhomb")
                        {
                            return "blue";
                        }

                        else if (t.neighbours[2] is  tile && t.neighbours[2].name == "thinRhomb")
                        {
                            return "Illegal";
                        }

                        break;      


                    case 3:

                        if (t.neighbours[1] is  tile && t.neighbours[1].name == "thickRhomb")
                        {
                            return "blue";
                        }

                        else if (t.neighbours[3] is  tile && t.neighbours[3].name == "thickRhomb")
                        {
                            return "blue";
                        }

                        else if (t.neighbours[1] is  tile && t.neighbours[1].name == "thinRhomb")
                        {
                            return "Illegal";
                        }

                        else if (t.neighbours[3] is  tile && t.neighbours[3].name == "thinRhomb")
                        {
                            return "blue";
                        }

                        break;     


                    case 4:

                        if (t.neighbours[0] is  tile && t.neighbours[0].name == "thickRhomb")
                        {
                            return "red or blue";
                        }

                        else if (t.neighbours[0] is  tile && t.neighbours[2].name == "thickRhomb")
                        {
                            return "red or blue";
                        }

                        else if (t.neighbours[0] is  tile && t.neighbours[0].name == "thinRhomb")
                        {
                            return "blue";
                        }

                        else if (t.neighbours[2] is  tile && t.neighbours[2].name == "thinRhomb")
                        {
                            return "Illegal";
                        }

                        break;               
                }
            }    

            return "Error";
        }
        
    }
}

