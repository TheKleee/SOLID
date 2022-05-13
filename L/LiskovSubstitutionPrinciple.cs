//Liskov Substitution Principle Example:

//Every sublcass of derived class should be substitutable of their base or parent class!

using System;

public class LiskovSubstitutionPrinciple
{
    public static void Main(string[] args)
    {
        var volume = new VolumeCalculator();
        var cube = new Cube();
        cube.SetShape(12);
        var ball = new Ball();
        ball.SetShape(12);
        var shapes = new Shapes[] { cube, ball };
        volume.SetShape(shapes);
        Console.WriteLine($"Given Cube volume is: {volume.Volume()[0]}cm^3 and \nGiven Ball volume is: {volume.Volume()[1]}cm^3");
    }
}

//Editing class from Open-Closed Principle example:
public class Calculator
{
    protected Shapes[] shapes;
    protected void SetShape(Shapes[] shapes) =>
        this.shapes = shapes;
}

public class AreaCalculator : Calculator
{
    public new void SetShape(Shapes[] shapes) =>
           base.SetShape(shapes);

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

/// <summary>
/// This class exends from AreaCalculator
/// </summary>
public class VolumeCalculator : AreaCalculator
{
    public new void SetShape(Shapes[] shapes) =>
        base.SetShape(shapes);

    public float[] Volume()
    {
        float[] volume = new float[base.shapes.Length];
        int i = 0;
        foreach (var s in base.shapes)
        {
            volume[i] = s.ShapeVolume();
            i++;
        }
        return volume;
    }
}

public abstract class Shapes
{
    protected float length, radius;
    public abstract void SetShape(float data);
    public abstract float ShapeArea();
    public virtual float ShapeVolume() { return 0; }
}

public class Rectangle : Shapes
{
    public override void SetShape(float data)
    {
        SetLen(data);
    }

    public void SetLen(float length) =>
        this.length = length;

    public override float ShapeArea()
    {
        return (float)Math.Pow(length, 2);
    }
}

public class Circle : Shapes
{
    public override void SetShape(float data)
    {
        SetRad(data);
    }

    public void SetRad(float radius) =>
        this.radius = radius;

    public override float ShapeArea()
    {
        return (float)(Math.PI * Math.Pow(radius, 2));
    }
}


#region 3D shapes:
public class Cube : Rectangle
{
    public override float ShapeVolume()
    {
        return (float)Math.Pow(length, 3);
    }
}

public class Ball : Circle
{
    public override float ShapeVolume()
    {
        return (float)(Math.PI * Math.Pow(radius, 3));
    }
}
#endregion
