using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppearPlat : MonoBehaviour
{
[SerializeField] GameObject[] yourText;
 
void Start()
{
    yourText[0].SetActive(false);
    if(yourText.Length > 1){ 
        for(int i = 1; i < yourText.Length; i++){
    
        yourText[i].SetActive(false);
    }
}
}
 
 
void OnCollisionEnter2D(Collision2D collision)
{
     if(collision.gameObject.tag == "WholeNote" || collision.gameObject.tag == "HalfNote" || collision.gameObject.tag == "EightNote" || collision.gameObject.tag == "QuarterNote" ) 
{
    yourText[0].SetActive(true); 
    if(yourText.Length > 1){ 
        for(int i = 1; i < yourText.Length; i++){
    
        yourText[i].SetActive(true);
    }
}
}
}
 
void OnCollisionExit2D(Collision2D collision)
{
     if(collision.gameObject.tag == "WholeNote" || collision.gameObject.tag == "HalfNote" || collision.gameObject.tag == "EightNote" || collision.gameObject.tag == "QuarterNote" ) 
{
    yourText[0].SetActive(false); 
        if(yourText.Length > 1){ 
        for(int i = 1; i < yourText.Length; i++){
    
        yourText[i].SetActive(false);
    }
}
}
}
}
