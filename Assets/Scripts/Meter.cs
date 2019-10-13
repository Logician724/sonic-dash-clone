using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meter : MonoBehaviour
{
    public float currentLevel;
    public Vector2 position = new Vector2(20,40);
    public Vector2 size = new Vector2(60, 20);
    public Texture2D emptyMeterTexture;
    public Texture2D fullMeterTexture;

    void OnGUI()
    {
        //draw the background:
         GUI.BeginGroup(new Rect(position.x, position.y, size.x, size.y));
             GUI.Box(new Rect(0,0, size.x, size.y), emptyMeterTexture);
         
             //draw the filled-in part:
             GUI.BeginGroup(new Rect(0,0, size.x * currentLevel, size.y));
                 GUI.Box(new Rect(0,0, size.x, size.y), fullMeterTexture);
             GUI.EndGroup();
         GUI.EndGroup();
    }

    // Update is called once per frame
    void Update()
    {

    }

}
