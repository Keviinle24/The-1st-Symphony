using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnReload : MonoBehaviour
 {
//     public GameObject objectToDeactivate; // The object to deactivate on subsequent reloads
//     private const string ReloadCountKey = "SceneReloadCount";
//     private const string CurrentSceneKey = "CurrentScene";

//     private void Start()
//     {
//         // Get the current scene name
//         string currentSceneName = SceneManager.GetActiveScene().name;

//         // Check if the current scene is the same as the one stored in PlayerPrefs
//         if (PlayerPrefs.GetString(CurrentSceneKey) == currentSceneName)
//         {
//             // Scene is the same as the stored scene, so handle reload count
//             int reloadCount = PlayerPrefs.GetInt(ReloadCountKey, 0);
//             if (reloadCount > 0)
//             {
//                 // Scene has been reloaded before, deactivate the object
//                 if (objectToDeactivate != null)
//                 {
//                     objectToDeactivate.SetActive(false);
//                 }
//             }

//             // Increment the reload count
//             PlayerPrefs.SetInt(ReloadCountKey, reloadCount + 1);
//         }
//         else
//         {
//             // Scene has changed, reset reload count and update current scene
//             PlayerPrefs.SetInt(ReloadCountKey, 0);
//             PlayerPrefs.SetString(CurrentSceneKey, currentSceneName);
//         }
//     }

//     private void OnDestroy()
//     {
//         // Reset reload count if needed, when transitioning out of this scene
//         PlayerPrefs.SetInt(ReloadCountKey, 0);
//     }
}
