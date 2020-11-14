using UnityEngine;
using System.IO;
using Bluetooth_value;
using UnityEngine.SceneManagement;

public class read_file_test : MonoBehaviour
{
    string path = "C:\\Users\\yuuki\\動画再生\\Assets\\bluetooth_unity.pfu";
    float dt = 0;
    float gt = 0.5f;
    string before_deta;
    public bool[] local_flag = new bool[Bv.box_flag_num];
    string deta = "";
    public string next_scene;

    //フラグの名前を書く場所
    //-------------------------------------------------------
    const int box1 = 0;
    const int box2 = 1;
    const int box3 = 2;
    const int box4 = 3;
    const int box5 = 4;
    //-------------------------------------------------------

    //flag_change(このデータが来たとき, 書き換える配列の番号（デフォルトで受信した文字列の後ろ二桁）,trueにするかfalseにするか（デフォルトでtrue）);
    void flag_change(int d, int num, bool t_f = true)
    {
        if (d == int.Parse(deta))
        {
            Debug.Log("Successfully read" + num);
            for (int i = 0; i < Bv.box_flag_num; i++)
            {
                Bv.push_flag[i] = false;
            }
            Bv.push_flag[num] = t_f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;
        for (int i = 0; i < Bv.box_flag_num; i++)
        {
            local_flag[i] = Bv.push_flag[i];
        }
        if (dt > gt)
        {
            deta = File.ReadAllText(path);
            if (before_deta != deta)
            {
                Debug.Log(deta);
                //ここからフラグ管理
                flag_change(1, box1);
                flag_change(2, box2);
                flag_change(3, box3);
                flag_change(4, box4);
                flag_change(5, box5);
                if (7 == int.Parse(deta)) Bv.動画だけ = true;
                if (8 == int.Parse(deta)) Bv.動画だけ = false;
                //ここまでフラグ管理
                before_deta = deta;
            }
            dt = 0;
        }
    }
}

namespace Bluetooth_value
{
    public class Bv
    {
        //フラグ数
        public static int box_flag_num { get; } = 5;
        public static bool[] push_flag = new bool[box_flag_num];
        public static bool 動画だけ = false;

    }
}