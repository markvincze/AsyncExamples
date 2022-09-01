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
using System.Windows.Shapes;

namespace AsyncExamples.Wpf.NoThreadTask
{
    /// <summary>
    /// Interaction logic for StringInputWindow.xaml
    /// </summary>
    public partial class StringInputWindow : Window
    {
        public StringInputWindow()
        {
            InitializeComponent();
        }

        public string CustomerInput { get; private set; }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            CustomerInput = tbInput.Text;

            Close();
        }
    }
}
