using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayGame : MonoBehaviour
{
    [SerializeField] Animator fader;

    public void playGame()
    {
        fader.SetTrigger("FadeOut");
        StartCoroutine(LoadLevel());
    }
    public IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
        StopCoroutine(LoadLevel());
    }
}
