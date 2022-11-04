using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    [SerializeField] private int _multyple = 0;
    [SerializeField] private Transform _point;
    [SerializeField] private List<Transform> _points;

    private LineRenderer _line;

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
        _line.positionCount = _points.Count;
        InvokeRepeating(nameof(AddPoint), 0, 2);
    }

    private void Update()
    {
        for (int i = 0; i < _points.Count; i++)
        {
            _line.SetPosition(i, _points[i].position);
        }
    }

    private void AddPoint()
    {
        Vector3 newPos = _points[_points.Count - 1].position;
        newPos.y += Random.Range(-40, 40) + _multyple;
        newPos.x += 10;
        Transform point = Instantiate(_point, newPos, Quaternion.identity, transform);
        _line.positionCount++;
        _points.Add(point);
    }
}
