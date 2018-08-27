using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using EZCameraShake;

[System.Serializable]
public class CameraShakeCreator
{
    public float magnitude = 0f;
    public float roughness = 0f;
    public float fadeInTime = 0f;
    public float fadeOutTime = 0f;
    public Vector3 positionInfluence = Vector3.zero;
    public Vector3 rotationInfluence = Vector3.zero;
    public bool deleteOnInactive = true;

    public CameraShakeInstance GetInstance()
    {
        CameraShakeInstance cameraShakeInstance = new CameraShakeInstance(magnitude, roughness, fadeInTime, fadeOutTime);
        cameraShakeInstance.PositionInfluence = positionInfluence;
        cameraShakeInstance.RotationInfluence = rotationInfluence;
        cameraShakeInstance.DeleteOnInactive = deleteOnInactive;
        return cameraShakeInstance;
    }
}