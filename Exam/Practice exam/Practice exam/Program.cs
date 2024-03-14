using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cylinder cylinder = new Cylinder();
            Console.WriteLine("Enter the dimenstions of the cylinder:");
            Console.Write("Radius: ");
            double radius = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            double height = double.Parse(Console.ReadLine());
            cylinder.SetDimensions(radius, height);

            cylinder.Process();

            cylinder.Result();
        }
    }
    class Cylinder
    {
        double Radius { get; set; }
        double Height { get; set; }
        double BaseArea { get; set; }
        double LateralArea { get; set; }
        double TotalArea { get; set; }
        double Volume { get; set; }
        public void SetDimensions(double radius, double height)
        {
            Radius = radius;
            Height = height;
        }

        public void Process()
        {
            BaseArea = Radius * Radius * Math.PI;
            LateralArea = 2 * Math.PI * Radius * Height;
            TotalArea = 2 * Math.PI * Radius * (Height + Radius);
            Volume = Math.PI * Radius * Radius * Height;
        }

        public void Result()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Cylinder Characteristics");
            Console.WriteLine($"Radius: {Radius}");
            Console.WriteLine($"Height: {Height}");
            Console.WriteLine($"Base Area: {BaseArea}");
            Console.WriteLine($"Lateral Area: {LateralArea}");
            Console.WriteLine($"Total Area: {TotalArea}");
            Console.WriteLine($"Volume: {Volume}");
        }
    }
}
