using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject Earth;
    //필요속성 : 이동속도
    public float speed = 5;

    //필요속성 Character Controller
    CharacterController cc;

    //필요속성 : 중력
    public float gravityPower = 10;

    public Vector3 gravity = Vector3.zero;

    //필요속성 : 수직속도
    public Vector3 gravityDir;

    //필요속성 : 점프파워
    public float jumpPower = 5;

    int jumpCount = 0;
    public int maxJumpCount = 2;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        gravityDir = (Earth.transform.position - transform.position).normalized;
        gravity += gravityPower * gravityDir * Time.deltaTime;
        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();
        dir = Camera.main.transform.TransformDirection(dir);
        transform.up = -gravityDir;
        if (cc.collisionFlags == CollisionFlags.Below)
        {
            gravityDir = Vector3.zero;
            jumpCount = 0;
        }
        else
        {
            //yVelocity +=  gravity * Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumpCount)
        {
            //yVelocity = jumpPower;
            jumpCount++;
        }
        cc.Move(dir * speed * Time.deltaTime + gravity);
    }
}
