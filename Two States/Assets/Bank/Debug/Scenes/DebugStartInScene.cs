using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugStartInScene : MonoBehaviour
{
    [SerializeField] private string sceneName = "MainMenu";
    private void Awake()
    {
        //starts from mainmenu when playing in editor
        SceneManager.LoadScene(sceneName);
    }
}
