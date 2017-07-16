//using System;
//using Com.Ericmas001.LoggingDb.Test.Util;
//using Xunit;

//namespace Com.Ericmas001.LoggingDb.Test
//{
//    public class ValidateTokenTest
//    {
//        [Fact]
//        public void WithNoUserReturnsFalse()
//        {
//            // Arrange
//            var util = new LoggingDbSystemUtil(delegate { });

//            // Act
//            var result = util.System.ValidateToken(Values.UsernameSpongeBob, Values.ValidToken.Token);

//            // Assert
//            Assert.False(result.Success);
//        }

//        [Fact]
//        public void WithInvalidUserReturnsFalse()
//        {
//            // Arrange
//            var util = new LoggingDbSystemUtil(delegate (ILoggingDbContext model)
//            {
//                model.Users.Add(Values.UserSpongeBob);
//            });

//            // Act
//            var result = util.System.ValidateToken(Values.UsernameDora, Values.ValidToken.Token);

//            // Assert
//            Assert.False(result.Success);
//        }
//        [Fact]
//        public void WithValidUserNoTokensReturnsFalse()
//        {
//            // Arrange
//            var util = new LoggingDbSystemUtil(delegate (ILoggingDbContext model)
//            {
//                model.Users.Add(Values.UserSpongeBob);
//            });

//            // Act
//            var result = util.System.ValidateToken(Values.UsernameSpongeBob, Values.ValidToken.Token);

//            // Assert
//            Assert.False(result.Success);
//        }
//        [Fact]
//        public void WithValidUserInvalidTokenReturnsFalse()
//        {
//            // Arrange
//            var util = new LoggingDbSystemUtil(delegate (ILoggingDbContext model)
//            {
//                var u = Values.UserSpongeBob;
//                u.UserTokens.Add(Values.ValidToken);
//                model.Users.Add(u);
//            });

//            // Act
//            var result = util.System.ValidateToken(Values.UsernameSpongeBob, Guid.NewGuid());

//            // Assert
//            Assert.False(result.Success);
//        }
//        [Fact]
//        public void WithValidUserExpiredTokenReturnsFalse()
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
//            var result = util.System.ValidateToken(Values.UsernameSpongeBob, tok.Token);

//            // Assert
//            Assert.False(result.Success);
//        }
//        [Fact]
//        public void WithValidUserValidTokenReturnsTrue()
//        {
//            // Arrange
//            var tok = Values.ValidToken;
//            var expiration = tok.Expiration;
//            var util = new LoggingDbSystemUtil(delegate (ILoggingDbContext model)
//            {
//                var u = Values.UserSpongeBob;
//                u.UserTokens.Add(tok);
//                model.Users.Add(u);
//            });

//            // Act
//            var result = util.System.ValidateToken(Values.UsernameSpongeBob, tok.Token);

//            // Assert
//            Assert.True(result.Success);
//            Assert.Equal(tok.Token, result.Token.Id);
//            Assert.True(expiration < result.Token.ValidUntil);
//        }
//    }
//}
