using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UniversityCourse.Tests.ScheduleTests
{
    [TestClass]
    public class AdditionalStructTests
    {
        private Car MyCar { get; set; }
        private CarPart MyCarPart { get; set; }
        
        [TestInitialize]
        public void Initialize_Struct_and_Class()
        {
            MyCar = new Car("Nissan", "240sx");
            MyCarPart = new CarPart("AEM", "Infinity-6");
        }

        [TestMethod]
        public void Pass_Struct_By_Value_Passed_Not_Changes()
        {
            ChangeValues.ChangeStructValue(MyCar);
            Assert.AreEqual("Nissan", MyCar.Manufacturer);
            Assert.AreEqual("240sx", MyCar.Model);
        }

        [TestMethod]
        public void Pass_Class_Original_Changed()
        {
            ChangeValues.ChangeClass(MyCarPart);
            Assert.AreEqual("Garrett", MyCarPart.Manufacturer);
            Assert.AreEqual("m24 ar 80", MyCarPart.PartNo);
        }

        [TestMethod]
        public void Pass_Struct_Ref_Original_Changed()
        {
            Car myCar = new Car();
            ChangeValues.ChangeStructRef(ref myCar);
            Assert.AreEqual("Toyota", myCar.Manufacturer);
            Assert.AreEqual("Supra Mk IV", myCar.Model);
        }

        [TestMethod]
        public void Pass_Class_Change_New_Instance()
        {
            CarPart myCarPart = new CarPart("","");
            ChangeValues.ChangeClassRef(ref myCarPart);
            Assert.AreEqual("Tial", myCarPart.Manufacturer);
            Assert.AreEqual("50mm bov", myCarPart.PartNo);
        }
    }

    
    
    
    
    struct Car
    {
        public Car(string manufacturer, string model)
        {
            Manufacturer = manufacturer;
            Model = model;
        }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
    }

    class CarPart
    {
        public CarPart(string manufacturer, string partNo)
        {
            Manufacturer = manufacturer;
            PartNo = partNo;
        }
        public string PartNo { get; set; }
        public string Manufacturer { get; set; }
    }

    static class ChangeValues
    {
        public static void ChangeStructValue(Car car)
        {
            car.Manufacturer = "Toyota";
            car.Model = "Supra Mk IV";
        }
        
        public static void ChangeStructRef(ref Car car)
        {
            car.Manufacturer = "Toyota";
            car.Model = "Supra Mk IV";
        }
        
        public static void ChangeClass(CarPart carPart)
        {
            carPart.Manufacturer = "Garrett";
            carPart.PartNo = "m24 ar 80";
        }
        
        public static void ChangeClassRef(ref CarPart carPart)
        {
            carPart = new CarPart("Tial" ,"50mm bov");
        }
    }
    
}