using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    [SerializeField] public float Vida = 100f;

    [SerializeField] GameObject deathVFX;

    [SerializeField] int AttackersKilled;

    private void Start()
    {
        Debug.Log(PlayerPrefsController.GetDifficulty());
    }

    

    public void Damage(float damage)
    {
        Vida -= damage;
        if (Vida <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);


        }

    }

    void TriggerDeathVFX()
    {
        if(!deathVFX)
        {
            return;
        }

            var VarDeathVFX = Instantiate(deathVFX, new Vector2(transform.position.x - 0.60f, transform.position.y - 0.26f), Quaternion.identity);
            Destroy(VarDeathVFX.gameObject, 0.8f);

    }

    // Update is called once per frame
    void Update()
    {
       
    }

  
}
