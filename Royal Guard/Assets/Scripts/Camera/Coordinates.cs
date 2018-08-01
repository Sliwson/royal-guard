using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinates : MonoBehaviour {

    private Dictionary<Corner, Vector3> corners = new Dictionary<Corner, Vector3>();

    private void Start()
    {
        InitializeDictionary();
    }

    public Vector2 GetCameraCorner(Corner corner)
    {
        if (corners.ContainsKey(corner))
            return corners[corner];
        else
            return Vector3.zero;
    }

    private void InitializeDictionary()
    {
        Camera camera = Camera.main;

        corners.Add(Corner.LeftBottom, camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane)));
        corners.Add(Corner.LeftTop, camera.ViewportToWorldPoint(new Vector3(0, 1, camera.nearClipPlane)));
        corners.Add(Corner.RightBottom, camera.ViewportToWorldPoint(new Vector3(1, 0, camera.nearClipPlane)));
        corners.Add(Corner.RightTop, camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane)));
    }

    private void CalculateCorners()
    {
        Camera camera = Camera.main;

        corners[Corner.LeftBottom] = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        corners[Corner.LeftTop] = camera.ViewportToWorldPoint(new Vector3(0, 1, camera.nearClipPlane));
        corners[Corner.RightBottom] = camera.ViewportToWorldPoint(new Vector3(1, 0, camera.nearClipPlane));
        corners[Corner.RightTop] = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
    }
}
