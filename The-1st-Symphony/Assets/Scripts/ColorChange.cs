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

        //spriteRenderer.material.color = Color.black;
      //  gameObject.GetComponent<SpriteRenderer>().material.color = Color.black;
    }


public void OnCollisionEnter2D(Collision2D collision)
{
     if(collision.gameObject.tag == "Player")
        {
            if (colors != null && colors.Length > 0){

            //gameObject.GetComponent<SpriteRenderer>().material.color = Color.materials[0];
                Color newColor = colors[0];
                newColor.a = spriteRenderer.color.a;
                spriteRenderer.material.color = newColor;

        }
}
 
}

public void OnCollisionExit2D(Collision2D collision)
{
         if(collision.gameObject.tag == "Player")
        {
            //gameObject.GetComponent<SpriteRenderer>().material.color = Color.black;
            spriteRenderer.material.color = defaultColor;

        }
}
}
