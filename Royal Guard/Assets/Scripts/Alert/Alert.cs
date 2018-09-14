using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class Alert : MonoBehaviour {

    [SerializeField]
    private float screenBorderOffset = 2f;

    [SerializeField]
    private ProjectilePositions[] ignoredPositions;

    private bool fadedOut = false;

    private Dictionary<Corner, Vector3> cameraCorners;
    private AlertAnimationController alertAnimationController;

    public void SpawnAlert(Transform projectileTransform)
    {
        cameraCorners = Coordinates.GetDictionary();

        ProjectilePositions position = CalculateProjectilePosition(projectileTransform);
        MoveAlert(projectileTransform, position);

        alertAnimationController = new AlertAnimationController(GetComponent<Animator>());
        FadeIn();
    }

    public void UpdateAlert(Transform projectileTransform)
    {
        ProjectilePositions position = CalculateProjectilePosition(projectileTransform);

        if(!ArrayUtility.Contains<ProjectilePositions>(ignoredPositions, position))
        {
            MoveAlert(projectileTransform, position);

            if (fadedOut && position != ProjectilePositions.OnCamera)
                FadeIn();
        }            

        if (!fadedOut && position == ProjectilePositions.OnCamera)
            FadeOut();
    }

    public void DestroyAlert()
    {
        Destroy(gameObject);
    }

    private ProjectilePositions CalculateProjectilePosition(Transform projectileTransform)
    {
        Vector3 leftTop = cameraCorners[Corner.LeftTop];
        Vector3 rightBottom = cameraCorners[Corner.RightBottom];

        Vector3 projectilePosition = projectileTransform.position;

        if (projectilePosition.x < leftTop.x)
        {
            if (projectilePosition.y > leftTop.y)
                return ProjectilePositions.LeftUp;
            else if (projectilePosition.y < rightBottom.y)
                return ProjectilePositions.LeftDown;
            else
                return ProjectilePositions.Left;
        }
        else if (projectilePosition.x > rightBottom.x)
        {
            if (projectilePosition.y > leftTop.y)
                return ProjectilePositions.RightUp;
            else if (projectilePosition.y < rightBottom.y)
                return ProjectilePositions.RightDown;
            else
                return ProjectilePositions.Right;
        }
        else
        {
            if (projectilePosition.y > leftTop.y)
                return ProjectilePositions.Up;
            else if (projectilePosition.y < rightBottom.y)
                return ProjectilePositions.Down;
            else
                return ProjectilePositions.OnCamera;
        }
    }

    private void MoveAlert(Transform projectileTransform, ProjectilePositions position)
    {
        RotateAlert(projectileTransform, position);

        PositionAlert(projectileTransform, position);
    }

    private void RotateAlert(Transform projectileTransform, ProjectilePositions position)
    {
        transform.rotation = CalculateRotation(projectileTransform, position);
    }

    private Quaternion CalculateRotation(Transform projectileTransform, ProjectilePositions position)
    {
        switch (position)
        {
            case ProjectilePositions.Down:
                return Quaternion.identity;
            case ProjectilePositions.Left:
                return Quaternion.Euler(0f, 0f, -90f);
            case ProjectilePositions.Up:
                return Quaternion.Euler(0f, 0f, 180f);
            case ProjectilePositions.Right:
                return Quaternion.Euler(0f, 0f, 90f);
            case ProjectilePositions.OnCamera:
                return transform.rotation;
            default:
                return CalculateCornerRotation(projectileTransform, position);

        }
    }

    private Quaternion CalculateCornerRotation(Transform projectileTransform, ProjectilePositions position)
    {
        Vector3 diffVector = ProjectilePositionToCameraCorner(position);

        Vector3 diff = projectileTransform.position - diffVector;
        diff.z = 0;

        float angle = Vector3.Angle(diff, Vector3.up) - 180;

        if (position == ProjectilePositions.RightUp || position == ProjectilePositions.RightDown)
            angle *= -1;

        return Quaternion.Euler(0f, 0f, angle);
    }        

    private Vector3 ProjectilePositionToCameraCorner(ProjectilePositions position)
    {
        switch (position)
        {
            case ProjectilePositions.LeftUp:
                return cameraCorners[Corner.LeftTop];
            case ProjectilePositions.LeftDown:
                return cameraCorners[Corner.LeftBottom];
            case ProjectilePositions.RightUp:
                return cameraCorners[Corner.RightTop];
            case ProjectilePositions.RightDown:
                return cameraCorners[Corner.RightBottom];
        }

        return Vector3.zero;
    }

    private void PositionAlert(Transform projectileTransform, ProjectilePositions position)
    {
        transform.position = CalculateTransformPosition(projectileTransform, position);
    }

    private Vector3 CalculateTransformPosition(Transform projectileTransform, ProjectilePositions position)
    {
        Vector3 leftTop = cameraCorners[Corner.LeftTop];
        Vector3 rightBottom = cameraCorners[Corner.RightBottom];

        float y = CutYCorners(projectileTransform.position.y, leftTop, rightBottom);
        float x = CutXCorners(projectileTransform.position.x, leftTop, rightBottom);

        switch (position)
        {
            case ProjectilePositions.Left:
                return new Vector3(leftTop.x + screenBorderOffset, y);
            case ProjectilePositions.Up:
                return new Vector3(x, leftTop.y - screenBorderOffset);
            case ProjectilePositions.Right:
                return new Vector3(rightBottom.x - screenBorderOffset, y);
            case ProjectilePositions.Down:
                return new Vector3(x, rightBottom.y + screenBorderOffset);
            case ProjectilePositions.OnCamera:
                return transform.position;
            default:
                return new Vector3(x, y);
        }
    }

    private float CutYCorners(float y, Vector3 leftTop, Vector3 rightBottom)
    {
        if (y > leftTop.y - screenBorderOffset)
            return leftTop.y - screenBorderOffset;
        else if (y < rightBottom.y + screenBorderOffset)
            return rightBottom.y + screenBorderOffset;
        else
            return y;
    }

    private float CutXCorners(float x, Vector3 leftTop, Vector3 rightBottom)
    {
        if (x < leftTop.x + screenBorderOffset)
            return leftTop.x + screenBorderOffset;
        else if (x > rightBottom.x - screenBorderOffset)
            return rightBottom.x - screenBorderOffset;
        else
            return x;
    }

    private void FadeIn()
    {
        fadedOut = false;
        alertAnimationController.TriggerAnimation(AlertAnimations.FadeIn);
    }

    private void FadeOut()
    {
        fadedOut = true;
        alertAnimationController.TriggerAnimation(AlertAnimations.FadeOut);
    }
}
