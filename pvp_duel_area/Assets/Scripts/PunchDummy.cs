using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PunchDummy : MonoBehaviour
{

    public KeyCode punchKey = KeyCode.Mouse0;
    public float punchRange;

    public Transform orientation;

    [Header("Game Data")]
    public GameObject gameManager;
    public Camera cam;

    [Header("Sword Data")]
    public GameObject sword;
    public float cooldown = 0.5f;

    //raycast variables
    Ray ray;
    RaycastHit hit;

    bool isAttacking;

    private void Start()
    {
        isAttacking = false;
    }

    void Update()
    {
        //if punching, send a raycast out. if it hits something within a range,
        //return to gamemanager

        ray = cam.ScreenPointToRay(Input.mousePosition);

        /*
        if (sword.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            isAttacking = false;
        }
        */

        if (Input.GetKeyDown(punchKey))
        {

            if (!isAttacking)
            {
                isAttacking = true;
                StartCoroutine(SwordAttack());
            }
        }
    }

    IEnumerator SwordAttack()
    {
        //do animations
        sword.GetComponent<Animator>().SetTrigger("swingSword");

        //wait for animation
        yield return new WaitForSeconds(0.17f);

        //do this after each animation
        if (Physics.Raycast(ray, out hit, punchRange))
        {

            DummyTest dt;
            if (hit.transform.gameObject.TryGetComponent<DummyTest>(out dt))
            {
                dt.attacked(1);
            }
        }

        if (cooldown < 1f - 0.17f)
        {
            cooldown = 1f - 0.17f;
        }

        yield return new WaitForSeconds(cooldown);

        isAttacking = false;
    }
}
