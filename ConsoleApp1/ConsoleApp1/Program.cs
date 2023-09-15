    public abstract class Figure
    {
        public abstract double find_Square();
        public abstract double find_Perimetr();
    }

    public class Circle : Figure
    {
        private double radius;
        public Circle(double radius = 0) { this.radius = radius; }
        public override double find_Square()
        {
            double Square = 0;
            if (radius <= 0)
            {
                Console.WriteLine("Радиус не может быть меньше нуля или равен ему");
            }
            else
                Square = Math.PI * radius * radius;
            return Square;
        }
        public override double find_Perimetr()
        {
            double Perimetr = 0;
            if (radius <= 0)
            {
                Console.WriteLine("Радиус не может быть меньше нуля или равен ему");
            }
            else
                Perimetr = 2 * Math.PI * radius;
            return Perimetr;
        }
        public double get() { return radius; }
        public void set(double radius) { this.radius = radius; }
    }
    public class Square : Figure
    {
        private double side;
        public Square(double side = 0) { this.side = side; }
        public override double find_Square()
        {
            double square = 0;
            if (side <= 0)
            {
                Console.WriteLine("Сторона не может быть меньше нуля или равна ему");
            }
            else
                square = side * side;
            return square;
        }
        public override double find_Perimetr()
        {
            double Perimetr = 0;
            if (side <= 0)
            {
                Console.WriteLine("Сторона не может быть меньше нуля или равна ему");
            }
            else
                Perimetr = 4 * side;
            return Perimetr;
        }
        public double get() { return side; }
        public void set(double side) { this.side = side; }
    }
    public class Triangle : Figure
    {
        private double side_A, side_B, side_C, semi_Perimetr;
        public Triangle(double side_A, double side_B, double side_C) { this.side_A = side_A; this.side_B = side_B; this.side_C = side_C; semi_Perimetr = (side_A + side_B + side_C) / 2; }
        public override double find_Square()
        {
            double Square = 0;
            if (side_A + side_B < side_C || side_B + side_C < side_A || side_A + side_C < side_B)
                Console.WriteLine("Такой треугольник не существует");
            else
                Square = Math.Sqrt(semi_Perimetr * (semi_Perimetr - side_A) * (semi_Perimetr - side_B) * (semi_Perimetr - side_C));
            return Square;
        }
        public override double find_Perimetr()
        {
            double Perimetr = 0;
            if (side_A + side_B < side_C || side_B + side_C < side_A || side_A + side_C < side_B)
                Console.WriteLine("Такой треугольник не существует");
            else
                Perimetr = side_A + side_B + side_C;
            return Perimetr;
        }
        public double get_side_A() { return side_A; }
        public double get_side_B() { return side_B; }
        public double get_side_C() { return side_C; }
        public void set_side_A(double side_A) { this.side_A = side_A; }
        public void set_side_B(double side_B) { this.side_B = side_B; }
        public void set_side_C(double side_C) { this.side_C = side_C; }
    }

class Program
{
    static void Main(string[] args)
    {
        int n = 0;
        do
        {
            Console.WriteLine("Введите что хотите выбрать: \n 1-Круг \n2-Квадрат\n3-Треугольник\n0-Выход\n");
            n=Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    Console.WriteLine("Введите радиус круга: \n");
                    double radius = Convert.ToInt32(Console.ReadLine());
                    Circle circle= new Circle(radius);
                    Console.WriteLine(circle.find_Square() + " " + circle.find_Perimetr());
                    break;
                    case 2:
                    Console.WriteLine("Введите Сторону квадрата: \n");
                    double side = Convert.ToInt32(Console.ReadLine());
                    Square square= new Square(side);
                    Console.WriteLine(square.find_Square()+ " " + square.find_Perimetr());
                    break;
                case 3:
                    Console.WriteLine("Введите cтороны треугольника: \n");
                    double side_a=Convert.ToInt32(Console.ReadLine());
                    double side_b=Convert.ToInt32(Console.ReadLine());
                    double side_c=Convert.ToInt32(Console.ReadLine());
                    Triangle triangle = new Triangle(side_a,side_b,side_c);
                    Console.WriteLine(triangle.find_Square() + " "+ triangle.find_Perimetr());
                    break;
                default:
                    break;
            }


        } while (n != 0);

    }
}