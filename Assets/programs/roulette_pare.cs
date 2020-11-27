using UnityEngine;
using Bluetooth_value;
using roulette;
using System.Threading;

public class roulette_pare : MonoBehaviour
{
    const int 一の位 = 0;
    const int 十の位 = 1;
    const int 百の位 = 2;
    float dt = 0;
    float dtr = 0;
    void Update()
    {
        if (dt > 0.1f)
        {
            if (Bv.ルーレットが回せる)
            {
                if (Bv.確定演出)
                {
                    dtr += 100;
                    if (dtr < 1000) { value.位[一の位] = Random.Range(0, 10).ToString(); } else { value.位[一の位] = "7"; }
                    if (dtr < 1500) { value.位[十の位] = Random.Range(0, 10).ToString(); } else { value.位[十の位] = "7"; }
                    if (dtr < 2500) value.位[百の位] = Random.Range(0, 10).ToString();
                    else
                    {
                        value.位[百の位] = "7";
                        Bv.ルーレットが回せる = false;
                        dtr = 0;
                        Bv.確定演出 = false;
                        Bv.動画切り替え = 3;
                    }
                }
                else
                {
                    dtr += 100;
                    if (dtr < 1000) value.位[一の位] = Random.Range(0, 10).ToString();
                    if (dtr < 1500) value.位[十の位] = Random.Range(0, 10).ToString();
                    if (dtr < 2500) value.位[百の位] = Random.Range(0, 10).ToString();
                    else
                    {
                        Bv.ルーレットが回せる = false;
                        dtr = 0;
                        if (value.位[一の位] == value.位[十の位] &&
                             value.位[十の位] == value.位[百の位] &&
                             value.位[百の位] == "7")
                        {
                            Bv.動画切り替え = 3;
                        }
                    }
                }
            }
            dt = 0;
        }
        dt += Time.deltaTime;
    }
}

namespace roulette
{
    public class value
    {
        public static string[] 位 { get; set; } = { "8", "8", "8" };
    }
}
