using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigidbody2D;

    
    void Update()
    {
        rigidbody2D.velocity = new Vector2(GameManager.instance.Speed * -1, 0);
        rigidbody2D.velocity = new Vector2(GameManager.instance.Speed * -1, 0);

        if (transform.position.x < -GameManager.instance.ScreenBounds.x)
        {
            Destroy(gameObject);
        }
    }

}