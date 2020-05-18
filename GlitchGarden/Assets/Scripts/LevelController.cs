using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] float waitToLoad = 4f;

    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers += 1;
    }

    public void AttackerKilled()
    {
        numberOfAttackers -= 1;
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
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
