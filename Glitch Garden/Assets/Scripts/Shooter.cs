using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectile = null;
    [SerializeField] Transform gun = null;
    AttackerSpawner myLaneSpawner = null;
    Animator anim;
    int _isAttacking;

    private void Start()
    {
        SetLaneSpawner();
        anim = GetComponent<Animator>();
        _isAttacking = Animator.StringToHash("isAttacking");
    }

    private void Update()
    {
        if(IsAttackerInLane())
        {
            anim.SetBool(_isAttacking, true);
        }
        else
        {
            anim.SetBool(_isAttacking, false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.localPosition.y - transform.position.y) <= Mathf.Epsilon);
            if(isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if(myLaneSpawner.transform.childCount<=0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Fire()
    {
        Instantiate(projectile, gun.position, Quaternion.identity);
    }
}
