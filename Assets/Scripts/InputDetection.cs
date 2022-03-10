using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class InputDetection : MonoBehaviour
{
    private bool deviceActive = false;
    private float lastActiveTime;
    public VideoPlayer videoPlayer;
    public float restartVideoAfterTime = 10f;

    void Update()
    {
        deviceActive = IsHeadsetMounted();
        
        if (deviceActive == true)
        {
            if (videoPlayer.isPlaying == false && Time.time > lastActiveTime + restartVideoAfterTime) 
            {
                videoPlayer.Stop();
                videoPlayer.Play();
            }
            else if(videoPlayer.isPlaying == false)
            {
                videoPlayer.Play();
            }

            lastActiveTime = Time.time;
        }
        else
        {
            if (videoPlayer.isPlaying == true)
            {
                videoPlayer.Pause();
            }
        }
    }

    private bool IsHeadsetMounted()
    {
        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);

        foreach (var device in inputDevices)
        {
            return true;
        }
        return false;
    }
}
