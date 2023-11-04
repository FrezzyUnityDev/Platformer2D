using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _pauseCanvas;
    public void PauseHandler()
    {
        _pauseCanvas.SetActive(true);
    }
}
