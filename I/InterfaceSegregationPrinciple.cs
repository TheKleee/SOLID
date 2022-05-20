//Interface Segregation Principle:

//A client should never be forced to implement an interface that it doesn’t use,
//or clients shouldn’t be forced to depend on methods they do not use.

using System;

public class InterfaceSegregationPrinciple
{
    public static void Main(string[] args)
    {
        var volume = new VolumeCalculator();
        var rect = new Rectangle();
        rect.SetShape(12);
        var cube = new Cube();
        cube.SetShape(12);
        var shapes = new iManageShapes[] { rect, cube };
        volume.SetShape(shapes);
        Console.WriteLine($"Given Rectangle area is: {volume.Calculate()[0]}cm^2 and \nGiven Cube volume is: {volume.Calculate()[1]}cm^3");
    }
}

//Editing class from Liskov Substitution Principle example:
public class Calculator
{
    protected iManageShapes[] shapes;
    protected void SetShape(iManageShapes[] shapes) =>
        this.shapes = shapes;
}

public interface iManageCalculator
{
    public float[] Calculate();
}

public class AreaCalculator : Calculator, iManageCalculator
{
    public new void SetShape(iManageShapes[] shapes) =>
           base.SetShape(shapes);

    public float[] Area()
    {
        float[] area = new float[shapes.Length];
        int i = 0;
        foreach (var s in shapes)
        {
            area[i] = s.Calculate();
            i++;
        }
        return area;
    }

    public float[] Calculate()
    {
        return Area();
    }
}

public class VolumeCalculator : AreaCalculator
{

    public new void SetShape(iManageShapes[] shapes) =>
        base.SetShape(shapes);

    public float[] Volume()
    {
        float[] volume = new float[base.shapes.Length];
        int i = 0;
        foreach (var s in base.shapes)
        {
            volume[i] = s.Calculate();
            i++;
        }
        return volume;
    }
    public new float[] Calculate()
    {
        return Volume();
    }
}

public abstract class Shapes
{
    protected float length, radius;
    public abstract void SetShape(float data);
    public abstract float ShapeArea();
    public virtual float ShapeVolume() { return 0; }
}

public interface iManageShapes
{
    public abstract float Calculate();
}

public class Rectangle : Shapes, iManageShapes
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

    public virtual float Calculate()
    {
        return ShapeArea();
    }
}

public class Circle : Shapes, iManageShapes
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

    public virtual float Calculate()
    {
        return ShapeArea();
    }
}


#region 3D shapes:
public class Cube : Rectangle
{
    public override float ShapeVolume()
    {
        return (float)Math.Pow(length, 3);
    }

    public override float Calculate()
    {
        return ShapeVolume();
    }
}

public class Ball : Circle
{
    public override float ShapeVolume()
    {
        return (float)(Math.PI * Math.Pow(radius, 3));
    }

    public override float Calculate()
    {
        return ShapeVolume();
    }
}
#endregion
