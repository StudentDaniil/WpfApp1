using System.Diagnostics.SymbolStore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            
            String text2 = textBox1.Text;
            if (text2 != "")
            {
                (ComplexNumber num1, ComplexNumber num2) = ComplexNumber.ParseComplexNumbers(text2);

                ComplexNumber sum = (num1 + num2);
                ComplexNumber difference = num1 - num2;
                ComplexNumber product = num1 * num2;
                ComplexNumber delenie = num1 / num2;


                String text = sum.ToString() + ", " + difference.ToString() + ", " + product.ToString() + ", " + delenie.ToString();



                button1.Content = text;
            }
            
            
            
           
            
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text = textBox1.Text;
            if (text != "")
            {
                (ComplexNumber num1, ComplexNumber num2) = ComplexNumber.ParseComplexNumbers(text);

                ComplexNumber sum = (num1 + num2);
                ComplexNumber difference = num1 - num2;
                ComplexNumber product = num1 * num2;
                ComplexNumber division = num1 / num2;
                bool equality = num1 == num2;
                string boolt = "Равны";
                if (equality == true) {
                    boolt = "Равны";
                }
                else { 
                    boolt = "Не равны";  
                }

                String text2 ="Сумма: " +  sum.ToString() + "\n" + "Разность: " + difference.ToString() + "\n" + "Произведение: " + product.ToString() + "\n" +  
                    "Частное: " + division.ToString() + "\n" + "Равенство: " +boolt;



                MessageBox.Show(text2);
            }
        }
         
    }
}