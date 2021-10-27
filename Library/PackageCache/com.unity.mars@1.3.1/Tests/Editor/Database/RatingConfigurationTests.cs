#if UNITY_EDITOR
using NUnit.Framework;
using Unity.MARS.Conditions;

namespace Unity.MARS.Data.Tests.ConditionMatching
{
    class RatingConfigurationTests
    {
        [Test]
        public void DeadZoneIsClampedInConstructor()
        {
            var config = new RatingConfiguration(1.1f);
            Assert.AreEqual(config.deadZone, RatingConfiguration.MaxDeadZone);
            config = new RatingConfiguration(-0.1f);
            Assert.AreEqual(config.deadZone, 0f);
        }

        [Test]
        public void CenterIsClampedInConstructor()
        {
            var config = new RatingConfiguration(0f, 0f);
            Assert.AreEqual(RatingConfiguration.MinimumCenter, config.center);
            config = new RatingConfiguration(0f, 1f);
            Assert.AreEqual(RatingConfiguration.MaximumCenter, config.center);
        }
    }
}
#endif
