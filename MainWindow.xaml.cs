using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace SOD_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string[] files = { @"C:\Users\Janu\Desktop\stereo-pairs\" };

            foreach (string file in files)
            {
                Bitmap leftImage = (Bitmap)System.Drawing.Image.FromFile(file + @"\imL.png");
                Bitmap rightImage = (Bitmap)System.Drawing.Image.FromFile(file + @"\imR.png");

                Bitmap RangeImage = RangeMap.RangeMapGenerator(leftImage, rightImage);

                RangeImage.Save(file + @"\imD.png");
            }
        }
    }
}
