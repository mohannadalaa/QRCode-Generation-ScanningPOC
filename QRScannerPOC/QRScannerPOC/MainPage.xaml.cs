using QRScannerPOC.DependencyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing;

namespace QRScannerPOC
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Generate_Barcode(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(BCString.Text))
            {
                BarcodeImageView.BarcodeValue = BCString.Text;
                BarcodeImageView.IsVisible = true;
            }
        }

        //Using Dependency Service .. Stable
        private async void Scan_QRcode_FirstWay_DS(object sender, EventArgs e)
        {
            try
            {
                var scanner = DependencyService.Get<IQRScannerService>();
                var result = await scanner.ScanAsync();
                if (result != null)
                {
                    resultt.Text = result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Using built-in Library Component ..
       public void Scan_QRcode_2ndway(object sender, EventArgs e)
        {
            BarcodeImageView.IsVisible = false;
            //BarcodeScanView.IsVisible = true;
            //BarcodeScanView.IsScanning = true;
        }

        public void Handle_OnScanResult(Result result)
        {
            if (string.IsNullOrWhiteSpace(result.Text))
                return;
            resultt.Text = result.Text;

        }

    }
}
