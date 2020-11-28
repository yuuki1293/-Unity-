using UnityEngine;
using UnityEngine.Video;
using Bluetooth_value;

public class video_change : MonoBehaviour
{
    public VideoClip[] NewVideoClip = new VideoClip[4];
    public AudioClip NewAudioClip;
    public VideoPlayer VideoPlayerComponent;
    private bool 再生 = true;
    public float ボリューム;
    AudioSource audio_;
    AudioSource source;
    void Start()
    {
        audio_ = GetComponent<AudioSource>();
        audio_.loop = true;
    }
    void Update()
    {
        audio_.volume = Bv.bgmを流す;
        ボリューム = Bv.bgmを流す;
        if (Bv.daisuke) VideoPlayerComponent.clip = NewVideoClip[3];
        else VideoPlayerComponent.clip = NewVideoClip[Bv.動画切り替え];
        if (Bv.daisuke && 再生)
        {
            audio_.PlayOneShot(NewAudioClip); 再生 = false;
        }
        else if (!Bv.daisuke)
        {
            audio_.Stop(); 再生 = true;
        }
    }
}
