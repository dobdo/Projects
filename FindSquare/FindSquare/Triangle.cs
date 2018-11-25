using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindSLib
{
    public class Triangle : IGetSquare
    {
        public readonly bool RightTriangle = false;
        double SideA, SideB, SideC;

        public Triangle(double SideA, double SideB, double SideC)
        {
            this.SideA = SideA;
            this.SideB = SideB;
            this.SideC = SideC;
            RightTriangle = ItRightTriangle(SideA, SideB, SideC);

        }

        public double GetSquare()
        {
            double p = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        bool ItRightTriangle(double SideA, double SideB, double SideC)
        {
            if ((Math.Pow(SideA, 2) + Math.Pow(SideB, 2) == Math.Pow(SideC, 2)) ||
                (Math.Pow(SideA, 2) + Math.Pow(SideC, 2) == Math.Pow(SideB, 2)) ||
                (Math.Pow(SideB, 2) + Math.Pow(SideC, 2) == Math.Pow(SideA, 2)))
            {
                return true;
            }
            return false;
        }
    }
}
