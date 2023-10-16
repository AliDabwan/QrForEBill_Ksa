using Greensoft.TlvLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QrForEBill_Ksa
{
   public class GetAcceptedQr
    {
        private  string MexucName;
        private  string MtaxNumber;
        private  double MnetBill; //
		private  string MCompanyName;

		private  DateTime MTimeStamp;
		private  double MbillVatValue;

        public  string GetQr(string exucName, string companyName, string taxNumber, DateTime timeStamp, double netBill, double billVatValue)
        {
			string name2 = System.AppDomain.CurrentDomain.FriendlyName;

			return name2;
		}
		public string GetQr()
		{
			string name2 = System.AppDomain.CurrentDomain.FriendlyName;

			return name2;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="exucName">Enter the exe file name of your app.</param>
		/// <param name="companyName">your company name </param>
		/// <param name="taxNumber"> your tax number </param>
		/// <param name="timeStamp">bill datetime as - yyyy-MM-ddTHH:mm:ss </param>
		/// <param name="netBill"> Bill net Amount After Vat </param> 
		/// <param name="billVatValu"> the VAT Value </param>
		/// <returns></returns>
		public string getAcceptedQR( string companyName, string taxNumber, DateTime timeStamp, double netBill, double billVatValu)
		{
            //string myFn = "restaurantpos10.exe"; 
            //string myFn = "murunaeasypos.exe";
			// Name of the application  that will use this dll
            string myFn = "restaurantpos10.exe";

            string name2 = System.AppDomain.CurrentDomain.FriendlyName;
            if (myFn != name2.ToLower())
            {
                return "هذا البرنامج غير مرخص";
            }
            GetAcceptedQr.TagedValue[] tagedValue = new GetAcceptedQr.TagedValue[] { new GetAcceptedQr.TagedValue(1, companyName ?? string.Empty), new GetAcceptedQr.TagedValue(2, taxNumber ?? string.Empty), null, null, null };
			//DateTime dateCreated = DateTime.Now;
			tagedValue[2] = new GetAcceptedQr.TagedValue(3, timeStamp.ToString("yyyy-MM-ddTHH:mm:ss"));
			tagedValue[3] = new GetAcceptedQr.TagedValue(4, string.Format("{0:R}", netBill));
			tagedValue[4] = new GetAcceptedQr.TagedValue(5, string.Format("{0:R}", billVatValu));
			string str = GetAcceptedQr.UseTlvLibFor((IEnumerable<GetAcceptedQr.TagedValue>)tagedValue);
			
			return str;

			//Parameters.Add("E_INVOICE_QR_CODE_GENERATED_VALUE", str);


		}
		//Parameters.Add("E_INVOICE_QR_CODE_GENERATED_VALUE", str);


	
		private static string UseTlvLibFor(IEnumerable<GetAcceptedQr.TagedValue> input)
		{
			string base64String;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				input.ToList<GetAcceptedQr.TagedValue>().ForEach((GetAcceptedQr.TagedValue tlv) => TlvEncoding.WriteTlv(memoryStream, tlv.Tag, tlv.Value));
				base64String = Convert.ToBase64String(memoryStream.ToArray());
			}
			return base64String;
		}

		protected class TagedValue
		{
			public uint Tag
			{
				get;
				set;
			}

			public byte[] Value
			{
				get;
				set;
			}

			public TagedValue(uint tag, string value)
			{
				this.Tag = tag;
				this.Value = Encoding.UTF8.GetBytes(value);
			}
		}

	}
}
