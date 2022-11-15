using System;
using System.Collections.Generic;
using UnityEngine;

public class GraphicController : MonoBehaviour
{
    public float Speed=1; 
    [SerializeField] private LineRenderer _currentCource;
    [SerializeField] private Transform[] _courcePoints;
    [SerializeField] private int _multyple = 0;
    [SerializeField] private Transform _point;
    [SerializeField] private List<Transform> _points;

    private LineRenderer _line;

    public static Action addPoint;

    public List<Transform> Points { get => _points; set => _points = value; }

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
        _line.positionCount = _points.Count;

        _currentCource.positionCount = 2;

        PlayGraphic();
    }

    public void AddPoint()
    {
        Vector3 newPos = _points[_points.Count - 1].position;
        float r = UnityEngine.Random.Range(-100, 100);
        if (r < 0 && r>-10)
        {
            r = r - UnityEngine.Random.Range(40, 80);
        }
        if(r>0 && r < 10)
        {
            r = r + UnityEngine.Random.Range(10, 90);
        }
        float rand = (r + _multyple) / 100;

        newPos.y += rand;
        if (newPos.y > 3.9f || newPos.y < 1.8f)
        {
            newPos.y += -2 * rand;
        }

        newPos.x += 0.2f;
        Transform point = Instantiate(_point, newPos, Quaternion.identity);

        _line.positionCount++;
        _points.Add(point);
        foreach (var points in _courcePoints) points.position = new Vector3(points.position.x, newPos.y, points.position.z);
        for (int i = 0; i < _courcePoints.Length; i++)
        {
            _currentCource.SetPosition(i, _courcePoints[i].position);
        }

        if (_points.Count > 25)
        {
            addPoint.Invoke();
            DestroyPoint();
        }


        
        for (int i = 0; i < _points.Count; i++)
        {
            _line.SetPosition(i, _points[i].position);
        }
    }

    public void DestroyPoint()
    {
        Destroy(_points[0].gameObject);
        _points.Remove(_points[0]);
        _line.positionCount--;
    }

    public float GetCource()
    {
        return _points[_points.Count - 1].gameObject.transform.position.y;
    }
    
    public void StopGraphic()
    {
        CancelInvoke(nameof(AddPoint));
    }
    
    public void PlayGraphic()
    {
        InvokeRepeating(nameof(AddPoint), 0, Speed);
    }
}
