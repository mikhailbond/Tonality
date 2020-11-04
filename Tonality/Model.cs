using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace Tonality
{
    class Model : IModel
    {
        private string _temporaryDirectoryName = "Notes";
        private List<PianoKey> _pianoKeys = new List<PianoKey>();

        public Model()
        {
            InitialiseButtons();
            CreateTemporaryFolder();
            ResourceExtraction();
        }

        ~Model()
        {
            DeleteTemporaryFolder();
        }

        #region Methods

        

        private void InitialiseButtons()
        {
            //_pianoKeys.Add(new PianoKey("btnFA_LOWER", "FA_LOWER.wav", ColorsAndLegends.White, ColorsAndLegends.DarkGreen, ColorsAndLegends.White, 
            //                            ColorsAndLegends.White, ColorsAndLegends.White, ColorsAndLegends.White, ColorsAndLegends.White, 
            //                            ColorsAndLegends.White, ColorsAndLegends.White, ColorsAndLegends.White, ColorsAndLegends.White,
            //                            ColorsAndLegends.White, ColorsAndLegends.White, ColorsAndLegends.White, ColorsAndLegends.White));

            //_pianoKeys.Add(new PianoKey("btnSI_LOWER", "SI_LOWER.wav", ColorsAndLegends.White, ColorsAndLegends.White, ColorsAndLegends.SeaWave,
            //                            ColorsAndLegends.White, ColorsAndLegends.White, ColorsAndLegends.White, ColorsAndLegends.White,
            //                            ColorsAndLegends.White, ColorsAndLegends.White, ColorsAndLegends.White, ColorsAndLegends.White,
            //                            ColorsAndLegends.White, ColorsAndLegends.White, ColorsAndLegends.White, ColorsAndLegends.White));


            _pianoKeys.Add(new PianoKey("btnFA_LOWER", "FA_LOWER.wav", Color.White));
            _pianoKeys.Add(new PianoKey("btnFA_DIEZ_LOWER", "FA_DIEZ_LOWER.wav", Color.Black));  
            _pianoKeys.Add(new PianoKey("btnSOL_LOWER", "SOL_LOWER.wav", Color.White));
            _pianoKeys.Add(new PianoKey("btnSOL_DIEZ_LOWER", "SOL_DIEZ_LOWER.wav", Color.Black));
            _pianoKeys.Add(new PianoKey("btnLA_LOWER", "LA_LOWER.wav", Color.White));
            _pianoKeys.Add(new PianoKey("btnLA_DIEZ_LOWER", "LA_DIEZ_LOWER.wav", Color.Black));
            _pianoKeys.Add(new PianoKey("btnSI_LOWER", "SI_LOWER.wav", Color.White));

            _pianoKeys.Add(new PianoKey("btnDO_MIDDLE", "DO_MIDDLE.wav", Color.White));
            _pianoKeys.Add(new PianoKey("btnDO_DIEZ_MIDDLE", "DO_DIEZ_MIDDLE.wav", Color.Black));
            _pianoKeys.Add(new PianoKey("btnRE_MIDDLE", "RE_MIDDLE.wav", Color.White));
            _pianoKeys.Add(new PianoKey("btnRE_DIEZ_MIDDLE", "RE_DIEZ_MIDDLE.wav", Color.Black));
            _pianoKeys.Add(new PianoKey("btnMI_MIDDLE", "MI_MIDDLE.wav", Color.White));
            _pianoKeys.Add(new PianoKey("btnFA_MIDDLE", "FA_MIDDLE.wav", Color.White));
            _pianoKeys.Add(new PianoKey("btnFA_DIEZ_MIDDLE", "FA_DIEZ_MIDDLE.wav", Color.Black));
            _pianoKeys.Add(new PianoKey("btnSOL_MIDDLE", "SOL_MIDDLE.wav", Color.White));
            _pianoKeys.Add(new PianoKey("btnSOL_DIEZ_MIDDLE", "SOL_DIEZ_MIDDLE.wav", Color.Black));
            _pianoKeys.Add(new PianoKey("btnLA_MIDDLE", "LA_MIDDLE.wav", Color.White));
            _pianoKeys.Add(new PianoKey("btnLA_DIEZ_MIDDLE", "LA_DIEZ_MIDDLE.wav", Color.Black));
            _pianoKeys.Add(new PianoKey("btnSI_MIDDLE", "SI_MIDDLE.wav", Color.White));

            _pianoKeys.Add(new PianoKey("btnDO_UPPER", "DO_UPPER.wav", Color.White));
            _pianoKeys.Add(new PianoKey("btnDO_DIEZ_UPPER", "DO_DIEZ_UPPER.wav", Color.Black));
            _pianoKeys.Add(new PianoKey("btnRE_UPPER", "RE_UPPER.wav", Color.White));
            _pianoKeys.Add(new PianoKey("btnRE_DIEZ_UPPER", "RE_DIEZ_UPPER.wav", Color.Black));
            _pianoKeys.Add(new PianoKey("btnMI_UPPER", "MI_UPPER.wav", Color.White));
            _pianoKeys.Add(new PianoKey("btnFA_UPPER", "FA_UPPER.wav", Color.White));
            _pianoKeys.Add(new PianoKey("btnFA_DIEZ_UPPER", "FA_DIEZ_UPPER.wav", Color.Black));
            _pianoKeys.Add(new PianoKey("btnSOL_UPPER", "SOL_UPPER.wav", Color.White));

            foreach (var pianoKey in _pianoKeys)
            {
                pianoKey.OnChangeCurrentKeyColor += pianoKey.ChangeLegend;
            }
        }

        private void ResourceExtraction()
        {
            foreach (var key in _pianoKeys)
            {
                System.Reflection.Assembly executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                System.IO.Stream resourceStream = executingAssembly.GetManifestResourceStream("Tonality.Resources.Notes." + key.AudioFileName);
                System.IO.Stream fileStream = System.IO.File.OpenWrite(_temporaryDirectoryName + "/" + key.AudioFileName);
                resourceStream.CopyTo(fileStream);
                fileStream.Flush();
                fileStream.Close();
            }
        }

        private void CreateTemporaryFolder()
        {
            Directory.CreateDirectory(_temporaryDirectoryName); // создание папки в директории, где лежит exe файл
        }

        private void DeleteTemporaryFolder()
        {
            Directory.Delete(_temporaryDirectoryName, true);
        }

        #endregion

        #region IModel implementation

        public void PlayNote(object pressedPianoKey)
        {
            Thread threadForPlayer = new Thread(new ParameterizedThreadStart(InitialisePlayer));
            threadForPlayer.Start(pressedPianoKey);      
        }
        
        private void InitialisePlayer(object pressedPianoKey)
        {
            string pathToWAV = _temporaryDirectoryName + "/" + _pianoKeys.Find(key => key.KeyName == ((Button)pressedPianoKey).Name).AudioFileName;
            System.Windows.Media.MediaPlayer player = new System.Windows.Media.MediaPlayer();
            player.Open(new Uri(pathToWAV, System.UriKind.Relative));
            player.Play();
            Thread.Sleep(2000);
            player.Close();
        }

        public List<PianoKey> ChangePianoKeysAttributes(string mode) // + int add и сделать словарь для какого режима какой add // запрос к базе данных возварат коллекции
        {
            foreach (var key in _pianoKeys)
            {
                key.CurrentKeyColor = key._defaultColor;
            }


            int add = 0; //при режиме До Мажор add = 0, поэтому в свитче нет аткого кейса

            switch (mode)
            {
                case "По умолчанию":
                    add = 27;
                    //foreach (var key in _pianoKeys)
                    //{
                    //    key.CurrentKeyColor = key._defaultColor;
                    //}
                    break;
                case "До диез мажор":
                    add = 1;
                    break;
                case "Ре мажор":
                    add = 2;
                    break;
                case "Ми бемоль мажор":
                    add = 3;
                    break;
                case "Ми мажор":
                    add = 4;
                    break;
                case "Фа мажор":
                    add = 5;
                    break;
                case "Фа диез мажор":
                    add = 6;
                    break;
                case "Соль мажор":
                    add = 7;
                    break;
                case "Ля бемоль мажор":
                    add = 8;
                    break;
                case "Ля мажор":
                    add = 9;
                    break;
                case "Си бемоль мажор":
                    add = 10;
                    break;
                case "Си мажор":
                    add = 11;
                    break;
                case "Ре бемоль мажор":
                    add = 1;
                    break;
                case "Соль бемоль мажор":
                    add = 6;
                    break;
                default:
                    break;
            }

            int count = 0;

            for (int i = 0; i < _pianoKeys.Count; i++)
            {
                if ((count + add) >= 27)
                {

                }
                else
                {
                    if (ColorsAndLegends.ButtonsColors[count] == Color.Aqua)
                    {
                        _pianoKeys[i + add].CurrentKeyColor = _pianoKeys[i + add]._defaultColor;
                        count++;
                    }
                    else
                    {
                        _pianoKeys[i + add].CurrentKeyColor = ColorsAndLegends.ButtonsColors[count];
                        count++;
                    }                    
                }
            }

            //foreach (var key in _pianoKeys)
            //{
            //    //key.CurrentKeyColor = key.ButtonsColors[mode];
            //    if ((count + add) >= 7)
            //    {
            //        //leave key colors they was
            //    }
            //    else
            //    {
            //        key.CurrentKeyColor = ColorsAndLegends.ButtonsColors[count + add];
            //        count++;
            //    }
            //}
            count = 0;
            return _pianoKeys;
        }

        #endregion
    }
}
