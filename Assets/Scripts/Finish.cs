using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _levelCompleteCanvas;
    [SerializeField] private GameObject _messageUI;

    private bool _isActivated = false;

    public void Activate()
    {
        _isActivated = true;
        _messageUI.SetActive(false);
    }
    public void FinishLevel ()
    {
        if (_isActivated)
        {
            _levelCompleteCanvas.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            _messageUI.SetActive(true);
        }
    }
}
