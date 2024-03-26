using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    //store sensytivity of camera
    public float sensX;
    public float sensY;

    //transform to store orientation of player
    public Transform orientation;

    //x & y rotation of camera
    float xRotation;
    float yRotation;

    private void Start()
    {
        //lock cursor to middle of screen and invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        //allow look up and down 90 deg
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate came and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
