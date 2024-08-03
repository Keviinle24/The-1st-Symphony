using UnityEngine;
public class boxpull : MonoBehaviour {

    public float defaultMass; // Mass of the Rigidbody when being pushed.
    public float immovableMass; // Mass of the Rigidbody when not being pushed
    public bool beingPushed; 
    private Rigidbody2D rb;

    private void Awake () {
        rb = GetComponent<Rigidbody2D>();
    }
 
    private void Update () {
  float horizontalInput = Input.GetAxis("Horizontal");
     rb.gravityScale = 80;
            if (beingPushed == false) {
                rb.mass = immovableMass; // Set mass to imovableMass when not being pushed.
                
			
			
            } else {
                rb.mass = defaultMass; // Set mass to defaultMass when being pushed.
                // rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.velocity = Vector3.zero;
              
                //GetComponent<Rigidbody2D>().isKinematic = false; 
			
            }
        }
    }


// using UnityEngine;
// public class boxpull : MonoBehaviour {

//     public float defaultMass; // Mass of the Rigidbody when being pushed.
//     public float immovableMass; // Mass of the Rigidbody when not being pushed
//     public bool beingPushed; 
 
//     void Update () {

//             if (beingPushed == false) {
//                 GetComponent<Rigidbody2D>().mass = immovableMass; // Set mass to imovableMass when not being pushed.
            
            
//             } else {
//                 GetComponent<Rigidbody2D>().mass = defaultMass; // Set mass to defaultMass when being pushed.
//                  GetComponent<Rigidbody2D>().velocity = Vector3.zero;
//                 //GetComponent<Rigidbody2D>().isKinematic = false; 
            
//             }
//         }
//     }