using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFlipper : MonoBehaviour {

    private float previousAngle;

    [SerializeField]
    private Controlls controlls; //for getting current angle

    [SerializeField]
    private Transform characterSprites;
    
    void Start () {
        previousAngle = controlls.GetCurrentAngle();
	}
	
	void Update () {
        float currentAngle = controlls.GetCurrentAngle();

        if (previousAngle != currentAngle && previousAngle * currentAngle <= 0)
            Flip();

        previousAngle = currentAngle;
	}
    
    private void Flip()
    {
        Vector3 newScale = characterSprites.localScale;
        newScale.x *= -1;
        characterSprites.localScale = newScale;
    }
}
