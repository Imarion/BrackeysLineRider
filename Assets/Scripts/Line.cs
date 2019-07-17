using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCol;    

    List<Vector2> points;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLine(Vector2 mousePos)
    {
        if (points==null)
        {
            points = new List<Vector2>();
            SetPoint(mousePos);
            return;
        }

        // Check if the mouse has moved enough to insert new point
        // If it has, insert a point at mouse position
        if (Vector2.Distance(points.Last(), mousePos) > .1f)
        {
            SetPoint(mousePos);
        }

    }

    void SetPoint(Vector2 point)
    {
        points.Add(point);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

        if (points.Count > 1)
        {
            edgeCol.points = points.ToArray();
        }
    }
}
