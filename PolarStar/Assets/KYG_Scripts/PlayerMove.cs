using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject Planet;

    public float speed = 5f;
    public float jumpPower = 1.2f;

    float gravity = 100;
    bool OnGround = false;

    float distanceToGround;
    Vector3 Groundnormal;

    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Movement
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(h, 0, v);

        // Local Lotation
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 150 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -150 * Time.deltaTime, 0);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * 40000 * jumpPower * Time.deltaTime);
        }

        // Ground Control
        RaycastHit hit = new RaycastHit();
        if(Physics.Raycast(transform.position, -transform.up, out hit, 10))
        {
            distanceToGround = hit.distance;
            Groundnormal = hit.normal;

            if(distanceToGround <= 0.2f)
            {
                OnGround = true;
            }
            else
            {
                OnGround = false;
            }
        }

        // Vector3 and Rotation
        Vector3 gravityDirection = (transform.position - Planet.transform.position).normalized;

        if (OnGround == false)
        {
            rb.AddForce(gravityDirection * -gravity);
        }

        // 
        Quaternion toRotation = Quaternion.FromToRotation(transform.up, Groundnormal) * transform.rotation;
        transform.rotation = toRotation;
    }
}
