using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [SerializeField] Color[] colors; 
    private SpriteRenderer spriteRenderer;
    private Color defaultColor = Color.black;

    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.material.color = defaultColor; 

    }


public void OnCollisionEnter2D(Collision2D collision)
{
     if(collision.gameObject.tag == "WholeNote" || collision.gameObject.tag == "HalfNote" || collision.gameObject.tag == "EightNote" || collision.gameObject.tag == "QuarterNote" ) 

        {
            if (colors != null && colors.Length > 0){

                Color newColor = colors[0];
                newColor.a = spriteRenderer.color.a;
                spriteRenderer.material.color = newColor;

        }
}
 
}

public void OnCollisionExit2D(Collision2D collision)
{
     if(collision.gameObject.tag == "WholeNote" || collision.gameObject.tag == "HalfNote" || collision.gameObject.tag == "EightNote" || collision.gameObject.tag == "QuarterNote" ) 
        {
            spriteRenderer.material.color = defaultColor;

        }
}
}
