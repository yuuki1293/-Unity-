using UnityEngine;
using System.Diagnostics;
using Bluetooth_value;

public class start_teraterm : MonoBehaviour
{
    Process exProcess;
    bool 起動 = false;
    void Start()
    {

    }

    void Update()
    {
        if (!起動)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo()
            {
                FileName = "C:\\Program Files (x86)\\teraterm\\ttpmacro.exe",    // 実行するファイル 
                Arguments = Application.streamingAssetsPath + "\\tera_macro_unity.ttl",    // コマンドパラメータ（引数）
                CreateNoWindow = true,    // コンソール・ウィンドウを開かない
                UseShellExecute = false,  // シェル機能を使用しない
            };
            Process p = Process.Start(psInfo);
            起動 = true;
        }
        if (Bv.プログラム終了 == 1)
        {
            exProcess.CloseMainWindow();
            exProcess.Dispose();
            exProcess = null;
            Bv.プログラム終了 = 2;
        }
    }
}
