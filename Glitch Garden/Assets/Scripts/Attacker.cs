using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f,5f)][SerializeField] float moveSpeed = 2f;
    
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
    }

    public void SetMovementSpeed(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed;
    }
}
