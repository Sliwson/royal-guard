using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinates : MonoBehaviour {

    private static Dictionary<Corner, Vector3> corners = new Dictionary<Corner, Vector3>();

    private void Start()
    {
        InitializeDictionary();
        CalculateCorners();
    }

    public static Vector2 GetCameraCorner(Corner corner)
    {
        if (corners.ContainsKey(corner))
            return corners[corner];
        else
            return Vector3.zero;
    }

    public static Dictionary<Corner, Vector3> GetDictionary()
    {
        return corners;
    }

    private void InitializeDictionary()
    {
        corners.Add(Corner.LeftBottom, Vector3.zero);
        corners.Add(Corner.LeftTop, Vector3.zero);
        corners.Add(Corner.RightBottom, Vector3.zero);
        corners.Add(Corner.RightTop, Vector3.zero);
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
