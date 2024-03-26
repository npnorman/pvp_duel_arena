using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    bool isAttacking = true;
    LayerMask punchable;
    public int damage = 1;
    public float cooldown = 1f;

    private void Start()
    {
        punchable = LayerMask.NameToLayer("punchable");
    }

    private void OnTriggerEnter(Collider other)
    {

        if (isAttacking)
        {
            if(other.gameObject.layer == punchable)
            {
                //do attack on chickens

                Debug.Log(other.gameObject.name);

                DummyTest dt;
                if (other.TryGetComponent<DummyTest>(out dt))
                {
                    //Get dummy test
                    //do attack
                    dt.attacked(damage);
                }
            }
        }
    }

    public bool attack()
    {
        //do animations
        StartCoroutine(Attacking());

        return false;
    }

    IEnumerator Attacking()
    {
        this.GetComponent<Animator>().SetTrigger("swingSword");
        isAttacking = true;

        yield return new WaitForSeconds(cooldown);

        isAttacking = false;
    }
}
