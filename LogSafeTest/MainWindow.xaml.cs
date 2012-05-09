using System;
using System.Collections.Generic;
using System.Linq;
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

namespace MediaPlayerMvvmSample
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

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ViewModel.ViewModel vm = DataContext as ViewModel.ViewModel;
            if (vm != null)
            {
                CommandBinding cb = new CommandBinding(vm.TaskIsDone);

                cb.Command.Execute(this);
            }
        }

        private void ListBoxItem_MouseDoubleClick2(object sender, MouseButtonEventArgs e)
        {
            ViewModel.ViewModel vm = DataContext as ViewModel.ViewModel;
            if (vm != null)
            {
                CommandBinding cb = new CommandBinding(vm.TaskIsToDo);

                cb.Command.Execute(this);
            }
        }
    }
}
