using System;
using System.IO;

namespace BmpInspector
{
    class MonochromeBitmap
    {
		public byte[] image_data;
		public byte[] signature = new byte[2];
		public byte[] file_size = new byte[4];
		public byte[] reserved = new byte[4];
		public byte[] data_offset = new byte[4];
		public byte[] size = new byte[4];
		public byte[] width = new byte[4];
		public byte[] height = new byte[4];
		public byte[] planes = new byte[2];
		public byte[] bits_per_pixel = new byte[2];
		public byte[] compression = new byte[4];
		public byte[] image_size = new byte[4];
		public byte[] xPixelsPerM = new byte[4];
		public byte[] yPixelsPerM = new byte[4];
		public byte[] colors_used = new byte[4];
		public byte[] important_colors = new byte[4];
		public byte[] color_table;
		public byte[] pixel_data;


		public MonochromeBitmap(byte[] source_image) {
			this.image_data = source_image;
			ProcessImageData();
		}

		public MonochromeBitmap(string path) {
			this.image_data = File.ReadAllBytes(path);
			ProcessImageData();
		}

		private void ProcessImageData() {
			this.signature = this.image_data[0..2];
			this.file_size = this.image_data[2..6];
			this.reserved = this.image_data[6..10];
			this.data_offset = this.image_data[10..14];
			this.size = this.image_data[14..18];
			this.width = this.image_data[18..22];
			this.height = this.image_data[22..26];
			this.planes = this.image_data[26..28];
			this.bits_per_pixel = this.image_data[28..30];
			this.compression = this.image_data[30..34];
			this.image_size = this.image_data[34..38];
			this.xPixelsPerM = this.image_data[38..42];
			this.yPixelsPerM = this.image_data[42..46];
			this.colors_used = this.image_data[46..50];
			this.important_colors = this.image_data[50..54];

			if(this.colors_used[0] == 0x00) {
				Console.WriteLine("Monochrome Image");
				this.color_table = this.image_data[54..62];
				this.pixel_data = this.image_data[62..];
			}
			else {
				Console.WriteLine("This bitmap is not a monochrome image.");
			}
		}

	}

}