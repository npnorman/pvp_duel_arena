using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTest : MonoBehaviour
{
    Animator animator;

    public int health = 10;
    bool isDead;

    private void Start()
    {
        isDead = false;
        animator = GetComponent<Animator>();
    }

    public void attacked(int attk)
    {
        health -= attk;

        if (health > 0)
        {
            animator.SetTrigger("isPunched");
        }
        else if (health <= 0 && !isDead)
        {
            isDead = true;
            animator.SetTrigger("isDead");
        }
    }
}
