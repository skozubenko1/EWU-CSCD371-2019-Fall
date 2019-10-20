using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        string TestActor(Actor actor, bool WomenArePresent = false)
        {
            var talk = actor.Speak(WomenArePresent);
            Assert.IsNotNull(talk);
            Assert.IsTrue(talk.Length > 0, $"{actor.GetType()} didn't say anything");
            return talk;
        }

        [TestMethod]
        public void TestMethodPenny()
        {
            TestActor(new Penny());
        }

        [TestMethod]
        public void TestMethodSheldon()
        {
            TestActor(new Sheldon());
        }

        [TestMethod]
        public void TestMethodRaj()
        {
            var speak = TestActor(new Raj());
            var mumble = TestActor(new Raj(), true);
            Assert.AreNotEqual(speak, mumble);
        }
    }
}
