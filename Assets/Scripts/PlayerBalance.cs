using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBalance : MonoBehaviour
{
    [SerializeField] private GraphicController _graphic;
    [SerializeField] private TMP_Text _balanceTxt;
    [SerializeField] private LineRenderer _line;
    [SerializeField] private Transform[] _points;

    private float _cource;
    private float _balance = 5000;
    private float _currency;

    private void Awake()
    {
        _line.positionCount = 2;
    }

    public void Buy()
    {
        DrawLine();        
        _balance = _currency / _cource;
        _balanceTxt.text = $"{_balance}";
    }

    public void Sell()
    {
        DrawLine();
        _balanceTxt.text = "0";
        _currency = _balance * _cource;
    }

    public void DrawLine()
    {
        _cource = _graphic.GetCource();
        foreach (var point in _points) point.position = new Vector3(point.position.x, _cource, point.position.z);
        for (int i = 0; i < _points.Length; i++)
        {
            _line.SetPosition(i, _points[i].position);
        }
    }
}