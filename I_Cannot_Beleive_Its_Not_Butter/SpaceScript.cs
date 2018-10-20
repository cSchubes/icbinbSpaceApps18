using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Drawing;

namespace I_Cannot_Beleive_Its_Not_Butter
{
    public class SpaceScript : MonoBehaviour
    {
        List<ImageProcessors> MMODImages = new List<ImageProcessors>();
        Camera cam;
        int resWidth = 2550;
        int resHeight = 3300;

        void Start()
        {
            cam = Camera.main;
        }
        void Update()
        {

        }

        void StartOnClick()
        {
            //Start drone navigation


            //Start the coroutine to start collecting Sensor data 
            StartCoroutine(GetSensorData());

        }

        IEnumerator GetSensorData()
        {
            yield return new WaitForSeconds(2);

            // Setup a camera, texture and render texture
            RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
            cam.targetTexture = rt;
            Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            cam.Render();
            // Read pixels to texture
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            camera.targetTexture = null;
            RenderTexture.active = null; // JC: added to avoid errors

            System.Drawing.Image im = ImageProcessors.byteArrayToImage(screenShot.EncodeToPNG());
            ImageProcessors image = new ImageProcessors(1, im)
            {
                X = cam.transform.position.x,
                Y = cam.transform.position.y,
                Z = cam.transform.position.z,
                Description = "ahahhahhaha",
            };

            MMODImages.Add(image);
        }
    }
}