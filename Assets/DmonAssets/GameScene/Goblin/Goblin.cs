using System.Collections;
using UnityEngine;
using UnityEngine.UI;
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
    // Start is called before the first frame update
    void Start()
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
        IsActiveToBuy = true;
        anim.SetTrigger("Come");
        print("Come");
    }
    private void GoblinOut()
    {
        IsActiveToBuy = false;
        anim.SetTrigger("Out");
        print("Out");
    }
}
