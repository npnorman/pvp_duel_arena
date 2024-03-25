using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PunchDummy : MonoBehaviour
{

    public KeyCode punchKey = KeyCode.Mouse0;
    public float punchRange;
    public GameObject gameManager;
    public LayerMask punchable;
    bool hasHit = false;

    private void Start()
    {
        hasHit = false;
    }

    void Update()
    {
        //if punching, send a raycast out. if it hits something within a range,
        //return to gamemanager

        if(Input.GetKey(punchKey))
        {
            Debug.Log("pucnhed");
            //Ray ray = Physics.Raycast(transform.position, Vector3.forward, punchRange, punchable);
        }
    }
}
