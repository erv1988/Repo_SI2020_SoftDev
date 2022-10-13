using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_test_cs
{
    public class Rational
    {
        public int P { set; get; }
        public int Q { set; get; }
        public int Numerator
        {
            set { P = value; }
            get => P;
        }
        public int Denominator
        {
            set { Q = value; }
            get => Q;
        }

        public Rational(int p, int q)
        {
            Numerator = p;
            Denominator = q;
            Simplify();
        }

        public static Rational Mul(Rational a, Rational b) => new Rational(a.P * b.P, a.Q * b.Q);

        public override bool Equals(object obj)
        {
            Rational a = obj as Rational;
            return (this.P == a.P && this.Q == a.Q);
        }

        public void Simplify()
        {
            int gcd = GCD(this.P, this.Q);
            P /= gcd;
            Q /= gcd;
        }

        static int GCD(int num1, int num2)
        {
            int Remainder;

            while (num2 != 0)
            {
                Remainder = num1 % num2;
                num1 = num2;
                num2 = Remainder;
            }

            return num1;
        }
    }

}
