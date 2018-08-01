using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInterpolation
{
    private Range range;

    public MovementInterpolation(Range r)
    {
        range = r;
    }
        
    public float InterpolateRotation(float rotation, float currentAngle)
    {
        float angleScaled = ScaleAngle(currentAngle); //[0,1] - distance from top to side

        float lerpInterpolationValue = CalculateInterpolationValue(angleScaled);

        return Mathf.Lerp(0, rotation, lerpInterpolationValue);
    }

    private float CalculateInterpolationValue(float angleScaled)
    {
        return 0.6f + 0.4f * angleScaled; //function to tweak with
    }

    private float ScaleAngle(float currentAngle)
    {
        float angle = currentAngle;

        if (angle < 0)
            angle = angle / range.min;
        else
            angle = angle / range.max;

        return angle;
    }
}
