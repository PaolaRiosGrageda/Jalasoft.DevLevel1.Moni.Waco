using WACO;

namespace TestWaco
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestValidateUserCreationWithDuplicateValues()
        {
            User myUser1 = new User(345431, "Pedro", "Vargas");
            User myUser2 = new User(123412, "Pablo", "Camacho");
            User myUser3 = new User(544323, "Jorge", "Venegas");

            WacoController myList = new WacoController();
            myList.Add(myUser1);
            myList.Add(myUser2);
            myList.Add(myUser3);

            bool status = myList.VerifyCI(544323);
            Assert.AreEqual(status, true);
        }

        [TestMethod]
        public void Test()
        {
        }

    }

}