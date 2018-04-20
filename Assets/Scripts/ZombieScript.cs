using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ZombieScript : MonoBehaviour {

    public float Speed = 2;

    private bool _playerInRange;
    private bool _isAttacking;
    private Transform _target;
    private Animator _animator;
    private bool _isDead;

    // Use this for initialization
    void Awake () {
        _animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (_isDead)
        {
            return;
        }
        if (other.tag == "Player")
        {
            SetAttack(_playerInRange);
            _target = other.transform;
            _playerInRange = true;
        }
        
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_isAttacking)
            {
                SetAttack(false);
            }
            else
            {
                _playerInRange = false;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (_isDead)
        {
            return;
        }
        if (_playerInRange && !_isAttacking)
        {
            _animator.SetBool("FollowTarget", true);
            Vector3 targetDir = _target.position - transform.position;
            float step = Speed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
            transform.position = Vector3.MoveTowards(transform.position, _target.position, step);
        }
	}



    private void SetAttack(bool shouldAttack)
    {
        _animator.SetBool("IsAttacking", shouldAttack);
        _isAttacking = shouldAttack;
    }
}
