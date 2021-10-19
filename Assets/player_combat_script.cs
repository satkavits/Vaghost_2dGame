using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_combat_script : MonoBehaviour
{
    public Animator animator;
    bool second_attack=false;
    public int health = 500;
    int currenthealth;
    public Transform attackpoint;
    public float range = 0.5f;
    public int attackDamage = 20;
    public LayerMask enemyLayers;
    public float attackrate = 2f;
    float nextattacktime = 0;
    public healthBar healthbar;


    void Start() 
    {
        
        currenthealth = health;
        healthbar.setMaxHealth(health);
    
    }



    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextattacktime) 
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (second_attack == false)
                { Attack(); }
                else
                { Attack2(); }
                nextattacktime = Time.time + 1f / attackrate;

            }
        }
       
    }

    void Attack()
    {
        
        animator.SetTrigger("Attack");
        FindObjectOfType<audio_Manager>().Play("attack1");

        second_attack = true;

       Collider2D[] hitEnemies= Physics2D.OverlapCircleAll(attackpoint.position,range,enemyLayers);

        foreach (Collider2D enemy in hitEnemies) 
        {
        
            try
            {
                enemy.GetComponent<enemy_movement>().isHit(attackDamage);
            }
            catch (NullReferenceException )
            {               
                enemy.GetComponent<BossHealth>().TakeDamage(attackDamage);
            }
           
        }
    }

    void Attack2()
    {
        
        animator.SetTrigger("Attack2");
        FindObjectOfType<audio_Manager>().Play("attack2");

        second_attack = false;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, range, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            try
            {
                enemy.GetComponent<enemy_movement>().isHit(attackDamage);
            }
            catch (NullReferenceException )
            {
                enemy.GetComponent<BossHealth>().TakeDamage(attackDamage);
            }



        }

    }

    public void isHit(int damage)
    {
        if (currenthealth > 0)
        {
            animator.SetTrigger("isHurt");

            currenthealth -= damage;
            healthbar.setHealth(currenthealth);
        }
        if (currenthealth <= 0)
        {
            animator.SetBool("isDead", true);

            StartCoroutine(GameOver());
            

        }

    }

    void onDrawGizmosSelected() 
    {
        if (attackpoint == null)
            return;
        Gizmos.DrawWireSphere(attackpoint.position, range);
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
