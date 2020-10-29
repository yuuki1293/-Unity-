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
    public bool[] local_flag = new bool[11];
    string deta = new string;

    //フラグの名前を書く場所
    //-------------------------------------------------------
    //0  工具1
    //1  工具2
    //2  工具3
    //3  工具4
    //4  工具5
    //-------------------------------------------------------

    //flag_change(受信した文字列,書き換える配列の番号（デフォルトで受信した文字列の後ろ二桁）,trueにするかfalseにするか（デフォルトでtrue）);
    void flag_change(string num1,int num2 = -1, bool t_f = true){
        if(deta == num1){
            if(num2 == -1){
                num2 = int.Parse(num1)-1000;
            }
            Debug.Log("Successfully read" + num2);
            Bv.push_flag[num2] = t_f;
        }
    }

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;
        for(int i = 0;i<Bv.flag_num;i++){
            local_flag[i] = Bv.push_flag[i];
        }
        if (dt>gt){
            deta = File.ReadAllText(path);
            //Debug.Log("Data is " + deta);
            if(before_deta!=deta){
                //ここからフラグ管理
                flag_change(deta);
                //ここまでフラグ管理
                before_deta = deta;
            }
            dt=0;
        }
    }
}

namespace Bluetooth_value{
    public class Bv{
        //フラグ数
        public static int flag_num = 11;
        public static bool[] push_flag = new bool[flag_num];
        
    }
}