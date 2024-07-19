using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{

    FadeInOut Fade;
    // Start is called before the first frame update
    void Start()
    {
        Fade = FindObjectOfType<FadeInOut>();

        Fade.FadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
