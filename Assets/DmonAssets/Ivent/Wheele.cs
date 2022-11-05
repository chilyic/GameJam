using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Wheele : MonoBehaviour
{

    private int numberOfWheeles;
    public int whatWeWin;
    private float speed;
    private bool canWeTurn;
    [SerializeField]
    private TMPro.TMP_Text winningText;
    // Start is called before the first frame update
    void Start()
    {
        canWeTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canWeTurn == true)
        {
            StartCoroutine(TurnTheWheele());
        }
    }

    private IEnumerator TurnTheWheele()
    {
        canWeTurn = false;
        numberOfWheeles = Random.Range(40, 70);
        speed = 0.02f;
        for(int i=0; i<numberOfWheeles; i++)
        {
            transform.Rotate(0, 0, 22.5f);

            if (i > Mathf.RoundToInt(numberOfWheeles * 0.5f))
            {
                speed = 0.05f;
            }
            else if (i > Mathf.RoundToInt(numberOfWheeles * 0.7f))
            {
                speed = 0.07f;
            }
            else if (i > Mathf.RoundToInt(numberOfWheeles * 0.9f))
            {
                speed = 0.1f;
            }

            yield return new WaitForSeconds(speed);
        }

        if(Mathf.RoundToInt(transform.eulerAngles.z) % 45 != 0)
        {
            transform.Rotate(0, 0, 22.5f);
        }

        whatWeWin = Mathf.RoundToInt(transform.eulerAngles.z);
        switch (whatWeWin)
        {
            case 0:
                winningText.text = "1";
                break;
            case 45:
                winningText.text = "2";
                break;
            case 90:
                winningText.text = "3";
                break;
            case 135:
                winningText.text = "4";
                break;
            case 180:
                winningText.text = "5";
                break;
            case 225:
                winningText.text = "6";
                break;
            case 270:
                winningText.text = "7";
                break;
            case 315:
                winningText.text = "8";
                break;
        }


        //canWeTurn = true;
    }
}
