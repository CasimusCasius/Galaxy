using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float bottomBorder = -5f;
    [SerializeField] float horizontalAbsBorder = 11.3f;
    [SerializeField] float respawnYPos = 5.8f;

    private void Start()
    {
        SpawnOnTheTop();
    }

    void Update()
    {
        transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
        if (transform.position.y < bottomBorder)
        {
            SpawnOnTheTop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.Damage();
            Destroy(gameObject);
        }
        if (other.gameObject.TryGetComponent(out Laser laser))
        {
            Destroy(laser.gameObject);
            Destroy(gameObject);
        }
    }

    private void SpawnOnTheTop()
    {
        transform.position = new Vector3(Random.Range(-horizontalAbsBorder, horizontalAbsBorder), respawnYPos, 0);
    }
}
