using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f,5f)][SerializeField] float moveSpeed = 2f;
    [SerializeField] int damage = 0;
    GameObject currentTarget = null;
    Health currTargetHealth = null;
    Animator anim;
    int _isAttacking;

    private void Start()
    {
        anim = GetComponent<Animator>();
        _isAttacking = Animator.StringToHash("isAttacking");
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        CheckIfTargetAlive();
    }

    private void CheckIfTargetAlive()
    {
        if (!currentTarget)
        {
            anim.SetBool(_isAttacking, false);
        }
    }

    public void SetMovementSpeed(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed;
    }

    public void StrikeCurrentTarget()
    {
        if (!currentTarget) { return; }
        if(currTargetHealth)
        { 
            currTargetHealth.DealDamage(damage);
        }
    }

    public void Attack(GameObject target)
    {
        anim.SetBool(_isAttacking, true);
        currentTarget = target;
        currTargetHealth = target.GetComponent<Health>();
    }
}
