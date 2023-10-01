using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Linq;

namespace Lab_13
{
    class Program
    {
        static void Main()
        {
            // - - - - - - Task_01 - - - - - - - - -

            // - - - создание объектов сериализации - - -
            Car car_01 = new Car();
            Car car_02 = new Car(1,4);
            Car car_03 = new Car(2,5);
            Car car_04 = new Car(3,6);
            Car car_05 = new Car(4,5);

            Car[] cars = { car_01, car_02, car_03, car_04, car_05 };

            Engine engine_01 = new Engine(4);
            Engine engine_02 = new Engine(8);
            Engine engine_03 = new Engine(12);

            Engine[] engines = { engine_01, engine_02, engine_03 };

            Train train_01 = new Train(12,2004);
            Train train_02 = new Train(10, 2020);
            Train train_03 = new Train();

            Train[] trains = {train_01,train_02,train_03 };


            Car[] containsCar = null;

            
            CustomSerializer.Serialize<Car[]>(cars,"xml", "C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_13\\Lab_13\\Lab_13\\CustomSerialize.xml");
            CustomSerializer.Deserialize<Car[]>(ref containsCar,"xml", "C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_13\\Lab_13\\Lab_13\\CustomSerialize.xml");

            foreach(var carItem in containsCar)
            {
                Console.WriteLine(carItem);
            }

            Train[] containsTrain = null;

            // - - - - - - Task_02 - - - - - - - - -
            CustomSerializer.Serialize<Train[]>(trains, "json", "C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_13\\Lab_13\\Lab_13\\CustomSerialize1.json");
            CustomSerializer.Deserialize<Train[]>(ref containsTrain, "json", "C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_13\\Lab_13\\Lab_13\\CustomSerialize1.json");

            foreach (var train in containsTrain)
            {
                Console.WriteLine(train);
            }

            Console.WriteLine();

            // - - - - - - Task_03 - - - - - - - - -

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Name all nodes:");
            Console.ForegroundColor = ConsoleColor.Green;
            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.Load(@"C:\Users\Илья\Desktop\Пацей\ООП\Labs\Lab_13\Lab_13\Lab_13\XML.xml");
            var xRoot = xmlDocument.DocumentElement;

            var xmlNodes = xRoot.SelectNodes("*");
            foreach (XmlNode node in xmlNodes)
                Console.WriteLine(node.Name);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Text from nodesName:");
            var xmlNameNodes = xRoot.SelectNodes("Name");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (XmlNode nameNode in xmlNameNodes)
                Console.WriteLine(nameNode.InnerText);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;

            

            // - - - - - - Task_04 - - - - - - - - -
            XDocument xmlCar = new XDocument();
            XElement root = new XElement("Cars");

            XElement car;
            XElement name;
            XAttribute years;

            car = new XElement("car");
            name = new XElement("name");
            name.Value = "Mercedes-Benz";
            years = new XAttribute("years", "2017");
            car.Add(name);
            car.Add(years);
            root.Add(car);

            car = new XElement("car");
            name = new XElement("name");
            name.Value = "Mercedes-Benz";
            years = new XAttribute("years", "2018");
            car.Add(name);
            car.Add(years);
            root.Add(car);

            car = new XElement("car");
            name = new XElement("name");
            name.Value = "Porsche";
            years = new XAttribute("years", "2018");
            car.Add(name);
            car.Add(years);
            root.Add(car);
            
            xmlCar.Add(root);
            xmlCar.Save(@"C:\Users\Илья\Desktop\Пацей\ООП\Labs\Lab_13\Lab_13\Lab_13\newXML.xml");

            
            Console.WriteLine("Введите год: ");
            string yearsUser = Console.ReadLine();
            var elements = root.Elements("car");

            foreach (var item in elements)
            {
                if (item.Attribute("years").Value == yearsUser)
                {
                    Console.WriteLine(item.Value);
                }
            }
            
            /*
            
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            SoapFormatter soapFormatter = new SoapFormatter();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Car[]));
            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(Train[]));

            // - - -  сериализация  и десериализация - - - 
            
            
            // BinaryFormatter
            using (FileStream fs = new FileStream("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_13\\Lab_13\\Lab_13\\BinarySerialize.bin", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fs, engines);
            }

            using (FileStream fs = new FileStream("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_13\\Lab_13\\Lab_13\\BinarySerialize.bin", FileMode.OpenOrCreate))
            {
                foreach (var engine in (Engine[])binaryFormatter.Deserialize(fs))
                {
                    Console.WriteLine(engine);
                }
            }
            
            // SoapFormatter
            using (FileStream fs = new FileStream("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_13\\Lab_13\\Lab_13\\SoapSerialize.dat", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(fs, engines);
            }
            using (FileStream fs = new FileStream("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_13\\Lab_13\\Lab_13\\SoapSerialize.dat", FileMode.OpenOrCreate))
            {
                foreach (var engine in (Engine[])soapFormatter.Deserialize(fs))
                {
                    Console.WriteLine(engine);
                }
            }

            // XmlSerializer
            using (FileStream fs = new FileStream("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_13\\Lab_13\\Lab_13\\XmlSerialize.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, cars);
            }
            using (FileStream fs = new FileStream("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_13\\Lab_13\\Lab_13\\XmlSerialize.xml", FileMode.OpenOrCreate))
            {
                foreach (var car in (Car[])xmlSerializer.Deserialize(fs))
                {
                    Console.WriteLine(car);
                }
            }

            // DataContractJsonSerializer
            using (FileStream fs = new FileStream("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_13\\Lab_13\\Lab_13\\JsonSerialize.json", FileMode.OpenOrCreate))
            {
                dataContractJsonSerializer.WriteObject(fs, trains);
            }
            using (FileStream fs = new FileStream("C:\\Users\\Илья\\Desktop\\Пацей\\ООП\\Labs\\Lab_13\\Lab_13\\Lab_13\\JsonSerialize.json", FileMode.OpenOrCreate))
            {
                foreach (var train in (Train[])dataContractJsonSerializer.ReadObject(fs))
                {
                    Console.WriteLine(train);
                }
            }

            
            */
        }
    }
}