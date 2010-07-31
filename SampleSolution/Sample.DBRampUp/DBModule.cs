using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBRampUp;

namespace Sample.DBRampUp
{
	public class DBModule : IDBRampUpModule
	{
		public void Finalize(DBRampUpContext context)
		{
			
		}

		public void Initialize(DBRampUpContext context)
		{
			context.EventHub.BuildTestData += new DBRampUpEventHandler(EventHub_BuildTestData);

			DBRampUpProvider.Instance().SqlPath = "database\\sql";
		}

		void EventHub_BuildTestData(DBRampUpContext context)
		{
			
		}
	}
}
