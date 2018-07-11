using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlls : MonoBehaviour {

    //debug controlls
    public bool arrowControlls = true;

    [SerializeField]
    private float shieldSpeed = 10f;
        
    private enum Direction
    {
        Left, 
        Right
    }
    
    private class ActiveDirections
    {
        public bool left = false;
        public bool right = false;
    }

    private ActiveDirections activeDirections = new ActiveDirections();

    private MovementInterpolation movementInterpolation;
        
    [SerializeField]
    private Range range;

    [SerializeField]
    private Transform shieldSphere; 
        
    public void RotateLeftStart()
    {
        activeDirections.left = true;
    }

    public void RotateLeftStop()
    {
        activeDirections.left = false;
    }

    public void RotateRightStart()
    {
        activeDirections.right = true;
    }

    public void RotateRightStop()
    {
        activeDirections.right = false;
    }

    public float GetCurrentAngle()
    {
        float angle = -shieldSphere.transform.localEulerAngles.z;

        if (angle < -180)
            angle += 360; //as angle returns range (-360, 0]

        return angle;
    }

    void Start ()
    {
        if (shieldSphere == null)
            Debug.LogError("Shield sphere is not set in Controlls Script!");

        shieldSphere.rotation = Quaternion.identity;

        movementInterpolation = new MovementInterpolation(range);
    }
	
	void Update ()
    {
        if (arrowControlls)
        {
            HandleArrowControlls();    
        }
        else
        {
            HandleTouchControlls();
        }
    }

    private void HandleArrowControlls()
    {
        if (Input.GetKey("left"))
        {
            RotateShield(Direction.Left);
        }
        if (Input.GetKey("right"))
        {
            RotateShield(Direction.Right);
        }
    }

    private void HandleTouchControlls()
    {
        if(activeDirections.left)
        {
            RotateShield(Direction.Left);
        }
        if(activeDirections.right)
        {
            RotateShield(Direction.Right);
        }
    }

    private float CalculateRotation(Direction d)
    {
        float angle = GetCurrentAngle();

        float diff = shieldSpeed * Time.deltaTime;

        if (d == Direction.Left && angle - diff > range.min)
            return diff;
        else if (d == Direction.Right && angle + diff < range.max)
            return diff;
        else
            return 0f;
    }    

    private void RotateShield(Direction d)
    {
        float rotation = 0f;
        float diff = movementInterpolation.InterpolateRotation(CalculateRotation(d), GetCurrentAngle());

        switch (d)
        {
            case Direction.Left:
                rotation += diff;
                break;
            case Direction.Right:
                rotation -= diff;
                break;
        }

        shieldSphere.Rotate(0, 0, rotation);
    }
}
