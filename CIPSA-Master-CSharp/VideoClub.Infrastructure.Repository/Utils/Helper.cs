using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace VideoClub.Infrastructure.Repository.Utils
{
    public class Helper
    {
        public static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        //public static readonly Assembly assembly = Assembly.Load("VuelingExam.Infrastructure.Repository");
        //public static readonly ResourceManager resourceManager = new ResourceManager("VuelingExam.Infrastructure.Repository.en-US", assembly);
        public static readonly string VideoClubConnection = ConfigurationManager.AppSettings.Get("VideoClubConnection");
    }
}
