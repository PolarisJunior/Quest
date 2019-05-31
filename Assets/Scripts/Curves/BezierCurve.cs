using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System;

public class BezierCurve : MonoBehaviour
{
    public int pointDensity = 4;

    public string inFile;
    public string outFile;

    private float delta;

    private string directory = "Assets/Paths/";

    private delegate List<Vector3> PointsTransform(List<Vector3> points);

    // Start is called before the first frame update
    void Start()
    {
        delta = 1f / pointDensity;

        if (!string.IsNullOrEmpty(inFile) && !string.IsNullOrEmpty(outFile))
        {
            TransformFromFile(inFile, outFile, TransformPointsCubic);
        }
    }

    void TransformFromFile(string inFileName, string outFileName, PointsTransform func)
    {
        string path = directory + inFileName + ".txt";

        List<Vector3> fileVertices = new List<Vector3>();

        StreamReader reader = new StreamReader(path);
        string line;
        while (!reader.EndOfStream)
        {
            line = reader.ReadLine();

            var tokens = line.Split(',');
            var v = new Vector3(float.Parse(tokens[0]), float.Parse(tokens[1]), float.Parse(tokens[2]));

            fileVertices.Add(v);
        }
        reader.Close();

        List<Vector3> transformed = func(fileVertices);

        StreamWriter writer = new StreamWriter(directory + outFileName + ".txt", false);
        foreach (var v in transformed)
        {
            writer.WriteLine(v.x + "," + v.y + "," + v.z);
        }

        writer.Close();
    }

    public Vector3 QuadraticTransform(Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        Vector3 l1 = Vector3.Lerp(p1, p2, t);
        Vector3 l2 = Vector3.Lerp(p2, p3, t);
        return Vector3.Lerp(l1, l2, t);
    }

    public Vector3 CubicTransform(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, float t)
    {
        Vector3 m1 = Vector3.Lerp(p1, p2, t);
        Vector3 m2 = Vector3.Lerp(p2, p3, t);
        Vector3 m3 = Vector3.Lerp(p3, p4, t);
        return QuadraticTransform(m1, m2, m3, t);
    }

    List<Vector3> TransformPointsQuad(List<Vector3> points)
    {
        List<Vector3> res = new List<Vector3>();

        for (int i = 0; i < points.Count - 2; i += 2)
        {
            Vector3 p1 = points[i];
            Vector3 p2 = points[i + 1];
            Vector3 p3 = points[i + 2];

            for (int j = 0; j < pointDensity; j++)
            {
                float t = j * delta;
                res.Add(QuadraticTransform(p1, p2, p3, t));
            }
        }

        return res;
    }

    public List<Vector3> TransformPointsCubic(List<Vector3> points)
    {
        List<Vector3> res = new List<Vector3>();

        for (int i = 0; i < points.Count - 3; i += 3)
        {
            Vector3 p1 = points[i];
            Vector3 p2 = points[i + 1];
            Vector3 p3 = points[i + 2];
            Vector3 p4 = points[i + 3];

            for (int j = 0; j < pointDensity; j++)
            {
                float t = j * delta;
                res.Add(CubicTransform(p1, p2, p3, p4, t));
            }
        }

        return res;
    }
}
