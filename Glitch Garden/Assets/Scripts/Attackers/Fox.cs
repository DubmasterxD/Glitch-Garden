using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if(otherObject.CompareTag("Obstacle"))
        {
            gameObject.GetComponent<Animator>().SetTrigger("jumpTrigger");
        }
        else if (otherObject.GetComponent<Defender>())
        {
            gameObject.GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
