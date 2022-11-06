using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicContr : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip BloodClipSale;

    public AudioClip BloodClipBuy;

    


    public void BloodOnSale()
    {
        audioSource.PlayOneShot(BloodClipSale);
    }
    public void BloodOnBuy()
    {
        audioSource.PlayOneShot(BloodClipBuy);
    }

}
