using System;

namespace BmpInspector
{
    static class BitmapHelper
    {

		static public void PrintRawHex(byte[] hex_data) {
			int line_counter = 0;
            foreach(byte s in hex_data) {
                Console.Write(s.ToString("X2"));
				line_counter++;
				if(line_counter == 16) {
					line_counter = 0;
					Console.Write("\n");
				}
				else {
					Console.Write(" ");
				}
            }
		}

		static public void PrintHexString(byte[] string_to_print) {
			foreach(byte s in string_to_print) {
				Console.Write(s.ToString("X2"));
				Console.Write(" ");
			}
		}

		static private void PrintDivider() {
			Console.Write(" | ");
		}

		static private void PrintSpacer() {
			Console.Write("\n\n");
		}

		static public void PrintFormattedHeader(MonochromeBitmap bitmap) {
			Console.WriteLine("Signature | File Size    | Reserved     | Data Offset");
			PrintHexString(bitmap.signature);
			Console.Write("    | ");
			PrintHexString(bitmap.file_size);
			PrintDivider();
			PrintHexString(bitmap.reserved);
			PrintDivider();
			PrintHexString(bitmap.data_offset);
			PrintSpacer();

			Console.WriteLine("Size         | Width        | Height       | Planes | Bits Per Pixel");
			PrintHexString(bitmap.size);
			PrintDivider();
			PrintHexString(bitmap.width);
			PrintDivider();
			PrintHexString(bitmap.height);
			PrintDivider();
			PrintHexString(bitmap.planes);
			PrintDivider();
			PrintHexString(bitmap.bits_per_pixel);
			PrintSpacer();

			Console.WriteLine("Compression  | Image Size   | XpixelsPerM  | YpixelsPerM");
			PrintHexString(bitmap.compression);
			PrintDivider();
			PrintHexString(bitmap.image_size);
			PrintDivider();
			PrintHexString(bitmap.xPixelsPerM);
			PrintDivider();
			PrintHexString(bitmap.yPixelsPerM);
			PrintSpacer();

			Console.WriteLine("Colors Used  | Important Colors");
			PrintHexString(bitmap.colors_used);
			PrintDivider();
			PrintHexString(bitmap.important_colors);
			PrintSpacer();

			Console.WriteLine("Red | Green | Blue | Reserved");
			for(int chunk = 0; chunk < 4; chunk++ ) {
				Console.Write(bitmap.color_table[chunk].ToString("X2"));
				PrintDivider();
			}
			PrintSpacer();
			Console.WriteLine("Red | Green | Blue | Reserved");
			for(int chunk = 4; chunk < 8; chunk++ ) {
				Console.Write(bitmap.color_table[chunk].ToString("X2"));
				PrintDivider();
			}			
			PrintSpacer();

			PrintPixelData(bitmap, true);
		}

		static public void PrintPixelData(MonochromeBitmap bitmap, Boolean withBinary = true) {
			int lineCounter = 0;
			string binaryLine = "";

			foreach(byte chunk in bitmap.pixel_data) {
				Console.Write(chunk.ToString("X2"));
				Console.Write(" " );
				lineCounter++;
				if(withBinary) {
					binaryLine += Convert.ToString(chunk, 2).PadLeft(8, '0');
					binaryLine += " ";
				}

				if(lineCounter == 4) {
					if(withBinary) {
						Console.Write( " | " + binaryLine );
						binaryLine = "";
					}
					Console.Write("\n");
					lineCounter = 0;
				}
			}
		}
	}

}