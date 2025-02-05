using UnityEngine;

public class ButtonPath : MonoBehaviour
{

    public GameObject path; // The path object to activate/deactivate
  

    private void OnTriggerEnter2D(Collider2D other)
    { 

        if (other.CompareTag("player") || other.CompareTag("pushable") || other.CompareTag("HalfNote")) //add player tag if needed
        {
            path.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("player") || other.CompareTag("pushable") ||  other.CompareTag("HalfNote"))
        {
            path.SetActive(false);
        }
    }
}
