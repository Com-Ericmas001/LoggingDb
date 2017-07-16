//using System;
//using Com.Ericmas001.LoggingDb.Test.Util;
//using Xunit;

//namespace Com.Ericmas001.LoggingDb.Test
//{
//    public class DisconnectTest
//    {
//        [Fact]
//        public void WithInvalidUsernameReturnsFalse()
//        {
//            // Arrange
//            var util = new LoggingDbSystemUtil(delegate{});

//            // Act
//            var result = util.System.Disconnect(Values.UsernameSpongeBob, Guid.NewGuid());

//            // Assert
//            Assert.False(result);
//        }
//        [Fact]
//        public void WithValidUsernameButNoTokenReturnsFalse()
//        {
//            // Arrange
//            var util = new LoggingDbSystemUtil(delegate (ILoggingDbContext model)
//            {
//                model.Users.Add(Values.UserSpongeBob);
//            });

//            // Act
//            var result = util.System.Disconnect(Values.UsernameSpongeBob, Guid.NewGuid());

//            // Assert
//            Assert.False(result);
//        }
//        [Fact]
//        public void WithValidUsernameButInvalidTokenReturnsFalse()
//        {
//            // Arrange
//            var util = new LoggingDbSystemUtil(delegate (ILoggingDbContext model)
//            {
//                var u = Values.UserSpongeBob;
//                u.UserTokens.Add(Values.ValidToken);
//                model.Users.Add(u);
//            });

//            // Act
//            var result = util.System.Disconnect(Values.UsernameSpongeBob, Guid.NewGuid());

//            // Assert
//            Assert.False(result);
//        }
//        [Fact]
//        public void WithValidUsernameButExpiredTokenReturnsFalse()
//        {
//            // Arrange
//            var tok = Values.ExpiredToken;
//            var util = new LoggingDbSystemUtil(delegate (ILoggingDbContext model)
//            {
//                var u = Values.UserSpongeBob;
//                u.UserTokens.Add(tok);
//                model.Users.Add(u);
//            });

//            // Act
//            var result = util.System.Disconnect(Values.UsernameSpongeBob, tok.Token);

//            // Assert
//            Assert.False(result);
//        }
//        [Fact]
//        public void WithValidUsernameValidNotExpiredToken()
//        {
//            // Arrange
//            var tok = Values.ValidToken;
//            var u = Values.UserSpongeBob;
//            var util = new LoggingDbSystemUtil(delegate (ILoggingDbContext model)
//            {
//                u.UserTokens.Add(tok);
//                model.Users.Add(u);
//                model.Users.Add(Values.UserDora);
//            });

//            // Act
//            var result = util.System.Disconnect(Values.UsernameSpongeBob, tok.Token);

//            // Assert
//            Assert.True(result);
//            Assert.True(tok.Expiration < DateTime.Now);
//        }
//    }
//}
