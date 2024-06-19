using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    float clock, cooldown = 2;
    [SerializeField]
    GameObject[] obstacle;
    public static SpawnManager instance;
    int ObstacleType;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (clock <= 0)
        {
            ObstacleType = Random.Range(0, 100);


            if (ObstacleType > 85)
            {
                Instantiate(obstacle[1], new Vector2(13, -1), Quaternion.identity);
            } 
            else if (ObstacleType > 40)
            {
                Instantiate(obstacle[0], new Vector2(GameManager.instance.ScreenBounds.x, -4), Quaternion.identity);
            }

            if (GameManager.instance.Speed < 10)
            {
                GameManager.instance.Speed += 0.5f;
            }
            if (cooldown > 1)
            {
                cooldown -= 0.1f;
            }

            clock = cooldown;
        }
        else
        {
            clock -= Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true) ;
        {
            Destroy(gameObject);
        }
    }
}