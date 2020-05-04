using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise07
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private double aspectRatio = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap LoadPCX(string filename)
        {
            byte[] imageData;
            int width;
            int height;
            int scanLineLength;
            int linePaddingSize;
            int bitsPerPixel = 8;

            using (BinaryReader br = new BinaryReader(File.OpenRead(filename)))
            {
                #region Reading the PCX file header
                // Get the image width and height
                br.BaseStream.Seek(4, SeekOrigin.Begin);
                short xStart = br.ReadInt16();
                short yStart = br.ReadInt16();
                short xEnd = br.ReadInt16();
                short yEnd = br.ReadInt16();
                width = (xEnd - xStart + 1);
                height = (yEnd - yStart + 1);
                aspectRatio = (double) height / (double)width;
                Width = (int)Math.Round(Height / aspectRatio);

                // Calculate the number of bytes required to hold a decoded scan line 
                br.BaseStream.Seek(65, SeekOrigin.Begin);
                byte numBitPlanes = br.ReadByte();
                short bytesPerLine = br.ReadInt16();
                scanLineLength = (numBitPlanes * bytesPerLine);

                linePaddingSize = ((bytesPerLine * numBitPlanes) * (8 / bitsPerPixel)) - ((xEnd - yStart) + 1);
                #endregion

                #region Reading the PCX file data
                imageData = new byte[scanLineLength * height];
                int position = 0;
                byte @byte;
                byte runCount;
                byte runValue;
                br.BaseStream.Seek(128, SeekOrigin.Begin);
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < scanLineLength; j++)
                    {
                        @byte = br.ReadByte();
                        if ((@byte & 0xC0) == 0xC0) // Two high bits are set
                        {
                            runCount = (byte)(@byte & 0x3F);
                            runValue = br.ReadByte();

                            

                        }
                        else
                        {
                            runCount = 1;
                            runValue = @byte;
                        }

                        // Write the pixel run to the buffer
                        if (j <= scanLineLength)
                            while (runCount != 0)
                            {
                                imageData[position++] = runValue;
                                runCount--;
                                j++;
                            }
                    }
                }
                #endregion

                #region Reading the color palette
                br.BaseStream.Seek(-769, SeekOrigin.End);
                if (br.ReadByte() == 0x0C) // number 12
                {
                }
                #endregion

                br.Close();
            }
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {

                }
            }

            #region Turning byte array into bitmap
            // Create the Bitmap to the know height, width and format
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            // Create a BitmapData and Lock all pixels to be written
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.WriteOnly, bmp.PixelFormat);

            // Copy the data from the byte array into BitmapData.Scan0

            Marshal.Copy(imageData, 0, bmpData.Scan0, imageData.Length);
            // Unlock the pixels
            bmp.UnlockBits(bmpData);
            #endregion

            bmp.Save("bmp.bmp");

            return bmp;
        }

        private string ChooseFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "pcx files (*.pcx)|*.pcx";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    return openFileDialog.FileName;
                }
                return string.Empty;
            }
        }

        private void LoadFileBtn_Click(object sender, EventArgs e)
        {
            string filename = ChooseFile();
            if (filename != string.Empty)
                pictureBox.Image = LoadPCX(filename);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Width = (int)Math.Round(Height / aspectRatio);
        }
    }
}
