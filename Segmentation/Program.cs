using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Cvb;
using Emgu.CV.Util;
using System.Drawing;
using System.Collections.Generic;
using ContourAnalysis;
using System.Linq;

namespace Segmentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к файлу фала, или поместите файл в папку ..\\Assets\\Input под названием input.jpg");
            string inputPath = Console.ReadLine();
            
            if (inputPath != "")
            {
                //TODO: Проверка на корректность пути
            }
            else 
            {
                inputPath = @"C:\Selective_Search\Assets\input_1.jpg";
            }
            string outputPath = @"C:\Selective_Search\Assets\outputConture.jpg";
            
            Mat matInput = new Mat(inputPath);

            BinaryImage matrix = new BinaryImage(inputPath);
            VectorOfVectorOfPoint contour = ContourSegmentation.GetAllContours(matrix.Image);
            contour = ContourSegmentation.SortContours(contour);
            List<Rectangle> Box = ContourSegmentation.GetRectangle(contour);
            ContourSegmentation.DelineationOfRectangles(matInput, Box, outputPath);

            Console.WriteLine("Done");
        }
    }
}
