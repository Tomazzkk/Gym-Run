using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    bool jumping, onGround, doubleJump, imune;

    float lowJumpMultiplier = 1.5f, fallMultiplier = 2.5f;
    [SerializeField] Rigidbody2D rigidbody2d;

    [SerializeField] LayerMask groundMask;

    [SerializeField] Animator animator;
    [SerializeField] GameObject GamerOverPanel;
    [SerializeField] GameObject GameOverTransp;
    int scoreText;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    float Tempo;


    private void Update()
    {
        //CheckGround();
        UpdateGravity();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
            jumping = true;
            Pulando(true);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
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

        if (imune == true)

        { Tempo += Time.deltaTime; 
            if(Tempo >= 5)
            { imune = false;
                Tempo = 0;
            }
              
        }


        
        
        }
       

 
    private void Jump()
    {
        if (onGround)
        {
            rigidbody2d.velocity = new Vector2(0, 8);
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
        GamerOverPanel.SetActive(true);
        GameOverTransp.SetActive(true);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo") && imune == false)
        {
            GameOver();
            GamerOverPanel.SetActive(true);
            GameOverTransp.SetActive(true);
        }
        if (collision.gameObject.CompareTag("maca"))
        {
            scoreText += 1;
            textMeshProUGUI.text = scoreText.ToString();
           GameObject.Find("Image").GetComponent<Image>().fillAmount += 0.02f;
            if (GameObject.Find("Image").GetComponent<Image>().fillAmount >= 0.04f )
            {
                imune = true;
            }
            Destroy(collision.gameObject);

        }
        if(collision.gameObject.CompareTag("Obstaculo2"))
        {
            GameObject.Find("Image").GetComponent<Image>().fillAmount -= 0.02f;
            ZeraBarra();
           GameOver();
        }

           
  }

    private void ZeraBarra()
    {
        if (GameObject.Find("Image").GetComponent<Image>().fillAmount == 0.0f)
        {
            GameOver();
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
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
