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
using System.Windows.Media.Imaging;

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
            Bitmap bmp = null;
            byte[] imageData;
            int width;
            int height;
            int scanLineLength;
            int linePaddingSize;
            int bitsPerPixel = 8;
            bool hasColorPalette = false;

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
                aspectRatio = (double)height / (double)width;
                Width = (int)Math.Round(Height / aspectRatio);

                // Calculate the number of bytes required to hold a decoded scan line 
                br.BaseStream.Seek(65, SeekOrigin.Begin);
                byte numBitPlanes = br.ReadByte();
                short bytesPerLine = br.ReadInt16();
                scanLineLength = (numBitPlanes * bytesPerLine);
                linePaddingSize = (scanLineLength * (8 / bitsPerPixel)) - width;
                #endregion

                #region Reading the PCX file data
                imageData = new byte[numBitPlanes * (width+1) * height];
                byte[] scanLine = new byte[scanLineLength];
                int position = 0;
                byte @byte = 0;
                byte runCount = 0;
                byte runValue = 0;
                br.BaseStream.Seek(128, SeekOrigin.Begin);
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < numBitPlanes; j++)
                    {
                        for (int k = 0; k < bytesPerLine; k++)
                        {
                            //Write the pixel run to the buffer
                            if (runCount == 0)
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
                            }

                            while (runCount > 0 && k < bytesPerLine)
                            {
                                imageData[position++] = runValue;
                                runCount--;
                                k++;
                            }
                        }

                        //for (int l = 0; l < width; l++)
                        //{
                        //    imageData[position++] = scanLine[l]; 
                        //}
                    }
                }
                #endregion

                #region Reading the color palette
                br.BaseStream.Seek(-769, SeekOrigin.End);
                if (br.ReadByte() == 0x0C) // number 12
                {
                    hasColorPalette = true;

                    bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
                    ColorPalette palette = bmp.Palette;
                    Color[] entries = palette.Entries;

                    for (int i = 0; i < entries.Length; i++)
                    {
                        entries[i] = Color.FromArgb(br.ReadByte(), br.ReadByte(), br.ReadByte());
                    }
                    bmp.Palette = palette;
                }
                #endregion

                br.Close();
            }


            #region Turning byte array into bitmap
            // Create the Bitmap to the know height, width and format
            if (!hasColorPalette)
            {
                bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                int pos = 0;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color c;

                        if (hasColorPalette)
                        {
                            c = Color.FromArgb(imageData[pos]);
                        }
                        else
                        {
                            c = Color.FromArgb(imageData[pos], imageData[pos + (width)], imageData[pos + 2 * (width)]);

                        }
                        bmp.SetPixel(x, y, c);
                        pos++;
                    }
                    pos += 2 * width+3;
                }
            }
            else
            {
                // Create a BitmapData and Lock all pixels to be written
                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                    ImageLockMode.WriteOnly, bmp.PixelFormat);

                // Copy the data from the byte array into BitmapData.Scan0

                Marshal.Copy(imageData, 0, bmpData.Scan0, imageData.Length);
                // Unlock the pixels
                bmp.UnlockBits(bmpData);
                #endregion
            }
            bmp.Save(filename.Substring(0, filename.Length - 4) + ".bmp");

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
