using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileHelpers;

namespace Sample.DBRampUp.Wrapper
{
	[DelimitedRecord(",")]
	public class CustomerWrapper
	{
		[FieldQuoted(QuoteMode.OptionalForRead)]
		public string Name;
		
		[FieldQuoted(QuoteMode.OptionalForRead)]
		public string Phone;

		[FieldQuoted(QuoteMode.OptionalForRead)]
		public int Age;
	}
}