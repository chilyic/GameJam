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

    public float[] _cource;
    public float _balance = 100;

    private void Awake()
    {
        _line.positionCount = 2;
    }

    public void Buy()
    {
        DrawLine();
        _balanceTxt.text = "0";
    }

    public void Sell()
    {
        DrawLine();
        _balanceTxt.text = $"{_balance + _cource[0] / 10}";
    }

    public void DrawLine()
    {
        _cource = _graphic.GetCource();
        foreach (var point in _points) point.position = new Vector3(point.position.x, _cource[1], point.position.z);
        for (int i = 0; i < _points.Length; i++)
        {
            _line.SetPosition(i, _points[i].position);
        }
    }
}
