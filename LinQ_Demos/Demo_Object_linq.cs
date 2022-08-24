using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet.LinQ_Demos
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string CompanyName { get; set; }

        public override string ToString()
        {
            return $"{Id} -> {Name} -> {Price} -> {CompanyName}";
        }
    }

    class Demo_Object_linq
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            new Product { Id = 1, Name = "Mouse", Price = 799, CompanyName = "Dell" };
            new Product { Id = 2, Name = "Mouse", Price = 900, CompanyName = "Dell" };
            new Product { Id = 3, Name = "Mouse", Price = 799, CompanyName = "Dell" };
            new Product { Id = 4, Name = "Mouse", Price = 799, CompanyName = "Dell" };
            new Product { Id = 5, Name = "Mouse", Price = 799, CompanyName = "Dell" };
            new Product { Id = 6, Name = "Mouse", Price = 799, CompanyName = "Dell" };
            new Product { Id = 7, Name = "Mouse", Price = 799, CompanyName = "Dell" };
            new Product { Id = 8, Name = "Mouse", Price = 799, CompanyName = "Dell" };
            new Product { Id = 9, Name = "Mouse", Price = 799, CompanyName = "Dell" };
            new Product { Id = 10, Name = "Mouse", Price = 799, CompanyName = "Dell" };



            var result1 = from p in products
                          select p;

            var result2 = from p in products
                          where p.Price < 2000
                          select p;

            var result3 = from p in products
                          where p.Price > 2000 && p.Price < 3000
                          select p;

            //var result4 = from p in products
            //              where p.CompanyName.StartsWith("D")
            //              select p;
            //var result4 = from p in products
            //              where p.CompanyName.EndsWith("o")
            //              select p;
            var result4 = from p in products
                          where p.CompanyName.Contains("m") || p.CompanyName.Contains("M")
                          select p;
            var result5 = from p in products
                          where p.Price < 2500
                          orderby p.Price descending
                          select p;
            foreach(Product item in result4)
            {
                Console.WriteLine(item);
            }

        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        
        public string City { get; set; }
        public override string ToString()
        {
            return $"{Id} -->{Name}--> {Salary} -->{City} ";
        }

    }
    public class Assign_LinqToObject
    {

        static void Main(string[] args)
        {
            List<Employee> Emp = new List<Employee>()
            {


            new Employee { Id = 1, Name = "shital", Salary = 30000, City = "Kolhapur"},
            new Employee { Id = 2, Name = "sanket", Salary = 40000, City = "pune" },
            new Employee { Id = 3, Name = "saurav", Salary = 35000, City = "Solapur" },
            new Employee { Id = 4, Name = "manoj", Salary = 40000, City = "Ich" },
            new Employee { Id = 5, Name = "kiran", Salary = 50000, City = "pune" },
            new Employee { Id = 6, Name = "Rakesh", Salary = 30000, City = "mumbai" },
            new Employee { Id = 7, Name = "aniket", Salary = 45000, City = "Ich" },
            new Employee { Id = 8, Name = "Sanjay", Salary = 20000, City = "Kolhapur" },
            };
            //Display all emplyees
            var result1 = from p in Emp
                          select p;
            
            //Display employee with ascending order
            var result2 = from p in Emp
                          orderby p.Name 
                          select p;
            //display Employees whose salary is >25000
            var result3 = from p in Emp
                          where p.Salary > 25000
                          select p;
            //display Employees Whose city is "Pune"
            var result4 = from p in Emp
                          where p.City == "Pune"
                          select p;
            //display employee with desending order by salary
            var result5 = from p in Emp
                          orderby p.Salary descending
                          select p;
            //display employee whose name start with 'S'
            var result6 = from p in Emp
                          orderby p.Name.StartsWith("S")
                          select p;
            //display employee whose salary is > 25000 & emp is from 'Mumbai' city
            var result7 = from p in Emp
                          where (p.Salary > 25000) && (p.City == "mumbai")
                          select p;
            foreach (Employee item in result7)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

    }
        
}
