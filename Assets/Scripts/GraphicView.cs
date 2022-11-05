using System.Collections.Generic;
using UnityEngine;

public class GraphicView : MonoBehaviour
{
    [SerializeField] private GraphicController _graphic;
    [SerializeField] private RectTransform _graphicRect;

    private List<Transform> _points;

    private void Start()
    {
        _points = _graphic.Points;
        GraphicController.addPoint += MoveGraphic;
    }

    public void MoveGraphic()
    {
        foreach (var point in _points)
        {
            point.transform.position = new Vector3(point.position.x - 0.2f, point.position.y, point.position.z);
        }
    }
}
