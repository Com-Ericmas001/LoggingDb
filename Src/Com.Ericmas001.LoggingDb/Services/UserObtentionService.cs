//using System;
//using System.Linq;
//using Com.Ericmas001.LoggingDb.Models.Responses;
//using Com.Ericmas001.LoggingDb.Models.ServiceInterfaces;

//namespace Com.Ericmas001.LoggingDb.Services
//{
//    public class UserObtentionService : IUserObtentionService
//    {
//        private readonly ILoggingDbContext m_DbContext;

//        public UserObtentionService(ILoggingDbContext dbContext)
//        {
//            m_DbContext = dbContext;
//        }

//        public int FromUsername(string username)
//        {
//            return m_DbContext.Users.SingleOrDefault(x => x.Active && x.Name.Equals(username, StringComparison.InvariantCultureIgnoreCase))?.IdUser ?? 0;
//        }

//        public int FromEmail(string email)
//        {
//            return m_DbContext.Users.SingleOrDefault(x => x.Active && x.UserAuthentication.RecoveryEmail.Equals(email, StringComparison.InvariantCultureIgnoreCase))?.IdUser ?? 0;
//        }

//        public bool UsernameExists(string username)
//        {
//            return FromUsername(username) != 0;
//        }

//        public bool EmailExists(string email)
//        {
//            return FromEmail(email) != 0;
//        }

//        public ListUsersResponse ListAllUsers(string askingUser, Guid token)
//        {
//            throw new NotImplementedException();
//        }

//        public UserSummaryResponse UserSummary(string askingUser, Guid token, string requestedUser)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
