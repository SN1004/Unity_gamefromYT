using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        int selectedplayer =
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        
        GameManager.instance.PlyrIndex = selectedplayer;

        SceneManager.LoadScene("Gameplay");

    }
}
