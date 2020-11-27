using UnityEngine;
using Bluetooth_value;

public class hide_or_show : MonoBehaviour
{
    public int num;
    SpriteRenderer mr;
    float dt = 0;
    float gt = 0.95f;
    float nega = -1;

    // Update is called once per frame
    void Update()
    {
        dt += nega * Time.deltaTime;
        if (dt > gt) nega = -1;
        if (dt < 0.05f) nega = 1;
        mr = GetComponent<SpriteRenderer>();
        if (Bv.動画だけ) mr.material.color = new Color32(0, 0, 0, 0);
        else if (Bv.push_flag[num] && Bv.動画切り替え != 3) mr.material.color = new Color32(102, 255, 153, (byte)(dt * 255));
        else mr.material.color = new Color32(102, 255, 153, 0);
    }
}
