using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 5f;
    [Header("Borders of movement")]
    [SerializeField] private float topMovementBorder = 0;
    [SerializeField] private float bottomMovementBorder = -3.8f;
    [SerializeField] private float leftRightMovementBorder = 9f;


    private void Start()
    {
        transform.position = Vector3.zero;
    }

    private void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput);

        transform.Translate(direction * steerSpeed * Time.deltaTime);

        float verticalClampedPosition = Mathf.Clamp(transform.position.y, bottomMovementBorder ,topMovementBorder);
        transform.position = new Vector3 (transform.position.x, verticalClampedPosition,0);

        if (transform.position.x > leftRightMovementBorder || transform.position.x > leftRightMovementBorder)
        {
            float sign = Mathf.Sign(transform.position.x);
            transform.position = new Vector3(-leftRightMovementBorder * sign , transform.position.y,0);
        }
    }
}
