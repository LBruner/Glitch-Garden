using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] [Range(1f,5f)] float currentSpeed = 1f;

    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackersAlive();
    }

    private void OnDestroy()
    {
       LevelController levelcontroller = FindObjectOfType<LevelController>();
        if (levelcontroller != null)
        {
            levelcontroller.AttackersKilled();
        }
    }
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetUpMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget)
        {
            return;
        }

        Health health = currentTarget.GetComponent<Health>();
        SafeHouse safehouse = currentTarget.GetComponent<SafeHouse>();
        if (health)
        {
            health.Damage(damage);
        }

        else if (safehouse)
        {
            safehouse.Damage(damage);
        }
      }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }
}
