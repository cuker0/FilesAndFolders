using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNI005H_JSON
{
    public class DeviceState
    {
        [JsonProperty("ProductText")]  // atrybuty
        public string Product { get; set; }
        public string VendorName { get; set; }
        public string VendorText { get; set; }
        public string ProductName { get; set; }
        public string ProductId { get; set; }
        public string SerialNumber { get; set; }
        public string HwRev { get; set; }
        public string FwRev { get; set; }
        public string ApplTag { get; set; }
        public string Event { get; set; }
        public string EventFlag { get; set; }
        public string ProcessInputs { get; set; }
        public string ProcessOutputs { get; set; }
        public string DirectParameters { get; set; }
        public string Status { get; set; }
        public string DsContentVendorId { get; set; }
        public string DsContentDeviceId { get; set; }
        public string DsContentChecksum { get; set; }
        public string DsContentBuffer { get; set; }
    }
}

