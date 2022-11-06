using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    [SerializeField] PlayerBalance _balance;

    //private float Hpoints;
    [SerializeField]
    private TMP_Text HealthText;
    // Start is called before the first frame update
    void Start()
    {
        //Hpoints = _balance.Balance;
        HealthText.text = _balance.Balance.ToString();
    }

    public void ChangeHpoints(float value)
    {
        _balance.Balance += value;
        if (_balance.Balance < 0)
        {
            _balance.Balance = 0;
        }
        HealthText.text = _balance.Balance.ToString();
        if (_balance.Balance < 0)
        {
            DeathBecome();
        }
        else if (_balance.Balance > 10000)
        {
            WinBecome();
        }
    }

    public float CurrentHP()
    {
        return _balance.Balance;
    }

    public void DeathBecome()
    {
        SceneManager.LoadScene(2);
    }
    public void WinBecome()
    {
        SceneManager.LoadScene(3);
    }
}
