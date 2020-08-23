using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private PlayerMovement player;
    public Transform AttackPoint;
    public float attackRange = 1f;
    //public LayerMask playerLayer;

    public int attackDamage = 25;
    public Animator animator;

    public int maxHealth = 100;
    private int currentHealth;
     private Rigidbody2D enemyRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        enemyRigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        
        
    }

     void OnTriggerEnter2D(Collider2D player) {
        if (player.gameObject.tag == "Player") 
         {
             player.GetComponent<PlayerMovement>().TakeDamage(attackDamage);
             StartCoroutine(player.GetComponent<PlayerMovement>().Knockback(0.03f, 500, player.transform.position));
         }
    }


    public void TakeDamage(int damage){
        currentHealth -= damage;

        animator.SetTrigger("Hurt");
        if(currentHealth<=0)
        {
            Die();
        }
    }

       
	
    void Die(){
        animator.SetBool("IsDead",true);
        Destroy(gameObject,1);
         

        this.enabled = false; 
        GetComponent<Collider2D>().enabled = false; 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
     
}
