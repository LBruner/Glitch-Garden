using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButtom : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButtom>();
        foreach (DefenderButtom buttom in buttons)
        {
            buttom.GetComponent<SpriteRenderer>().color = new Color32(50, 50, 50, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;

        FindObjectOfType<DefenderSpawner>().SetSellectedDefender(defenderPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
