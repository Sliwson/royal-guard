using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Alert : MonoBehaviour {

    [SerializeField]
    private float screenBorderOffset = 2f;

    private bool fadedOut = false;

    private AlertAnimationController alertAnimationController;

    public void SpawnAlert(Transform transform)
    {
        ProjectilePositions position = CalculateProjectilePosition(transform);



        alertAnimationController = new AlertAnimationController(GetComponent<Animator>());
        alertAnimationController.TriggerAnimation(AlertAnimations.FadeIn);
    }

    public void UpdateAlert(Transform position)
    {
        
    }

    public void DestroyAlert()
    {
        Destroy(gameObject);
    }

    private ProjectilePositions CalculateProjectilePosition(Transform projectileTransform)
    {
        Vector3 leftTop = Coordinates.GetCameraCorner(Corner.LeftTop);
        Vector3 rightBottom = Coordinates.GetCameraCorner(Corner.RightBottom);

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
}
