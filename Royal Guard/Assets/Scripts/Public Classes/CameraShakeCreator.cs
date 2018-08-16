using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using EZCameraShake;

[System.Serializable]
class CameraShakeCreator
{
    public float magnitude;
    public float roughness;
    public float fadeInTime;
    public float fadeOutTime;
    public Vector3 positionInfluence;
    public Vector3 rotationInfluence;
    public bool deleteOnInactive;

    public CameraShakeInstance GetInstance()
    {
        CameraShakeInstance cameraShakeInstance = new CameraShakeInstance(magnitude, roughness, fadeInTime, fadeOutTime);
        cameraShakeInstance.PositionInfluence = positionInfluence;
        cameraShakeInstance.RotationInfluence = rotationInfluence;
        cameraShakeInstance.DeleteOnInactive = deleteOnInactive;
        return cameraShakeInstance;
    }
}