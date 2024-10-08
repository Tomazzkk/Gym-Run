using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigidbody2D;
    [SerializeField]
    Vector2 posicao;

    public Vector2 Posicao { get => posicao; set => posicao = value; }

    void Update()
    {
     
        rigidbody2D.velocity = new Vector2(GameManager.instance.Speed * -1* GameManager.instance.GameSpeed, 0);

        if (transform.position.x < -GameManager.instance.ScreenBounds.x)
        {
            Destroy(gameObject);
        }
    }

}