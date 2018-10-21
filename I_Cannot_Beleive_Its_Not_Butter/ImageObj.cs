using System.Drawing;

namespace I_Cannot_Beleive_Its_Not_Butter
{
    public class ImageObj
    {
        private int iD;
        private Image cameraImage;
        public int ID { get => iD; set => iD = value; }
        public Image CameraImage { get => cameraImage; set => cameraImage = value; }

        public ImageObj(int _id, Image _cameraimage)
        {
            iD = _id;
            cameraImage = _cameraimage;
        }
    }
}