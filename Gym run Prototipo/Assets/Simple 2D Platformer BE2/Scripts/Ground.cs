using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField]
    Material Texture;
  

    // Update is called once per frame
    void Update()
    {
        Texture.mainTextureOffset = Texture.mainTextureOffset + new Vector2(GameManager.instance.Speed * Time.deltaTime, 0);
    }
}
