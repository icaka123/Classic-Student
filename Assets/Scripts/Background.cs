using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    public int materialIndex = 0;
    public Vector2 uvAnimationRate = new Vector2(1.0f, 0.0f);
    public string textureName = "_MainTex";


    Vector2 uvOffset = Vector2.zero;
    void LateUpdate()
    {
     
        if (GetComponent<Renderer>().enabled)
        {
            GetComponent<Renderer>().materials[materialIndex].SetTextureOffset(textureName, GetComponent<Rigidbody2D>().velocity);
        }
    }
}
