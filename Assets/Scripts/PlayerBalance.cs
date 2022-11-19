using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerBalance : MonoBehaviour
{
    [SerializeField] private float _balance = 5000;
    [SerializeField] private GraphicController _graphic;

    [SerializeField] private TMP_Text _balanceTxt;
    [SerializeField] private Transform[] _points;

    [SerializeField] private Health health;


    [SerializeField] TMP_Text BtnInvestText;
    [SerializeField] Image BtnInvest;
    [SerializeField] Sprite RedBtn;
    [SerializeField] Sprite BlueBtn;

    [SerializeField]private SpriteRenderer spriteRenderer;

    private float _cource;
    public float _currency;

    public float Balance { get => _balance; set => _balance = value; }

    private void Start()
    {
        BtnInvest.sprite = RedBtn;
        BtnInvestText.text = "Вложить";
        spriteRenderer.color = new Color(0.6352941f, 0.07058824f, 0);
    }
    public void Sell()
    {
        //_cource = _graphic.GetCource();
        //DrawLine();

        //_balance += (_currency / _cource) - (_balance / 2);
        //_balanceTxt.text = $"{_balance}";

        // health.ChangeHpoints((_currency / _cource) + (_balance / 2));
        health.ChangeHpoints(500);
        _balanceTxt.text = _balance.ToString();

        BtnInvest.sprite = RedBtn;
        BtnInvestText.text = "Вложить";
        spriteRenderer.color = new Color(0.6352941f, 0.07058824f, 0);
    }

    public void Buy()
    {
        //_cource = _graphic.GetCource();
        // DrawLine();
       // _currency = (_balance / 2) * _cource;
        _balanceTxt.text = "В банке";

        BtnInvest.sprite = BlueBtn;
        BtnInvestText.text = "Забрать";
        spriteRenderer.color = new Color(0.4f, 0.4078432f, 0.682353f);
    }

    public bool CanBuy()
    {
        if(BtnInvestText.text == "Вложить")
        {
            return false;
        }
        return true;
    }
    public void DrawLine()
    {
       // _cource = _graphic.GetCource();
       // foreach (var point in _points) point.position = new Vector3(point.position.x, _cource, point.position.z);
    }
}