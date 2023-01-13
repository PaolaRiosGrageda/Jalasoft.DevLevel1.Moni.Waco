using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
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

            Assert.IsTrue(myList.ExistsUserWithCI(544323));
        }

        [TestMethod]
        public void TestValidateMoreThanOneLectureByPeriod()
        {
            User myUser1 = new User(345431, "Pedro", "Vargas");

            Consumption consumption1 = new Consumption("01/2023", 500);
            Consumption consumption2 = new Consumption("01/2023", 400);
            Consumption consumption3 = new Consumption("03/2023", 600);
            Consumption consumption4 = new Consumption("01/2023", 100);

            myUser1.Add_Consumption(consumption1);
            myUser1.Add_Consumption(consumption2);
            myUser1.Add_Consumption(consumption3);
            myUser1.Add_Consumption(consumption4);

            var status = myUser1.VerifyLecture("01/2023");
            Assert.AreEqual(status, 3);
        }

        [TestMethod]
        public void TestValidateUserExistenceInReadingConsumptionReturnErrorMessage()
        {
            string message = string.Empty;
            User myUser1 = new User(345431, "Pedro", "Vargas");
            User myUser2 = new User(123412, "Pablo", "Camacho");
            User myUser3 = new User(544323, "Jorge", "Venegas");

            WacoController myList = new WacoController();
            myList.Add(myUser1);
            myList.Add(myUser2);
            myList.Add(myUser3);

            try
            {
                myList.FindUser(7896642);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            Assert.AreEqual(message, "The CI doesn't Exist");
        }

    }
}