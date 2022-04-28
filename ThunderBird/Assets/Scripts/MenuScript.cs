using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public Animator ticket;

    private void Start()
    {
        ticket = GetComponent<Animator>();
    }
    public void PlayGame()
    {
        Debug.Log("Play");
        ticket.SetTrigger("play");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
