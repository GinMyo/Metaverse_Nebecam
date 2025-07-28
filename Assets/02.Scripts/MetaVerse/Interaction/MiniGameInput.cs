using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MiniGameInput : MonoBehaviour
{
    public string miniGameSceneName = "FlappyBird";
    public GameObject interactionPopup;

    public void OnInteraction(InputValue inputValue)
    {
        if (interactionPopup.activeSelf)
        {
            EnterMiniGame();
        }
    }

    private void EnterMiniGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(miniGameSceneName);
    }
}

