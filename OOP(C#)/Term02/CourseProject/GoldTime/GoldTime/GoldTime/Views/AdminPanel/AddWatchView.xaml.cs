﻿using System;
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

namespace GoldTime.Views.AdminPanel
{
    /// <summary>
    /// Логика взаимодействия для AddWatchView.xaml
    /// </summary>
    public partial class AddWatchView : Page
    {
        public AddWatchView()
        {
            InitializeComponent();
        }

        private void Price_KeyDown(object sender, KeyEventArgs e)
        {
            var allowed = new[] { Key.D0, Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6,
                                    Key.D7, Key.D8, Key.D9, Key.NumPad0, Key.NumPad1, Key.NumPad2, Key.NumPad3, Key.NumPad4,
                                    Key.NumPad5, Key.NumPad6, Key.NumPad7, Key.NumPad8, Key.NumPad9, Key.Back, Key.OemComma};
            if (allowed.Contains(e.Key))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void Price_TextChanged(object sender, TextChangedEventArgs e)
        {
            //(TextBox)sender.Text = .Replace(" ", "");
        }
    }
}
