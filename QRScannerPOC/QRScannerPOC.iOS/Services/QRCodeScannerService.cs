using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using QRScannerPOC.DependencyServices;
using UIKit;
using Xamarin.Forms;
using ZXing.Mobile;

[assembly: Dependency(typeof(QRScannerPOC.iOS.Services.QRCodeScannerService))]
namespace QRScannerPOC.iOS.Services
{
    class QRCodeScannerService : IQRScannerService
    {
        public async Task<string> ScanAsync()
        {
            var scanner = new MobileBarcodeScanner();
            var scanResults = await scanner.Scan();

            return (scanResults != null) ? scanResults.Text : string.Empty;
        }
    }
}