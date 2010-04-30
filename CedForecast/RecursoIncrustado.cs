using System;
using System.Reflection;

namespace Cedeira
{
	public class RecursoIncrustado
	{

		public void GuardarRecursoIncrustado()
		{
			// get a reference to the current assembly
			Assembly a = Assembly.GetExecutingAssembly();
        
			// get a list of resource names from the manifest
			string [] resNames = a.GetManifestResourceNames();

			foreach(string s in resNames)
			{
				if (!s.EndsWith("resources") && !s.EndsWith("licenses") && !s.EndsWith("license") && !s.EndsWith("ico"))
				{	
					if(!System.IO.File.Exists(Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\"+s))
					{
						System.IO.Stream aStream;
						aStream = this.GetType().Assembly.GetManifestResourceStream(s);
						System.IO.FileStream aFileStream=new System.IO.FileStream(Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\"+s,System.IO.FileMode.Create,System.IO.FileAccess.Write);
						int Length = 256;
						Byte [] buffer = new Byte[Length];
						int bytesRead = aStream.Read(buffer,0,Length);
						while( bytesRead > 0 )
						{
							aFileStream.Write(buffer,0,bytesRead);
							bytesRead = aStream.Read(buffer,0,Length);
						}
						aStream.Close();
						aFileStream.Close();
					}
				}
			}
		}
	}
}
