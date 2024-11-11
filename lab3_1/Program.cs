namespace lab3_1
{

    public struct Vector
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static double operator *(Vector a, Vector b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        public static Vector operator *(Vector v, double scalar)
        {
            return new Vector(v.X * scalar, v.Y * scalar, v.Z * scalar);
        }

        public static Vector operator *(double scalar, Vector v)
        {
            return v * scalar;
        }

        public static bool operator ==(Vector a, Vector b)
        {
            return a.Length() == b.Length();
        }

        public static bool operator !=(Vector a, Vector b)
        {
            return !(a == b);
        }

        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector)
            {
                Vector v = (Vector)obj;
                return this == v;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Vector({X}, {Y}, {Z})";
        }
    }

    public class Program
    {
        public static void Main()
        {
            Vector v1 = new(1, 2, 3);
            Vector v2 = new(4, 5, 6);
            int num = 2;

            Vector sum = v1 + v2;
            double dotProduct = v1 * v2;
            Vector scaled1 = v1 * num;
            Vector scaled2 = v2 * num;

            Console.WriteLine(v1 + "\n" + v2 + "\n");
            Console.WriteLine($"Сумма: {sum}");
            Console.WriteLine($"Скалярное произведение: {dotProduct}");
            Console.WriteLine($"Умноженные вектора на {num}: {scaled1}  {scaled2}");

            Console.WriteLine($"v1 == v2: {v1 == v2}");
            Console.WriteLine($"v1 != v2: {v1 != v2}");
        }
    }
}