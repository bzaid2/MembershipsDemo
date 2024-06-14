using log4net.Config;
using log4net.Core;
using log4net;
using System.Reflection;
using System.Xml;
using MembershipsDemo.Interfaces;

namespace MembershipsDemo.Plugins
{
    public class LoggerManager : ILoggerManager
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(LoggerManager));
        public LoggerManager()
        {
            try
            {
                XmlDocument log4netConfig = new XmlDocument();

                using (var fs = File.OpenRead("log4net.config"))
                {
                    log4netConfig.Load(fs);

                    var repo = LogManager.CreateRepository(
                            Assembly.GetEntryAssembly(),
                            typeof(log4net.Repository.Hierarchy.Hierarchy));
                    string ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                    GlobalContext.Properties["FilePath"] = ruta.Substring(6, ruta.Length - 6);
                    XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Error", ex);
            }
        }

        public void Information(string message)
        {
            _logger.Info(message);
        }
        public void Information(string message, Exception ex)
        {
            _logger.Info(message, ex);
        }
        public void Warning(string message)
        {
            _logger.Warn(message);
        }
        public void Warning(string message, Exception ex)
        {
            _logger.Warn(message, ex);
        }
        public void Error(string message)
        {
            _logger.Error(message);
        }
        public void Error(string message, Exception ex)
        {
            _logger.Error(message, ex);
        }
    }
}