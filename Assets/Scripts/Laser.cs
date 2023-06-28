using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    
    [SerializeField] private float laserSpeed = 10f;
    [SerializeField] private float lifeTime = 2f;

    void Update()
    {
        transform.Translate(Vector3.up * laserSpeed * Time.deltaTime);
        Destroy(gameObject, lifeTime);
    }
}
