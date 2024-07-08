using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    float clock, cooldown = 2;
    [SerializeField]
    GameObject[] obstacle;
    [SerializeField]
    GameObject[] comida;
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
            ObstacleType = Random.Range(0, 5);


            if (ObstacleType > 1)
            {
                 int i = Random.Range(0, obstacle.Length);
                Instantiate(obstacle[i], obstacle[i].GetComponent<Obstacle>().Posicao, Quaternion.identity);
            } 
            else
            {
                Instantiate(comida[Random.Range(0, comida.Length)], new Vector2(13, -1), Quaternion.identity);
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
    
}