using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QRScannerPOC.DependencyServices
{
    public interface IQRScannerService
    {
        Task<string> ScanAsync();
    }
}
