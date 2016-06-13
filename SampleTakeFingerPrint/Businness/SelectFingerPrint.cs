using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SampleTakeFingerPrint.Businness
{
    public class SelectFingerPrint
    {
        [STAThread]
        public string TakeSelectedFingerPrint()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"D:\Projects\FingerprintRecognition_v2.2\Fingerprint_Database\FVC2000\DB1_B";
            Stream stream = null;
            string ImagePath = "";
            dialog.RestoreDirectory = true;


            var thread = new Thread(new ParameterizedThreadStart(param => { dialog.ShowDialog(); }));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ImagePath = dialog.FileName;
            }

            return ImagePath;
        }
    }
}
