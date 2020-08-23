using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hell_Gato : Enemy
{

    private PlayerMovement player;
    public Transform player_t;
    public float moveSpeed = 0.05f;
    //public LayerMask playerLayer;
    private Vector2 movement; 
    //public int attackDamage = 25;
    //public Animator animator;

    public  int maxGatoHealth = 50;
    private int currentGatoHealth;
     private Rigidbody2D enemyGatoRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        currentGatoHealth = maxGatoHealth;
        enemyGatoRigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        //rb = this.GetComponent<Rigidbody2D>();

        
    }

     void OnTriggerEnter2D(Collider2D player) {
        if (player.gameObject.tag == "Player") 
         {
             player.GetComponent<PlayerMovement>().TakeDamage(attackDamage);
             StartCoroutine(player.GetComponent<PlayerMovement>().Knockback(0.02f, 50, player.transform.position));
         }
    }


    /*public void TakeDamage(int damage){
        currentGatoHealth -= damage;

        animator.SetTrigger("Hurt");
        if(currentGatoHealth<=0)
        {
            Die();
        }
    }*/

       
	
    void Die(){
        animator.SetBool("IsDead",true);
        Destroy(gameObject,1);
         

        this.enabled = false; 
        GetComponent<Collider2D>().enabled = false; 
    }
    // Update is called once per frame
    void Update()
    {
         Vector3 direction = player_t.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //enemyGatoRigidBody.rotation = angle;
        direction.Normalize();
        movement = direction;

                 /* bool isFacingRight;
        if(player_t.position.x > transform.position.x){
        isFacingRight=true;
        //face right
        if(isFacingRight){
        transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);
        
        }
        }
        else if(player_t.position.x < transform.position.x){
        isFacingRight=false;
        //face left
        if(!isFacingRight){
        transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);}}
        */
           /*if(player_t.position.x > transform.position.x){
     //face right
     transform.localScale = new Vector3(1,1,1);
     }else if(player_t.position.x < transform.position.x){
     //face left
     transform.localScale = new Vector3(-1,1,1);
     }*/
        if (player.transform.position.x < gameObject.transform.position.x && !facingRight)
Flip ();
if (player.transform.position.x > gameObject.transform.position.x && facingRight)
Flip ();
        

        
    }

     
public bool facingRight = false;

void Flip () {
//here your flip funktion, as example
facingRight = !facingRight;
Vector3 tmpScale = gameObject.transform.localScale;
tmpScale.x *= -1;
gameObject.transform.localScale = tmpScale;
}


     private void FixedUpdate() {

       
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction){
        enemyGatoRigidBody.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
     
}
