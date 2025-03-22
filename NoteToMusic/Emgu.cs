
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteToMusic
{
    public class Emgu
    {
        public static void editImg(string imagePath, string outputPath)
        {
            Mat image = Cv2.ImRead(imagePath, ImreadModes.Color);

            Mat grayImage = new Mat();
            Cv2.CvtColor(image, grayImage, ColorConversionCodes.BGR2GRAY);

            Mat doubledHeightImage = new Mat();
            Cv2.Resize(grayImage, doubledHeightImage, new Size(grayImage.Cols * 2, grayImage.Rows * 2), 0, 0, InterpolationFlags.Linear);

            Mat blurredImage = new Mat();
            Cv2.GaussianBlur(doubledHeightImage, blurredImage, new Size(3, 3), 0);

            Mat contrastImage = new Mat();
            double alpha = 1.5;  // Kontrast
            int beta = -90;      // Parlaklık
            blurredImage.ConvertTo(contrastImage, MatType.CV_8UC1, alpha, beta);

            Mat sharpenedImage = new Mat();
            float[,] kernelValues = new float[,]
            {
                { -1, -1, -1 },
                { -1,  9, -1 },
                { -1, -1, -1 }
            };
            Mat kernel = Mat.FromArray(kernelValues);
            Cv2.Filter2D(contrastImage, sharpenedImage, MatType.CV_8UC1, kernel);

            Mat binaryImage = new Mat();
            Cv2.Threshold(sharpenedImage, binaryImage, 127, 255, ThresholdTypes.Binary);

            Cv2.ImWrite(outputPath, binaryImage);


        }


    }
}
