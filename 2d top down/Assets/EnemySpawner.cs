
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public Transform spawnpoint1;
    public Transform spawnpoint2;
    public GameObject enemyToSpawn;


    public void SpawnNewSlime()
    {
        print("should spawn now");
        Instantiate(enemyToSpawn, new Vector3(-0.72f, -2f, 0), Quaternion.identity);    }
}

