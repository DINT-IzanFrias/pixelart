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

namespace PixelArt
{
    public partial class MainWindow : Window
    {
        String color = "Black";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Pequeño_Click(object sender, RoutedEventArgs e)
        {
            int tamaño = 0;

            Button boton = (Button)sender;
            if (boton.Content.Equals("Pequeño"))
            {
                tamaño = 5;
            }
            if (boton.Content.Equals("Mediano"))
            {
                tamaño = 15;

            }
            if (boton.Content.Equals("Grande"))
            {
                tamaño = 25;

            }

            lienzo.Children.Clear();
            lienzo.RowDefinitions.Clear();
            lienzo.ColumnDefinitions.Clear();

            for (int i = 0; i < tamaño; i++) // Filas
            {
                RowDefinition rowDefinition = new RowDefinition();
                lienzo.RowDefinitions.Add(rowDefinition);
            }

            for (int j = 0; j < tamaño; j++) // Colmunas
            {
                ColumnDefinition columnDefinition = new ColumnDefinition();
                lienzo.ColumnDefinitions.Add(columnDefinition);
            }

            for (int row = 0; row < tamaño; row++)
            {
                for (int col = 0; col < tamaño; col++)
                {
                   Border border = new Border();
                    border.BorderBrush = System.Windows.Media.Brushes.Black;
                    border.BorderThickness = new System.Windows.Thickness(1);   
                    TextBlock t = new TextBlock();
                    border.Child = t;
                    Grid.SetRow(border, row);
                    Grid.SetColumn(border, col);
                    t.MouseLeftButtonDown+= Colorear;
                    t.MouseEnter += Colorear_varios;
                    lienzo.Children.Add(border);
                }
            }
        }

        private void Colorear(object sender, MouseButtonEventArgs e)
        {
            TextBlock t = (TextBlock) sender;
            t.Background= new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));    
        }

        private void CambiarColor(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if(rb.Content.Equals("Rojo"))
            {
                color = "Red";
            }
            if (rb.Content.Equals("Negro"))
            {
                color = "Black";
            }
            if (rb.Content.Equals("Blanco"))
            {
                color = "White";
            }
            if (rb.Content.Equals("Verde"))
            {
                color = "Green";
            }
            if (rb.Content.Equals("Azul"))
            {
                color = "Blue";
            }
            if (rb.Content.Equals("Amarillo"))
            {
                color = "Yellow";
            }
            if (rb.Content.Equals("Naranja"))
            {
                color = "Orange";
            }
            if (rb.Content.Equals("Rosa"))
            {
                color = "Pink";
            }
        }

        private void CambiarColor_Personalizado(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            color = per.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in lienzo.Children)
            {
                if (element is Border border)
                {
                    if (border.Child is TextBlock t)
                    {
                        t.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
                    }
                }
            }
        }

        private void Colorear_varios(object sender, RoutedEventArgs e)
        {
            TextBlock t = (TextBlock)sender;
            if(ClickMode.Hover.Equals(true))
            {
                t.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
            }
            
        }
    }
}
