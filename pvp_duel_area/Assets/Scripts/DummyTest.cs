using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DummyTest : MonoBehaviour
{
    Animator animator;

    GameObject player;
    public int health = 10;
    bool isDead;
    public float knockback = 10;
    Vector3 kb;

    private void Start()
    {
        isDead = false;
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void attacked(int attk)
    {
        kb = this.transform.position - player.transform.position;
        kb = kb.normalized;

        kb = new Vector3(kb.x, 0, kb.z);

        health -= attk;

        if (health > 0)
        {
            animator.SetTrigger("isPunched");

            //knockback
            Rigidbody rb;
            if (this.gameObject.TryGetComponent<Rigidbody>(out rb))
            {
                rb.AddForce(kb * knockback, ForceMode.Impulse);
            }
        }
        else if (health <= 0 && !isDead)
        {
            isDead = true;
            animator.SetTrigger("isDead");

            BoxCollider col;
            if(this.TryGetComponent<BoxCollider>(out col))
            {
                col.enabled = false;
            }
        }
    }
}
