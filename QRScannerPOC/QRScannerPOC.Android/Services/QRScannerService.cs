using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using QRScannerPOC.DependencyServices;
using System.Threading.Tasks;
using ZXing.Mobile;

[assembly: Dependency(typeof(QRScannerPOC.Droid.Services.QRScannerService))]
namespace QRScannerPOC.Droid.Services
{
    class QRScannerService : IQRScannerService
    {
        public async Task<string> ScanAsync()
        {
            var optionsDefault = new MobileBarcodeScanningOptions();
            var optionsCustom = new MobileBarcodeScanningOptions();

            var scanner = new MobileBarcodeScanner()
            {
                TopText = "Scan the QR Code",
                BottomText = "Please Wait",
            };

            var scanResult = await scanner.Scan(optionsCustom);
            return scanResult.Text;
        }
    }
}