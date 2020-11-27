using UnityEngine;
using System.IO;
using Bluetooth_value;

public class read_file_test : MonoBehaviour
{
    string bluetooth_unity = Application.streamingAssetsPath + "\\bluetooth_unity.pfu";
    float dt = 0;
    float gt = 0.5f;
    string before_deta;
    public bool[] local_flag = new bool[Bv.box_flag_num];
    string deta = "";

    //フラグの名前を書く場所
    //-------------------------------------------------------
    const int box1 = 0;
    const int box2 = 1;
    const int box3 = 2;
    const int box4 = 3;
    const int box5 = 4;
    //-------------------------------------------------------


    void flag_change(string このデータが来たとき, int 置き換える配列の番号, bool trueにするかfalseにするか = true)
    {
        if (int.Parse(このデータが来たとき) == int.Parse(deta))
        {
            Debug.Log("Successfully read" + 置き換える配列の番号);
            // if(Bv.動画切り替え == 2)Bv.ルーレットが回せる = true;
            for (int i = 0; i < 5; i++)
            {
                Bv.push_flag[i] = false;
            }
            Bv.push_flag[置き換える配列の番号] = trueにするかfalseにするか;
        }
    }

    void reset(string このデータが来たとき)
    {
        if (int.Parse(このデータが来たとき) == int.Parse(deta))
        {
            for (int i = 0; i < 5; i++)
            {
                Bv.push_flag[i] = false;
            }
        }
    }

    void program_finish()
    {
        File.WriteAllText(bluetooth_unity, "");
        Application.Quit();
    }

    void Start()
    {
        while (dt < 3)
            dt += Time.deltaTime;
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
            deta = File.ReadAllText(bluetooth_unity);
            deta = deta.Replace("\n", "");
            if (before_deta != deta && int.TryParse(deta, out int a))
            {
                Debug.Log(deta);
                //ここからフラグ管理
                reset("00");
                flag_change("01", box1);
                flag_change("02", box2);
                flag_change("03", box3);
                flag_change("04", box4);
                flag_change("05", box5);
                if (int.Parse("06") == int.Parse(deta)) Bv.動画だけ = true;
                if (int.Parse("07") == int.Parse(deta)) Bv.動画だけ = false;
                if (int.Parse("08") == int.Parse(deta)) Bv.動画切り替え = 0;
                if (int.Parse("09") == int.Parse(deta)) Bv.動画切り替え = 1;
                if (int.Parse("10") == int.Parse(deta)) Bv.動画切り替え = 2;
                if (int.Parse("11") == int.Parse(deta)) program_finish();
                if (int.Parse("12") == int.Parse(deta)) Bv.確定演出 = true;
                if (int.Parse("13") == int.Parse(deta) && Bv.動画切り替え == 2) Bv.ルーレットが回せる = true;

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
        public static bool[] push_flag { get; set; } = new bool[box_flag_num];
        public static bool 動画だけ { get; set; } = false;
        public static bool ルーレットが回せる { get; set; } = false;
        public static byte 動画切り替え { get; set; } = 0;
        public static int プログラム終了 { get; set; } = 0;
        public static bool 確定演出 { get; set; } = false;
        public static bool daisuke { get; set; } = false;
    }
}