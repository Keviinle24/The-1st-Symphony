using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThroughPlat : MonoBehaviour
{

    [SerializeField] private List<GameObject> players = new List<GameObject>();
    private Collider2D _collider;
    private bool _playerOnPlatform;
    void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void SetPlayerOnPlatform(Collision2D other, bool value)
    {
       // var player = other.gameObject.GetComponent<Player>();
        if (players.Contains(other.gameObject))
        {
            _playerOnPlatform = value;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        SetPlayerOnPlatform(other, true);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        SetPlayerOnPlatform(other, true);
    }
    // Update is called once per frame
    void Update()
    {
        if (_playerOnPlatform && Input.GetAxisRaw("Vertical") < 0)
        {
            _collider.enabled = false;
            StartCoroutine(EnableCollider());
        }
    }

    private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(0.4f);
        _collider.enabled = true;
    }
}
