using UnityEngine;
using UnityEngine.UI;
using roulette;
using Bluetooth_value;

public class roulette_child : MonoBehaviour
{
    const int 一の位 = 0;
    const int 十の位 = 1;
    const int 百の位 = 2;
    public int num;
    public Text te;

    void Update()
    {
        if (Bv.動画だけ) te.color = new Color(0, 0, 0, 0);
        else te.color = new Color(0, 0, 0, 1);
        te.text = value.位[num];
    }
}
