using SharpCompress.Common;
using SharpCompress.Readers;
using System;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;

namespace MS
{   




    /// <summary>
    /// ms读取文件类
    /// </summary>
    public class MSHelper
    {  


        /// <summary>
        /// 下载解压文件
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool Download(string url)
        {

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var file = httpClient.GetByteArrayAsync(url).Result;
                    //下载压缩包
                   // Bytes2File(file, @"D:\\3dmax.zip");
                    //解压文件
                    ExtractToDirectory("http://192.168.0.251:8888/previews/1171610671746519040.zip", @"D:\\");
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="buff"></param>
        /// <param name="savepath"></param>
        public void Bytes2File(byte[] buff, string savepath)
        {
            if (File.Exists(savepath))
                File.Delete(savepath);
            using (FileStream fs = new FileStream(savepath, FileMode.CreateNew))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write(buff, 0, buff.Length);
                }
            }
        }
        /// <summary>
        /// 解压文件
        /// </summary>
        /// <param name="zipPath"></param>
        /// <param name="unZipPath"></param>
        public void ExtractToDirectory(string zipPath, string unZipPath)
        {

            using (var httpclient = new HttpClient())
            {   
                var reader = ReaderFactory.Open(httpclient.GetStreamAsync(zipPath).Result);
                while (reader.MoveToNextEntry())
                {
                    reader.WriteEntryToDirectory(unZipPath, new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
                }
            }
        }

        // 声明INI文件的写操作函数 WritePrivateProfileString()
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        // 声明INI文件的读操作函数 GetPrivateProfileString()
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, System.Text.StringBuilder retVal, int size, string filePath);
        
        public string sPath = null;
        public void WriteValue(string section, string key, string value)
        {
            // section=配置节，key=键名，value=键值，path=路径
            WritePrivateProfileString(section, key, value, sPath);
        }
        public string ReadValue(string section, string key)
        {
            // 每次从ini中读取多少字节
            var temp = new StringBuilder(255);
            // section=配置节，key=键名，temp=上面，path=路径
            GetPrivateProfileString(section, key, "", temp, 255, sPath);
            return temp.ToString();
        }





    }
}
