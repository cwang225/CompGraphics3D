using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreOnDeath : MonoBehaviour
{
    public int amount;

    private void Awake()
    {
        var life = GetComponent<Life>();
        life.onDeath.AddListener(GivePoints);
    }

    void GivePoints()
    {
        // not giving points
       // Debug.Log("giving points");
        ScoreManager.instance.amount += amount;
    }
}
