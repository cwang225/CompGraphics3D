using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float startTime;
    public float endTime;
    public float spawnRate;
    void Start()
    {
        WavesManager.instance.AddWave(this);
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("EndSpawner", endTime);
    }

    void Spawn()
    {

        Instantiate(prefab, transform.position, transform.rotation);
        // GameObject enemy = Instantiate(prefab, transform.position, transform.rotation);
        // PlayerShootingFlower script = enemy.AddComponent<PlayerShootingFlower>();
        // script.shootFlower = GameObject.Find("enemyshoot");
    }


    void EndSpawner()
    {
        WavesManager.instance.RemoveWave(this);
        CancelInvoke();
    }
    
}
