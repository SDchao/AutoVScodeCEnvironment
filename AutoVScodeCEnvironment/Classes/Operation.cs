using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using SevenZip;
using System.Windows.Forms;
using System.Diagnostics;
using AutoVScodeCEnvironment;

namespace AutoVScodeCEnvironment.Classes
{
    class Operation
    {
        
        Form_Process form;

        public void Start(string projectPath,Form_main mainForm)
        {
            form = new Form_Process();
            form.Show();
            try
            {
                Thread thread = new Thread(() => StartThread(projectPath,mainForm));
                thread.Start();
            }
            catch(Exception e)
            {
                ExceptionHandler.ShowError("创建线程", e);
            }
            
        }

        private void StartThread(string projectPath,Form_main mainForm)
        {
            string phase = "创建.vscode目录";
            UpdateFormText(phase);
            try
            {
                string jsonPath = projectPath + @"\.vscode";
                if (!Directory.Exists(jsonPath))
                {
                    Directory.CreateDirectory(jsonPath);
                }

                phase = "写出json文件";
                UpdateFormText(phase);
                File.WriteAllBytes(jsonPath + "\\c_cpp_properties.json", Resource.c_cpp_properties);
                File.WriteAllBytes(jsonPath + "\\launch.json", Resource.launch);
                File.WriteAllBytes(jsonPath + "\\tasks.json", Resource.tasks);
                UpdateProcess(5);

                phase = "写出MinGW编译器文件";
                UpdateFormText(phase);
                string szPath = Path.GetTempPath() + "\\MinGW.7z";
                File.WriteAllBytes(szPath, Resource.MinGW);
                UpdateProcess(10);

                phase = "创建文件索引";
                UpdateFormText(phase);

                SevenZipExtractor extractor = new SevenZipExtractor(szPath);
                string targetPath = @"C:\MinGW";
                List<string> files = new List<string>();         

                foreach(var file in extractor.ArchiveFileData)
                {
                    if (!file.IsDirectory)
                    {
                        if (!File.Exists(targetPath + "\\" + file.FileName))
                        {
                            files.Add(file.FileName);
                        }
                    }
                }

                extractor.FileExtractionStarted += new EventHandler<FileInfoEventArgs>((s, e) =>
                {
                    UpdateProcess(10 + (int)(e.PercentDone * 0.7));
                });

                phase = "解压MinGW编译器文件";
                UpdateFormText(phase);
                extractor.ExtractFiles(targetPath, files.ToArray());

                if (File.Exists(Path.GetTempPath() + "\\MinGW.7z"))
                    File.Delete(Path.GetTempPath() + "\\MinGW.7z");

                phase = "设置环境变量";
                UpdateFormText(phase);
                string pathVar = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);
                Console.WriteLine(pathVar);
                if (!pathVar.Contains("C:\\MinGW\\bin"))
                {
                    if (!pathVar.EndsWith(";") && pathVar != string.Empty)
                    {
                        pathVar += ";";
                    }
                    pathVar += "C:\\MinGW\\bin;";
                    Environment.SetEnvironmentVariable("PATH", pathVar, EnvironmentVariableTarget.User);
                }
                UpdateProcess(90);

                phase = "安装Vscode C/C++插件";
                UpdateFormText(phase);
                string strOutPut = ExecuteOutCmd("code --install-extension ms-vscode.cpptools");
                if (!strOutPut.Contains("was successfully installed")
                    && !strOutPut.Contains("is already installed"))
                {
                    string tip = "未能成功安装C/C++插件" + "\n" + strOutPut
                        + "\n可能安装VScode后未重启计算机？" +
                        "\n该错误并不影响配置过程。您可以在启动VS code后手动安装C/C++插件";
                    MessageBox.Show(tip, "哎呦被玩坏了", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
                UpdateProcess(100);

                
                MessageBox.Show("已完成全部操作\n[]~(￣▽￣)~*" +
                    "\n若仍然调试失败，请尝试重启VS code" +
                    "\n如果该软件对您有帮助，欢迎点击左下角文字到B站三连~", "提示");
                form.Close();
                ExecuteOutCmd("code -a " + projectPath);

                mainForm.Visible = true;
                // Environment.Exit(0);
            }
            catch (Exception e)
            {
                ResetAllFiles(projectPath);
                ExceptionHandler.ShowError(phase, e);
            }
        }

        private void UpdateFormText(string phase)
        {
            form.UpdateText(phase);
        }

        private void UpdateProcess(int p)
        {
            form.UpdateProcess(p);
        }

        private void ResetAllFiles(string projectPath)
        {
            if (Directory.Exists(projectPath + "\\.vscode"))
            {
                Directory.Delete(projectPath + "\\.vscode", true);
            }

            if (File.Exists(Path.GetTempPath() + "\\MinGW.7z"))
                File.Delete(Path.GetTempPath() + "\\MinGW.7z");
        }

        public static string ExecuteOutCmd(string cmdline)
        {
            using (var process = new Process())
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                process.StandardInput.AutoFlush = true;
                process.StandardInput.WriteLine(cmdline + "&exit");

                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                process.Close();

                return output;
            }
        }
    }
}
