using d_fgdfhfdgh123.Models;
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

namespace d_fgdfhfdgh123
{

    public partial class MainWindow : Window
    {
        IKrip kripLeft;

        IKrip kripRight;
        private void clear_button_Click(object sender, RoutedEventArgs e)
        {
            textBoxResult.Text = string.Empty;
        }
        public MainWindow()
        {
            InitializeComponent();
            //kripLeft = new Skeleton();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (!Validate())
            {
                MessageBox.Show("Ошибка при вводе характеристик", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int damagekripLeft = int.Parse(this.textBoxDamagekripLeft.Text);

                int healthkripLeft = int.Parse(this.textBoxHealthkripLeft.Text);

                int damagekripRight = int.Parse(this.textBoxDamagekripRight.Text);

                int healthkripRight = int.Parse(this.textBoxHealthkripRight.Text);
                textBoxHealthkripRight.Clear();

                kripLeft.UpdateStat(damagekripLeft, healthkripLeft);
                kripRight.UpdateStat(damagekripRight, healthkripRight);
                while (true)
                {
                    if (!kripLeft.IsDead())
                    {
                        damagekripLeft = kripLeft.Storming();
                        kripRight.LossOfHealth(damagekripLeft);
                        textBoxResult.Text += string.Format("{0} атакует {1}. Жизней у {1}: {2}.\n\r", kripLeft.ToString(), kripRight.ToString(), kripRight.GetHp());

                        if (!kripRight.IsDead())
                        {
                            damagekripRight = kripRight.Storming();
                            kripLeft.LossOfHealth(damagekripRight);
                            textBoxResult.Text += string.Format("{0} атакует {1}. Жизней у {1}: {2}.\n\r", kripRight.ToString(), kripLeft.ToString(), kripLeft.GetHp());


                        }
                        else
                        {

                            textBoxResult.Text += " Выиграл " + kripLeft.ToString() + "\n\r";
                            break;
                        }
                    }
                    else
                    {
                        textBoxResult.Text += " Выиграл " + kripRight.ToString() + "\n\r";
                        break;
                    }
                }
            }
        }  
        

        private bool Validate()
        {
            int temp;
            if (int.TryParse(textBoxDamagekripLeft.Text, out temp) &&
                int.TryParse(textBoxDamagekripRight.Text, out temp) &&
                 int.TryParse(textBoxHealthkripLeft.Text, out temp) &&
                  int.TryParse(textBoxHealthkripRight.Text, out temp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChangedLeft(object sender, SelectionChangedEventArgs e)
        {
            string nameLeft = ((System.Windows.Controls.ContentControl)((System.Windows.Controls.Primitives.Selector)sender).SelectedItem).Content.ToString();
            switch (nameLeft)
            {
                case "Копейщик":
                    {
                        kripLeft = new Spearman();
                        break;
                    }
                case "Скелет":
                    {
                        kripLeft = new Skeleton();
                        break;
                    }
                case "Призрак":
                    {
                        kripLeft = new Ghost();
                        break;
                    }
            }
        }
        private void ComboBox_SelectionChangedRight(object sender, SelectionChangedEventArgs e)
        {
            string nameRight = ((System.Windows.Controls.ContentControl)((System.Windows.Controls.Primitives.Selector)sender).SelectedItem).Content.ToString();
            switch (nameRight)
            {
                case "Копейщик":
                    {
                        kripRight = new Spearman();
                        break;
                    }
                case "Скелет":
                    {
                        kripRight = new Skeleton();
                        break;
                    }
                case "Призрак":
                    {
                        kripRight = new Ghost();
                        break;
                    }
            }
        }
    }
}
