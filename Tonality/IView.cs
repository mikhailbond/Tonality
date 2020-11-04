using System;
using System.Collections.Generic;

namespace Tonality
{
    interface IView
    {
        event EventHandler ModeChanged;
        event EventHandler PianoKeysClick;

        void ChangePianoKeysColor(List<PianoKey> paintedPianoKeys);
    }
}
