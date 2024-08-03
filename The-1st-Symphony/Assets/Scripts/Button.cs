using UnityEngine;

public class Button : MonoBehaviour
{
 
    [SerializeField] private string myId;
    [SerializeField] private bool oneShot = false;

    
  

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.CompareTag("player")) {
            EventManager.SendSignal(myId, true);
        }
        // if (other.CompareTag(" ") || other.CompareTag("pushable")) //add player tag if needed
        // {
        //     path.SetActive(true);
        // }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
                if (other.gameObject.CompareTag("player") && !oneShot) {       
                EventManager.SendSignal(myId, false);
        }
        // if (other.CompareTag(" ") || other.CompareTag("pushable"))
        // {
        //     path.SetActive(false);
        // }
    }
}
