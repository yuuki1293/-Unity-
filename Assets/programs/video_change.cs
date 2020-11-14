using UnityEngine;
using UnityEngine.Video;
using Bluetooth_value;

public class video_change : MonoBehaviour
{
    public VideoClip[] NewClip = new VideoClip[3];
    public VideoPlayer VideoPlayerComponent;
    void Update()
    {
        VideoPlayerComponent.clip = NewClip[Bv.動画切り替え];
    }
}
