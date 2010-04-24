using System;
using System.IO;
using System.Security.Cryptography;

namespace Cedeira.SV
{
	public class Cripto
	{
		private RSACryptoServiceProvider rsa;
		private void GrabarClaveCompleta(CspParameters cp, RSACryptoServiceProvider rsa)
		{
			StreamWriter s = new StreamWriter(cp.KeyContainerName + ".pubpriv.rsa");
			rsa.PersistKeyInCsp = false;
			s.WriteLine(rsa.ToXmlString(true));
			s.Close();
		}
		private void GrabarClavePublica(CspParameters cp, RSACryptoServiceProvider rsa)
		{
			StreamWriter s = new StreamWriter(cp.KeyContainerName + ".pub.rsa");
			rsa.PersistKeyInCsp = false;
			s.WriteLine(rsa.ToXmlString(false));
			s.Close();
		}
		private void AsignarParametros(string ClavePrivada)
		{
			const int PROVIDER_RSA_FULL = 1;
			CspParameters cspParams;
			cspParams = new CspParameters(PROVIDER_RSA_FULL);
			cspParams.KeyContainerName = ClavePrivada;
			rsa = new RSACryptoServiceProvider(cspParams);
			FileStream fileStream = File.OpenRead(ClavePrivada + ".pubpriv.rsa");
			StreamReader streamReader = new StreamReader(fileStream);
			string privateKeyXML = streamReader.ReadToEnd();
			streamReader.Close();
			rsa.FromXmlString(privateKeyXML);
		}
		public void GrabarClaves(string NombreAplicacion)
		{
			const int PROVIDER_RSA_FULL = 1;
			CspParameters cspParams;
			cspParams = new CspParameters(PROVIDER_RSA_FULL);
			cspParams.KeyContainerName = NombreAplicacion;
			rsa = new RSACryptoServiceProvider(cspParams);
			GrabarClaveCompleta(cspParams, rsa);
			GrabarClavePublica(cspParams, rsa);
		}
		public string EncryptData(string data2Encrypt, string ClavePrivadaPropia, string ClavePublicaAjena)
		{
			AsignarParametros(ClavePrivadaPropia);
			StreamReader reader = new StreamReader(ClavePublicaAjena + ".pub.rsa");
			string publicOnlyKeyXML = reader.ReadToEnd();
			rsa.FromXmlString(publicOnlyKeyXML);
			reader.Close();
			byte[] plainbytes = System.Text.Encoding.UTF8.GetBytes(data2Encrypt);
			byte[] cipherbytes = rsa.Encrypt(plainbytes, false);
			return Convert.ToBase64String(cipherbytes);
		}
		public string DecryptData(string data2Decrypt, string ClavePrivadaPropia)
		{
			AsignarParametros(ClavePrivadaPropia);
			byte[] getpassword = Convert.FromBase64String(data2Decrypt);
			byte[] plain = rsa.Decrypt(getpassword, false);
			return System.Text.Encoding.UTF8.GetString(plain);
		}
	}	
}

