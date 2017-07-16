//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Com.Ericmas001.LoggingDb.Models.ServiceInterfaces;
//using Microsoft.Practices.Unity;

//namespace Com.Ericmas001.LoggingDb.Test.Util
//{
//    class LoggingDbSystemUtil
//    {
//        public LoggingDbSystem System { get; }
//        public ILoggingDbContext Model { get; }
//        public SendRecoveryTokenTest.DummyEmailSender EmailSender { get; }
//        public LoggingDbSystemUtil(Action<ILoggingDbContext> initDb)
//        {
//            IUnityContainer container = new UnityContainer();
//            System = new LoggingDbSystem(container, Values.Salt);

//            Model = new DummyLoggingDbContext();
//            initDb(Model);
//            Model.SaveChanges();
//            container.RegisterInstance(Model);

//            EmailSender = new SendRecoveryTokenTest.DummyEmailSender();
//            container.RegisterInstance<ISendEmailService>(EmailSender);
//        }
//    }
//}
