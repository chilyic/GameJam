using System;
using System.Collections.Generic;
using UnityEngine;

public class GraphicController : MonoBehaviour
{
    public float Speed = 1;
   // [SerializeField] private LineRenderer _currentCource;
    public List<Transform> _points;

    private LineRenderer _line;

    public static Action addPoint;

    public Transform _point;
    public Transform _point1;
    public Transform _point2;

    public List<Transform> Points { get => _points; set => _points = value; }

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
        _line.positionCount = _points.Count;

        // _currentCource.positionCount = 2;

        PlayGraphic();

        for (int i = 0; i < 18; i++)
        {
            AddPoint();
        }
    }

    private Vector3 newPos;
    private void Update()
    {

        if(_points[0].gameObject.transform.position.x< -0.76f)
        {
            DestroyPoint();
        }



        /*
        if (newPos.y > 3.9f || newPos.y < 1.8f)
        {
            newPos.y += -2 * rand;
        }
        */
        newPos.x += 1 * Time.deltaTime;
       // _currentCource.SetPosition(i, _courcePoints[i].position);



        for (int j = 0; j < _points.Count; j++)
        {
            _line.SetPosition(j, _points[j].position);
        }
    }


    private bool IsBuy = false;
    private int StayWait = 0;
    public void AddPoint()
    {
        Transform point;
        if (StayWait == 0)
        {
            if (IsBuy)
            {
                newPos = _points[_points.Count - 1].position;
                float r = UnityEngine.Random.Range(-125, -75);
                float rand = (r) / 100;
                newPos.y = rand + 2.85f;
                newPos.x += 0.4f;
                point = Instantiate(_point1, newPos, Quaternion.identity);
            }
            else
            {
                newPos = _points[_points.Count - 1].position;
                float r = UnityEngine.Random.Range(75, 125);
                float rand = (r) / 100;
                newPos.y = rand + 2.85f;
                newPos.x += 0.4f;
                point = Instantiate(_point2, newPos, Quaternion.identity);
            }
            StayWait = UnityEngine.Random.Range(3,9);
            IsBuy = !IsBuy;
        }
        else
        {
            newPos = _points[_points.Count - 1].position;
            float r = UnityEngine.Random.Range(-75, 75);
            float rand = (r) / 100;
            newPos.y = rand + 2.85f;
            newPos.x += 0.4f;
            point = Instantiate(_point, newPos, Quaternion.identity);
            StayWait--;
        }



        _line.positionCount++;
        _points.Add(point);
        _line.SetPosition(_points.Count-1, _points[_points.Count-1].position);       

       
        if (_points.Count > 18)
        {
            addPoint.Invoke();
           // DestroyPoint();
        }


    }

    public void DestroyPoint()
    {
        Destroy(_points[0].gameObject);
        _points.Remove(_points[0]);
        _line.positionCount--;
        AddPoint();
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
        //InvokeRepeating(nameof(AddPoint), 0, Speed);
    }
}
