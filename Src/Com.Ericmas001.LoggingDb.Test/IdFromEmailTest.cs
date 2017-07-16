//using Com.Ericmas001.LoggingDb.Test.Util;
//using Xunit;

//namespace Com.Ericmas001.LoggingDb.Test
//{
//    public class IdFromEmailTest
//    {
//        [Fact]
//        public void WithNoUserReturnsZero()
//        {
//            // Arrange
//            var util = new LoggingDbSystemUtil(delegate { });

//            // Act
//            var result = util.System.IdFromEmail(Values.EmailSpongeBob);

//            // Assert
//            Assert.Equal(0, result);
//        }

//        [Fact]
//        public void WithInvalidUserReturnsZero()
//        {
//            // Arrange
//            var util = new LoggingDbSystemUtil(delegate (ILoggingDbContext model)
//            {
//                model.Users.Add(Values.UserSpongeBob);
//            });

//            // Act
//            var result = util.System.IdFromEmail(Values.EmailDora);

//            // Assert
//            Assert.Equal(0, result);
//        }
//        [Fact]
//        public void WithValidUserReturnsId()
//        {
//            // Arrange
//            var util = new LoggingDbSystemUtil(delegate (ILoggingDbContext model)
//            {
//                model.Users.Add(Values.UserSpongeBob);
//            });

//            // Act
//            var result = util.System.IdFromEmail(Values.EmailSpongeBob);

//            // Assert
//            Assert.NotEqual(0, result);
//            Assert.Equal(Values.UserSpongeBob.IdUser, result);
//        }
//    }
//}
