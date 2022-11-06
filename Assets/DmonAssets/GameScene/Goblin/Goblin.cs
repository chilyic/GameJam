using System.Collections;
using UnityEngine;
using TMPro;

public class Goblin : MonoBehaviour
{

    public bool IsActiveToBuy;
    public float GarlicCost;
    [SerializeField]
    private TMP_Text GarlicCostText;

    [SerializeField]
    private float StayTime;
    [SerializeField]
    private float MinTime;
    [SerializeField]
    private float MaxTime;

    private Animator anim;



    [SerializeField]
    private AudioClip G1;
    [SerializeField]
    private AudioClip G2;
    [SerializeField]
    private AudioSource AS;

private void Start()
    {
        IsActiveToBuy = false;
        GarlicCostText.text = GarlicCost.ToString();
        anim = gameObject.GetComponent<Animator>();
        StartCoroutine(GoblinBecome());
    }

    private IEnumerator GoblinBecome()
    {
        yield return new WaitForSeconds(Random.Range(MinTime, MaxTime));
        GoblinCome();
        yield return new WaitForSeconds(StayTime);
        GoblinOut();
        StartCoroutine(GoblinBecome());
    }

    private void GoblinCome()
    {
        if (Random.Range(0, 100) > 50)
        {
            AS.PlayOneShot(G1);
        }
        else
        {
            AS.PlayOneShot(G2);
        }
        IsActiveToBuy = true;
        anim.SetTrigger("Come");
        //print("Come");
    }
    private void GoblinOut()
    {
        IsActiveToBuy = false;
        anim.SetTrigger("Out");
        //print("Out");
    }
}
