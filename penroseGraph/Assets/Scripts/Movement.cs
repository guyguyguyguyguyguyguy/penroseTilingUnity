using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelperFunctions;

public class Movement : MonoBehaviour
{
    private float speed = 0.44f;


    void Start()
    {

    }


    void Update()
    {
        Camera.main.orthographicSize -= Input.mouseScrollDelta.y * 0.23f;
        speed -= Input.mouseScrollDelta.y * 0.23f;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Camera.main.orthographicSize *= HelperFunctionsClass.GOLDENRATIO;
            speed *= HelperFunctionsClass.GOLDENRATIO;
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
