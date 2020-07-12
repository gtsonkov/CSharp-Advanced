using System;

namespace ClassBoxData
{
    public class Box
    {
        private double length;

        private double width;

        private double height;

        public Box(double l, double w, double h)
        {
            this.Length = l;
            this.Width = w;
            this.Height = h;
        }

        public double Length
        {
            get
            {
                return this.length;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }

        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }

        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }

        }

        public double SurfaceArea()
        {
            return (2.00*Length*Width + 2.00*Length*Height + 2.00*Width*Height);
        }

        public double LateralSurfaceArea()
        {
            return (2.00*Length*Height + 2.00*Width*Height);
        }

        public double Volume()
        {
            return (Length*Width*Height);
        }

    }
}