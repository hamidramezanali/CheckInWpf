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

namespace CheckInWpf.View
{ 

    /// <summary>
    /// Interaction logic for CheckedInListView.xaml
    /// </summary>
    public partial class CheckedInListView : UserControl
    {

        public ICommand LoadCommand
        {
            get { return (ICommand)GetValue(LoadCommandProperty); }
            set { SetValue(LoadCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoadCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadCommandProperty =
            DependencyProperty.Register("LoadCommand", typeof(ICommand), typeof(CheckedInListView), new PropertyMetadata(null));


        public CheckedInListView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(LoadCommand != null)
            {
                LoadCommand.Execute(null);
            }
        }
    }
}
