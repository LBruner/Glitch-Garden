using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Attacker[] LizardPrefab;

    [SerializeField] float minRandomTime = 1f, maxRandomTime = 5f;

    [SerializeField] int AttackerNumber = 0;
    bool Spawn = true;

    // Start is called before the first frame update
    

    IEnumerator Start()
    {
        while(Spawn)
        {
            yield return new WaitForSeconds(Random.Range(minRandomTime,maxRandomTime));
            AttackerSpawn();
        }
    }

    void AttackerSpawn()
    {
        int Value = Random.Range(0, LizardPrefab.Length);
        NewSpawn(Value);
        
    }

    private void NewSpawn(int arraynumber)
    {
        Attacker newAttacker = Instantiate(LizardPrefab[arraynumber], transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;
    }

    public void StopSpawning()
    {
        Spawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
