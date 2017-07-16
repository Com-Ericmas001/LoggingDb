//using Com.Ericmas001.LoggingDb.Test.Util;
//using Xunit;

//namespace Com.Ericmas001.LoggingDb.Test
//{
//    public class IdFromUsernameTest
//    {
//        [Fact]
//        public void WithNoUserReturnsZero()
//        {
//            // Arrange
//            var util = new LoggingDbSystemUtil(delegate{});

//            // Act
//            var result = util.System.IdFromUsername(Values.UsernameSpongeBob);

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
//            var result = util.System.IdFromUsername(Values.UsernameDora);

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
//            var result = util.System.IdFromUsername(Values.UsernameSpongeBob);

//            // Assert
//            Assert.NotEqual(0, result);
//            Assert.Equal(Values.UserSpongeBob.IdUser, result);
//        }
//    }
//}
