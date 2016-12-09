using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CommandLine;
using CID.Utility;

namespace JenkinsTest
{
    public class Program
    {
        public IRepository Repository { get; private set; }
        public const string Name = "JenkinsTest";

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += (obj, ueea) => 
                SendError(ueea.ExceptionObject as Exception);

            Log.Logger = new LoggerConfiguration()
                    .ReadFrom.AppSettings()
                    .CreateLogger();

            var repository = new SqlRepository
                (ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

            var program = new Program(repository);
        }

        public Program(IRepository repository)
        {
            Repository = repository;
        }

        protected static void SendError(Exception e)
        {
            if (typeof(AggregateException) == e.GetType())
                e = e.GetBaseException();

            Log.Error(e, "ERR");
            Emailer.Send(new Email(
                ConfigurationManager.AppSettings["EmailErrorsTo"],
                String.Format("ERROR: {0}", Name),
                String.Format("ERROR: {0} @ {1}\n\n{2}", Name, DateTime.Now, e.Message)
            ));
            Environment.Exit(1);
        }
    }
}

