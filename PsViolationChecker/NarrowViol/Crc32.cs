using System;
using System.IO;

namespace NarrowViol
{
	public static class Crc32 
	{
		private const UInt32 _defaultPolynomial = 0xedb88320;
		private const UInt32 _defaultSeed = 0xffffffff;
	
		private static UInt32[] _defaultTable;


		public static UInt32 GetFileHash(string fileName)
		{
            byte[] fileContent = null;
            try
            {
                fileContent = File.ReadAllBytes(fileName);
                return Compute(fileContent);
            }
            catch (IOException e)
            {
                // Extract some information from this exception, and then 
                // throw it to the parent method.
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
            }
            return 0;
		}

	

		public static UInt32 Compute(byte[] buffer)
		{
			return ~CalculateHash(InitializeTable(_defaultPolynomial), _defaultSeed, buffer, 0, buffer.Length);
		}

		private static UInt32[] InitializeTable(UInt32 polynomial)
		{
			if (polynomial == _defaultPolynomial && _defaultTable != null)
				return _defaultTable;

			var createTable = new UInt32[256];
			for (var i = 0; i < 256; i++)
			{
				var entry = (UInt32)i;
				for (int j = 0; j < 8; j++)
					if ((entry & 1) == 1)
						entry = (entry >> 1) ^ polynomial;
					else
						entry = entry >> 1;
				createTable[i] = entry;
			}

			if (polynomial == _defaultPolynomial)
				_defaultTable = createTable;

			return createTable;
		}

		private static UInt32 CalculateHash(UInt32[] table, UInt32 seed, byte[] buffer, int start, int size)
		{
			var crc = seed;
			for (var i = start; i < size; i++)
				unchecked
				{
					crc = (crc >> 8) ^ table[buffer[i] ^ crc & 0xff];
				}
			return crc;
		}
		
	}

    //    public string XmlHash(XmlDocument myDoc)
    //{
    //    // System.Security.Cryptography.MACTripleDES hash = new System.Security.Cryptography.MACTripleDES(Encoding.Default.GetBytes("mykey"));
    //    // string hashString = Convert.ToBase64String(hash.ComputeHash(Encoding.Default.GetBytes(myXMLString)));


    //    var t = new System.Security.Cryptography.Xml.XmlDsigC14NTransform();
    //    t.LoadInput(myDoc);
    //    var s = (Stream)t.GetOutput(typeof(Stream));
    //    var sha1 = SHA1.Create();

    //    var hash = sha1.ComputeHash(s);
    //    var base64String = Convert.ToBase64String(hash);
    //    s.Close();
    //    return base64String;
    //}
}
