using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; 

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject _mainMenuCanvasGO;
    [SerializeField] private GameObject _settingsMenuCanvasGO;

   // [SerializeField] private Player _player;
    [SerializeField] private Walk_mechanic _playerAttack;


    [SerializeField] private GameObject _mainMenuFirst;
    [SerializeField] private GameObject _settingsMenuFirst;

    private bool isPaused;

    private void Start()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(false);
    }

    private void Update()
    {
        if(InputManager.instance.MenuOpenCloseInput)
        {
            if(!isPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        if(_playerAttack != null){
        _playerAttack.enabled = false;
        }
        // if(_player != null){
        // _player.enabled = false;
        // }


        OpenMainMenu();
    }

    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1f;

        
        _playerAttack.enabled = true;
       // _player.enabled = true;

        CloseAllMenus();
    }

    #region Canvas Activations/Deactivations

    private void OpenMainMenu()
    {
        _mainMenuCanvasGO.SetActive(true);
        _settingsMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);

    }

    private void OpenSettingsMenuHandle()
    {
        _settingsMenuCanvasGO.SetActive(true);
        _mainMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_settingsMenuFirst);
    }

    private void CloseAllMenus()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
    }

    #endregion

    public void OnSettingsPress()
    {
        OpenSettingsMenuHandle();
    }

    public void OnResumePress()
    {
        Unpause();
    }

    public void OnSettingsBackPress()
    {
        OpenMainMenu();
    }

    public void RestartLevel()
    {
    Unpause();
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}