using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Bluetooth_value;

public class read_file_test : MonoBehaviour
{
    string path = "C:\\Users\\yuuki\\動画再生\\Assets\\bluetooth_unity.pfu";
    float dt=0;
    float gt=0.5f;
    string before_deta;

    //flag_change(受信した文字列,書き換える配列の番号（デフォルトで受信した文字列）,trueにするかfalseにするか（デフォルトでtrue）);
    void flag_change(string num1,int num2 = int.Parse(num1)-1000, bool t_f = true){
        Debug.Log("Successfully read" + num2);
        Bv.push_flag[num2] = t_f;
    }

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;
        if (dt>gt){
            string deta = File.ReadAllText(path);
            //Debug.Log("Data is " + deta);
            if(before_deta!=deta){
                //ここからフラグ管理
                flag_change();
                //ここまでフラグ管理
                before_deta = deta;
            }
            dt=0;
        }
    }
}
