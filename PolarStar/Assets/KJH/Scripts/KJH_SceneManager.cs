using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class KJH_SceneManager : MonoBehaviour
{
    public Image whiteImage;
    public static KJH_SceneManager instance;

    //float currentTime = 0f;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadWebCamScene()
    {
        // 이미지 페이드 아웃



        SceneManager.LoadScene("WebCamScene");
    }
}
