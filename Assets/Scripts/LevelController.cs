using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] int NumberOfAttackersAlive = 0;
    GameTimer GameTimer;
    bool isLevelTimerFinished = false;
    SafeHouse safehouse;


    // Start is called before the first frame update
    void Start()
    {
        GameTimer = FindObjectOfType<GameTimer>();
        safehouse = FindObjectOfType<SafeHouse>();
    }

    public void AttackersAlive()
    {
        NumberOfAttackersAlive += 1;
    }

    public void AttackersKilled()
    {
        NumberOfAttackersAlive -= 1;
        if(NumberOfAttackersAlive <= 0 &&  isLevelTimerFinished)
        {
            StartCoroutine(safehouse.HandleWinCondition());
        }
    }

    public void LevelTimerFinished()
    {
        isLevelTimerFinished = true;
        StopSpawners();
    }

    void StopSpawners()
    {
        AttackerSpawner[] SpawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner Spawner in SpawnerArray)
        {
            Spawner.StopSpawning();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
