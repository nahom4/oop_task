using System;
class Shape{

    public string? Name {

        get;set;
    }

    public virtual double CalculateArea(){
        return 0.0;

    }
}

class Circle : Shape{

    public double Radius {
        get;set;
    }
    public override double CalculateArea()
    {
       return Math.PI * Math.Pow(Radius,2);
    }

}

class Rectangle : Shape{

    public double Width {
        get;set;
    }
    public double Height {
        get;set;
    }
     public override double CalculateArea()
    {
       return Width * Height; 
    }
}

class Triangle : Shape{

    public double Base{
        get;set;
        
    }
    public double Height{
        get;set;

    }
     public override double CalculateArea()
    {
        return 0.5 * Height * Base;
        
    }
}

class Driver{

    public  static void Main(){
        //create a circle
        Circle FirstCircle = new Circle();
        FirstCircle.Name = "Circle";
        FirstCircle.Radius = 10;

        //create a Rectangle
        Rectangle FirstRectangle = new Rectangle();
        FirstRectangle.Name = "Rectangle";
        FirstRectangle.Width = 10;
        FirstRectangle.Height = 10;

        // create a Triangle
        Triangle FirstTriangle = new Triangle();
        FirstTriangle.Name = "Triangle";
        FirstTriangle.Base = 10;
        FirstTriangle.Height = 8;

        Driver.PrintShapeArea(FirstCircle);
        Driver.PrintShapeArea(FirstRectangle);
        Driver.PrintShapeArea(FirstTriangle);



    }

    public static void PrintShapeArea(Shape SpecificShape ) {

        Console.WriteLine($"{SpecificShape.Name} ------------- {SpecificShape.CalculateArea()}");
    }
}