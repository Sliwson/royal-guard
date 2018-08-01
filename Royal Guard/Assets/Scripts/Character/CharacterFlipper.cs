﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFlipper : MonoBehaviour {
    [SerializeField]
    private Controlls controlls; //for getting current angle

    [SerializeField]
    private Transform characterSprites;

    private Direction characterDirection;
    private Direction shieldDirection;
    
    void Start () {
        characterDirection = Direction.Right;

        UpdateShieldDirection();
	}
	
	void Update () {
        UpdateShieldDirection();

        if (characterDirection != shieldDirection)
            FlipCharacter();
	}

    private void UpdateShieldDirection()
    {
        float angle = controlls.GetCurrentAngle();

        if (angle < 0)
            shieldDirection = Direction.Left;
        else
            shieldDirection = Direction.Right;
    }
    
    private void FlipCharacter()
    {
        Vector3 newScale = characterSprites.localScale;
        newScale.x *= -1;
        characterSprites.localScale = newScale;

        characterDirection = Invert(characterDirection);
    }

    private Direction Invert(Direction d)
    {
        if (d == Direction.Right)
            return Direction.Left;
        else
            return Direction.Right;
    }
}