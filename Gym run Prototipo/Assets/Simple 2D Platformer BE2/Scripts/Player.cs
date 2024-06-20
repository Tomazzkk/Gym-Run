using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool jumping, onGround, doubleJump;

    float lowJumpMultiplier = 1.5f, fallMultiplier = 2.5f;
    [SerializeField] Rigidbody2D rigidbody2d;

    [SerializeField] LayerMask groundMask;

    [SerializeField] Animator animator;



    private void Update()
    {
        CheckGround();
        UpdateGravity();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            jumping = true;
            Pulando(true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumping = false;
            Pulando(false);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
           Agachado(true);
            
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Agachado(false) ;
        }
    }

 
    private void Jump()
    {
        if (onGround)
        {
            rigidbody2d.velocity = new Vector2(0, 8);
        }
        else if (doubleJump)
        {
            rigidbody2d.velocity = new Vector2(0, 8);
            doubleJump = false;
        }

    }

    private void CheckGround()
    {
        onGround = Physics2D.OverlapCircle(transform.position, 0.2f, groundMask);
        if (onGround)
        {
            doubleJump = true;
        }
    }

    private void UpdateGravity()
    {
        if (rigidbody2d.velocity.y > 0 && !jumping)
        {
            rigidbody2d.velocity += Physics2D.gravity * lowJumpMultiplier * Time.deltaTime;
        }
        else if (rigidbody2d.velocity.y < 0)
        {
            rigidbody2d.velocity = rigidbody2d.velocity + (Physics2D.gravity * fallMultiplier) * Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 1.2f);
    }
    void GameOver()
    {
        Time.timeScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            GameOver();
        }
    }


    private void Agachado(bool agachado)
    {
        if (agachado == true) 
        {
            GetComponent<BoxCollider2D>().size = new Vector2(0.60f, 0.65f);
        }

        else
        {
            GetComponent<BoxCollider2D>().size = new Vector2(0.60f, 0.86f);
        }
        animator.SetBool("Agachado", agachado);
    }

    private void Pulando(bool pulando)
    {
        animator.SetBool("Pulando", pulando);
    }
}   
