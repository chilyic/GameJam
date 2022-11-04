using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicView : MonoBehaviour
{
    [SerializeField] private GraphicController _graphic;
    [SerializeField] private RectTransform _graphicRect;

    public List<Transform> _points;

    private void Start()
    {
        _points = _graphic.Points;
    }

    public void CorrectScale()
    {
        if (_points[_points.Count - 1].position.y > 220 && 
            _points[_points.Count - 1].position.y >_points[_points.Count - 2].position.y)
        {
            _graphicRect.localScale = new Vector3(1, _graphicRect.localScale.y - 0.1f, 1);
        }

        if (_points[_points.Count - 1].position.y < -220 &&
            _points[_points.Count - 1].position.y < _points[_points.Count - 2].position.y)
        {
            _graphicRect.localScale = new Vector3(1, _graphicRect.localScale.y - 0.1f, 1);
        }
    }

    public void MoveGraphic()
    {
        //if (_points[0].position.y > 220)            
        //{
        //    _graphicRect.localScale = new Vector3(1, _graphicRect.localScale.y + 0.1f, 1);
        //}

        //if (_points[0].position.y < -220)            
        //{
        //    _graphicRect.localScale = new Vector3(1, _graphicRect.localScale.y + 0.1f, 1);
        //}
        
        foreach (var point in _points)
        {
            point.transform.position = new Vector3(point.position.x - 30, point.position.y, point.position.z);
        }
    }
}
