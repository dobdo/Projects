using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FindSLib
{
    public class Сircle : IGetSquare
    {
        const float Pi = 3.14F;
        double Radius;

        public Сircle(double Radius)
        {
            this.Radius = Radius;
        }

        public double GetSquare()
        {
            return Pi * (Math.Pow(Radius, 2));
        }


    }
}
