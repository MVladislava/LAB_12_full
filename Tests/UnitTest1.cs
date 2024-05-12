using Cars;
using LAB_12;
using System.Collections.Generic;
namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateList()
        {
            //Arrange
            MyList<Car> exp = new MyList<Car>(10);
            // Assert
            Assert.AreEqual(9, exp.Count);
        }

        [TestMethod]
        public void FindItemByBrand()
        {
            //Arrange
            Car midcar = new Car();
            midcar.RandomInit();
            MyList<Car> list = new MyList<Car>(5);
            // Act
            list.AddInMiddle(midcar);
            // Assert
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(0, list.IndexOf(midcar));
        }
        [TestMethod]
        public void DeepClone() 
        {
            //Arrange
            MyList<Car> origList = new MyList<Car>(5);
            // Act
            MyList<Car> cloneList = origList.DeepClone();
            // Assert
            Assert.IsNotNull(cloneList);
            Assert.AreEqual(5, cloneList.Count);
        }
        [TestMethod]
        public void Delete()
        {
            //Arrange
            MyList<Car> carDel = new MyList<Car>(5);
            // Act
            carDel.Delete();
            // Assert
            Assert.AreEqual(0, carDel.Count);
        }
        [TestMethod]
        public void RemoveItem_Midle()
        {
            // Arrange
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car { Brand = "Toyota" };
            Car car2 = new Car { Brand = "Honda" };
            Car car3 = new Car { Brand = "Ford" };
            list.AddToEnd(car1);
            list.AddToEnd(car2);
            list.AddToEnd(car3);

            // Act
            bool result = list.RemoveItem(car2);
            bool result2 = list.RemoveItem(car3);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(result2);
            Assert.AreEqual(1, list.Count);
            Assert.IsNull(list.FindItem(car2));
            Assert.IsNull(list.FindItem(car3));
        }
        [TestMethod]
        public void RemoveItem_One()
        {
            // Arrange
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car { Brand = "Toyota" };
            list.AddToEnd(car1);

            // Act
            bool result = list.RemoveItem(car1);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.FindItem(car1));
        }
        [TestMethod]
        public void RemoveItem_FirstAndAddToBegin()
        {
            // Arrange
            MyList<Car> list = new MyList<Car>();
            Car car1 = new Car { Brand = "Toyota" };
            Car car2 = new Car { Brand = "Honda" };
            Car car3 = new Car { Brand = "Ford" };
            list.AddToEnd(car1);
            list.AddToEnd(car2);
            list.AddToBegin(car3);
            // Act
            bool result = list.RemoveItem(car3);
            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(2, list.Count);
            Assert.IsNull(list.FindItem(car3));
        }
        [TestMethod]
        public void TestCreateHTable()
        {
            //Arrange
            HTable<Car> exp = new HTable<Car>(10);
            // Assert
            Assert.AreEqual(10, exp.Capacity);
        }
        [TestMethod]
        public void HAdd()
        {
            //Arrange
            HTable<Car> exp = new HTable<Car>(10);
            Car car1 = new Car { Brand = "Toyota" };
            Car car2 = new Car();
            // Act
            car2.RandomInit();
            exp.Add(car1);
            exp.Add(car2);
            // Assert
            Assert.AreEqual(10, exp.Capacity);
            Assert.IsTrue(exp.FindPoint(car1));
        }
        [TestMethod]
        public void HFindPoint()
        {
            //Arrange
            HTable<Car> exp = new HTable<Car>();
            var Id = new IdNumber(123);
            var car = new Car(Id, "BMW", 2010, "Черный", 506000, 150);
            var car2 = new Car { Brand = "Toyota" };
            // Act
            exp.Add(car);
            bool found = exp.FindPoint(car);
            bool notFound = exp.FindPoint(car2);
            // Assert
            Assert.IsTrue(found);
            Assert.IsFalse(notFound);
        }
        [TestMethod]
        public void HFindPoint2()
        {
            // Arrange
            HTable<Car> exp = new HTable<Car>();
            Car car1 = new Car { Brand = "Toyota" };
            Car car2 = new Car { Brand = "Honda" };
            exp.Add(car1);
            exp.Add(car2);
            Car car4 = new Car { Brand = "Audi" };
            exp.Add(car4);
            // Act
            bool found = exp.FindPoint(car4);
            // Assert
            Assert.IsTrue(found);
        }
        [TestMethod]
        public void HDelPoint_returnTrue()
        {
            // Arrange
            HTable<Car> exp = new HTable<Car>();
            Car car1 = new Car { Brand = "Toyota" };
            Car car2 = new Car { Brand = "Toyota" };
            Car car3 = new Car { Brand = "Honda" };
            exp.Add(car1);
            exp.Add(car2);
            exp.Add(car3);
            // Act
            bool del = exp.DelPoint(car2);
            // Assert
            Assert.IsTrue(del);
        }
    }
}