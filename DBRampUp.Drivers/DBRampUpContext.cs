using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DBRampUp
{
    public class DBRampUpContext
    {
        public SetupArgs SetupArgs { get; set; }
        public DBRampUpEventHub EventHub { get; internal set; }
    }
}
