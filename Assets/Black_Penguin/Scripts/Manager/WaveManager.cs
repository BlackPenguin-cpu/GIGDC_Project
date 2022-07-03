using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseEnemySpawnPos
{
    readonly public Vector3 OverLeft = new Vector3(-90, 3);
    readonly public Vector3 OverRight = new Vector3(90, 3);
    readonly public Vector3 UnderLeft = new Vector3(-90, -3);
    readonly public Vector3 UnderRight = new Vector3(90, -3);
}
public class WaveManager : MonoBehaviour
{
    readonly baseEnemySpawnPos enemySpawnPos;

}
