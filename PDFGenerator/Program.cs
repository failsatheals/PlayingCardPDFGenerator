using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFGenerator
{
    class Program
    {
        
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form cardGenForm = new Form1();
            cardGenForm.Text = "Card image to PDF generator";
            Application.Run(cardGenForm);
        }
    }
}
