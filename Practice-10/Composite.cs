using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_10
{
    public abstract class OrganizationComponent
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string JobTitle { get; set; }
        public abstract void AddComponent(OrganizationComponent component);
        public abstract void RemoveComponent(OrganizationComponent component);
        public abstract int GetTotalEmployees();
        public abstract double GetTotalBudget();
        public abstract void Display(int depth = 1);
    }
    public class Employee : OrganizationComponent
    {
        public override void AddComponent(OrganizationComponent component) { }
        public override void RemoveComponent(OrganizationComponent component) { }
        public override int GetTotalEmployees()
        {
            return 1;
        }

        public override double GetTotalBudget()
        {
            return Salary;
        }

        public override void Display(int depth = 0)
        {
            Console.WriteLine($"{new string(' ', depth * 2)}- {Name} ({JobTitle}) - Зарплата: {Salary}");
        }
    }
    public class Department : OrganizationComponent
    {
        public List<OrganizationComponent> _components;
        public Department()
        {
            _components = new List<OrganizationComponent>();
        }
        public override void AddComponent(OrganizationComponent component)
        {
            _components.Add(component);
        }
        public override void RemoveComponent(OrganizationComponent component)
        {
            _components.Remove(component);
        }
        public override int GetTotalEmployees()
        {
            return _components.Sum(c => c.GetTotalEmployees());
        }

        public override double GetTotalBudget()
        {
            return _components.Sum(c => c.GetTotalBudget());
        }

        public override void Display(int depth = 1)
        {
            Console.WriteLine($"{new string(' ', depth * 2)}- {Name}");
            foreach (var component in _components)
            {
                component.Display(depth + 1);
            }
        }
    }

    internal class Composite
    {
    }
}
