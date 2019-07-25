using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            DAL.BaseDatos db = new DAL.BaseDatos();
            Console.WriteLine(db.cnn.State.ToString());
            db.cnn.Open();
            Console.WriteLine(db.cnn.State.ToString());
            Console.ReadKey();
        }
    }
}
