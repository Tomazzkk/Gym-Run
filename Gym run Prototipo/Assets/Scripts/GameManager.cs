using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Variáveis
    static public GameManager instance;
    float speed = 700;
    int score;
    Vector2 screenBounds;
    private float gameSpeed;//deltaTime
    private float scaleTime;//timeSacle

    //Encapsulamento das variáveis
    public float Speed { get => speed; set => speed = value; }
    public int Score { get => score; set => score = value; }
    public Vector2 ScreenBounds { get => screenBounds; }
    public float GameSpeed { get => gameSpeed; set => gameSpeed = value; }
    public float ScaleTime { get => scaleTime; set => scaleTime = value; }

    private void Awake()
    {
        instance = this;
        scaleTime = 1;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)) + new Vector3(1, 0, 0);
        Time.timeScale = 1.0f;

    }
    private void Update()
    {
        gameSpeed = Time.deltaTime * scaleTime;

    }


}