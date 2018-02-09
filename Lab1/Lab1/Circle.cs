using System;
namespace Lab1
{
    public class Circle
    {
        public int radius;
        public Circle(int _radius){
            this.radius = _radius;

        }
        public float FindArea()
        {
            return MathF.PI * MathF.Pow(radius, 2);

        }
        public float FindDiameter()
        {
            return 2 * radius;
        }
        public float FindCircumference()
        {
            return 2 * radius * MathF.PI;

        }
        public override string ToString()
        {
            return "Area: "+ FindArea() + "; "+"Diameter: " + FindDiameter() + "; " +"Circumference: " + FindCircumference();
        }

        
    }

}
