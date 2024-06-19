using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Variáveis
    static public GameManager instance;
    float speed = 1;
    int score;
    Vector2 screenBounds;

    //Encapsulamento das variáveis
    public float Speed { get => speed; set => speed = value; }
    public int Score { get => score; set => score = value; }
    public Vector2 ScreenBounds { get => screenBounds; }

    private void Awake()
    {
        instance = this;

        //screenVounds = A ( ) + B( C( ) )
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)) + new Vector3(1, 0, 0);

        
    }


}