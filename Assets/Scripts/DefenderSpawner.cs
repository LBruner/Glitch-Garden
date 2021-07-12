using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
     Defender defender;

    [SerializeField] GameObject defenderParent;

    const string DEFENDER_PARENT_NAME = "Defenders";


    // Start is called before the first frame update
    void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        AtemptToPlaceDefender(GetSquareClicked());
    }

    public void SetSellectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    public void AtemptToPlaceDefender(Vector2 gridPos)
    {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();
        
        if(StarDisplay && defender != null)
        {
            if (StarDisplay.HaveEnoughStars(defenderCost))
            {
                SpawnDefender(gridPos);
                StarDisplay.spendStars(defenderCost);
            }
        }
        
            
    }



    Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 RawWorldPos)
    {
        float newX = Mathf.RoundToInt(RawWorldPos.x);
        float newY = Mathf.RoundToInt(RawWorldPos.y);
        return new Vector2(newX, newY);
    }

    public void SpawnDefender(Vector2 RoundedPos)
    {
        GetSquareClicked();
      Defender newDefender =  Instantiate(defender, RoundedPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }
}
