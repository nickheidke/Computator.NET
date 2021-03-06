using System;
using System.Reflection;
using System.Windows.Forms;
using Computator.NET.DataTypes;
using Computator.NET.Logging;

namespace Computator.NET.UI.ErrorHandling
{
    public class SimpleErrorHandler : IErrorHandler
    {
        private static SimpleErrorHandler _instance;
        private readonly SimpleLogger.SimpleLogger logger;

        private SimpleErrorHandler()
        {
            logger = new SimpleLogger.SimpleLogger((GlobalConfig.AppName));
        }

        public static SimpleErrorHandler Instance { get; } = new SimpleErrorHandler();

        public void DispalyError(string message, string title)
        {
            MessageBox.Show(message, title);
        }

        public void LogError(string message, ErrorType errorType, Exception ex)
        {
            logger.MethodName = MethodBase.GetCurrentMethod().Name;
            logger.Log(message, ErrorType.General, ex);
        }
    }
}