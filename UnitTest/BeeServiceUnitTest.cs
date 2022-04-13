using BeeCore.Services;
using NUnit.Framework;
using System.Linq;

namespace UniTest
{
    public class BeeServiceUnitTest
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void Damage_Positive()
        {
            //Arrange
            BeeService service = new BeeService();
            var queenservice = new QueenService(service);
            var queen = queenservice.AddBeeDetails();
            service.Bees.AddRange(queen);
            service.SelectedBeeIndex = 1;

            //Act
            service.Damage(10);

            //Assert
            var res = service.Bees.Where(x => x.Id ==service.SelectedBeeIndex).FirstOrDefault();
            Assert.IsTrue(res.Health == 90);
        }


        [Test]
        public void Damage_Nagative_SelectedIndexNotFound()
        {
            //Arrange
            BeeService service = new BeeService();           
            service.SelectedBeeIndex = 1;

            //Act
            service.Damage(10);

            //Assert
            var res = service.Bees.Where(x => x.Id == service.SelectedBeeIndex).FirstOrDefault();
            Assert.IsNull(res);
        }

        [Test]
        public void Damage_Nagative_SelectedIndex_NegativeValue()
        {
            //Arrange
            BeeService service = new BeeService();
            service.SelectedBeeIndex = -1;

            //Act
            service.Damage(10);

            //Assert
            var res = service.Bees.Where(x => x.Id == service.SelectedBeeIndex).FirstOrDefault();
            Assert.IsNull(res);
        }

        [Test]
        public void Damage_Input_Less_Than_Zero()
        {
            //Arrange
            BeeService service = new BeeService();
            var queenservice = new QueenService(service);
            var queen = queenservice.AddBeeDetails();
            service.Bees.AddRange(queen);
            service.SelectedBeeIndex = 1;

            //Act
            service.Damage(-1);

            //Assert
            var res = service.Bees.Where(x => x.Id == service.SelectedBeeIndex).FirstOrDefault();
            Assert.IsTrue(res.Health == 100);
        }

        [Test]
        public void Damage_Input_Greater_Than_100()
        {
            //Arrange
            BeeService service = new BeeService();
            var queenservice = new QueenService(service);
            var queen = queenservice.AddBeeDetails();
            service.Bees.AddRange(queen);
            service.SelectedBeeIndex = 1;

            //Act
            service.Damage(101);

            //Assert
            var res = service.Bees.Where(x => x.Id == service.SelectedBeeIndex).FirstOrDefault();
            Assert.IsTrue(res.Health == 100);
        }

        [Test]
        public void Damage_Health_Lessthan_Zero()
        {
            //Arrange
            BeeService service = new BeeService();
            var queenservice = new WorkerService(service);
            var queen = queenservice.AddBeeDetails();
            service.Bees.AddRange(queen);
            service.SelectedBeeIndex = 1;

            //Act
            service.Damage(20);
            service.Damage(90);

            //Assert
            var res = service.Bees.Where(x => x.Id == service.SelectedBeeIndex).FirstOrDefault();
            Assert.IsTrue(res.Health == 0);
        }

        [Test]
        public void Damage_PronounceDead()
        {
            //Arrange
            BeeService service = new BeeService();
            var queenservice = new DroneService(service);
            var queen = queenservice.AddBeeDetails();
            service.Bees.AddRange(queen);
            service.SelectedBeeIndex = 1;

            //Act
            service.Damage(60);

            //Assert
            var res = service.Bees.Where(x => x.Id == service.SelectedBeeIndex).FirstOrDefault();
            Assert.IsTrue(res.Dead);
        }

        [Test]
        public void Damage_Pronounce_NotDead()
        {
            //Arrange
            BeeService service = new BeeService();
            var queenservice = new DroneService(service);
            var queen = queenservice.AddBeeDetails();
            service.Bees.AddRange(queen);
            service.SelectedBeeIndex = 9;

            //Act
            service.Damage(30);

            //Assert
            var res = service.Bees.Where(x => x.Id == service.SelectedBeeIndex).FirstOrDefault();
            Assert.IsFalse(res.Dead);
        }
    }
}