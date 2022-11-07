using UnityEngine;
using TMPro;

public class Garlik : MonoBehaviour
{
    public int Garlics;
    public TMP_Text GarlicsText;
    [SerializeField]
    private Goblin goblin;
    [SerializeField]
    private Health health;

    [SerializeField]
    private AudioClip G2;
    [SerializeField]
    private AudioSource AS;
    private void Start()
    {
        Garlics = 1;
        GarlicsText.text = Garlics.ToString();
    }

    public void TryBuyGarlic()
    {
        if (health.CurrentHP() - goblin.GarlicCost > 0 && goblin.IsActiveToBuy)
        {
            AS.PlayOneShot(G2);
            health.ChangeHpoints(-goblin.GarlicCost);
            Garlics++;
            GarlicsText.text = Garlics.ToString();
        }
    }
}
