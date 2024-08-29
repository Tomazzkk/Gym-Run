using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
    [SerializeField] GameObject[] comidaGordurosa;

    int alturaSpawn;
    Vector2 posicaoObstacle; 


    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
       SpawmObstaculos();
    }
    public void SpawmObstaculos()
    {
        alturaSpawn = Random.Range(0, -4);
        


        if (clock <= 0)
        {
            ObstacleType = Random.Range(0, 10);


            if (ObstacleType >= 7)
            {
                 int i = Random.Range(0, obstacle.Length);
                Instantiate(obstacle[i], obstacle[i].GetComponent<Obstacle>().Posicao,Quaternion.identity);
                // Instantiate(obstacle[i], obstacle[i].GetComponent<Obstacle>().Posicao, Quaternion.identity);
            } 
            else if(ObstacleType >= 4 && ObstacleType < 7)
            {
                Instantiate(comida[Random.Range(0, comida.Length)], new Vector2(13, alturaSpawn), Quaternion.identity);
            }
            else if (ObstacleType <= 4)
            {
                Instantiate(comidaGordurosa[Random.Range(0, comida.Length)], new Vector2(13, alturaSpawn), Quaternion.identity);
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