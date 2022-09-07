using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarGuide : MonoBehaviour
{
    public enum GuideState
    {
        Idle,
        guideStart,
        state1,
        state2,
        state3,
        state4,
        state5
    }
    //public string startText = "환영합니다!!";
    //public string S_1Text = "1번 키를 눌러 찾고싶은 별자리를 말해주세요!";
    //public string S_2Text = "음성 인식 중...";
    //public string S_3Text = "별자리를 찾았습니다! 고개를 들어 하늘을 바라보세요!";
    //public string S_4Text = "오디오 재생 중...";
    //public string S_5Text = "2번 키를 눌러 별자리와 사진을 찍어보세요!";
    public Image GuideBar;
    //public Text guideText;
    public Image startImage;
    public Image S_1Image;
    public Image S_2Image;
    public Image S_3Image;
    public Image S_4Image;
    public Image S_5Image;
    public GuideState guideState;

    public WebcamHandler web;
    public RawImage rawImage;

    // 싱글톤으로 사용
    public static StarGuide Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        guideState = GuideState.guideStart;
        startImage.enabled = false;
        S_1Image.enabled = false;
        S_2Image.enabled = false;
        S_3Image.enabled = false;
        S_4Image.enabled = false;
        S_5Image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine();
    }

    private void StateMachine()
    {
        switch (guideState)
        {
            case GuideState.Idle:
                Idle();
                break;
            case GuideState.guideStart:
                guideStart();
                break;
            case GuideState.state1:
                state1();
                break;
            case GuideState.state2:
                state2();
                break;
            case GuideState.state3:
                state3();
                break;
            case GuideState.state4:
                state4();
                break;
            case GuideState.state5:
                state5();
                break;
        }
    }

    private void Idle()
    {
        
    }

    float currentTime = 0;
    float guideStartTime = 5f;
    private void guideStart()
    {
        startImage.enabled = true;
        //StartCoroutine("FadeOut");
        //guideText.text = startText;
        currentTime += Time.deltaTime;
        if (currentTime > guideStartTime)
        {
            //StopAllCoroutines();
            //StartCoroutine("FadeIn");
            startImage.enabled = false;
            guideState = GuideState.state1;
            currentTime = 0;
        }
    }

    // 1번을 눌러줘
    private void state1()
    {
        //currentTime += Time.deltaTime;
        S_1Image.enabled = true;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // 통신
            KJH_DrawConstellation.instance.Http();
        }
    }

    // 음성인식 중
    private void state2()
    {
        S_1Image.enabled = false;
        S_2Image.enabled = true;
        //guideText.text = S_2Text;
        //guideState = GuideState.state3;
    }

    // 별자리를 봐
    float audioDelayTime = 3f;
    private void state3()
    {
        S_2Image.enabled = false;
        S_3Image.enabled = true;
        //guideText.text = S_3Text;
        //guideState = GuideState.state4;

        currentTime += Time.deltaTime;
        if (currentTime > audioDelayTime)
        {
            S_3Image.enabled = false;
            guideState = GuideState.state4;
            KJH_AudioPlay.instance.PlaySound(KJH_DrawConstellation.instance.audioIndex);
            currentTime = 0;
        }
    }

    // 오디오 재생 중
    private void state4()
    {
        S_4Image.enabled = true;

        //guideText.text = S_4Text;
        // 오디오 끝나면 상태 전이
        // --> 오디오 끝나면 이미지 매쉬 바뀔거임
        //if (AlphaChange.instance.isColorChange)
        //{
        //    //S_4Image.enabled = false;
        //    guideState = GuideState.state5;
        //}

    }
    // 2번키를 누르면 사진을 찍을 수 있어
    private void state5()
    {
        S_5Image.enabled = true;
        //guideText.text = S_5Text;
        // 2번 키를 누르면 idle 상태로 전이
        if (web.isDownAlpha2)
        {
            S_5Image.enabled = false;

            //currentTime += Time.deltaTime;

            //if (currentTime > 4f)
            //{
            //    web.isDownAlpha2 = false;
            //    rawImage.enabled = false;
            //    guideState = GuideState.state1;

            //    currentTime = 0f;

            //}
        }
    }
}