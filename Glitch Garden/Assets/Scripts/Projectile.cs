using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] bool isRotating = true;
    [Range(0f, 360f)] [SerializeField] float rotationSpeed = 180f;
    [SerializeField] float speed = 10f;
    [SerializeField] int damage = 50;

    private void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed, Space.World);
        if (isRotating)
        {
            transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * rotationSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<Health>();
        var attacker = collision.GetComponent<Attacker>();
        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }

}
