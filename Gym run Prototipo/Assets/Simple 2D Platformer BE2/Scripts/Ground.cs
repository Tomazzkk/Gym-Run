using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField]
    Material Texture;
    float speedSky = 0.3f;
  

    // Update is called once per frame
    void Update()
    {
        Texture.mainTextureOffset = Texture.mainTextureOffset + new Vector2(speedSky * Time.deltaTime, 0);
    }
}
