using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour
{

    FadeInOut fade;
    public GameObject[] players;
    private HashSet<GameObject> enteredPlayers = new HashSet<GameObject>();

    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }

    public IEnumerator ChangeScene()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (IsPlayer(other.gameObject))
        {
            enteredPlayers.Add(other.gameObject);

            // Check if all players have entered
            if (AllPlayersEntered())
            {
                StartCoroutine(ChangeScene());
            }
        }
    }

    private bool IsPlayer(GameObject obj)
    {
        foreach (GameObject player in players)
        {
            if (obj == player)
            {
                return true;
            }
        }
        return false;
    }

    private bool AllPlayersEntered()
    {
        foreach (GameObject player in players)
        {
            if (!enteredPlayers.Contains(player))
            {
                return false;
            }
        }
        return true;
    }

    public float rotationSpeed = 50f; 

   // comment out if no want to spin (to comment out use //)
    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}


