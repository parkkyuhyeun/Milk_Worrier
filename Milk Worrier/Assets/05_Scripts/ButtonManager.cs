using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void Starting()
    {
        SceneManager.LoadScene("03_Lobby");
    }
    public void Guide()
    {
        SceneManager.LoadScene("02_Guide");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
