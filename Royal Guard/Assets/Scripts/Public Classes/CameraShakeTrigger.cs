using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EZCameraShake;

public class CameraShakeTrigger
{
    public static void ShakeCamera(CameraShakeCreator cameraShakeParameters)
    {
        CameraShakeInstance cameraShakeInstance = cameraShakeParameters.GetInstance();
        CameraShaker.Instance.Shake(cameraShakeInstance);
    }
}