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
    public bool[] local_flag = new bool[Bv.flag_num];
    string deta = "";

    //フラグの名前を書く場所
    //-------------------------------------------------------
    const int box1 = 0;
    const int box2 = 1;
    const int box3 = 2;
    const int box4 = 3;
    const int box5 = 4;
    //-------------------------------------------------------

    //flag_change(このデータが来たとき, 書き換える配列の番号（デフォルトで受信した文字列の後ろ二桁）,trueにするかfalseにするか（デフォルトでtrue）);
    void flag_change(int d, int num, bool t_f = true){
        if(d == int.Parse(deta)){
                Debug.Log("Successfully read" + num);
                Bv.push_flag[num] = t_f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;
        for(int i = 0;i<Bv.flag_num;i++){
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
                
                flag_change(1, box1);
                flag_change(2, box2);
                flag_change(3, box3);
                flag_change(4, box4);
                flag_change(5, box5);
                flag_change(6, box1, false);
                flag_change(6, box2, false);
                flag_change(6, box3, false);
                flag_change(6, box4, false);
                flag_change(6, box5, false);
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
        public static int flag_num = 5;
        public static bool[] push_flag = new bool[flag_num];
        
    }
}