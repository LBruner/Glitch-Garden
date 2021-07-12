using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectille : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f, projectileRotation = 4f;

    [SerializeField] public float PepinoDamage = 50f;

   

    Health health;
    void Start()
    {
    }

   

    void Update()
    {
       transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attackers")
        {
            var health = collision.GetComponent<Health>();
            health.Damage(PepinoDamage);
            Destroy(gameObject);
        }
    }
}
