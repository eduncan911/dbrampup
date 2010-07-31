using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileHelpers;

namespace Sample.DBRampUp
{
	public static class CsvReader
	{
		public static List<T> Read<T>(string filePath)
		{
			var engine = new FileHelperEngine<T>();
			return engine.ReadFile(filePath).ToList();
		}
	}
}
