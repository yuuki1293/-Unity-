using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bluetooth_value;
using roulette;

public class roulette_pare : MonoBehaviour
{
    const int 一の位 = 0;
    const int 十の位 = 1;
    const int 百の位 = 2;
    void Update()
    {
        if (Bv.ルーレットが回せる)
        {
            value.位[一の位] = Random.Range(0, 10).ToString();
            value.位[十の位] = Random.Range(0, 10).ToString();
            value.位[百の位] = Random.Range(0, 10).ToString();
            Debug.Log(value.位);
            Bv.ルーレットが回せる = false;
        }

    }
}

namespace roulette
{
    public class value
    {
        public static string[] 位 { get; set; } = { "8", "8", "8" };
    }
}
