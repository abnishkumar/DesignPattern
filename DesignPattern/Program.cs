using DesignPattern.Behaviourial.ReactiveOvserver;
using DesignPatterns.Creational;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace DesignPattern
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    //builder design pattern
        //    ComputerBuilder obj = new ComputerBuilder()
        //        .SetBluetoothEnabled(true)
        //        .SetGraphicsCardEnabled(true);
        //    var builder = obj.Build();
        //    Console.WriteLine(builder.IsGraphicsCardEnabled());

        //    // Abstract Factory Design pattern
        //    ConcreteFactory concreteFactory = new ConcreteFactory();
        //    Console.WriteLine(concreteFactory.GetFactory2().GetProduct().GetName());

        //    // Factory design pattern
        //    Factory factory = new Factory();
        //    Console.WriteLine(factory.GetPeople(PeopleType.RURAL).GetName());

        //    ConcretePrototype1 concretePrototype1 = new ConcretePrototype1();
        //    ConcretePrototype2 concretePrototype2 = new ConcretePrototype2();

        //    // singleton
        //    var instance = SingleTon.Instance;

        //    Console.ReadKey();
        //}

        //static void Main(string[] args)
        //{

        //    C objC = new C(4);
        //    A objA = new B(5);
        //    B objB = (B)objA; //Will this work??  
        //    Console.ReadKey();
        //}

        static void Main(string[] args)
        {
            var location = new Location();
            var tracker = new Tracker();

            Subject<Location> subject = new Subject<Location>();
           
            var unsubscriber = location.Subscribe(tracker);

            double latitude = 37.44;
            double longitude = -122.14;

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                latitude -= 0.1;
                longitude += 0.1;

                location.Latitude = latitude;
                location.Longitude = longitude;
                subject.OnNext(location);
            }

            unsubscriber.Dispose();
            // Subject 
            var source = Observable.Interval(TimeSpan.FromSeconds(1));
            IDisposable subscription1 = source.Subscribe(
                x => Console.WriteLine("Observer 1: OnNext: {0}", x),
                ex => Console.WriteLine("Observer 1: OnError: {0}", ex.Message),
                () => Console.WriteLine("Observer 1: OnCompleted"));

            IDisposable subscription2 = source.Subscribe(
                            x => Console.WriteLine("Observer 2: OnNext: {0}", x),
                            ex => Console.WriteLine("Observer 2: OnError: {0}", ex.Message),
                            () => Console.WriteLine("Observer 2: OnCompleted"));

            Console.WriteLine("Press any key to unsubscribe");
            Console.ReadLine();
            subscription1.Dispose();
            subscription2.Dispose();

            Console.ReadKey();
        }
    }

    class A
    {
        public A(int value)
        {
            // Executes some code in the constructor.
            Console.WriteLine("Base constructor A()");
        }
    }
    class B : A
    {
        public B(int value) : base(value)
        {
            // The base constructor is called first.
            // ... Then this code is executed.
            Console.WriteLine("Derived constructor B()");
        }
    }



}
