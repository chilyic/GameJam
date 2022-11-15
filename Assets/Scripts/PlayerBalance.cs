using UnityEngine;
using TMPro;

public class PlayerBalance : MonoBehaviour
{
    [SerializeField] private float _balance = 5000;
    [SerializeField] private GraphicController _graphic;

    [SerializeField] private TMP_Text _balanceTxt;
    [SerializeField] private LineRenderer _BuySellLine;
    [SerializeField] private Transform[] _points;

    [SerializeField] private Health health;



    private float _cource;
    public float _currency;

    public float Balance { get => _balance; set => _balance = value; }

    private void Awake()
    {
        _BuySellLine.positionCount = 2;
    }

    public void Buy()
    {
        _BuySellLine.enabled = false;
        DrawLine();

        //_balance += (_currency / _cource) - (_balance / 2);
        //_balanceTxt.text = $"{_balance}";

        health.ChangeHpoints((_currency / _cource) - (_balance / 2));
        _balanceTxt.text = _balance.ToString();

    }

    public void Sell()
    {
        _BuySellLine.enabled = true;
        DrawLine();
        _currency = (_balance / 2) * _cource;
        _balanceTxt.text = "� �����";
       
    }

    public void DrawLine()
    {
        _cource = _graphic.GetCource();
        foreach (var point in _points) point.position = new Vector3(point.position.x, _cource, point.position.z);
        for (int i = 0; i < _points.Length; i++)
        {
            _BuySellLine.SetPosition(i, _points[i].position);
        }
    }
}