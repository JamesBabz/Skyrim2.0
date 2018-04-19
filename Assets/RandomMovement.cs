using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{

    public int MaxWalkingRadius = 50;

    private System.Random _random = new System.Random();
    private bool _isMoving;
    private bool _isRotating;
    private bool _testBool = true;
    private int _turnAngle;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
    void Update()
    {
        if (!_isMoving)
        {
            if (shouldIMove())
            {
                Turn();
            }
        }
        else if (_isRotating)
        {
            Rotate();
        }
        else
        {
            Move();
        }
        
    }

    private void Rotate()
    {
        Vector3 to = new Vector3(0, _turnAngle, 0);
        if (Vector3.Distance(transform.eulerAngles, to) > 0.01f)
        {
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);
        }
        else
        {
            transform.eulerAngles = to;
            _isRotating = false;
        }
    }

    private void Move()
    {
        Debug.Log("HFJSFHDJFHDSHJ");
    }

 private void Turn()
    {
        _turnAngle = _random.Next(361);
        _isRotating = true;
    }
    
    private bool shouldIMove()
    {
         return _isMoving = _random.Next(10000) > 9950;
        return _isMoving = _random.Next(10000) > 9995;
    }
}
