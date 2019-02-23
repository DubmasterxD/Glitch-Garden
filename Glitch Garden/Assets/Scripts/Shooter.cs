using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectile = null;
    [SerializeField] Transform gun = null;

    public void Fire()
    {
        Instantiate(projectile, gun.position, Quaternion.identity);
    }
}
