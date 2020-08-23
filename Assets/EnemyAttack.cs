using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator animator;
    public LayerMask playerLayer;
      public Transform AttackPoint;
    public float attackRange = 1f;
    
    Rigidbody2D Rigidbody2D; 
    public int attackDamage = 25;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

   public float speed;
     private Transform target;
    // private float someScale;
 
     // Amount of "kick" the force has
     //public float forceAmount;
 
     // Time to wait until the knockback occurs
     //public float knockbackDelay;
 
     // Rigidbody2D variable to hold the player Rigidbody2D
     private Rigidbody2D rb;
 
     // Use this for initialization
     /*void Start()
     {
         someScale = transform.localScale.x;
 
         target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
         rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
     }*/
 
     // Update is called once per frame
     void Update()
     {
        /* if (Vector2.Distance(transform.position, target.position) > 1.8)
         {
             transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
         }*/
 
         // Your other stuff in here about turning
         // ...
         // ... etc.
 
     }
 
     void OnTriggerEnter2D(Collider2D collision )
     {
         if (collision.gameObject.tag == "Player")
         {
             Attack();
              
              
                    UnityEngine.Debug.Log("we hit");
                
                             // Call coroutine to wait for the set amount of time
             //StartCoroutine(WaitForKnockback(knockbackDelay));
 
             // This adds a force to the PLAYER in the "forward" direction of THIS gameobject
             // This assumes the rotation of this gameobject is facing the player
             //rb.AddForce(transform.right * forceAmount, ForceMode2D.Impulse);
         }
     }

     void Attack(){

            UnityEngine.Debug.Log("Hit Player");
            animator.SetTrigger("Attack");
        
       Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(AttackPoint.position,attackRange
        ,playerLayer);

        foreach(Collider2D player in hitPlayer)
        {
            player.GetComponent<PlayerMovement>().TakeDamage(attackDamage);
            //Debug.Log("we hit");
        }
     }
 
     // Waits for the amount of time passed in as a parameter
     /*IEnumerator WaitForKnockback(float time)
     {
         yield return new WaitForSeconds(time);
     }*/
     private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(AttackPoint.position,attackRange);
    }
}
