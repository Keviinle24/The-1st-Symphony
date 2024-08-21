using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsToThanks : MonoBehaviour
{
    public CanvasGroup firstCanvasGroup; // Reference to the CanvasGroup for the first image
    public CanvasGroup secondCanvasGroup; // Reference to the CanvasGroup for the second image
    public GameObject objectToActivate; // The GameObject to activate when the second CanvasGroup is visible

    public float fadeDuration = 1f; // Duration of the fade effect
    public float delayBeforeFade = 1f; // Delay before starting the fade

    private void Start()
    {
        if (firstCanvasGroup == null || secondCanvasGroup == null)
        {
            Debug.LogError("CanvasGroups are not assigned.");
            return;
        }

        // Ensure second CanvasGroup starts invisible
        secondCanvasGroup.alpha = 0;
        secondCanvasGroup.gameObject.SetActive(true);

        // Start the fading process with delay
        StartCoroutine(FadeImagesWithDelay());
    }

    private IEnumerator FadeImagesWithDelay()
    {
        // Wait for the specified delay before starting the fade
        yield return new WaitForSeconds(delayBeforeFade);

        // Proceed with fading images
        yield return StartCoroutine(FadeImages());
    }

    private IEnumerator FadeImages()
    {
        // Fade out the first CanvasGroup
        yield return StartCoroutine(FadeCanvasGroup(firstCanvasGroup, 1, 0));

        // Ensure the first CanvasGroup is completely hidden
        firstCanvasGroup.gameObject.SetActive(false);

        // Fade in the second CanvasGroup
        secondCanvasGroup.gameObject.SetActive(true);
        yield return StartCoroutine(FadeCanvasGroup(secondCanvasGroup, 0, 1));

        // Activate the object
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float startAlpha, float endAlpha)
    {
        float elapsedTime = 0;
        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = endAlpha; // Ensure the final alpha value is set
    }
}
