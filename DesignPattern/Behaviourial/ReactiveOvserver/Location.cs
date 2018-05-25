
namespace DesignPattern.Behaviourial.ReactiveOvserver
{
    public class Location : Observable<Location>
    {
        private double longitude = 0;
        private double latitude = 0;

        public double Longitude
        {
            get { return longitude; }
            set
            {
                longitude = value;
                Notify(this);
            }
        }

        public double Latitude
        {
            get { return latitude; }
            set
            {
                latitude = value;
                Notify(this);
            }
        }
    }
}
