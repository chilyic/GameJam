using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicController : MonoBehaviour
{
    [SerializeField] private GraphicView _view;
    [SerializeField] private LineRenderer _currentCource;
    [SerializeField] private Transform[] _courcePoints;
    [SerializeField] private int _multyple = 0;
    [SerializeField] private Transform _point;
    [SerializeField] private List<Transform> _points;

    private LineRenderer _line;

    public List<Transform> Points { get => _points; set => _points = value; }

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
        _line.positionCount = _points.Count;

        _currentCource.positionCount = 2;

        InvokeRepeating(nameof(AddPoint), 0, 2);
    }

    private void Update()
    {
        for (int i = 0; i < _points.Count; i++)
        {
            _line.SetPosition(i, _points[i].position);
        }

        for (int i = 0; i < _courcePoints.Length; i++)
        {
            _currentCource.SetPosition(i, _courcePoints[i].position);
        }
    }

    public void AddPoint()
    {
        Vector3 newPos = _points[_points.Count - 1].position;
        newPos.y += Random.Range(-40, 40) + _multyple;

        //if (newPos.y > 220 || newPos.y < 220)
        //{
        //    _view.CorrectScale();
        //}

        newPos.x += 30;
        Transform point = Instantiate(_point, newPos, Quaternion.identity, transform);
        _line.positionCount++;
        _points.Add(point);

        foreach (var points in _courcePoints) points.position = new Vector3(points.position.x, newPos.y, points.position.z);

        if (_points.Count > 25)
        {
            _view.MoveGraphic();
            DestroyPoint();
        }
    }

    public void DestroyPoint()
    {
        Destroy(_points[0].gameObject);
        _points.Remove(_points[0]);
        _line.positionCount--;
    }
}
