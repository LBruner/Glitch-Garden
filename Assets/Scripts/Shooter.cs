using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    Animator animator;

    [SerializeField] GameObject Projectille, gun;

    AttackerSpawner myLaneSpawner;

    GameObject ProjectileParent;

    const string PROJECTILE_PARENT_NAME = "Projectiles";
    public void Fire()
    {
         GameObject shooter = Instantiate(Projectille,gun.transform.position, transform.rotation);
        shooter.transform.parent = ProjectileParent.transform;
    }

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }
    private void CreateProjectileParent()
    {
        ProjectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!ProjectileParent)
        {
            ProjectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    void SetLaneSpawner()
    {
        AttackerSpawner[] Spawners = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner Spawner in Spawners)
        {
            bool isCloseEnough = (Mathf.Abs(Spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (isCloseEnough)
            {
                myLaneSpawner = Spawner;
            }
                
        }
    }

    private bool isAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void Update()
    {
        if (isAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }
}
