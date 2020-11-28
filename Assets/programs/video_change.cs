using UnityEngine;
using UnityEngine.Video;
using Bluetooth_value;

public class video_change : MonoBehaviour
{
    public VideoClip[] NewVideoClip = new VideoClip[4];
    public AudioClip NewAudioClip;
    public VideoPlayer VideoPlayerComponent;
    private bool 再生 = true;
    AudioSource audio_;
    AudioSource source;
    void Start()
    {
        audio_ = GetComponent<AudioSource>();
        source = gameObject.GetComponent<AudioSource>();
        audio_.loop = true;
    }
    void Update()
    {
        if (Bv.daisuke) VideoPlayerComponent.clip = NewVideoClip[3];
        else VideoPlayerComponent.clip = NewVideoClip[Bv.動画切り替え];
        if (Bv.daisuke && 再生)
        {
            if (Bv.bgmを流す) audio_.PlayOneShot(NewAudioClip, 1.0f);
            再生 = false;
        }
        else if (!Bv.daisuke)
        {
            source.Stop(); 再生 = true;
        }
    }
}
