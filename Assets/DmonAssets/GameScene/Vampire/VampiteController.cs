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
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(AngerTimer());
    }


    public void TryUseGarlic()
    {
        if (garlic.Garlics > 0)
        {
            garlic.Garlics--;
            garlic.GarlicsText.text = garlic.Garlics.ToString();
            AngerSlider.value = 0;
        }
    }
}
