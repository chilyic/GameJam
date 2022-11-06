using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
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
        HealthText.text = ((int)(_balance.Balance)).ToString();
        StartCoroutine(AwtoWin());
    }

    private IEnumerator AwtoWin()
    {
        yield return new WaitForSeconds(60*5);
        WinBecome();
    }

        public void ChangeHpoints(float value)
    {
       
        _balance.Balance -= value;
        if (_balance.Balance < 0)
        {
            _balance.Balance = 0;
        }
        HealthText.text = ((int)(_balance.Balance)).ToString();
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
