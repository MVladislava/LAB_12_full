using Cars;
using LAB_12;
using LAB_12_3;
using LAB_12_4;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace Tests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestCreateTree()
        {
            //Arrange
            MyTree<Car> exp = new MyTree<Car>(10);
            // Assert
            Assert.AreEqual(10, exp.Count);
        }
        [TestMethod]
        public void TransformToFindTree()
        {
            //Arrange
            MyTree<Car> exp = new MyTree<Car>(10);
            Car car1 = new Car { Brand = "Acura" };
            // Act
            exp.AddPoint(car1);
            exp.TransformToFindTree();
            exp.FindMax();
            // Assert
            Assert.AreEqual(car1, exp.FindMax());
        }
        [TestMethod]
        public void FindMax_TreeEmpty()
        {
            //Arrange
            var exp = new MyTree<Car>(5);
            Car car1 = new Car();
            // Act
            exp.Delete();
            // Assert
            Assert.ThrowsException<InvalidOperationException>(() => exp.FindMax());
        }
        [TestMethod]
        public void Delete()
        {
            //Arrange
            MyTree<Car> exp = new MyTree<Car>(10);
            // Act
            exp.Delete();
            // Assert
            Assert.AreEqual(0, exp.Count);
        }
        [TestMethod]
        public void Remove()
        {
            MyTree<Car> exp = new MyTree<Car>(5);
            Car car1 = new Car{Brand = "Toyota"};
            Car car2 = new Car{Brand = "Honda"};
            Car car3 = new Car{Brand = "Ford"};
            Car car4 = new Car{Brand = "BMW"};
            Car car5 = new Car { Brand = "Audi" };
            // Act
            exp.AddPoint(car1);
            exp.AddPoint(car2);
            exp.AddPoint(car3);
            exp.AddPoint(car4);
            exp.AddPoint(car5);
            bool res = exp.Remove(car1);

            // Assert
            Assert.IsTrue(res);
        }
        [TestMethod]
        public void Remove_One()
        {
            MyTree<Car> exp = new MyTree<Car>(1);
            Car car1 = new Car { Brand = "Toyota" };
            Car car2 = new Car { Brand = "Honda" };
            Car car3 = new Car { Brand = "Ford" };
            Car car4 = new Car { Brand = "BMW" };
            Car car5 = new Car { Brand = "Audi" };
            // Act
            exp.AddPoint(car1);
            exp.AddPoint(car2);
            bool res = exp.Remove(car1);

            // Assert
            Assert.IsTrue(res);
        }
        [TestMethod]
        public void Remove_Two()
        {
            MyTree<Car> exp = new MyTree<Car>(1);
            Car car1 = new Car { Brand = "Toyota" };
            Car car2 = new Car { Brand = "Honda" };
            // Act
            exp.AddPoint(car1);
            bool res = exp.Remove(car1);
            // Assert
            Assert.IsTrue(res);
            Assert.IsFalse(exp.Remove(car2));
        }
        [TestMethod]
        public void Remove_Yzel()
        {
            MyTree<Car> exp = new MyTree<Car>(50);
            Car car = new Car();
            Car car1 = new Car();
            Car car2 = new Car();
            car.Brand = "Acura";
            car1.Brand = "Mercedes";
            car2.Brand = "Nissan";
            // Act
            bool res = exp.Remove(car);
            bool res1 = exp.Remove(car1);
            bool res2 = exp.Remove(car2);

            // Assert
            Assert.IsTrue(res);
        }
        [TestMethod]
        public void Foreach() 
        {
            MyCollection<Car> carCollection = new MyCollection<Car>();

            // Act
            carCollection.AddToEnd(new Car {Brand = "Honda" });

            // Assert
            Assert.AreEqual(1, carCollection.Count);
        }
        [TestMethod]
        public void Foreach1()
        {
            MyCollection<Car> carCollection = new MyCollection<Car>(1);

            // Act
            carCollection.AddToEnd(new Car { Brand = "Honda" });

            // Assert
            Assert.AreEqual(1, carCollection.Count);
        }
        [TestMethod]
        public void MoveNext()
        {
            Car[] cars = { new Car { Brand = "Toyota" }, new Car { Brand = "Honda" }, new Car { Brand = "Ford" } };
            MyCollection<Car> carCollection = new MyCollection<Car>(cars);

            // Act
            IEnumerator<Car> enumerator = carCollection.GetEnumerator();

            // Assert
            int count = 0;
            while (enumerator.MoveNext())
            {
                count++;
            }
            Assert.AreEqual(2, count);
        }
    }
}
