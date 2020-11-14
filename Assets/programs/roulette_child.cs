using UnityEngine;
using UnityEngine.UI;
using roulette;

public class roulette_child : MonoBehaviour
{
    const int 一の位 = 0;
    const int 十の位 = 1;
    const int 百の位 = 2;
    public int num;
    public Text te;

    // Update is called once per frame
    void Update()
    {
        te.text = value.位[num];
    }
}
