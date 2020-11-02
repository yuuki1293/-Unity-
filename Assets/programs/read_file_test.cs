﻿using System.Collections;
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
    public bool[] local_flag = new bool[Bv.flag_num];
    string deta = "";

    //フラグの名前を書く場所
    //-------------------------------------------------------
    const int box1 = 1;
    const int box2 = 2;
    const int box3 = 3;
    const int box4 = 4;
    const int box5 = 5;
    //-------------------------------------------------------

    //flag_change(このデータが来たとき, 書き換える配列の番号（デフォルトで受信した文字列の後ろ二桁）,trueにするかfalseにするか（デフォルトでtrue）);
    void flag_change(int d, int num, bool t_f = true){
        if(d == int.Parse(deta)){
                Debug.Log("Successfully read" + num);
                Bv.push_flag[num] = t_f;
        }
    }

    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;
        for(int i = 0;i<11;i++){
            local_flag[i] = Bv.push_flag[i];
        }
        if (dt>gt){
            deta = File.ReadAllText(path);
            // Debug.Log("////"+deta);
            // string buf = "1001";
            //Debug.Log("Data is " + deta);
            if(before_deta!=deta){
                Debug.Log(deta);
                //ここからフラグ管理
                
                flag_change(1001, box1);
                flag_change(1002, box2);
                flag_change(1003, box3);
                flag_change(1004, box4);
                flag_change(1005, box5);
                flag_change(1006, box1, false);
                flag_change(1007, box2, false);
                flag_change(1008, box3, false);
                flag_change(1009, box4, false);
                flag_change(1010, box5, false);
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