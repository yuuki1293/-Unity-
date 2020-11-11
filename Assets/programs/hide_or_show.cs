using System.Collections;
using System.Collections.Generic;
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
        if (dt > gt || dt < 0.05) nega *= -1;
        mr = GetComponent<SpriteRenderer>();
        if (Bv.push_flag[num]) mr.material.color = new Color32(0, 255, 10, (byte)(dt * 255));
        else mr.material.color = new Color32(255, 100, 100, 0);
    }
}
