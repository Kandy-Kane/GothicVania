using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
   //How Fast do we dash
        public float dashMultipler;
        //For how long
        public float dashTimer;
        //Is player dashing
        public bool isDashing;
        //How long between dashes
        public float dashCooldown;
        //Dash dir to listen for cancels and to apply speed
        public enum dirOfDashEnum {EAST, WEST};
        public dirOfDashEnum dirOfDash;
        //Player is able to dash
        public bool canDash = true;
        //player has air dash
        public bool hasAirDash;
        //Hidden float that tracks speed that should be applied to dash
        [HideInInspector]
        public float dashSpeed;

         [Header("Dash")]
    public PlayerDash dashControl;

    private void dash(){

         if ((Input.GetButton("DashRight") ||Input.GetButton("DashLeft")) && dashControl.canDash && !dashControl.isDashing)
        {
            //Air Dash Check                             //Ground dash
           if((!isGrounded && dashControl.hasAirDash) || isGrounded)
            {
                dashControl.isDashing = true;
                dashControl.canDash = false;
                //Need to listen to specifically which button was pressed down
                if (Input.GetButton("DashRight"))
                    dashControl.dirOfDash = dashClass.dirOfDashEnum.EAST;
                if (Input.GetButton("DashLeft"))
                    dashControl.dirOfDash = dashClass.dirOfDashEnum.WEST;
                StartCoroutine(dash());
            }
        }

         IEnumerator dash()
    {
        switch (dashControl.dirOfDash)
        {
            case dashClass.dirOfDashEnum.EAST:
                dashControl.dashSpeed = moveVelocity * dashControl.dashMultipler;
                break;
            case dashClass.dirOfDashEnum.WEST:
                dashControl.dashSpeed = moveVelocity * -dashControl.dashMultipler;
                break;
        }
        yield return new WaitForSeconds(dashControl.dashTimer);
        StartCoroutine(clearDash());
    }

     if (dashControl.isDashing)
        {
            if ((dashControl.dirOfDash == dashClass.dirOfDashEnum.EAST && Input.GetAxis("Horizontal") < -0.5f)
                || (dashControl.dirOfDash == dashClass.dirOfDashEnum.WEST && Input.GetAxis("Horizontal") > 0.5f))
            {
                StopCoroutine(dash());
                StartCoroutine(clearDash());
            }
        }

         if (!dashControl.isDashing)
            rb.velocity = new Vector2(moveX, rb.velocity.y);
        else
            rb.velocity = new Vector2(dashControl.dashSpeed, 0);

    // #endregion;
}

}


