using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperMode : MonoBehaviour {

    float horizontalMove = 0f;
    private bool m_FacingRight = true;

    private void FixedUpdate()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        if (horizontalMove > 0 && !m_FacingRight)
        {
            // ... flip the player.
            flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (horizontalMove < 0 && m_FacingRight)
        {
            // ... flip the player.
            flip();
        }
    }

    private void flip ()
    {
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);


        //Vector3 theScale = transform.localScale;
        //theScale.x *= -1;
        //transform.localScale = theScale;
    }


    

}

