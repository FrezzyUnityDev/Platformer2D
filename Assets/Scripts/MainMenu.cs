using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private string _loadGameScene;
    public void StartHandler()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(_loadGameScene);
    }

    public void ExitHandler()
    {
        Application.Quit();
    }

}
