using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour
{
   
    [SerializeField] private string myId;
    [SerializeField] private Vector3 offset = new Vector3(0, -150, 0);
    [SerializeField] private float fullDuration = 6f;
    private float elapsedTime = 0f;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Coroutine moveRoutine = null;

    private void Awake() {
        startPosition = transform.position;
        targetPosition = startPosition + offset; 
        EventManager.OnSignaled += MovePlatform;
    }

    private void OnDestroy() {
        EventManager.OnSignaled -= MovePlatform;
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
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / fullDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        moveRoutine = null;
    }

    private IEnumerator MoveToHome() {

        while (elapsedTime > 0) {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / fullDuration);
            elapsedTime -= Time.deltaTime;
            yield return null;
        }
        transform.position = startPosition;
        moveRoutine = null;
    }
}
