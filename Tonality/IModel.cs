using System.Collections.Generic;
using System.Windows.Forms;

namespace Tonality
{
    interface IModel
    {
        void PlayNote(object pressedPianoKey);

        List<PianoKey> ChangePianoKeysAttributes(string mode);
    }
}
