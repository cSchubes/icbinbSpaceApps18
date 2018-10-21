using System;
using System.Collections.Generic;
using IronPython.Hosting;
using System.Drawing;
using System.Linq;
using System.IO;

namespace I_Cannot_Beleive_Its_Not_Butter
{
    public class ImageProcessors : ImageObj
    {
        public ImageProcessors(int iD, Image cameraImage)
        : base(iD, cameraImage)
        {

        }
        private float x, y, z;
        private string description;

        // Sensor Data 
        private int depthImage;

        //TODO: make a coordinate object?
        public float Z { get => z; set => z = value; }
        public float Y { get => y; set => y = value; }
        public float X { get => x; set => x = value; }
        public int DepthImage { get => depthImage; set => depthImage = value; }
        public string Description { get => description; set => description = value; }

        public static List<ImageProcessors> ProcessImages(List<ImageProcessors> allImages)
        {
            List<ImageProcessors> postiveImages = new List<ImageProcessors>();
            var sendImages = new List<ImageObj>();
            sendImages.AddRange(allImages); 

            var ipy = Python.CreateRuntime();
            dynamic test = ipy.UseFile("test.py");
            
            List<ImageObj> resultImage = test.my_function(sendImages);

            postiveImages = (List<ImageProcessors>)resultImage.Select(res => res.ID).Intersect(allImages.Select(a => a.ID));

            return postiveImages;
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        

    }

}