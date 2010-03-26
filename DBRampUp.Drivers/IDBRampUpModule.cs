using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DBRampUp
{
    public interface IDBRampUpModule
    {
        /// <summary>
        /// Attach yourself to the event hub here
        /// </summary>
        /// <param name="hub">Event hub</param>
        void Initialize(DBRampUpContext context);

        /// <summary>
        /// Detach yourself from the event hub here
        /// </summary>
        /// <param name="hub">Event hub</param>
        void Finalize(DBRampUpContext context);

    }
}
