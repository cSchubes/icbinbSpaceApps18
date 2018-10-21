using System;
using System.Collections.Generic;
using System.Drawing;
using IronPython.Hosting;

namespace I_Cannot_Beleive_Its_Not_Butter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<ImageProcessors> allim = new List<ImageProcessors>();
            Image i1 = Image.FromFile("cat1.jpeg");
            Image i2 = Image.FromFile("cat2.jpg");

            allim.Add(new ImageProcessors(1, i1));
            allim.Add(new ImageProcessors(2, i2));

            List<ImageObj> imgObj = new List<ImageObj>();
            imgObj.AddRange(allim);

            var ipy = Python.CreateRuntime();
            dynamic test = ipy.UseFile("ReturnDamaged.py");

            var resultImage = test.feed_model(imgObj);

            Console.WriteLine($"{imgObj[0].ID}");
            Console.WriteLine($"{imgObj[1].ID}");

        }
    }
}
