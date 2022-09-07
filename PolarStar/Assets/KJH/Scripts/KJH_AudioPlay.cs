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
    Transform parent;

    private void Awake()
    {
        if (!instance)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlaySound(int index)
    {
        // 전달받은 인덱스에 해당하는 audiosource 가져오기

        //AudioSource source = transform.GetChild(index).GetComponent<AudioSource>();
        source = parent.GetChild(index).GetComponent<AudioSource>();

        if (!source.isPlaying)
        {
            print("audio index : " + index);

            if (index > 11)
            {
                print("오디오 없음");
                return;
            }

            source.Play();
            isStartSound = true;
        }
    }

}
