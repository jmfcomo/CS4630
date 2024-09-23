using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{

    LineRenderer triRender;
    LineRenderer polyRender;
    // Start is called before the first frame update
    void Start()
    {
        triRender = GameObject.Find("Triangle").GetComponent<LineRenderer>();
        polyRender = GameObject.Find("Polygon").GetComponent<LineRenderer>();

        Vector3 p1 = new Vector3(0, 0, 0);
        Vector3 p2 = new Vector3(3, 0, 0);
        Vector3 p3 = new Vector3(5, 5, 0);
        Vector3[] points = { p1, p2, p3 };
        DrawTriangle(points, .2f, .15f, triRender);

        Vector3 center = new Vector3(-3, 5, 0);
        DrawPolygon(5, 2, center, .2f, .2f, polyRender);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 center = new Vector3(-3, 5, 0);
            DrawPolygon(5, 1, center, .1f, .1f, triRender);
        }
    }

    void DrawTriangle(Vector3[] vertexPositions, float startWidth, float endWidth, LineRenderer lineRenderer)
    {
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;
        lineRenderer.loop = true;
        lineRenderer.positionCount = 3;
        lineRenderer.SetPositions(vertexPositions);
    }

    void DrawPolygon(int vertexNumber, float radius, Vector3 centerPos, float startWidth, float endWidth, LineRenderer lineRenderer)
    {
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;
        lineRenderer.loop = true;
        float angle = 2 * Mathf.PI / vertexNumber;
        lineRenderer.positionCount = vertexNumber;

        for (int i = 0; i < vertexNumber; i++)
        {
            Matrix4x4 rotationMatrix = new Matrix4x4(new Vector4(Mathf.Cos(angle * i), Mathf.Sin(angle * i), 0, 0),
                                                     new Vector4(-1 * Mathf.Sin(angle * i), Mathf.Cos(angle * i), 0, 0),
                                       new Vector4(0, 0, 1, 0),
                                       new Vector4(0, 0, 0, 1));
            Vector3 initialRelativePosition = new Vector3(0, radius, 0);
            lineRenderer.SetPosition(i, centerPos + rotationMatrix.MultiplyPoint(initialRelativePosition));

        }
    }
}
