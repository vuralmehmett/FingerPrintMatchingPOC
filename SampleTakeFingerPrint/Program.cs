using System;
using System.IO;
using System.Windows.Forms;
using SampleTakeFingerPrint.BaseHttpRequest;
using SampleTakeFingerPrint.Model;
using System.Threading;

namespace SampleTakeFingerPrint
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ConsoleKeyInfo tus = new ConsoleKeyInfo();
            Console.WriteLine("Welcome ! Do you want match fingerprint ? y/n ");
            tus = Console.ReadKey(true);
            Console.Clear();

            string key;
            while ((tus.KeyChar.ToString() != "n"))
            {

                ProcessInput(tus.KeyChar.ToString());
            }

        }

        private static void ProcessInput(string keyValue)
        {
            switch (keyValue)
            {
                case "y":
                    SelectFingerPrint();
                    break;
               
                case "n":
                    Console.WriteLine("Bitti");
                    break;
            }
        }
    


    public static void SelectFingerPrint()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"D:\Projects\FingerprintRecognition_v2.2\Fingerprint_Database\FVC2000\DB1_B";
            Stream stream = null;
            string ImagePath = "";
            dialog.RestoreDirectory = true;


            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ImagePath = dialog.FileName;
            }

            var model = new FingerPrintRequest
            {
                ImagePath = ImagePath
            };

            var conn = new Connection();
            var result = conn.Post(model);
            Console.WriteLine("Similarity is " + "%" + result);
          
        }
    }
}
