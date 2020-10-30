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
    const int box1 = 1;
    const int box2 = 2;
    const int box3 = 3;
    const int box4 = 4;
    const int box5 = 5;
    //-------------------------------------------------------

    //flag_change(このデータが来たとき, 書き換える配列の番号（デフォルトで受信した文字列の後ろ二桁）,trueにするかfalseにするか（デフォルトでtrue）);
    void flag_change(string d = "-1", int num = -1, bool t_f = true){
        if(num != -1 && d == deta){
                Debug.Log("Successfully read" + num);
                Bv.push_flag[num] = t_f;
            
        }else if(d == deta){
            Bv.push_flag[int.Parse(deta)-1000] = t_f;
            Debug.Log("Successfully read" + deta);
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
                flag_change("1001", box1);
                flag_change("1002", box2);
                flag_change("1003", box3);
                flag_change("1004", box4);
                flag_change("1005", box5);
                flag_change("1006", box1, false);
                flag_change("1007", box2, false);
                flag_change("1008", box3, false);
                flag_change("1009", box4, false);
                flag_change("1010", box5, false);
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