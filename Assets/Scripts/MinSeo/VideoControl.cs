using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{
    public GameObject myVideo;
    public VideoPlayer videoClip;
    public RawImage rawImageHandle;

    private void Start()
    {
        rawImageHandle.enabled = false;
    }
    public void OnPlayVideo()
    {
        rawImageHandle.enabled = true;  // 24.01.06 나중에 없애고, 이 위치에 설명 부분 추가 함. 

        myVideo.SetActive(true);
        videoClip.Play();

        videoClip.loopPointReached += OnVideoEnd;
    }

  

    public void OnPauseVideo()
    {
        videoClip.Pause();
        myVideo.SetActive(false);
    }

    private void OnVideoEnd(VideoPlayer source)
    {
        rawImageHandle.enabled = false;

        videoClip.loopPointReached -= OnVideoEnd;
        
        OnPauseVideo();
    }
}