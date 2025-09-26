using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int amount;
    public static ScoreManager instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Duplicated ScoreManager, ignoring this one", gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
