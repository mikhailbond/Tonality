using System.Drawing;
using System.Collections.Generic;

namespace Tonality
{
    public class PianoKey
    {
        public delegate void ChangeCurrentKeyColor();
        public event ChangeCurrentKeyColor OnChangeCurrentKeyColor;

        public string KeyName { get; set; }
        public string AudioFileName { get; set; }
        public string CurrentKeyLegend { get; set; }

        // public Color _activeColor;
        public Color _defaultColor;

        private Color _currentKeyColor;
        public Color CurrentKeyColor
        {
            get { return _currentKeyColor; }
            set { _currentKeyColor = value; OnChangeCurrentKeyColor(); }
        }

        public readonly Dictionary<string, Color> ButtonsColors;

        public PianoKey(string keyName, string pathToWAV, Color defaultMode, Color doMajor, Color doDiezMajor, Color ReMajor, Color miBemolMajor, 
                        Color miMajor, Color faMajor, Color faDiezMajor, Color solMajor, Color laBemolMajor, Color laMajor, Color siBemolMajor, 
                        Color siMajor, Color reBemolMajor, Color solBemolMajor)
        {
            KeyName = keyName;
            AudioFileName = pathToWAV;

            ButtonsColors = new Dictionary<string, Color>
            {
                ["По умолчанию"] = defaultMode,
                ["До мажор"] = doMajor,
                ["До диез мажор"] = doDiezMajor,
                ["Ре мажор"] = ReMajor,
                ["Ми бемоль мажор"] = miBemolMajor,
                ["Ми мажор"] = miMajor,
                ["Фа мажор"] = faMajor,
                ["Фа диез мажор"] = faDiezMajor,
                ["Соль мажор"] = solMajor,
                ["Ля бемоль мажор"] = laBemolMajor,
                ["Ля мажор"] = laMajor,
                ["Си бемоль мажор"] = siBemolMajor,
                ["Си мажор"] = siMajor,
                ["Ре бемоль мажор"] = reBemolMajor,
                ["Соль бемоль мажор"] = solBemolMajor
            };          
        }

        //public PianoKey(string keyName, string pathToWAV, Color activeColor)
        //{
        //    //KeyName = keyName;
        //    //AudioFileName = pathToWAV;

        //    //_activeColor = activeColor;

        //    ButtonsColors = new Dictionary<string, Color>
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
        //    };
        //}

        public PianoKey(string keyName, string pathToWAV, Color defaultColor)
        {
            KeyName = keyName;
            AudioFileName = pathToWAV;
            _defaultColor = defaultColor;
        }

        public void ChangeLegend()
        {
            CurrentKeyLegend = ColorsAndLegends.ButtonsLegends[CurrentKeyColor];
        }

        //public void ChangeColor(string mode)
        //{
        //    CurrentKeyColor = mode == "До мажор" ? ColorsAndLegends.DarkGreen : Color.White;
        //}
    }
}
