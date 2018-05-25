using System;

namespace DesignPattern.Behaviourial.ReactiveOvserver
{
    public class Tracker : IObserver<Location>
    {
        public void OnCompleted()
        {
            Console.WriteLine("untracked");
        }

        public void OnError(Exception error)
        {
            //some error handling
        }

        public void OnNext(Location value)
        {
            Console.WriteLine("Longitude: " + value.Latitude.ToString() + " " +
                             "Latitude: " + value.Longitude.ToString());
        }
    }
}
