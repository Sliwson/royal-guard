using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlls : MonoBehaviour {

    //debug controlls
    public bool arrowControlls = true;

    [SerializeField]
    private float shieldSpeed = 10f;

    [System.Serializable]
    private class Range
    {
        public float min = -70f;
        public float max = 90f;
    };

    private enum Direction
    {
        Left, 
        Right
    }

    [SerializeField]
    private Range range;

    [SerializeField]
    private Transform shieldSphere; 

    void Start ()
    {
        if (shieldSphere == null)
            Debug.LogError("Shield sphere is not set in Controlls Script!");

        shieldSphere.rotation = Quaternion.identity;
    }
	
	void Update ()
    {
		if(arrowControlls)
        {
            float rotation = 0f;

            if (Input.GetKey("left"))
            {
                rotation += CalculateRotation(Direction.Left);
            }

            if (Input.GetKey("right"))
            {
                rotation -= CalculateRotation(Direction.Right);
            }

            shieldSphere.Rotate(0, 0, rotation);

        }
    }

    private float CalculateRotation(Direction d)
    {
        float angle = -shieldSphere.transform.localEulerAngles.z;

        if (angle < -180)
            angle += 360; //as angle returns range (-360, 0]

        float diff = shieldSpeed * Time.deltaTime;

        if (d == Direction.Left && angle - diff > range.min)
            return diff;
        else if (d == Direction.Right && angle + diff < range.max)
            return diff;
        else
            return 0f;
    }
}
