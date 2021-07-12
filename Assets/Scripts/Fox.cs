using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;


        if (other.GetComponent<Gravestone>())
        {
            GetComponent<Animator>().SetTrigger("JumpTrigger");
        }

        else if (collision.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(other);
        }
         else if (collision.GetComponent<SafeHouse>())
        {
            GetComponent<Attacker>().Attack(other);
        }

        


    }
}
