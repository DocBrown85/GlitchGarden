using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    public void AttackerSpawned()
    {
        numberOfAttackers += 1;
    }

    public void AttackerKilled()
    {
        numberOfAttackers -= 1;
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            Debug.Log("End Level Now!");
        }
    }

    public void StopSpawners()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner attackerSpawner in attackerSpawners)
        {
            attackerSpawner.StopSpawning();
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }
}
