using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    public void ViewGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
        _gameOverPanel.transform.localScale = Vector3.zero;
        _gameOverPanel.transform.DOScale(1f, 0.5f).OnComplete(() =>
        {
            Time.timeScale = 0f;
        });
    }

    public void RestartHandler()
    {
        
        _gameOverPanel.transform.DOScale(0f, 1f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            _gameOverPanel.SetActive(false);
        });
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void ExitHandler()
    {
        SceneManager.LoadScene(0);
    }
}
