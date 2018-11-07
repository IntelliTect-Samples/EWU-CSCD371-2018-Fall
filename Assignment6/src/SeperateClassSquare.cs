using System;
namespace Assignment6
{
    public class SeperateClassSquare: IArea
    {
        public double width
        {
            get;
            set;
        }
        public double height
        {
            get;
            set;
        }

        public SeperateClassSquare(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        
        public double calculateAreaAny(double width, double height)
        {
            return width * height;
        }

        public double calculateAreaSelf()
        {
            return this.width * this.height;
        }

        public void copyValueToSquareStructure(SeperateClassSquare square)
        {
            square.width = this.width;
            square.height = this.height;
        }

        public void copyValueToSquareStructureReference(ref SeperateClassSquare square)
        {
            square = new SeperateClassSquare(this.width, this.height);
        }

        public void reset()
        {
            this.height = 0;
            this.width = 0;
        }

        public static void Main()
        {

        }
    }
}