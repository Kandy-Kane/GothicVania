using System.Threading;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerAttack : MonoBehaviour
{

    public Animator animator;
    public Transform AttackPoint;
    public float attackRange = 1f;
    public LayerMask enemyLayers;

    public int attackDamage = 25;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if(Time.time>= nextAttackTime)
        {
             if(Input.GetKeyDown(KeyCode.Z))
        {
            Attack();
            nextAttackTime = Time.time + 1/attackRate; 

        }

        }
       
    }

    void Attack(){
        animator.SetTrigger("Attack");
        
       Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position,attackRange
        ,enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            //enemy.GetComponent<Hell_Gato>().TakeDamage(attackDamage);
            //Debug.Log("we hit");
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(AttackPoint.position,attackRange);
    }

}
