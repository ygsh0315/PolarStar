using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 통신 성공하면 오디오를 출력하고 싶다.
public class KJH_AudioPlay : MonoBehaviour
{
    public AudioSource source;
    public bool isStartSound = false;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (KJH_DrawConstellation.instance.isSuccess)
        {
            if (!source.isPlaying)
            {
                print("양자리 시나리오 플레이");
                source.Play();
                isStartSound = true;                
            }
        }
    }
}
