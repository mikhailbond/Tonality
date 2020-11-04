using System.Drawing;
using System.Collections.Generic;


namespace Tonality
{
    public static class ColorsAndLegends
    {
        public static readonly Color White = Color.White;
        public static readonly Color Black = Color.Black;
        public static readonly Color DarkGreen = Color.FromArgb(0, 130, 0);
        public static readonly Color Lemon = Color.FromArgb(225, 255, 0);
        public static readonly Color Orange = Color.FromArgb(221, 96, 1);
        public static readonly Color SeaWave = Color.FromArgb(0, 172, 196);
        public static readonly Color LightGreen = Color.FromArgb(0, 255, 0);
        public static readonly Color DarkYellow = Color.FromArgb(254, 181, 0);
        public static readonly Color Red = Color.FromArgb(200, 0, 0);

        public static readonly Dictionary<Color, string> ButtonsLegends = new Dictionary<Color, string>
        {
            [White] = string.Empty,
            [Black] = string.Empty,
            [DarkGreen] = "I",
            [Lemon] = "II",
            [Orange] = "III",
            [SeaWave] = "IV",
            [LightGreen] = "V",
            [DarkYellow] = "VI",
            [Red] = "VII"
        };

        //public static readonly Dictionary<string, Color> ButtonsColors = new Dictionary<string, Color>
        //    {
        //        //["По умолчанию"] = defaultMode,
        //        //["До мажор"] = doMajor,
        //        //["До диез мажор"] = doDiezMajor,
        //        //["Ре мажор"] = ReMajor,
        //        //["Ми бемоль мажор"] = miBemolMajor,
        //        //["Ми мажор"] = miMajor,
        //        //["Фа мажор"] = faMajor,
        //        //["Фа диез мажор"] = faDiezMajor,
        //        //["Соль мажор"] = solMajor,
        //        //["Ля бемоль мажор"] = laBemolMajor,
        //        //["Ля мажор"] = laMajor,
        //        //["Си бемоль мажор"] = siBemolMajor,
        //        //["Си мажор"] = siMajor,
        //        //["Ре бемоль мажор"] = reBemolMajor,
        //        //["Соль бемоль мажор"] = solBemolMajor



        //};

        //mode do major
        public static List<Color> ButtonsColors = new List<Color>()
        {
            Color.Aqua, //White, 
            Color.Aqua, //Black,
            LightGreen,
            Color.Aqua, //Black,
            DarkYellow,
            Color.Aqua, //Black,
            Red,
            DarkGreen,
            Color.Aqua, //Black,
            Lemon,
            Color.Aqua, //Black,
            Orange,
            SeaWave,
            Color.Aqua, //Black,
            LightGreen,
            Color.Aqua, //Black,
            Color.Aqua, //White,
            Color.Aqua, //Black,
            Color.Aqua, //White,
            Color.Aqua, //White,
            Color.Aqua, //Black,
            Color.Aqua, //White,
            Color.Aqua, //Black,
            Color.Aqua, //White,
            Color.Aqua, //White,
            Color.Aqua, //Black,
            Color.Aqua, //White
        };

    }
}
