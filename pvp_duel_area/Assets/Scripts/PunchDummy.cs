using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchDummy : MonoBehaviour
{

    public KeyCode punchKey = KeyCode.Mouse0;


    [Header("Sword Data")]
    public GameObject sword;
    public float cooldown = 0.5f;

    bool isAttacking;

    private void Start()
    {
        isAttacking = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(punchKey))
        {

            if (!isAttacking)
            {
                isAttacking = true;
                //call sword attack function
                SwordAttack sattck;
                if(sword.TryGetComponent<SwordAttack>(out sattck))
                {
                    sattck.attack();
                    StartCoroutine(cool());
                }
                
            }
        }
    }

    IEnumerator cool()
    {
        yield return new WaitForSeconds(cooldown);
        isAttacking = false;
    }
}
