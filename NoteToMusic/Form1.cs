using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteToMusic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        //Değişkenleri global olarak tanımlama
        string selectedFile, editedImg, directoryPath, mxlFilePath, xmlFilePath, midiFilePath;

   

        private void Form1_Load(object sender, EventArgs e)
        {
            directoryPath = @".\Output";

        }

        private void fileInputBtn_Click(object sender, EventArgs e)
        {
            //FileDialog ile kullanıcıdan resim aldırma
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları|*.png;*.jpg;*.jpeg;*.bmp;*.pdf";
            openFileDialog.Title = "Nota Resmini Seç";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Resmi seçip pictureBox'a yükleme
                selectedFile = openFileDialog.FileName;
                pictureBox.ImageLocation = selectedFile;
                Console.WriteLine("Seçilen Dosya: " + selectedFile);



                //Dosyaların konumları
                directoryPath = @".\Output";
                string selectedWithout = Path.GetFileNameWithoutExtension(selectedFile);
                mxlFilePath = Path.Combine(directoryPath, selectedWithout + "-edited.mxl");
                xmlFilePath = Path.Combine(directoryPath, selectedWithout + "-edited.xml");
                midiFilePath = Path.Combine(directoryPath, selectedWithout + "-edited.mid");
                editedImg = Path.Combine(directoryPath, selectedWithout + "-edited.jpg");

                //Dönüştürme işlemleri
                Emgu.editImg(selectedFile, editedImg);
                Audiveris.ConvertToMusicXml(editedImg, directoryPath);
                ConvertExtension.Convert(mxlFilePath, xmlFilePath);
                ToMIDI.Convert(xmlFilePath, midiFilePath);
            }

        }
        private async void triggerBtn_ClickAsync(object sender, EventArgs e)
        {
            NAudio n = new NAudio();
            await n.PlayMIDI(midiFilePath);
        }

        

    }
}
