using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPageScript : MonoBehaviour
{
    public GameObject MonsterEncounter;
    public GameObject EnemySpawn;
    public GameObject CombatDice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMonsterEncounter()    //This will toggle the monster ecounter images.
    {
        if (MonsterEncounter.activeSelf)
        {
            MonsterEncounter.SetActive(false);
        }
        else
        {
            MonsterEncounter.SetActive(true);
        }
    }
    public void ToggleEnemySpawn()    //This will toggle the enemy spawn symbol image.
    {
        if (EnemySpawn.activeSelf)
        {
            EnemySpawn.SetActive(false);
        }
        else
        {
            EnemySpawn.SetActive(true);
        }
    }
    public void ToggleCombatDice()    //This will toggle the combat dice roll images.
    {
        if (CombatDice.activeSelf)
        {
            CombatDice.SetActive(false);
        }
        else
        {
            CombatDice.SetActive(true);
        }
    }
}
