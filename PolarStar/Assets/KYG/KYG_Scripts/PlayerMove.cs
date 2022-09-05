using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject Earth;
    //필요속성 : 이동속도
    public float speed = 5;

    //필요속성 Character Controller
    Rigidbody rb;

    //필요속성 : 중력
    public float gravityPower = 10;

    public Vector3 gravity = Vector3.zero;

    //필요속성 : 수직속도
    public Vector3 gravityDir;

    public Vector3 yVelocity = Vector3.zero;

    //필요속성 : 점프파워
    public float jumpPower = 5;

    int jumpCount = 0;
    public int maxJumpCount = 2;

    AudioSource audioSource;
    public string sound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    public float h;
    public float v;
    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        gravityDir = (Earth.transform.position - transform.position).normalized;
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hitInfo;
        int layer = 1 << gameObject.layer;
        if (Physics.Raycast(ray, out hitInfo, 1.5f, ~layer))
        {
            yVelocity = Vector3.zero;
            jumpCount = 0;
        }
        else
        {
            //yVelocity +=  gravity * Time.deltaTime;
            gravity = gravityPower * gravityDir;
            yVelocity += gravity * Time.deltaTime;
        }
        //if (Input.GetButtonDown("Jump") && jumpCount < maxJumpCount)
        //{
        //    yVelocity = jumpPower * transform.up;
        //    jumpCount++;
        //}

        // 이동할 방향구하기
        //Vector3 dir = new Vector3(h, 0, v);
        //dir.Normalize();
        //Vector3 dir = transform.forward * v + transform.right * h;// transform.TransformDirection(dir);
        //dir = Camera.main.transform.TransformDirection(dir);
        Vector3 dir = Camera.main.transform.forward * v + Camera.main.transform.right * h;
        dir.Normalize();
        transform.up = -gravityDir;

        // 그 방향으로 이동
        dir += yVelocity;
        // up 방향 맞춰주기
        rb.velocity = dir * speed;

        if(dir != Vector3.zero)
        {
            if (!audioSource.isPlaying) audioSource.Play();
        }
        else
        {
            if(audioSource.isPlaying) audioSource.Stop();
        }
       
        
        // 중력적용
        //rb.velocity = dir;

    }

    private void OnDrawGizmos()
    {
        gravityDir = (Earth.transform.position - transform.position).normalized;

        Debug.DrawLine(transform.position, transform.position + gravityDir * 5, Color.red);

    }

    //void AudioPlay()
    //{
    //    // 리소스에서 비트(Beat) 음악 파일을 불러와 재생시키고 싶다.
    //    AudioClip audio = Resources.Load<AudioClip>("Audio/" + sound);
    //    audioSource = GetComponent<AudioSource>();
    //    audioSource.clip = audio;
    //    audioSource.Play();
    //}
}
