using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class transformscript : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private Vector2 movementValue;
    private float lookValue;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnMove(InputValue value)
    {
        movementValue = value.Get<Vector2>() * speed;
    }

    public void OnLook(InputValue value)
    {
        lookValue = value.Get<Vector2>().x * rotationSpeed;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(
            movementValue.x * Time.deltaTime,
            0,
            movementValue.y * Time.deltaTime
        );
        transform.Rotate(0, lookValue * Time.deltaTime, 0);

        // previous iteration of the chapters
        // float mouseX = Input.GetAxis("Mouse X");
        // transform.Rotate(0, mouseX + rotationSpeed + Time.deltaTime, 0);

        // if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        // {
        //     transform.Translate(0, 0, speed + Time.deltaTime);
        // }
        // else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        // {
        //     transform.Translate(0, 0, -speed + Time.deltaTime);
        // }
        // else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        // {
        //     transform.Translate(-speed + Time.deltaTime, 0, 0);
        // }
        // else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        // {
        //     transform.Translate(speed + Time.deltaTime, 0, 0);
        // }
        //transform.Translate(0, 0, speed);
    }
}
