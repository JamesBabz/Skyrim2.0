using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SamuraiScript : MonoBehaviour
{
    public float SecondsToShowText = 5;
    public Transform Enemy;

    private float _currentTime = 0.0f, _executedTime = 0.0f;
    private bool _playerInRange;
    private Text _text;
    private bool _hasQuestBeenGiven;

    void Start()
    {
        _text = GameObject.Find("bottomText").GetComponent<Text>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerInRange = true;
            _executedTime = Time.time;;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerInRange = false;
        }
    }


    // Update is called once per frame
    void FixedUpdate ()
	{
	    _currentTime = Time.time;
        if (_playerInRange)
	    {
	        if (_hasQuestBeenGiven)
	        {
	            if (_currentTime - _executedTime > SecondsToShowText)
	            {
	                _text.text = "";
	            }
	        }
	        else
	        {
	            _text.text = "Samurai: Please save our village! A Zombie is rampaging!";
	            _hasQuestBeenGiven = true;
	            Vector3 spawnPoint = gameObject.transform.position;
	            spawnPoint.x = spawnPoint.x - 20;
	            GameObject.Instantiate(Enemy, spawnPoint, Quaternion.identity);
	        }
	    }
	}
    
}
