using System;

namespace Classes
{
    class Program
    {
        static void Main()
        {
            Dog d = new Dog("Doggo", 50.0);
            FoodItem f = new FoodItem("Pizza", 800.0);

            Console.WriteLine("{0} weighs {1} pounds!", d.Name, d.Weight);
            Console.WriteLine("{0} eats a {1}!", d.Name, f.Name);
            d.eatFood(f);
            Console.WriteLine("{0} weighs {1} pounds!", d.Name, d.Weight);
            d.walk();
            Console.WriteLine("{0} goes for a walk to lose some weight.", d.Name);
            Console.WriteLine("{0} weighs {1} pounds!", d.Name, d.Weight);

            Dog d2 = new Dog("Doge", 60.0);
            Console.WriteLine("{0} weighs {1} pounds!", d2.Name, d2.Weight);
            d2.eatDog(d);
            Console.WriteLine("{0} eats {1}!!!", d2.Name, d.Name);
            Console.WriteLine("{0} weighs {1} pounds!", d2.Name, d2.Weight);
        }
    }

    class Dog 
    {
        public Dog (string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
        private string name = "";
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        private double weight = 0;
        public double Weight
        {
            get
            {
                return weight;
            }

            set
            {
                weight = value;
            }
        }
       
        public void eatFood(FoodItem f)
        {
            Weight += (f.Calories/100);

        }
        public void walk()
        {
            Weight -= 5;
        }
        public void eatDog(Dog d)
        {
            Weight = Weight + d.Weight;
        }
    }

    class FoodItem
    {
        public FoodItem (string name, double calories)
        {
            Name = name;
            Calories = calories;
        }
        private string name = "";
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        private double calories = 0;
        public double Calories
        {
            get
            {
                return calories;
            }

            set
            {
                calories = value;
            }
        }
    }
}
