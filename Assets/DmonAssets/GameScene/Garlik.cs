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


    [SerializeField] PlayerBalance playerBalance;
    private void Start()
    {
        Garlics = 1;
        GarlicsText.text = Garlics.ToString();
    }

    public void TryBuyGarlic()
    {
        if (health.CurrentHP() - goblin.GarlicCost > 0 && goblin.IsActiveToBuy && playerBalance.CanBuy())
        {
            AS.PlayOneShot(G2);
            health.ChangeHpoints(-goblin.GarlicCost);
            Garlics++;
            GarlicsText.text = Garlics.ToString();
        }
        else if (!goblin.IsActiveToBuy)
        {
            print("Упс, гоблин уже не активен");
        }
        else if (!playerBalance.CanBuy())
        {
            print("Нельзя купить, вы инвестировали деньги");
        }
        else if(health.CurrentHP() - goblin.GarlicCost <= 0)
        {
            print("У вас недостаточно крови");
        }

    }
}
