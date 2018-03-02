using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectOnPress : MonoBehaviour {

    float f_lastX = 0.0f; //last spin speed x
    float f_lastY = 0.0f; //last spin speed Y
    float f_difX = 0.0f; //current spin speed x
    float f_difY = 0.0f; //current spin speed x
    int i_direction_X = 1; //Rotation direction x
    int i_direction_Y = 1; //Rotation direction y
    
    public bool enable_X; public bool enable_Y;

    public float lerpResetSpeed = 1; //for reset lerp till later
    Transform currentTransform; //for reset lerp till later
    float lerpStartTime = 0f;


    // Update is called once per frame
    void Update () {

        if(enable_X || enable_Y)
        { 
            if (Input.GetMouseButtonDown(0))
            {
                f_difX = 0.0f; //Direction X
                f_difY = 0.0f; //Direction Y
            }

            else if (Input.GetMouseButton(0)) //During buttonpress

            {
                MouseSpin();
            }

            else if (Input.GetMouseButtonUp(0))
            {
                lerpStartTime = Time.time;
            }
            else
            {
                Rotatedown();
            }
        }


    }

    void MouseSpin()
    {
        if (enable_X) {
            //Y rotation
            f_difX = Mathf.Abs(f_lastX - Input.GetAxis("Mouse X"));

            if (f_lastX < Input.GetAxis("Mouse X"))
            {
                i_direction_X = -1;
                transform.Rotate(Vector3.forward, -f_difX);
            }

            if (f_lastX > Input.GetAxis("Mouse X"))
            {
                i_direction_X = 1;
                transform.Rotate(Vector3.forward, f_difX);
            }

            f_lastX = -Input.GetAxis("Mouse X");
        }

        if (enable_Y) {
            //Y rotation
            f_difY = Mathf.Abs(f_lastY - Input.GetAxis("Mouse Y"));

            if (f_lastY < Input.GetAxis("Mouse Y"))
            {
                i_direction_Y = -1;
                transform.Rotate(Vector3.left, -f_difY);
            }

            if (f_lastY > Input.GetAxis("Mouse Y"))
            {
                i_direction_Y = 1;
                transform.Rotate(Vector3.left, f_difY);
            }
            f_lastY = -Input.GetAxis("Mouse Y");
        }
    }

    void Rotatedown ()
    {
        if (enable_X)
        {
            if (f_difX > 0.5f) f_difX -= 0.05f;
            if (f_difX < 0.5f) f_difX -= 0.01f;
            if (f_difX <= 0) f_difX = 0f;

            transform.Rotate(Vector3.forward, f_difX * i_direction_X);
        }

        if (enable_Y)
        {
            if (f_difY > 0.5f) f_difY -= 0.05f;
            if (f_difY < 0.5f) f_difY -= 0.01f;
            if (f_difY <= 0) f_difY = 0f;

            transform.Rotate(Vector3.left, f_difY * i_direction_Y);

            
        }
        if(f_difX < 1f && f_difY < 1f) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z), Time.deltaTime * lerpResetSpeed); //for reset lerp till later

    }
}
