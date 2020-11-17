using UnityEngine;
using System.Diagnostics;

public class start_teraterm : MonoBehaviour
{
    Process exProcess;
    void Start()
    {
        ProcessStartInfo psInfo = new ProcessStartInfo()
        {
            FileName = "C:\\Program Files (x86)\\teraterm\\ttpmacro.exe",    // 実行するファイル 
            Arguments = Application.streamingAssetsPath + "\\tera_macro_unity.ttl",    // コマンドパラメータ（引数）
            CreateNoWindow = true,    // コンソール・ウィンドウを開かない
            UseShellExecute = false,  // シェル機能を使用しない
        };
        Process p = Process.Start(psInfo);
        //p.WaitForExit();
    }

    void Update()
    {
        ;
    }
}
