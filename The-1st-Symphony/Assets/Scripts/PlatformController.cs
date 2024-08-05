using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour
{
   
    [SerializeField] private string myId;
    [SerializeField] private Vector3 offset = new Vector3(0, -150, 0);
    [SerializeField] private float fullDuration = 6f;
    [SerializeField] private float returnDelay = 1f;
    private float elapsedTime = 0f;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Coroutine moveRoutine = null;
    private Rigidbody2D rb;
    private bool isPlayerOn;
    private Vector2 previousPosition;
    
    private void Awake() {
        startPosition = transform.position;
        targetPosition = startPosition + offset; 
        EventManager.OnSignaled += MovePlatform;
        EventManager.OnEnteredPlatform += OnPlayerEnteredPlatform;
        EventManager.OnExitedPlatform += OnPlayerExitedPlatform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy() {
        EventManager.OnSignaled -= MovePlatform;
        EventManager.OnEnteredPlatform -= OnPlayerEnteredPlatform;
        EventManager.OnExitedPlatform -= OnPlayerExitedPlatform;
    }

    private void FixedUpdate() {
        if (isPlayerOn) {
            EventManager.TickVelocity((Vector2)transform.position - previousPosition);
        }
        previousPosition = transform.position;
    }

    private void MovePlatform(string id, bool active) {
        if (id == myId) {
            if (moveRoutine != null) {
                StopCoroutine(moveRoutine);
                moveRoutine = null;
            }
            if (active) {
                moveRoutine = StartCoroutine(MoveToTarget());
            } else {
                moveRoutine = StartCoroutine(MoveToHome());
            }
        }
    }


    private IEnumerator MoveToTarget() {

        while (elapsedTime < fullDuration) {
            rb.MovePosition(Vector3.Lerp(startPosition, targetPosition, elapsedTime / fullDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        rb.MovePosition(targetPosition);
        moveRoutine = null;
    }

    private IEnumerator MoveToHome() { 
        yield return new WaitForSeconds(returnDelay);
        while (elapsedTime > 0) {
             rb.MovePosition(Vector3.Lerp(startPosition, targetPosition, elapsedTime / fullDuration));
            elapsedTime -= Time.deltaTime;
            yield return null;
        }
         rb.MovePosition(startPosition);
        moveRoutine = null;
    }

    private void OnPlayerEnteredPlatform(PlatformController pc) {
        if (pc == this) {
            previousPosition = transform.position;
            isPlayerOn = true;
 
        }
    }

        private void OnPlayerExitedPlatform(PlatformController pc) {
        if (pc == this) {
            isPlayerOn = false;
        }
    }
}
