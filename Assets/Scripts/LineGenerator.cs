using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineGenerator : Graphic
{
    [SerializeField] private Vector2Int _gridSize;
    [SerializeField] private float _thickness = 10f;
    [SerializeField] private List<Vector2> _points;

    private float _width;
    private float _height;
    private float _unitWidth;
    private float _unitHeight;

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        _width = rectTransform.rect.width;
        _height = rectTransform.rect.height;

        _unitWidth = _width / _gridSize.x;
        _unitHeight = _height / _gridSize.y;

        for (int i = 0; i < _points.Count; i++)
        {
            Vector2 point = _points[i];
            DrowVerticesForPoint(point, _thickness, vh);
        }

        for (int i = 0; i < _points.Count - 1; i++)
        {
            int index = i * 2;
            vh.AddTriangle(index + 0, index + 1, index + 3);
            vh.AddTriangle(index + 3, index + 2, index + 0);
        }
    }

    private void DrowVerticesForPoint(Vector2 point, float thickness, VertexHelper vh)
    {
        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;
        

        vertex.position = new Vector3(-_thickness / 2, 0);
        vertex.position += new Vector3(_unitWidth * point.x, _unitHeight * point.y);
        vh.AddVert(vertex);

        vertex.position = new Vector3(_thickness / 2, 0);
        vertex.position += new Vector3(_unitWidth * point.x, _unitHeight * point.y);
        vh.AddVert(vertex);
    }
}
