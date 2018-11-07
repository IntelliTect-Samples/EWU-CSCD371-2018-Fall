using System;

namespace Assignment6
{
    public interface IArea
    {
        double calculateAreaAny(double width, double height);
        double calculateAreaSelf();

        void reset();

    }
}