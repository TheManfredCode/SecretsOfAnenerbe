using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    public Enemy _enemy;
    public LayerMask platformLayer;
    public bool isGrounded;
    public float jumpForce = 50f;
    public Transform startPoint;
    public float distance = 0.3f;

    private void OnTriggerStay2D(Collider2D collider)
    {
        isGrounded = collider != null && (((1 << collider.gameObject.layer) & platformLayer) != 0);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
    public void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(startPoint.position, startPoint.right, distance, platformLayer);
        if (hitInfo.collider != null)
        {
            if (isGrounded == true)
            {
                _enemy.jump(jumpForce);
            }
        }
    }

}
