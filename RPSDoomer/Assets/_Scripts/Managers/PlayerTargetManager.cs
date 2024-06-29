using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetManager : MonoBehaviour
{
    public static PlayerTargetManager instance;

    public List<Enemy> enemiesInPlayerAtkRange;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        enemiesInPlayerAtkRange = new List<Enemy>();
    }

    public void AddEnemy(Enemy enemyToAdd)
    {
        if (!enemiesInPlayerAtkRange.Contains(enemyToAdd))
            enemiesInPlayerAtkRange.Add(enemyToAdd);
    }

    public bool RemoveEnemy(Enemy enemyToRemove)
    {
        return enemiesInPlayerAtkRange.Remove(enemyToRemove);
    }

    public void ClearEnemyList()
    {
        enemiesInPlayerAtkRange.Clear();
    }
}
