using System.Collections.Generic;
using UnityEngine;

public class GraphicView : MonoBehaviour
{
    [SerializeField] private GraphicController _graphic;

    private List<Transform> _points;
    [SerializeField] private GameObject MainDot;

    private bool IsMoveing;
    private void Awake()
    {
        _points = _graphic.Points;
        GraphicController.addPoint += MoveGraphic;
    }

    public void MoveGraphic()
    {
        IsMoveing = true;
    }

    private void Update()
    {
        if (IsMoveing)
        {
            foreach (var point in _points)
            {
                
                point.transform.position = new Vector3(point.position.x - 0.4f * Time.deltaTime/ _graphic.Speed, point.position.y, point.position.z);
            }
            MainDot.transform.position = new Vector3(MainDot.transform.position.x - 0.4f * Time.deltaTime / _graphic.Speed, MainDot.transform.position.y, MainDot.transform.position.z);

        }
    }
}
