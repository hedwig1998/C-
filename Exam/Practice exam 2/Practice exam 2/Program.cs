using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_exam_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lion lion = new Lion(100, "Lion");
            Tiger tiger = new Tiger(200, "Tiger");
            lion.Show();
            Console.WriteLine();

            tiger.Show();
        }
    }

    class Animal
    {
        protected double weight;
        protected string name;

        public Animal(double weight, string name)
        {
            this.weight = weight;
            this.name = name;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Name: {name}, Weight: {weight} kg");
        }

        public void SetMe(double weight, string name)
        {
            this.weight = weight;
            this.name = name;
        }
    }

    class Lion : Animal
    {
        public Lion(double weight, string name) : base(weight, name)
        {
        }

        public override void Show()
        {
            base.Show();
        }
    }

    class Tiger : Animal
    {
        public Tiger(double weight, string name) : base(weight, name)
        {
        }

        public override void Show()
        {
            base.Show();
        }
    }
}
