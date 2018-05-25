using System;

namespace DesignPatterns.Creational
{

    public class Computer
    {
        //required parameters
        private String HDD;
        private String RAM;

        //optional parameters
        private bool isGraphicsCardEnabled;
        private bool isBluetoothEnabled;


        public String getHDD()
        {
            return HDD;
        }

        public String getRAM()
        {
            return RAM;
        }

        public bool IsGraphicsCardEnabled()
        {
            return isGraphicsCardEnabled;
        }

        public bool IsBluetoothEnabled()
        {
            return isBluetoothEnabled;
        }

        public Computer(ComputerBuilder builder)
        {
            this.HDD = builder.HDD;
            this.RAM = builder.RAM;
            this.isGraphicsCardEnabled = builder.isGraphicsCardEnabled;
            this.isBluetoothEnabled = builder.isBluetoothEnabled;
        }
    }

    //Builder Class
    public sealed class ComputerBuilder
    {

        // required parameters
        public String HDD;
        public String RAM;

        // optional parameters
        public bool isGraphicsCardEnabled;
        public bool isBluetoothEnabled;

        public string HDD1 { get; set; }
        public string HDD2 { get; set; }
        public string HDD3 { get; set; }

        
        public ComputerBuilder SetGraphicsCardEnabled(bool isGraphicsCardEnabled)
        {
            this.isGraphicsCardEnabled = isGraphicsCardEnabled;
            return this;
        }

        public ComputerBuilder SetBluetoothEnabled(bool isBluetoothEnabled)
        {
            this.isBluetoothEnabled = isBluetoothEnabled;
            return this;
        }

        public Computer Build()
        {
            return new Computer(this);
        }

    }

}
