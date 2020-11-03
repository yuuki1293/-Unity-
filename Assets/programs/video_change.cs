using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Bluetooth_value;

public class video_change : MonoBehaviour
{
    public VideoClip[] NewClip = new VideoClip[5];
    public VideoPlayer VideoPlayerComponent;

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<5;i++){
            if(Bv.push_flag[i])VideoPlayerComponent.clip = NewClip[i];
        }
    }
}
