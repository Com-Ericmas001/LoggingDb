//using Com.Ericmas001.LoggingDb.Test.Util;
//using Xunit;

//namespace Com.Ericmas001.LoggingDb.Test
//{
//    public class EmailExistsTest
//    {
//        [Fact]
//        public void WithNoUserReturnsFalse()
//        {
//            // Arrange
//            var util = new LoggingDbSystemUtil(delegate { });

//            // Act
//            var result = util.System.EmailExists(Values.EmailSpongeBob);

//            // Assert
//            Assert.False(result);
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
//            var result = util.System.EmailExists(Values.EmailDora);

//            // Assert
//            Assert.False(result);
//        }
//        [Fact]
//        public void WithValidUserReturnsTrue()
//        {
//            // Arrange
//            var util = new LoggingDbSystemUtil(delegate (ILoggingDbContext model)
//            {
//                model.Users.Add(Values.UserSpongeBob);
//            });


//            // Act
//            var result = util.System.EmailExists(Values.EmailSpongeBob);

//            // Assert
//            Assert.True(result);
//        }
//    }
//}
