using System;
using System.Windows.Forms;

namespace Tonality
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            View view = new View();
            Model model = new Model();
            Presenter presenter = new Presenter(view, model);
            Application.Run(view);
        }
    }
}
