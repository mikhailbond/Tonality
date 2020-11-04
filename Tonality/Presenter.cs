using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tonality
{
    class Presenter
    {
        private readonly IView _view;
        private readonly IModel _model;

        public Presenter(IView view, IModel model)
        {
            _view = view;
            _model = model;

            _view.PianoKeysClick += OnPianoKeysClick;
            _view.ModeChanged += OnModeChanged;
        }

        #region Обработка событий

        private void OnPianoKeysClick(object sender, EventArgs e)
        {
            _model.PlayNote(sender);
        }

        private void OnModeChanged(object sender, EventArgs e)
        {
            List<PianoKey> paintedPianoKeys = _model.ChangePianoKeysAttributes(((ComboBox)sender).Text);
            _view.ChangePianoKeysColor(paintedPianoKeys);
        }

        #endregion
    }
}
