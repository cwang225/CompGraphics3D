using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;
        }
    }

    // // onfire is called once per frame
    // public void OnFire()
    // {
    //     GameObject clone = Instantiate(prefab);
    //     clone.transform.position = shootPoint.transform.position;
    //     clone.transform.rotation = shootPoint.transform.rotation;
    // }

    // public void OnFire(InputValue value)
    // {
    //     if (value.isPressed)
    //     {
    //         GameObject clone = Instantiate(prefab);
    //         clone.transform.position = shootPoint.transform.position;
    //         clone.transform.rotation = shootPoint.transform.rotation;
    //     }
    // }
}
