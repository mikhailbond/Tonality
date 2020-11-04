using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tonality
{
    public partial class View : Form, IView
    {
        public View()
        {
            InitializeComponent();
            SubscribeToEvents();
        }

        #region Проброс событий

        private void SubscribeToEvents()
        {
            foreach (Button btn in panelForPianoButtons.Controls)
            {
                btn.Click += OnButtonsClick;

                //btn.FlatAppearance.BorderColor = btn.BackColor;
                btn.FlatAppearance.MouseOverBackColor = btn.BackColor;
                btn.FlatAppearance.MouseDownBackColor = btn.BackColor;
                btn.BackColorChanged += (s, e) =>
                {
                    btn.FlatAppearance.MouseOverBackColor = btn.BackColor;
                    btn.FlatAppearance.MouseDownBackColor = btn.BackColor;
                //    btn.FlatAppearance.BorderColor = btn.BackColor;
                };
            }

            comboBoxMode.TextChanged += OnComboBoxModeTextChanged;
        }

        private void OnButtonsClick(object sender, EventArgs e)
        {
            PianoKeysClick?.Invoke(sender, EventArgs.Empty);
        }

        private void OnComboBoxModeTextChanged(object sender, EventArgs e)
        {
            ModeChanged?.Invoke(sender, EventArgs.Empty);
        }

        #endregion

        #region IView implementation

        public event EventHandler ModeChanged;
        public event EventHandler PianoKeysClick;

        public void ChangePianoKeysColor(List<PianoKey> paintedPianoKeys)
        {
            foreach (Button btn in panelForPianoButtons.Controls)
            {
                if (paintedPianoKeys.Exists(key => key.KeyName == btn.Name))
                {
                    btn.BackColor = paintedPianoKeys.Find(key => key.KeyName == btn.Name).CurrentKeyColor;
                    btn.Text = paintedPianoKeys.Find(key => key.KeyName == btn.Name).CurrentKeyLegend;

                    //btn.FlatAppearance.MouseOverBackColor = btn.BackColor;
                    //btn.FlatAppearance.MouseDownBackColor = btn.BackColor;
                }
                //else
                //{
                    //throw new Exception("Клавиши из paintedPianoKeys нет на форме");
                //}
            }
        }

        #endregion

    }
}
