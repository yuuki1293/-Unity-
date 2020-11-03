using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bluetooth_value;

public class hide_or_show : MonoBehaviour
{
    public int num;
    SpriteRenderer mr;

    // Update is called once per frame
    void Update()
    {
        mr = GetComponent<SpriteRenderer>();
        if(Bv.push_flag[num])mr.material.color = new Color32(0,0,0,0);
        else mr.material.color = new Color32(0,0,0,255);
    }
}
