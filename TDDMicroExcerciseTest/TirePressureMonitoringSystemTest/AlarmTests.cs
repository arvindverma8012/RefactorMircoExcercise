using Moq;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace TDDMicroExcerciseTest.TirePressureMonitoringSystem
{
    public class AlarmTests
    {
        public readonly Mock<ISensor> _sensorMock;
        public AlarmTests()
        {
           _sensorMock = new Mock<ISensor>(); 
        }
        [Fact]
        public void Check_AlarmOffWithinThreshold_ShouldNotTurnOn()
        {
            // Arrange
            var alarm = CreateAlarmService();

            _sensorMock.Setup(s => s.PopNextPressurePsiValue()).Returns(18); // psiPressureValue is within the threshold

            // Act
            alarm.Check();

            // Assert
            Assert.False(alarm.AlarmOn);
        }

        [Fact]
        public void Check_AlarmOnLowPressure_ShouldTurnOn()
        {
            // Arrange
            var alarm = CreateAlarmService();
            _sensorMock.Setup(s => s.PopNextPressurePsiValue()).Returns(16); // psiPressureValue is below the low threshold

            // Act
            alarm.Check();

            // Assert
            Assert.True(alarm.AlarmOn);
        }

        [Fact]
        public void Check_AlarmOnHighPressure_ShouldTurnOn()
        {
            // Arrange
            var alarm = CreateAlarmService();
            _sensorMock.Setup(s => s.PopNextPressurePsiValue()).Returns(22); // psiPressureValue is above the high threshold

            // Act
            alarm.Check();

            // Assert
            Assert.True(alarm.AlarmOn);
        }

        [Fact]
        public void Check_AlarmOffWithinThresholdAfterPreviousAlarm_ShouldNotTurnOn()
        {
            // Arrange
            var alarm = CreateAlarmService();
            _sensorMock.SetupSequence(s => s.PopNextPressurePsiValue())
                       .Returns(16) // psiPressureValue is below the low threshold
                       .Returns(18); // psiPressureValue is within the threshold

            // Act
            alarm.Check(); // Turn the alarm on
            alarm.Check(); // Check again with a valid pressure value

            // Assert
            Assert.False(alarm.AlarmOn);
        }

        private IAlarm CreateAlarmService()
        {
            return new Alarm(_sensorMock.Object);
        }
    }

}
