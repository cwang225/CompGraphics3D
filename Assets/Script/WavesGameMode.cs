using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WavesGameMode : MonoBehaviour
{
    [SerializeField] private Life playerLife;
    [SerializeField] private Life playerBaseLife;
    // Start is called before the first frame update
    void Start()
    {
        playerLife.onDeath.AddListener(OnPlayerOrBaseDied);
        playerBaseLife.onDeath.AddListener(OnPlayerOrBaseDied);
        EnemiesManager.instance.onChanged.AddListener(CheckWinCondition);
        WavesManager.instance.onChanged.AddListener(CheckWinCondition);   

    }
    void Awake()
    {
        playerLife.onDeath.AddListener(OnPlayerOrBaseDied);
        playerBaseLife.onDeath.AddListener(OnPlayerOrBaseDied);
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (EnemiesManager.instance.enemies.Count <= 0 &&
    //         WavesManager.instance.waves.Count <= 0)
    //     {
    //         SceneManager.LoadScene("WinScreen");
    //     }

    //     // if (playerLife.amount <= 0)
    //     // {
    //     //     SceneManager.LoadScene("LoseScreen");
    //     // }
    // }

    void OnPlayerOrBaseDied()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    void CheckWinCondition()
    {
        if (EnemiesManager.instance.enemies.Count <= 0 && WavesManager.instance.waves.Count <= 0)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
