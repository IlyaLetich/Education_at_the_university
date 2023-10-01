using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11
{
    internal static class Reflector
    {
        private static StreamWriter fileForInfortmation = null;

        private static readonly string fileForInfortmationPath = @"C:\Users\Илья\Desktop\Пацей\ООП\Labs\Lab_11\Reflector.txt";

        public static void WriteAssemblyName(string nameClass)
        {
            Type currentClass = Type.GetType(nameClass);
            string assemblyName = currentClass.Assembly.ToString();
            if (fileForInfortmation != null)
            {
                fileForInfortmation.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
                fileForInfortmation.WriteLine($"Имя класса: {nameClass}. Имя сборки: {assemblyName}");
                fileForInfortmation.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
            }
        }
        public static void WriteCheckPublicConstructors(string nameClass)
        {
            if (fileForInfortmation != null)
            {
                fileForInfortmation.WriteLine("-------------------------------------------------");
                fileForInfortmation.WriteLine("      Есть ли публичные конструкторы?            ");
                fileForInfortmation.WriteLine("-------------------------------------------------");
            }
            Type type = Type.GetType(nameClass);

            var bf = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance;

            var collectionPublicConstructors = type.GetConstructors(bf);

            if(collectionPublicConstructors.Length > 0)
                if (fileForInfortmation != null)  fileForInfortmation.WriteLine("Канешна есть");
            else
                if (fileForInfortmation != null) fileForInfortmation.WriteLine("Неа, не нашёл");

        }
        public static IEnumerable<string> WriteMethod(string nameClass)
        {
            if (fileForInfortmation != null)
            {
                fileForInfortmation.WriteLine("-------------------------------------------------");
                fileForInfortmation.WriteLine("                     Методы                      ");
                fileForInfortmation.WriteLine("-------------------------------------------------");
            }
            Type type = Type.GetType(nameClass);
            List<string> list = new List<string>();

            var bf = BindingFlags.Public  | BindingFlags.Static | BindingFlags.Instance | BindingFlags.Static;

            var collectionMethod = type.GetMethods(bf);

            foreach (var method in collectionMethod)
            {
                if (fileForInfortmation != null)
                    fileForInfortmation.WriteLine(method);
                list.Add(method.ToString());
            }
            return list;
        }
        public static IEnumerable<string> WriteFieldAndProperty(string nameClass)
        {
            if (fileForInfortmation != null)
            {
                fileForInfortmation.WriteLine("-------------------------------------------------");
                fileForInfortmation.WriteLine("             Поля и свойства                     ");
                fileForInfortmation.WriteLine("-------------------------------------------------");
            }
            Type type = Type.GetType(nameClass);

            var bf =  BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.Static;

            var collectionFieldsAndProperty = type.GetFields(bf);
            List<string> list = new List<string>();

            foreach (var fieldOrProperty in collectionFieldsAndProperty)
            {
                if (fileForInfortmation != null) 
                    fileForInfortmation.WriteLine(fieldOrProperty);
                list.Add(fieldOrProperty.ToString());
            }
            return list;
        }
        public static IEnumerable<string> WriteInterfece(string nameClass)
        {
            if (fileForInfortmation != null)
            {
                fileForInfortmation.WriteLine("-------------------------------------------------");
                fileForInfortmation.WriteLine("                 Интерфейсы                      ");
                fileForInfortmation.WriteLine("-------------------------------------------------");
            }
            Type type = Type.GetType(nameClass);

            var collectionInterfaces = type.GetInterfaces();
            List<string> list = new List<string>();

            foreach (var Interface in collectionInterfaces)
            {
                if (fileForInfortmation != null) fileForInfortmation.WriteLine(Interface);
                list.Add(Interface.ToString());
            }
            return list;
        }
        public static void WriteMethodsWithUserParametr(string nameClass)
        {
            Type type = Type.GetType(nameClass);

            var bf = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.Static;

            var collectionMethod = type.GetMethods(bf);

            Console.Write("Введите параметр, если хотите узнать методы, которые его содержат\n\n> ");

            string parameter = Console.ReadLine();

            if (fileForInfortmation != null)
            {
                fileForInfortmation.WriteLine("-------------------------------------------------");
                fileForInfortmation.WriteLine("      Методы, у которых есть введ. параметр      ");
                fileForInfortmation.WriteLine("-------------------------------------------------");
            }
            foreach (var method in collectionMethod)
            {
                var collectionParameters = method.GetParameters();
                for (int i = 0; i < collectionParameters.Length; i++)
                {
                    if (collectionParameters[i].ParameterType.Name == parameter)
                    {
                        if (fileForInfortmation != null) fileForInfortmation.WriteLine(method);
                    }
                }
            }
        }
        public static void Invoke(string nameClass, string nameMethod)
        {
            try
            {
                Object? obj = Activator.CreateInstance(Type.GetType(nameClass));
                var method = Type.GetType(nameClass).GetMethod(nameMethod);
                List<string> str = File.ReadAllLines(@"C:\Users\Илья\Desktop\Пацей\ООП\Labs\Lab_11\Invoke.txt").ToList();
                List<string>[] strings = new List<string>[] { str };
                method.Invoke(obj, strings);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ExploreClass(string NameClass)
        {
            Reflector.OpenFile();
            Reflector.WriteAssemblyName(NameClass);
            Reflector.WriteCheckPublicConstructors(NameClass);
            Reflector.WriteMethod(NameClass);
            Reflector.WriteFieldAndProperty(NameClass);
            Reflector.WriteInterfece(NameClass);
            Reflector.WriteMethodsWithUserParametr(NameClass);
            Reflector.CloseFile();
        }

        public static object Create(string currentClassName)
        {
            object obj = Activator.CreateInstance(Type.GetType(currentClassName));
            return obj;
        }

        private static void OpenFile()
        {
            if (fileForInfortmationPath != null)
                fileForInfortmation = new StreamWriter(fileForInfortmationPath, true);
        }
        private static void CloseFile()
        {
            fileForInfortmation.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
            fileForInfortmation?.Close();
        }
    }
}
