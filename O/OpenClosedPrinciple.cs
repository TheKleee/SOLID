//Open-Closed Principle Example:
//Objects or entities should be open for extansion, however closed for modification in OOP!

using System;

public class OpenClosedPrinciple
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

//Editing class from Single Responsibility Princibility example:
/// <summary>
/// Old: Area method required us to manually check for string "ShapeName" in order to return a value
/// New: This is now automated so that we can create any shape we need!
/// </summary>
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
            area[i] = s.ShapeArea();
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
    public abstract float ShapeArea();
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

    public override float ShapeArea()
    {
        return (float) Math.Pow(length, 2);
    }
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

    public override float ShapeArea()
    {
        return (float) (Math.PI * Math.Pow(radius, 2));
    }
}
