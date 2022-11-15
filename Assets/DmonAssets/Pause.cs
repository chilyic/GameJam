using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PauseBG;
    [SerializeField] private GraphicController graphicController;
    private void Start()
    {
        PauseBG.SetActive(false);
    }

    public void PauseOnBtnPress()
    {
        PauseBG.SetActive(true);
        Time.timeScale = 0;
    }
    public void PauseOffBtnPress()
    {
        PauseBG.SetActive(false);
        Time.timeScale = 1;
    }
}
