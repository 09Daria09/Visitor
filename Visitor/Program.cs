using System;
using System.Collections.Generic;

namespace RefactoringGuru.DesignPatterns.Visitor.Conceptual
{
    public interface IComponent
    {
        void Accept(IVisitor visitor);
    }
    public class Factory : IComponent
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitFactory(this);
        }
        public string ExclusiveMethodOfFactory()
        {
            return "Factory";
        }
    }
    public class Home : IComponent
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitHome(this);
        }

        public string SpecialMethodOfHome()
        {
            return "Home";
        }
    }
    public class Bank : IComponent
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitBank(this);
        }

        public string SpecialMethodOfBank() 
        {
            return "Bank";
        }
    }
    public interface IVisitor
    {
        void VisitFactory(Factory element);
        void VisitHome(Home element);
        void VisitBank(Bank element);
    }
    class MedicalInsurance : IVisitor
    {
        public void VisitBank(Bank element)
        {
            Console.WriteLine(element.SpecialMethodOfBank() + " + MedicalInsurance");
        }

        public void VisitFactory(Factory element)
        {
            Console.WriteLine(element.ExclusiveMethodOfFactory() + " + MedicalInsurance");
        }

        public void VisitHome(Home element)
        {
            Console.WriteLine(element.SpecialMethodOfHome() + " + MedicalInsurance");
        }
    }
    class RobberyInsurance : IVisitor
    {
        public void VisitBank(Bank element)
        {
            Console.WriteLine(element.SpecialMethodOfBank() + " + RobberyInsurance");
        }

        public void VisitFactory(Factory element)
        {
            Console.WriteLine(element.ExclusiveMethodOfFactory() + " + RobberyInsurance");
        }

        public void VisitHome(Home element)
        {
            Console.WriteLine(element.SpecialMethodOfHome() + " + RobberyInsurance");
        }
    }
    class FireInsurance : IVisitor
    {
        public void VisitBank(Bank element)
        {
            Console.WriteLine(element.SpecialMethodOfBank() + " + FireInsurance");
        }

        public void VisitFactory(Factory element)
        {
            Console.WriteLine(element.ExclusiveMethodOfFactory() + " + FireInsurance");
        }

        public void VisitHome(Home element)
        {
            Console.WriteLine(element.SpecialMethodOfHome() + " + FireInsurance");
        }
    }
    public class Client
    {
        public static void ClientCode(List<IComponent> components, IVisitor visitor)
        {
            foreach (var component in components)
            {
                component.Accept(visitor);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<IComponent> components = new List<IComponent>
        {
            new Home(),
            new Bank(),
            new Factory()
        };

            IVisitor medicalInsurance = new MedicalInsurance();
            IVisitor robberyInsurance = new RobberyInsurance();
            IVisitor fireInsurance = new FireInsurance();

            Console.WriteLine("\n== == == Medical Insurance == == ==");

            Client.ClientCode(components, medicalInsurance);

            Console.WriteLine("\n== == == Robbery Insurance == == ==");

            Client.ClientCode(components, robberyInsurance);

            Console.WriteLine("\n== == == Fire Insurance == == ==");

            Client.ClientCode(components, fireInsurance);

            Console.ReadKey();
        }
    }
}
