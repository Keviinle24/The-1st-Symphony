using UnityEngine;

public class RespawnGround : MonoBehaviour
{
    public void ResetPlatforms()
    {
        // Find all GameObjects tagged as "ground"
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Ground");

        foreach (GameObject platform in platforms)
        {
            FallingPlatform fallingPlatform = platform.GetComponent<FallingPlatform>();
            if (fallingPlatform != null)
            {
                fallingPlatform.ResetPlatform();
            }
        }
    }
}
