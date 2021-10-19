using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public Animator animator;
    public int health = 500;

    //public GameObject deathEffect;

    public bool isInvulnerable = false;

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("isHit");
        if (isInvulnerable)
            return;

        health -= damage;

        if (health <= 200)
        {
            GetComponent<Animator>().SetBool("phase2", true);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;

        this.enabled = false;

    }
}
