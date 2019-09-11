using MS;
using System;
using System.IO;
using System.Reflection;

namespace TestMS
{
    class Program
    {  

        static void Main(string[] args)
        {   

            var ms = new MSHelper();


            //string[] files = Directory.GetFiles(@"D:\MS\Cache\ms");
            //foreach (string file in files)
            //{
            //    Console.WriteLine(file);
            //}

            var res = ms.Download("https://resapi.neobai.com/previews/1168736497478799360.zip");

            Console.WriteLine(res ? "成功" : "失败");

            var materialParamet = new MaterialParamet();
            ms.sPath = @"D:\MS\Cache\ms\ms.ini";

            foreach (PropertyInfo key in materialParamet.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var value = ms.ReadValue("fileInfo", key.Name);
                if (key.Name == nameof(materialParamet.MaxVersion))
                    materialParamet.MaxVersion = value;
                else if (key.Name == nameof(materialParamet.Render))
                    materialParamet.Render = value;
                else if (key.Name == nameof(materialParamet.Vertices))
                    materialParamet.Vertices = value;
                else if (key.Name == nameof(materialParamet.Faces))
                    materialParamet.Faces = value;
                else if (key.Name == nameof(materialParamet.Objects))
                    materialParamet.Objects = value;
                else if (key.Name == nameof(materialParamet.Shapes))
                    materialParamet.Shapes = value;
                else if (key.Name == nameof(materialParamet.Lights))
                    materialParamet.Lights = value;
                else if (key.Name == nameof(materialParamet.Cameras))
                    materialParamet.Cameras = value;
                else if (key.Name == nameof(materialParamet.Helpers))
                    materialParamet.Helpers = value;
                else if (key.Name == nameof(materialParamet.SpaceWarps))
                    materialParamet.SpaceWarps = value;
                else if (key.Name == nameof(materialParamet.Total))
                    materialParamet.Total = value;
                else if (key.Name == nameof(materialParamet.maps))
                    materialParamet.maps = value;
                else if (key.Name == nameof(materialParamet.Materials))
                    materialParamet.Materials = value;
                else if (key.Name == nameof(materialParamet.Gamma))
                    materialParamet.Gamma = value;
                else if (key.Name == nameof(materialParamet.Width))
                    materialParamet.Width = value;
                else if (key.Name == nameof(materialParamet.Length))
                    materialParamet.Length = value;
                else if (key.Name == nameof(materialParamet.Height))
                    materialParamet.Height = value;
                else if (key.Name == nameof(materialParamet.Bone))
                    materialParamet.Bone = value;
                else if (key.Name == nameof(materialParamet.Animation))
                    materialParamet.Animation = value;
            }


            Console.ReadKey();
        }
    }
}
