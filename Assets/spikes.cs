using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour 
{ 



    private Transform player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) 
        {
            player.GetComponent<player_combat_script>().isHit(20);
        } 
    }
}
