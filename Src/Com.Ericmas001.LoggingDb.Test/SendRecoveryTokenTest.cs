//using System;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
//using System.Linq;
//using Com.Ericmas001.LoggingDb.Models;
//using Com.Ericmas001.LoggingDb.Models.ServiceInterfaces;
//using Com.Ericmas001.LoggingDb.Test.Util;
//using Xunit;

//namespace Com.Ericmas001.LoggingDb.Test
//{
//    public class SendRecoveryTokenTest
//    {
//        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
//        [SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
//        public class DummyEmailSender : ISendEmailService
//        {
//            public List<Tuple<RecoveryToken,string,string>> TokenSent { get; } = new List<Tuple<RecoveryToken, string, string>>();
//            public void SendRecoveryToken(RecoveryToken token, string username, string email)
//            {
//                TokenSent.Add(new Tuple<RecoveryToken, string, string>(token,username,email));
//            }
//        }

//        [Fact]
//        public void EmptyUsersReturnsFalse()
//        {
//            // Arrange
//            var util = new LoggingDbSystemUtil(delegate { });

//            // Act
//            var result = util.System.SendRecoveryToken(Values.UsernameSpongeBob);

//            // Assert
//            Assert.False(result);
//        }
//        [Fact]
//        public void ValidUsernameReturnsTrue()
//        {
//            // Arrange
//            var user = Values.UserSpongeBob;
//            var util = new LoggingDbSystemUtil(delegate (ILoggingDbContext model)
//            {
//                model.Users.Add(user);
//            });

//            // Act
//            var result = util.System.SendRecoveryToken(Values.UsernameSpongeBob);

//            // Assert
//            Assert.True(result);
//            Assert.Equal(1, user.UserRecoveryTokens.Count);
//            var token = user.UserRecoveryTokens.Single();

//            Assert.Equal(1, util.EmailSender.TokenSent.Count);
//            var sended = util.EmailSender.TokenSent.Single();

//            Assert.Equal(token.Token, sended.Item1.Id);
//            Assert.Equal(token.Expiration, sended.Item1.ValidUntil);
//            Assert.Equal(user.Name, sended.Item2);
//            Assert.Equal(user.UserAuthentication.RecoveryEmail, sended.Item3);
//        }
//    }
//}
