using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public int attackDamage = 20;
    public int enragedAttackDamage = 40;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    public Transform player;

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        FindObjectOfType<audio_Manager>().Play("enemyattack1");
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(pos, attackRange, attackMask);
        if (hitPlayer != null)
        {
            player.GetComponent<player_combat_script>().isHit(attackDamage);
        }
    }

    public void EnragedAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        FindObjectOfType<audio_Manager>().Play("enemyattack1");
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(pos, attackRange, attackMask);
        if (hitPlayer != null)
        {
            player.GetComponent<player_combat_script>().isHit(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
