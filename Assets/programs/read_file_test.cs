using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Bluetooth_value;

//
public class read_file_test : MonoBehaviour
{
    static string serial = "4523";
    string path = "C:\\Users\\yuuki\\動画再生\\Assets\\bluetooth_unity.pfu";
    float dt=0;
    float gt=0.5f;
    string before_deta;

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;
        if (dt>gt){
            string deta = File.ReadAllText(path);
            Debug.Log("Data is " + deta);
            if(before_deta!=deta){
                if(deta == serial + "00"){
                    Bv.push[0] = 1;
                }
            }
            before_deta = deta;
            dt=0;
        }
    }
}
