//Single Responsibility Principle Example:

//A class should only have one reason to change, thus only serve one purpose/job in OOP.

using System;

public class SingleResponsibilityPrinciple
{
    public static void Main(string[] args)
    {
        var area = new AreaCalculator();
        var rect = new Rectangle();
        rect.SetShape(12);
        var circle = new Circle();
        circle.SetShape(12);
        Shapes<string>[] shapes = new Shapes<string>[] { rect, circle };
        area.SetShape(shapes);
        Console.WriteLine($"Given Rectangle Area is: {area.Area()[0]}cm^3 and \nGiven Circle area is: {area.Area()[1]}cm^3");
    }
}

public class AreaCalculator
{
    protected Shapes<string>[] shapes;
    public void SetShape(Shapes<string>[] shapes) =>
        this.shapes = shapes;

    public float[] Area()
    {
        float[] area = new float[shapes.Length];
        int i = 0;
        foreach (var s in shapes)
        {
            area[i] = (float) (s.t == "Rectangle" ? Math.Pow(s.length, 2) : (s.t == "Circle" ? Math.PI * Math.Pow(s.radius, 2) : 0));
            i++;
        }
        return area;
    }
}

public abstract class Shapes<T>
{
    public T t;
    public float length { get; protected set; }
    public float radius { get; protected set; }
    public abstract void SetShape(float data);
}

public class Rectangle : Shapes<string>
{
    new string t = "Rectangle";
    public override void SetShape(float data)
    {
        SetT();
        SetLen(data);
    }
    public void SetT() => base.t = t;

    public void SetLen(float length) =>
        this.length = length;
}

public class Circle : Shapes<string>
{
    new string t = "Circle";
    public override void SetShape(float data)
    {
        SetT();
        SetRad(data);
    }
    public void SetT() => base.t = t;

    public void SetRad(float radius) =>
        this.radius = radius;
}
