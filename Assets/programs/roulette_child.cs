using UnityEngine;
using UnityEngine.UI;
using roulette;
using Bluetooth_value;

public class roulette_child : MonoBehaviour
{
    /*
    一の位 = 0;
    十の位 = 1;
    百の位 = 2;
    */
    public int num;
    public Sprite[] スプライト = new Sprite[10];
    public SpriteRenderer changesprite;

    void Update()
    {
        if (Bv.動画だけ || Bv.動画切り替え != 2) changesprite.color = new Color(255, 255, 255, 0);
        else changesprite.color = new Color(255, 255, 255, 1);
        changesprite.sprite = スプライト[int.Parse(value.位[num])];
    }
}
