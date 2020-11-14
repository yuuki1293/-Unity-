using UnityEngine;
using System.Diagnostics;
using System.IO;

public class start_teraterm : MonoBehaviour
{
    Process exProcess;
    // Start is called before the first frame update
    void Start()
    {
        ProcessStartInfo psInfo = new ProcessStartInfo()
        {
            FileName = "C:\\Program Files (x86)\\teraterm\\ttpmacro.exe",    // 実行するファイル 
            Arguments = Directory.GetCurrentDirectory() + "\\Assets\\tera_macro_unity.ttl",    // コマンドパラメータ（引数）
            CreateNoWindow = true,    // コンソール・ウィンドウを開かない
            UseShellExecute = false,  // シェル機能を使用しない
        };
        Process p = Process.Start(psInfo);
        //p.WaitForExit();
    }
}
