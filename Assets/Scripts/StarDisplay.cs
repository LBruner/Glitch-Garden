using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;

    Text starText;

    private void Start()
    {
        starText = GetComponent<Text>();
        updateDisplay();
    }

    void updateDisplay()
    {
        starText.text = stars.ToString();
    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }

    public void addStars(int amount)
    {
        stars += amount;
        updateDisplay();
    }

    public void spendStars(int cost)
    {
        if(stars >= cost)
        {
            stars -= cost;
            updateDisplay();
        }
        
    }

}
