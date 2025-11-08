using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootingFlower : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootFlower;
    public AudioSource shootSound;
    public int bulletsAmount = 100;

    // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Mouse0))
    //     {
    //         GameObject clone = Instantiate(prefab);
    //         clone.transform.position = shootFlower.transform.position;
    //         clone.transform.rotation = shootFlower.transform.rotation;
    //     }
    // }

    // public void OnFire()
    // {
    //     GameObject clone = Instantiate(prefab);
    //     clone.transform.position = shootFlower.transform.position;
    //     clone.transform.rotation = shootFlower.transform.rotation;

    // }

        public void OnFire(InputValue value)
    {
        if (value.isPressed && Time.timeScale > 0)
        {
            //shootSound.Play();
            bulletsAmount--;
            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootFlower.transform.position;
            clone.transform.rotation = shootFlower.transform.rotation;
            
        }


    }
}
