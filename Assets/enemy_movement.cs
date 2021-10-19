using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    public Animator animator;
    
    public int health = 100;
    int currenthealth;
    public Transform attackpoint;
    public float range = 3f;
    public LayerMask playerLayer;
    Transform player;
    Rigidbody2D rb;
    public float attackrate = 3f;
    float nextattacktime = 0;
    
    
    
    


    void Start()
    {
        currenthealth = health;
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        if (Time.time >=1+ nextattacktime)  
        {
            if (Vector2.Distance(player.position, rb.position) <= range)
            {     
                { Attack(); }
                
                nextattacktime = Time.time + 1f / attackrate;

            }
        }
    }

    void Attack()
    {

        animator.SetTrigger("Attack");
        FindObjectOfType<audio_Manager>().Play("enemyattack1");


        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackpoint.position, range, playerLayer);
        
        player.GetComponent<player_combat_script>().isHit(15);

        
    }

   

    public void isHit(int damage) 
    {
        
        
            currenthealth -= damage;
            

            animator.SetTrigger("isHit");
        
        if (currenthealth <=0)
        {
            animator.SetBool("isDead",true);

           GetComponent<Collider2D>().enabled = false;
            
            this.enabled = false;
        
        }

    }

    void onDrawGizmosSelected()
    {
        if (attackpoint == null)
            return;
        Gizmos.DrawWireSphere(attackpoint.position, range);
    }
}
