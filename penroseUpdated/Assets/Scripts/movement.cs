using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;

public class movement : MonoBehaviour
{
    private static float speed = 2f;


    void Start()
    {

    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Camera.main.orthographicSize *= helperFunctionsClass.GOLDENRATIO;
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0,-speed * Time.deltaTime,0));
        }
        
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0,speed * Time.deltaTime,0));
        }
    }
}
