using System;
public abstract class Figure
{
    public abstract double Area();
    public abstract double Perimeter();
}
public class Circle : Figure
{
    private double radius;

    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Невозможно построить");
        else
            this.radius = radius;
    }

    public override double Area()
    {
        return Math.PI * radius * radius;
    }

    public override double Perimeter()
    {
        return 2 * Math.PI * radius;
    }
}

public class Square : Figure
{
    private double side;

    public Square(double side)
    {
        if (side <= 0)
            throw new ArgumentException("Невозможно построить");
        else
            this.side = side;
    }
    public override double Area()
    {
        return side * side;
    }

    public override double Perimeter()
    {
        return 4 * side;
    }
}

public class Rectangle : Figure
{
    private double length;
    private double width;

    public Rectangle(double length, double width)
    {
        if (length <= 0 || width <= 0)
            throw new ArgumentException("Невозможно построить");
        else
        {
            this.length = length;
            this.width = width;
        }
    }

    public override double Area()
    {
        return length * width;
    }

    public override double Perimeter()
    {
        return 2 * (length + width);
    }
}

public class Triangle : Figure
{
    public double side1 { get; private set; }
    private double side2;
    private double side3;

    public Triangle(double side1, double side2, double side3)
    {
        if (side1 <= 0 || side2 <= 0 || side3 <= 0 || side1 + side2 <= side3 || side1 + side3 <= side2 || side2 + side3 <= side1)
            throw new ArgumentException("Невозможно построить");
        else
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }
    }

    public override double Area()
    {
        double s = (side1 + side2 + side3) / 2;
        return Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
    }

    public override double Perimeter()
    {
        return side1 + side2 + side3;
    }
}
