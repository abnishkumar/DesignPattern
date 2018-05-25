using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Creational
{
    /// <summary>
    /// Implementation of Singleton Pattern
    /// </summary>
    public sealed class SingleTon
    {
        private static SingleTon _instance = null;
        private SingleTon() // Made default constructor as private 
        {
        }
        /// <summary>
        /// Single Instance
        /// </summary>
        public static SingleTon Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_instance)
                    {
                        _instance = _instance ?? new SingleTon();
                        return _instance;
                    }
                }
                return _instance;
            }
        }

        # region Rest of Implementation Logic

        public void GetName()
        {
            Console.WriteLine("singleTon");
        }
        //Add As many method as u want here as instance member. No need to make them static.

        # endregion
    }
}
