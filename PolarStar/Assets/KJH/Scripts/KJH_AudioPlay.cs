using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 통신 성공하면 오디오를 출력하고 싶다.
// 통신에서 받은 인덱스로 자식 오브젝트에 접근해 오디오 소스를 플레이한다.

public class KJH_AudioPlay : MonoBehaviour
{
    public static KJH_AudioPlay instance;
    public AudioSource source;
    public bool isStartSound = false;

    private void Awake()
    {
        if(!instance)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlaySound(int index)
    {
        //if (KJH_DrawConstellation.instance.isSuccess)
        //{
            //if (!source.isPlaying)
            //{
                print(index);

                if (index > 11)
                {
                    print("오디오 없음");
                    return;
                }

                source = transform.GetChild(index).GetComponent<AudioSource>();
                source.Play();

                isStartSound = true;
            //}
        //}
    }

}
