using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppearPlat : MonoBehaviour
{
[SerializeField] GameObject[] yourText;
 
void Start()
{
    yourText[0].SetActive(false); 
    yourText[1].SetActive(false);
    yourText[2].SetActive(false);
    }
 
 
void OnCollisionEnter2D(Collision2D collision)
{
     if(collision.gameObject.tag == "WholeNote" || collision.gameObject.tag == "HalfNote" || collision.gameObject.tag == "EightNote" || collision.gameObject.tag == "QuarterNote" ) 
{
    yourText[0].SetActive(true); 
    yourText[1].SetActive(true);
    yourText[2].SetActive(true);
}
}
 
void OnCollisionExit2D(Collision2D collision)
{
     if(collision.gameObject.tag == "WholeNote" || collision.gameObject.tag == "HalfNote" || collision.gameObject.tag == "EightNote" || collision.gameObject.tag == "QuarterNote" ) 
{
    yourText[0].SetActive(false); 
    yourText[1].SetActive(false);
    yourText[2].SetActive(false);
}
}
}
