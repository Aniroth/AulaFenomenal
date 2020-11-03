using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public float playerSpeed;
    public float jumpForce;
    public Slider fuelLeft;

    bool grounded;
    bool shouldJump;
    bool shouldReturn;
    float currentSpeed;
    float fuel = 100f;
    Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        currentSpeed = playerSpeed;
    }

    void Update()
    {
        fuelLeft.value = fuel;

        if (Input.GetKeyDown(KeyCode.W))
        {
            shouldJump = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            shouldReturn = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fuel"))
        {
            fuel += 20f;
            if (fuel > 100f)
            {
                fuel = 100f;
            }
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Wall"))
        {
            GameManager.instance.PlayerDead();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Tile"))
        {
            grounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Tile"))
        {
            grounded = false;
        }
    }

    void FixedUpdate()
    {
        if (!GameManager.instance.isPlayerDead)
        {
            if (Input.GetKey(KeyCode.D))
            {
                rigidBody.MovePosition(new Vector3(currentSpeed * Time.fixedDeltaTime, 0f, 0f) + transform.position);
            }

            if (Input.GetKey(KeyCode.A))
            {
                rigidBody.MovePosition(new Vector3(-currentSpeed * Time.fixedDeltaTime, 0f, 0f) + transform.position);
            }

            if (shouldJump && fuel > 10f)
            {
                rigidBody.AddForce(new Vector3(0f, jumpForce, 0f));
                fuel -= 10f;
                shouldJump = false;
            }

            if (shouldReturn && !grounded && fuel > 5f)
            {
                rigidBody.AddForce(new Vector3(0f, -jumpForce * 2f, 0f));
                fuel -= 5f;
                shouldReturn = false;
            }
        }
    }
}