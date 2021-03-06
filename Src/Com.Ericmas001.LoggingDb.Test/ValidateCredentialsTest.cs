﻿//using Com.Ericmas001.LoggingDb.Test.Util;
//using Xunit;

//namespace Com.Ericmas001.LoggingDb.Test
//{
//    public class ValidateCredentialsTest
//    {
//        [Fact]
//        public void WithNoUserReturnsFalse()
//        {
//            // Arrange
//            var util = new LoggingDbSystemUtil(delegate { });

//            // Act
//            var result = util.System.ValidateCredentials(Values.UsernameSpongeBob, Values.PasswordSpongeBob);

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
//            var result = util.System.ValidateCredentials(Values.UsernameDora, Values.PasswordDora);

//            // Assert
//            Assert.False(result.Success);
//        }
//        [Fact]
//        public void WithValidUserWrongPasswordReturnsFalse()
//        {
//            // Arrange
//            var util = new LoggingDbSystemUtil(delegate (ILoggingDbContext model)
//            {
//                model.Users.Add(Values.UserSpongeBob);
//            });

//            // Act
//            var result = util.System.ValidateCredentials(Values.UsernameSpongeBob, Values.PasswordDumb);

//            // Assert
//            Assert.False(result.Success);
//        }
//        [Fact]
//        public void WithValidUserValidPasswordReturnsTrue()
//        {
//            // Arrange
//            var util = new LoggingDbSystemUtil(delegate (ILoggingDbContext model)
//            {
//                model.Users.Add(Values.UserSpongeBob);
//            });

//            // Act
//            var result = util.System.ValidateCredentials(Values.UsernameSpongeBob, Values.PasswordSpongeBob);

//            // Assert
//            Assert.True(result.Success);
//        }
//    }
//}
