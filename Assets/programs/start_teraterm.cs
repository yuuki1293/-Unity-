using UnityEngine;
using System.Diagnostics;
using Bluetooth_value;

public class start_teraterm : MonoBehaviour
{
    bool 起動 = false;
    Process exProcess;
    void Update()
    {
        if (起動 == false)
        {
            exProcess = new Process();

            exProcess.StartInfo.FileName = "C:\\Program Files (x86)\\teraterm\\ttpmacro.exe";
            exProcess.StartInfo.Arguments = Application.streamingAssetsPath + "\\tera_macro_unity.ttl";
            exProcess.StartInfo.CreateNoWindow = true;
            exProcess.StartInfo.UseShellExecute = false;

            //外部のプロセスを実行する
            exProcess.Start();

            起動 = true;
        }
        if (Bv.プログラム終了 == 1)
        {

            exProcess.Kill();
            exProcess.Close();
            exProcess.Dispose();
            exProcess = null;

        }
    }
}