//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Com.Ericmas001.LoggingDb.Entities;
//using Com.Ericmas001.LoggingDb.Models;
//using Com.Ericmas001.LoggingDb.Models.Requests;
//using Com.Ericmas001.LoggingDb.Models.Responses;
//using Com.Ericmas001.LoggingDb.Models.ServiceInterfaces;

//namespace Com.Ericmas001.LoggingDb.Services
//{
//    public class UserGroupingService : IUserGroupingService
//    {
//        private readonly ILoggingDbContext m_DbContext;
//        private readonly IUserConnectionService m_UserConnectionService;

//        public UserGroupingService(ILoggingDbContext dbContext, IUserConnectionService userConnectionService)
//        {
//            m_DbContext = dbContext;
//            m_UserConnectionService = userConnectionService;
//        }

//        public TokenSuccessResponse AddUserToGroup(AddUserToGroupRequest request)
//        {
//            var connection = m_UserConnectionService.ConnectWithToken(request.Username, request.Token);

//            if (!connection.Success)
//                return InvalidResponse;

//            User requestingUser = m_DbContext.Users.Single(x => x.IdUser == connection.IdUser);

//            if (requestingUser.UserGroups.All(x => x.UserGroupType.Name != UserGroupType.ADMIN_GRP))
//                return InvalidResponse;

//            User userToAdd = m_DbContext.Users.SingleOrDefault(x => x.Name == request.UserToAdd && x.Active);

//            if (userToAdd == null || userToAdd.UserGroups.Any(x => x.IdUserGroupType == request.IdGroup))
//                return InvalidResponse;

//            userToAdd.UserGroups.Add(new UserGroup { IdUser = userToAdd.IdUser, IdUserGroupType = request.IdGroup });

//            m_DbContext.SaveChanges();

//            return connection;
//        }

//        public TokenSuccessResponse ExcludeUserFromGroup(string requestingUsername, Guid token, string userToExclude, int idGroup)
//        {
//            var connection = m_UserConnectionService.ConnectWithToken(requestingUsername, token);

//            if (!connection.Success)
//                return InvalidResponse;

//            User requestingUser = m_DbContext.Users.Single(x => x.IdUser == connection.IdUser);

//            if (requestingUser.UserGroups.All(x => x.UserGroupType.Name != UserGroupType.ADMIN_GRP))
//                return InvalidResponse;

//            User userToAdd = m_DbContext.Users.SingleOrDefault(x => x.Name == userToExclude && x.Active);

//            if (userToAdd == null || userToAdd.UserGroups.All(x => x.IdUserGroupType != idGroup))
//                return InvalidResponse;

//            var grp = userToAdd.UserGroups.Single(x => x.IdUserGroupType == idGroup);
//            userToAdd.UserGroups.Remove(grp);
//            m_DbContext.UserGroups.Remove(grp);

//            m_DbContext.SaveChanges();

//            return connection;
//        }

//        private TokenSuccessResponse InvalidResponse => new TokenSuccessResponse
//        {
//            Token = null,
//            Success = false
//        };
//    }
//}
