using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    public class Circle : IDrawable
    {
        public static Circle Instance { get; } = new Circle();

        public double Radius { get; set; } = 0;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Colors.Blue;
            canvas.StrokeSize = 3;

            float scale = 5; // scale radius so it fits the view
            float r = (float)(Radius * scale);

            float centerX = (float)(dirtyRect.Width / 2);
            float centerY = (float)(dirtyRect.Height / 2);

            canvas.DrawCircle(centerX, centerY, r);
        }
    }
}
