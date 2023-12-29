using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingCar.Domain.Shared
{
    public class Field
    {
        public int Width { get; }
        public int Height { get; }
        public Field(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
