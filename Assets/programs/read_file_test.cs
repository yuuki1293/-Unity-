using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class read_file_test : MonoBehaviour
{
    string path = "C:\\Users\\yuuki\\動画再生\\Assets\\bluetooth_unity.pfu";
    float dt=0;
    float gt=0.5;

    // static async void delay_500min()
    // {
    //     await Task.Delay(5000);
    // }

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;
        if (dt>gt){
            string data = File.ReadAllText(path);
            Debug.Log("Data is " + data);
            dt=0;
        }
    }
}
