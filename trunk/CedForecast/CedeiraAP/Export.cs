using System;
using System.Data;
using System.Web;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.Threading;

namespace Cedeira.SV
{
	public class Export
	{		
		public enum ExportFormat : int {CSV = 1, Excel = 2}; 
			
		private string ReemplazarAcentos(string aux)
		{
			aux=aux.Replace("á","a");
			aux=aux.Replace("é","e");
			aux=aux.Replace("í","i");
			aux=aux.Replace("ó","o");
			aux=aux.Replace("ú","u");
			aux=aux.Replace("Á","A");
			aux=aux.Replace("É","E");
			aux=aux.Replace("Í","I");
			aux=aux.Replace("Ó","O");
			aux=aux.Replace("Ú","U");
			return aux;
		}
		
		private string ReemplazarXPath(string aux)
		{
			aux=aux.Replace("\"","'");
			aux=aux.Replace("N°","Nro");
			aux=aux.Replace("n°","nro");
			aux=aux.Replace("Nº","Nro");
			aux=aux.Replace("nº","nro");
			aux=aux.Replace("€","Euros");
			if (aux.StartsWith("(-"))
			{
				aux=aux.Replace("(-","-");
				aux=aux.Replace(")","");				
			}
			return ReemplazarAcentos(aux);
		}

		
		private string ReemplazarEspaciosyAcentos(string aux)
		{
			aux=aux.Replace("/","-");
			aux=aux.Replace(" ",String.Empty);
			aux=aux.Replace("u$s","Dolares");
			aux=aux.Replace("$","Pesos");
			aux=aux.Replace("(",String.Empty);
			aux=aux.Replace(")",String.Empty);
			return ReemplazarXPath(aux);
		}
		
		#region ExportDetails OverLoad : Type#1
		
		// Function  : ExportDetails 
		// Arguments : DetailsTable, FormatType, FileName
		// Purpose	 : To get all the column headers in the datatable and 
		//			   exorts in CSV / Excel format with all columns

		public void ExportDetails(DataTable DetailsTable, ExportFormat FormatType, string FileName)
		{
			try
			{				
				if(DetailsTable.Rows.Count == 0) 
					throw new Exception("There are no details to export.");				
				
				// Create Dataset
				DataSet dsExport = new DataSet("Export");
				DataTable dtExport = DetailsTable.Copy();
				dtExport.TableName = "Values"; 
				dsExport.Tables.Add(dtExport);	
				
				// Getting Field Names
				string[] sHeaders = new string[dtExport.Columns.Count];
				string[] sFileds = new string[dtExport.Columns.Count];
				
				for (int i=0; i < dtExport.Columns.Count; i++)
				{
					sHeaders[i] = dtExport.Columns[i].ColumnName;
					sFileds[i] = dtExport.Columns[i].ColumnName;					
				}
				Export_with_XSLT_Windows(dsExport, sHeaders, sFileds, FormatType, FileName);
			}			
			catch(Exception Ex)
			{
				throw Ex;
			}			
		}

		#endregion // ExportDetails OverLoad : Type#1

		#region ExportDetails OverLoad : Type#2

		// Function  : ExportDetails 
		// Arguments : DetailsTable, ColumnList, FormatType, FileName		
		// Purpose	 : To get the specified column headers in the datatable and
		//			   exorts in CSV / Excel format with specified columns

		public void ExportDetails(DataTable DetailsTable, int[] ColumnList, ExportFormat FormatType, string FileName)
		{
			try
			{
				if(DetailsTable.Rows.Count == 0)
					throw new Exception("There are no details to export");
				
				// Create Dataset
				DataSet dsExport = new DataSet("Export");
				DataTable dtExport = DetailsTable.Copy();
				dtExport.TableName = "Values"; 
				dsExport.Tables.Add(dtExport);

				if(ColumnList.Length > dtExport.Columns.Count)
					throw new Exception("ExportColumn List should not exceed Total Columns");
				
				// Getting Field Names
				string[] sHeaders = new string[ColumnList.Length];
				string[] sFileds = new string[ColumnList.Length];
				
				for (int i=0; i < ColumnList.Length; i++)
				{
					if((ColumnList[i] < 0) || (ColumnList[i] >= dtExport.Columns.Count))
						throw new Exception("ExportColumn Number should not exceed Total Columns Range");
					
					sHeaders[i] = dtExport.Columns[ColumnList[i]].ColumnName;
					sFileds[i] = dtExport.Columns[ColumnList[i]].ColumnName;					
				}
				Export_with_XSLT_Windows(dsExport, sHeaders, sFileds, FormatType, FileName);
			}			
			catch(Exception Ex)
			{
				throw Ex;
			}			
		}
		
		#endregion // ExportDetails OverLoad : Type#2

		#region ExportDetails OverLoad : Type#3

		// Function  : ExportDetails 
		// Arguments : DetailsTable, ColumnList, Headers, FormatType, FileName	
		// Purpose	 : To get the specified column headers in the datatable and	
		//			   exorts in CSV / Excel format with specified columns and 
		//			   with specified headers

		public void ExportDetails(DataTable DetailsTable, int[] ColumnList, string[] Headers, ExportFormat FormatType, 
			string FileName)
		{
			try
			{
				if(DetailsTable.Rows.Count == 0)
					throw new Exception("There are no details to export");
				
				// Create Dataset
				DataSet dsExport = new DataSet("Export");
				DataTable dtExport = DetailsTable.Copy();
				dtExport.TableName = "Values"; 
				dsExport.Tables.Add(dtExport);

				if(ColumnList.Length != Headers.Length)
					throw new Exception("ExportColumn List and Headers List should be of same length");
				else if(ColumnList.Length > dtExport.Columns.Count || Headers.Length > dtExport.Columns.Count)
					throw new Exception("ExportColumn List should not exceed Total Columns");
				
				// Getting Field Names
				string[] sFileds = new string[ColumnList.Length];
				
				for (int i=0; i < ColumnList.Length; i++)
				{
					if((ColumnList[i] < 0) || (ColumnList[i] >= dtExport.Columns.Count))
						throw new Exception("ExportColumn Number should not exceed Total Columns Range");
					
					sFileds[i] = dtExport.Columns[ColumnList[i]].ColumnName;					
				}
				Export_with_XSLT_Windows(dsExport, Headers, sFileds, FormatType, FileName);
			}			
			catch(Exception Ex)
			{
				throw Ex;
			}			
		}
		
		#endregion // ExportDetails OverLoad : Type#3


		#region Export_with_XSLT_Windows 

		// Function  : Export_with_XSLT_Windows 
		// Arguments : dsExport, sHeaders, sFileds, FormatType, FileName
		// Purpose   : Exports dataset into CSV / Excel format

		private void Export_with_XSLT_Windows(DataSet dsExport, string[] sHeaders, string[] sFileds, ExportFormat FormatType, string FileName)
		{
			try
			{				
				// XSLT to use for transforming this dataset.						
				MemoryStream stream = new MemoryStream( );
				System.Text.Encoding encod=System.Text.Encoding.GetEncoding("ISO-8859-1");
				XmlTextWriter writer = new XmlTextWriter(stream, encod);
				CreateStylesheet(writer, sHeaders, sFileds, FormatType);
				writer.Flush( ); 
				stream.Seek( 0, SeekOrigin.Begin); 
				XmlDocument xmlDoc = new XmlDocument();
				XmlDeclaration xmldecl;
				xmldecl = xmlDoc.CreateXmlDeclaration("1.0","ISO-8859-1","yes");
				XmlElement root = xmlDoc.DocumentElement;
				xmlDoc.InsertBefore(xmldecl, root);
				xmlDoc.LoadXml(dsExport.GetXml());
				
				XslTransform xslTran = new XslTransform();			

				StreamReader reader=new StreamReader(stream,encod); 
				XmlTextReader xmlTxtReader=new XmlTextReader(reader);

				xslTran.Load(xmlTxtReader, null, null);
				
				System.IO.StringWriter  sw = new System.IO.StringWriter();			
				xslTran.Transform(xmlDoc, null, sw, null);
									
				//Writeout the Content									
				StreamWriter strwriter =  new StreamWriter(FileName);
				if(dsExport.ExtendedProperties.ContainsKey("Nombre"))
				{
					strwriter.WriteLine(dsExport.ExtendedProperties["Nombre"].ToString());
				}
				strwriter.WriteLine(sw.ToString());
				strwriter.Close();
				
				sw.Close();	
				writer.Close();
				stream.Close();	
			}			
			catch(Exception Ex)
			{
				throw Ex;
			}
		}		
		
		#endregion // Export_with_XSLT 

		#region CreateStylesheet 

		// Function  : WriteStylesheet 
		// Arguments : writer, sHeaders, sFileds, FormatType
		// Purpose   : Creates XSLT file to apply on dataset's XML file 

		private void CreateStylesheet(XmlTextWriter writer, string[] sHeaders, string[] sFileds, ExportFormat FormatType)
		{
			try
			{
				// xsl:stylesheet
				string ns = "http://www.w3.org/1999/XSL/Transform";	
				writer.Formatting = Formatting.Indented;
				writer.WriteStartDocument( );				

				writer.WriteStartElement("xsl","stylesheet",ns);
				writer.WriteAttributeString("version","1.0");

				writer.WriteStartElement("xsl:output");
				writer.WriteAttributeString("method","text");
				writer.WriteAttributeString("version","4.0");
				writer.WriteAttributeString("encoding","ISO-8859-1");

				writer.WriteEndElement( );
				
				// xsl-template
				writer.WriteStartElement("xsl:template");
				writer.WriteAttributeString("match","/");

				// xsl:value-of for headers
				for(int i=0; i< sHeaders.Length; i++)
				{
					writer.WriteString("\"");
					writer.WriteStartElement("xsl:value-of");
					writer.WriteAttributeString("select", "'" + sHeaders[i] + "'");
					writer.WriteEndElement( ); // xsl:value-of
					writer.WriteString("\"");
					if (i != sFileds.Length - 1) writer.WriteString( (FormatType == ExportFormat.CSV ) ? "," : "	" );
				}
								
				// xsl:for-each
				writer.WriteStartElement("xsl:for-each");
				writer.WriteAttributeString("select","Export/Values");
				writer.WriteString("\r\n");				
				
				// xsl:value-of for data fields
				for(int i=0; i< sFileds.Length; i++)
				{					
					writer.WriteString("\"");
					writer.WriteStartElement("xsl:value-of");
					writer.WriteAttributeString("select", sFileds[i]);
					writer.WriteEndElement( ); // xsl:value-of
					writer.WriteString("\"");
					if (i != sFileds.Length - 1) writer.WriteString( (FormatType == ExportFormat.CSV ) ? "," : "	" );
				}
								
				writer.WriteEndElement( ); // xsl:for-each
				writer.WriteEndElement( ); // xsl-template
				writer.WriteEndElement( ); // xsl:stylesheet
				writer.WriteEndDocument( );					
			}
			catch(Exception Ex)
			{
				throw Ex;
			}
		}
		
		#endregion // WriteStylesheet

	}
}
