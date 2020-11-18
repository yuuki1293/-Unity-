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
            if (exProcess == null)
            {
                string path
                    = Application.dataPath + "/test.wmv";

                exProcess = new Process();

                exProcess.StartInfo.FileName = "C:\\Program Files\\Windows Media Player\\wmplayer.exe";
                exProcess.StartInfo.Arguments = path;

                //外部プロセスの終了を検知してイベントを発生させます.
                exProcess.EnableRaisingEvents = true;
                exProcess.Exited += exProcess_Exited;

                //外部のプロセスを実行する
                exProcess.Start();
            }
            起動 = true;
        }
        if (Bv.プログラム終了 == 1)
        {
            if (exProcess.HasExited == false)
            {
                exProcess.CloseMainWindow();
                exProcess.Dispose();
                exProcess = null;
            }
        }
    }
    void exProcess_Exited(object sender, System.EventArgs e)
    {
        UnityEngine.Debug.Log("Event!");
        exProcess.Dispose();
        exProcess = null;
    }
}