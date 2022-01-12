using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using QConsole.shit.screenshot;

namespace QConsole.commands
{
    class Screenshot : classes.Command
    {
        public Screenshot()
        {
            SetName("screenshot");
        }

        public override void Run(string[] args)
        {
            /*
           Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics g = Graphics.FromImage(bitmap as Image);

            g.CopyFromScreen(25, 25, 25, 25, bitmap.Size);

            Form form = new Form();

            form.BackgroundImage = bitmap;

           

            bitmap.Save("test.png", ImageFormat.Png);
            */

            SelectArea area = new SelectArea();

            area.Show();
        }
    }
}
