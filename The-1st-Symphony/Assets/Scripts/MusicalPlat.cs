using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicalPlat : MonoBehaviour
{

    [SerializeField] private AudioSource[] audioplayers;


    public void OnCollisionEnter2D(Collision2D collision)
{
    if(collision.gameObject.tag == "Player"){
        audioplayers[0].Play();
    }
}

}
