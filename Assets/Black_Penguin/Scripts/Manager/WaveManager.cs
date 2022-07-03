using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class baseEnemySpawnPos
{
    readonly public Vector3 OverLeft = new Vector3(-90, 3);
    readonly public Vector3 UnderLeft = new Vector3(-90, -3);
    readonly public Vector3 OverRight = new Vector3(90, 3);
    readonly public Vector3 UnderRight = new Vector3(90, -3);

    public Vector3 returnPos(int index)
    {
        switch (index)
        {
            case 1:
                return OverLeft;
            case 2:
                return UnderLeft;
            case 3:
                return OverRight;
            case 4:
                return UnderRight;
            default:
                Debug.Log("ÀÎµ¦½º ¿À·ù (OutOfRange)");
                return OverLeft;
        }
    }
}
[System.Serializable]
public class EnemySpawnInfo
{
    public float time;
    public int posIndex;
    public GameObject enemyObj;
}
[System.Serializable]
public class EnemySpawnPattern
{
    public List<EnemySpawnInfo> EnemySpawnInfos;
}
[System.Serializable]
public class WavePattern
{
    public List<EnemySpawnPattern> EnemySpawnPatterns;
}
public class WaveManager : MonoBehaviour
{
    readonly baseEnemySpawnPos enemySpawnPos;
    public List<WavePattern> wavePatterns;
    public int m_WaveNum;
    public List<GameObject> SummonedEnemies;

    public IEnumerator WaveProcessing(int waveNum)
    {
        int[] waveOrder = new int[5] { 0, 1, 2, 3, 4 };
        System.Random random = new System.Random();
        waveOrder = waveOrder.OrderBy(x => random.Next()).ToArray();
        for (int i = 0; i < 5; i++)
        {
            yield return StartCoroutine(WaveSpawn(wavePatterns[waveNum].EnemySpawnPatterns[waveOrder[i]].EnemySpawnInfos));
            while (!IsAllEnemyDead())
            {
                yield return null;
            }
            SummonedEnemies.Clear();
        }
    }
    IEnumerator WaveSpawn(List<EnemySpawnInfo> enemySpawnInfos)
    {
        foreach (EnemySpawnInfo enemySpawnInfo in enemySpawnInfos)
        {
            SummonedEnemies.Add(ObjectPool.Instance.CreateObj(enemySpawnInfo.enemyObj, enemySpawnPos.returnPos(enemySpawnInfo.posIndex), Quaternion.identity));
            yield return new WaitForSeconds(enemySpawnInfo.time);
        }
    }
    bool IsAllEnemyDead()
    {
        for (int i = 0; i < SummonedEnemies.Count; i++)
        {
            if (SummonedEnemies[i].activeSelf)
            {
                return false;
            }
        }
        return true;
    }
}
