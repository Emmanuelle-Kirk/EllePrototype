using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;

    private Rigidbody rb;

    public Camera BuildingEntrance;
    public Camera BuildingIndoors;

    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {

        BuildingEntrance.enabled = true;
        BuildingIndoors.enabled = false;

        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CamSwapTrigger"))
        {

            BuildingEntrance.enabled = false;
            BuildingIndoors.enabled = true;

        }
        if (other.gameObject.CompareTag("CamSwapTrigger2"))
        {

            BuildingEntrance.enabled = true;
            BuildingIndoors.enabled = false;

        }
    }
}