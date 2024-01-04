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
        rawImageHandle.enabled = true;

        myVideo.SetActive(true);
        videoClip.Play();

        videoClip.loopPointReached += OnVideoEnd;
    }

    public void OnPauseVideo()
    {
        myVideo.SetActive(false);
        videoClip.Pause();
    }

    private void OnVideoEnd(VideoPlayer source)
    {
        rawImageHandle.enabled = false;

        videoClip.loopPointReached -= OnVideoEnd;
    }
}