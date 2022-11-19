using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VampiteController : MonoBehaviour
{
    public bool IsActiveAnger;
    [SerializeField]
    private Garlik garlic;
    [SerializeField]
    private Health health;
    [SerializeField]
    private Slider AngerSlider;

    [SerializeField]
    private AudioSource AS;
    [SerializeField]
    private AudioClip AC;


    [SerializeField] private Animator animLight;
    private void Start()
    {
        IsActiveAnger = true;
        StartCoroutine(AngerTimer());
    }

    private IEnumerator AngerTimer()
    {
        AngerSlider.value += 1;
        if (AngerSlider.value == AngerSlider.maxValue)
        {
            health.DeathBecome();
        }
        if (AngerSlider.value == 85)
        {
            animLight.SetTrigger("LightOn");
        }
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(AngerTimer());
    }


    public void TryUseGarlic()
    {
        if (garlic.Garlics > 0)
        {
            AS.PlayOneShot(AC);
            garlic.Garlics--;
            garlic.GarlicsText.text = garlic.Garlics.ToString();
            AngerSlider.value = 0;
        }
    }
}
