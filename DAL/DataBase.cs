using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DAL
{
    static public class DataBase
    {
        static private string path = @"C:\Users\User\source\repos\CourseWork\DAL\Properties\";

        static public void UsersSerialize(object obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path + "users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }

        static public void BooksSerialize(object obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path + "books.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }

        static public object UsersDeserialize()
        {
            object obj;
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path + "users.dat", FileMode.Open))
            {
                obj = formatter.Deserialize(fs);
            }
            return obj;
        }

        static public object BooksDeserialize()
        {
            object obj;
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path + "books.dat", FileMode.Open))
            {
                obj = formatter.Deserialize(fs);
            }
            return obj;
        }
    }
}
