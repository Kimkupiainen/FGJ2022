using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayGame : MonoBehaviour
{
    [SerializeField] Animator fader;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void playGame()
    {
        fader.SetTrigger("FadeOut");
        StartCoroutine(LoadLevel());
        print("Player has started the game");
    }
    public IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
        StopCoroutine(LoadLevel());
    }
    public void QuitGame()
    {
        fader.SetTrigger("FadeOut");
        StartCoroutine(QuittingGame());
    }
    public IEnumerator QuittingGame()
    {
        yield return new WaitForSeconds(1);
        Application.Quit();
        print("Player has quit the game");
    }
}
