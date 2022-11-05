using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridRenderer : Graphic
{
    [SerializeField] private Vector2Int _gridSize = new(1, 1);
    [SerializeField] private float _thickness = 10f;

    public float _width;
    public float _height;
    public float _cellWidth;
    public float _cellHeight;

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        _width = rectTransform.rect.width;
        _height = rectTransform.rect.height;

        _cellWidth = _width / _gridSize.x;
        _cellHeight = _height / _gridSize.y;

        int count = 0;
        for (int y = 0; y < _gridSize.y; y++)
        {
            for (int x = 0; x < _gridSize.x; x++)
            {
                DrowCell(x, y, count, vh);
                count++;
            }
        }
    }

    private void DrowCell(int x, int y, int index, VertexHelper vh)
    {
        float xPos = _cellWidth * x;
        float yPos = _cellHeight * y;

        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        vertex.position = new Vector3(xPos, yPos);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos, yPos + _cellHeight);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + _cellWidth, yPos + _cellHeight);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + _cellWidth, yPos);
        vh.AddVert(vertex);

        //vh.AddTriangle(0, 1, 2);
        //vh.AddTriangle(2, 3, 0);

        float widthSqr = _thickness * _thickness;
        float distanceSqr = widthSqr / 2f;
        float distance = Mathf.Sqrt(distanceSqr);

        vertex.position = new Vector3(xPos + distance, yPos + distance);
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + distance, yPos + (_height - distance));
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + (_width - distance), yPos + (_height - distance));
        vh.AddVert(vertex);

        vertex.position = new Vector3(xPos + (_width - distance), yPos + distance);
        vh.AddVert(vertex);

        int offset = index * 8;

        vh.AddTriangle(offset + 0, offset + 1, offset + 5);
        vh.AddTriangle(offset + 5, offset + 4, offset + 0);

        vh.AddTriangle(offset + 1, offset + 2, offset + 6);
        vh.AddTriangle(offset + 6, offset + 5, offset + 1);

        vh.AddTriangle(offset + 2, offset + 3, offset + 7);
        vh.AddTriangle(offset + 7, offset + 6, offset + 2);

        vh.AddTriangle(offset + 3, offset + 0, offset + 4);
        vh.AddTriangle(offset + 4, offset + 7, offset + 3);
    }
}
