using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LIFEBAR : MonoBehaviour
{
    // Start is called before the first frame update
    public Image image;
    public Life targetLife;
    void Awake()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        image.fillAmount = targetLife.amount / 100;
    }
}
