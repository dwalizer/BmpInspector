using System;

namespace BmpInspector
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0) {
                Console.WriteLine("Usage: bmpinspector input_file.bmp");
            }
            else {
                MonochromeBitmap image = new MonochromeBitmap(args[0]);
                BitmapHelper.PrintFormattedHeader(image);
            }
        }
    }
}
