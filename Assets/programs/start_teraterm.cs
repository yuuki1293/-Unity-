// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using static System.Diagnostics.Process;

// public class start_teraterm : MonoBehaviour
// {
//     Process exProcess;
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (exProcess == null)
//         {
//             string path
//                 = Application.dataPath + "/test.wmv";
 
//             exProcess = new Process();
 
//             exProcess.StartInfo.FileName
// 　　　　　　　 = "C:\\Users\\yuuki\\動画再生\\Assets\\tera_macro_unity.ttl";
//             exProcess.StartInfo.Arguments = path;
 
//             //外部プロセスの終了を検知してイベントを発生させます.
//             exProcess.EnableRaisingEvents = true;
//             exProcess.Exited += exProcess_Exited;
 
//             //外部のプロセスを実行する
//             exProcess.Start();
//         }
//     }

//     void exProcess_Exited(object sender, System.EventArgs e)
// {
//     UnityEngine.Debug.Log("Event!");
//     exProcess.Dispose();
//     exProcess = null;
// }
// }
