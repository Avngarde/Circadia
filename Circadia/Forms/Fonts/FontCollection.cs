using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Text;

namespace Circadia.Forms.Fonts
{
    public static class CustomFontCollection
    {
        private static PrivateFontCollection fonts = new PrivateFontCollection();

        public static Font GetMontserrat(float size, FontStyle style)
        {
            fonts.AddFontFile("./Forms/Fonts/Montserrat.ttf");
            return new Font(fonts.Families[0], size, style);
        }
    }
}
