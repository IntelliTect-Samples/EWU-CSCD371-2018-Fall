using System;
namespace Assignment6
{
    public class SeperateStructRectangle: IArea
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

        public void reset()
        {
            this.height = 0;
            this.width = 0;
        }
        
        public double calculateAreaAny(double width, double height)
        {
            return width * height;
        }

        public double calculateAreaSelf()
        {
            return this.width * this.height;
        }

        public void copyValueToRectangleStructure(SeperateStructRectangle rectangle)
        {
            rectangle.width = this.width;
            rectangle.height = this.height;
        }

        public void copyValueToRectangleStructureReference(ref SeperateStructRectangle rectangle)
        {
            rectangle.width = this.width;
            rectangle.height = this.height;
        }

    }
}