using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] float movementSpeed = 2f;
    [SerializeField] float bottomBorder = -5f;
    [SerializeField] float durationOfPowerup = 5f;

    void Update()
    {
        transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);

        if (transform.position.y < bottomBorder)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player)) 
        { 
            player.onPowerupCollected(durationOfPowerup);
            Destroy(this.gameObject);
        }
    }
}
