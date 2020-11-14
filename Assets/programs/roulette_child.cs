using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roulette_child : MonoBehaviour
{
    string 一桁;
    public Text te;

    // Update is called once per frame
    void Update()
    {
        te.text = 一桁;
    }
}
