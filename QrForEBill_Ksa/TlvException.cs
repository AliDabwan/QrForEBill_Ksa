using System;

namespace QrForEBill_Ksa
{
	public class TlvException : Exception
	{
		public TlvException(string message) : base(message)
		{
		


		}

		public TlvException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}