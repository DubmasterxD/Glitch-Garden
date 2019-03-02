using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    HealthDisplay healthDisplay = null;

    private void Start()
    {
        healthDisplay = FindObjectOfType<HealthDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionObject = collision.gameObject;
        if(collisionObject.CompareTag("Attacker"))
        {
            healthDisplay.DecreaseHealth();
            Destroy(collisionObject);
        }
    }
}
