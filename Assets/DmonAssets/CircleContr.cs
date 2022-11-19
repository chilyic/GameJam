using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleContr : MonoBehaviour
{
    [SerializeField]  private bool IsCollisionDot1 = false;
    [SerializeField]  private bool IsCollisionDot2 = false;
    [SerializeField]  private bool BuyCheap = true;

    [SerializeField] GraphicController graphicController;
    [SerializeField] PlayerBalance playerBalance;


    private void Start()
    {
       // transform.position = graphicController._points[6].position;
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, graphicController._points[7].position, (graphicController._points[7].position - graphicController._points[6].position).magnitude *Time.deltaTime/graphicController.Speed);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dot1")
        {
            IsCollisionDot1 = true;
        }
        if (collision.gameObject.tag == "Dot2")
        {
            IsCollisionDot2 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dot1")
        {
            IsCollisionDot1 = false;
        }
        if (collision.gameObject.tag == "Dot2")
        {
            IsCollisionDot2 = false;
        }
    }

    public void OnClick(){
        if (IsCollisionDot1)
        {
            if (BuyCheap)
            {
                playerBalance.Buy();
                BuyCheap = false;
                print("Успех!");
            }
            else
            {
                print("Инвестировать нужно когда цена низкая");
                
            }
        }
        else if (IsCollisionDot2)
        {
            if (BuyCheap)
            {
                print("Забирать инвестиции нужно когда их цена высока");
            }
            else
            {
                playerBalance.Sell();
                BuyCheap = true;
                print("Успех!");
            }
        }
        else {
            print("Вы тыкнули не туда");
        }
    }
}
