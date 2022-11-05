using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Health : MonoBehaviour
{

    private int Hpoints;
    [SerializeField]
    private TMPro.TMP_Text HealthText;
    // Start is called before the first frame update
    void Start()
    {
        Hpoints = 10;
        HealthText.text = Hpoints.ToString();
    }

    public void ChangeHpoints(int value)
    {
        Hpoints += value;
        if (Hpoints < 0)
        {
            Hpoints = 0;
        }
        HealthText.text = Hpoints.ToString();
        if (Hpoints < 0)
        {
            DeathBecome();
        }
        else if (Hpoints>100)
        {
            WinBecome();
        }
    }

    public int CurrentHP()
    {
        return Hpoints;
    }

    public void DeathBecome()
    {

    }
    public void WinBecome()
    {

    }
}
