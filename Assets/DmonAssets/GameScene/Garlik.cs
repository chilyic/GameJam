using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Garlik : MonoBehaviour
{
    public int Garlics;
    public TMPro.TMP_Text GarlicsText;
    [SerializeField]
    private Goblin goblin;
    [SerializeField]
    private Health health;

    private void Start()
    {
        Garlics = 0;
        GarlicsText.text = Garlics.ToString();
    }
    public void TryBuyGarlic()
    {
        if (health.CurrentHP() - goblin.GarlicCost > 0 && goblin.IsActiveToBuy)
        {
            health.ChangeHpoints(-goblin.GarlicCost);
            Garlics++;
            GarlicsText.text = Garlics.ToString();
        }
    }
}
