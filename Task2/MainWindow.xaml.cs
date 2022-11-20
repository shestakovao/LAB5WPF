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
using Microsoft.Win32;
using System.IO;
using System.Windows.Ink;
using System.Windows.Media.Media3D;


namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "IncCanvas Format (*.sandy)|*.sandy|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                FileStream fs = new FileStream(openFileDialog.FileName, FileMode.OpenOrCreate);
                StrokeCollection strokes = new StrokeCollection(fs);
                inkCanvas.Strokes = strokes;
                fs.Close();
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "IncCanvas Format (*.sandy)|*.sandy|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate);
                inkCanvas.Strokes.Save(fileStream);
                fileStream.Close();
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            inkCanvas.Strokes.Clear();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (inkCanvas.EditingMode == InkCanvasEditingMode.Ink)
                inkCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
            else
                inkCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Colors.Blue;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Colors.Green;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Colors.Red;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Colors.Black;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Colors.Yellow;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (inkCanvas != null)
            {
                inkCanvas.DefaultDrawingAttributes.Height = Convert.ToInt32(comboBox.Text);
                inkCanvas.DefaultDrawingAttributes.Width = Convert.ToInt32(comboBox.Text);
            }
        }
    }
}
