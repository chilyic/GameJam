using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicContr : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip BloodClipSale;

    public AudioClip BloodClipBuy;

    public AudioClip Lampa;


    public void BloodOnSale()
    {
        audioSource.PlayOneShot(BloodClipSale);
    }
    public void BloodOnBuy()
    {
        audioSource.PlayOneShot(BloodClipBuy);
    }


    public void Lampada()
    {
        audioSource.PlayOneShot(Lampa);
    }


    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
