using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ZombieScript : MonoBehaviour {

    public float Speed = 2;

    private bool _playerInRange;
    private Transform _target;
    private Animator animator;
    private bool isDead;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (isDead)
        {
            return;
        }
        if (_playerInRange) // In attack range now
        {
            animator.SetTrigger("Die");
            isDead = true;
        }

        if (other.tag == "Player")
        {
            _target = other.transform;
            _playerInRange = true;
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
    void FixedUpdate () {
        if (isDead)
        {
            return;
        }
        if (_playerInRange)
        {
            animator.SetBool("FollowTarget", true);
            Vector3 targetDir = _target.position - transform.position;
            float step = Speed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
            transform.position = Vector3.MoveTowards(transform.position, _target.position, step);
        }
	}
}
