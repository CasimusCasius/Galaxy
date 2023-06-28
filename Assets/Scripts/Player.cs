using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 5f;
    [SerializeField] private int lives = 3;
    [Header("Borders of movement")]
    [SerializeField] private float topMovementBorder = 0;
    [SerializeField] private float bottomMovementBorder = -3.8f;
    [SerializeField] private float leftRightMovementBorder = 9f;
    [Header("Laser")]
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float cooldownTime = 0.5f;
    [SerializeField] private Vector3 spawnOffset = Vector3.zero;


    private float nextFire = 0.0f;

    private void Start()
    {
        transform.position = Vector3.zero;
    }

    private void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            FireLaser();
        }
    }
    public void Damage()
    {
        lives--;
        if (lives < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void FireLaser()
    {
        nextFire = Time.time + cooldownTime;
        Instantiate(laserPrefab, transform.position + spawnOffset, Quaternion.identity);
    }

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput);

        transform.Translate(direction * steerSpeed * Time.deltaTime);

        float verticalClampedPosition = Mathf.Clamp(transform.position.y, bottomMovementBorder, topMovementBorder);
        transform.position = new Vector3(transform.position.x, verticalClampedPosition, 0);

        if (transform.position.x > leftRightMovementBorder || transform.position.x > leftRightMovementBorder)
        {
            float sign = Mathf.Sign(transform.position.x);
            transform.position = new Vector3(-leftRightMovementBorder * sign, transform.position.y, 0);
        }
    }

    
}
