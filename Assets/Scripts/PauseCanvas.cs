using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Runtime.CompilerServices;
using UnityEngine.UI;

public class PauseCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _scalePausePanel;
    [SerializeField] private Image _fadePausePanel;
    [SerializeField] private Button _openPausePanel;

    [SerializeField] private Button _countinueButton;

    private void Start()
    {
        _openPausePanel.onClick.AddListener(OpenPause);
        _countinueButton.onClick.AddListener(ContinueGame);
    }

    private void OnDestroy()
    {
        _openPausePanel.onClick.RemoveListener(OpenPause);
        _countinueButton.onClick.RemoveListener(ContinueGame);
        
    }

    private void OpenPause()
    {
        _fadePausePanel.gameObject.SetActive(true);
        _fadePausePanel.DOFade(0.8f, 0.5f).SetEase(Ease.OutBack);
        ViewPausePanel();
    }
    private void ViewPausePanel()
    {
        _scalePausePanel.SetActive(true);
        _scalePausePanel.transform.localScale = Vector3.zero;
        _scalePausePanel.transform.DOScale(1f, 0.5f).OnComplete(() =>
        {
            Time.timeScale = 0f;
        });
    }

    private void ContinueGame()
    {
        Time.timeScale = 1f;
        _fadePausePanel.DOFade(0.0f, 0.5f).SetEase(Ease.OutBack);
        _scalePausePanel.transform.DOScale(0f, 0.5f).OnComplete(() =>
        {
            
            _fadePausePanel.gameObject.SetActive(false);
            _scalePausePanel.gameObject.SetActive(false);
            
        });
    }
}


