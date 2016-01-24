using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace Foody.Services
{
    public static class Logger
    {
        private static ILog mLogger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static ILog Instance()
        {
            return mLogger;
        }
    } 
}