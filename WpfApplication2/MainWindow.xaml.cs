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
using System.Xml;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReadXML();
        }

        public void ReadXML()
        {
            // First write something so that there is something to read ... 
            var b = new Book { title = "Serialization Overview" };
            var writer = new System.Xml.Serialization.XmlSerializer(typeof(Book));
           // var wfile = new System.IO.StreamWriter(@"overview.xml");

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//serialization.xml";
            System.IO.FileStream fil = System.IO.File.Create(path);


            writer.Serialize(fil, b);
            fil.Close();

            // Now we can read the serialized book ...
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(Book));
            System.IO.StreamReader file = new System.IO.StreamReader(
                @path);
            Book overview = (Book)reader.Deserialize(file);
            file.Close();

            Console.WriteLine(overview.title);

        }
    }
    public class Book
{
    public String title;
}       



}
