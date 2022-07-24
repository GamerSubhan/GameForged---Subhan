using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class MobilePlayerMovement : MonoBehaviour
{
    PlayerInput _playerInput;
    NavMeshAgent _navMeshAgent;
    Animator _animator;
    float speed = 0.01f;
    float timeCount = 0f;
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        if (!_playerInput.actions["Move"].IsPressed())
        {
            return;
        }
        Vector2 input = _playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 destination = transform.position + transform.right * input.x + transform.forward * input.y;
        Debug.Log("x axis is " + input.x);
        Debug.Log("y axis is " + input.y);
        Rotate(input);
        Move(destination);
    }

    private void Rotate(Vector2 input)
    {
        _navMeshAgent.destination = transform.position;
        float angle = MathF.Atan2(input.y, input.x) * -1;
        float degrees = angle * Mathf.Rad2Deg;
        //  Debug.Log("degree is " + degrees);
        timeCount = timeCount + Time.deltaTime;
    }

    private void Move(Vector3 destination)
    {
        _navMeshAgent.SetDestination(destination);
    }
}
