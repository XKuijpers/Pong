using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public void loadTwoPlayer()
    {
        SceneManager.LoadScene("pongBasic");
    }

    public void loadOnePlayer()
    {
        SceneManager.LoadScene("pongTwist");
    }

    public void loadAtariMode()
    {
        SceneManager.LoadScene("pongAtari");
    }
}
