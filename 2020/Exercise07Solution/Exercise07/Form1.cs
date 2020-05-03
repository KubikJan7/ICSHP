using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise07
{
    public partial class Form1 : Form
    {
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

                // Calculate the number of bytes required to hold a decoded scan line 
                br.BaseStream.Seek(65, SeekOrigin.Begin);
                byte numBitPlanes = br.ReadByte();
                short bytesPerLine = br.ReadInt16();
                scanLineLength = (numBitPlanes * bytesPerLine);

                linePaddingSize = ((bytesPerLine * numBitPlanes) * (8 / bitsPerPixel)) - ((xEnd - yStart) + 1);
                #endregion

                #region Reading the PCX file data
                imageData = new byte[scanLineLength];
                byte @byte;
                byte runCount;
                byte runValue;
                br.BaseStream.Seek(128, SeekOrigin.Begin);
                for (int i = 0; i < imageData.Length; i++)
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
                    while (runCount != 0)
                    {
                        if (i >= imageData.Length)
                            break;
                        imageData[i] = runValue;
                        runCount--;
                        i++;
                    }
                }

                #endregion

                br.Close();
            }

            //BinaryWriter bw = new BinaryWriter(File.OpenWrite("export.bmp"));
            //bw.Write(imageData);
            //bw.Close();


            Bitmap bmp = new Bitmap(width, height);
            using (var ms = new MemoryStream(imageData))
            {
                bmp = new Bitmap(ms);
            }
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
            pictureBox.Image = LoadPCX(ChooseFile());
        }
    }
}
