using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{

    private void Start()
    {
    }
    public void PlayGame()
    {
       StartCoroutine(play());
    }

    IEnumerator play()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);

    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }

}
