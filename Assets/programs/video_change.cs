using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Bluetooth_value;

public class video_change : MonoBehaviour
{
    public VideoClip[] NewClip = new VideoClip[5];
    public VideoClip DefaultClip;
    public VideoPlayer VideoPlayerComponent;
    void Update()
    {

        if (Bv.push_flag[0]) VideoPlayerComponent.clip = NewClip[0];
        else if (Bv.push_flag[1]) VideoPlayerComponent.clip = NewClip[1];
        else if (Bv.push_flag[2]) VideoPlayerComponent.clip = NewClip[2];
        else if (Bv.push_flag[3]) VideoPlayerComponent.clip = NewClip[3];
        else if (Bv.push_flag[4]) VideoPlayerComponent.clip = NewClip[4];
        else VideoPlayerComponent.clip = DefaultClip;

    }
}
