using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PunchDummy : MonoBehaviour
{

    public KeyCode punchKey = KeyCode.Mouse0;
    public float punchRange;

    public Transform orientation;
    
    public GameObject gameManager;
    public Camera cam;

    //raycast variables
    Ray ray;
    RaycastHit hit;

    void Update()
    {
        //if punching, send a raycast out. if it hits something within a range,
        //return to gamemanager

        ray = cam.ScreenPointToRay(Input.mousePosition);

        if(Input.GetKeyDown(punchKey))
        {
            if(Physics.Raycast(ray, out hit, punchRange))
            {

                DummyTest dt;
                if(hit.transform.gameObject.TryGetComponent<DummyTest>(out  dt))
                {
                    dt.attacked(1);
                }
            }
        }
    }
}
