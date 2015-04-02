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
using System.Windows.Shapes;

namespace Fitness_Application
{
    /// <summary>
    /// Interaction logic for RunningWindow.xaml
    /// </summary>
    public partial class RunningWindow : Window
    {
        Boolean isVisible = false;
        public RunningWindow()
        {
            
            InitializeComponent();
            hideControls();
            
        }

        private void enterNewRunButton_Click(object sender, RoutedEventArgs e)
        {
            if (isVisible)
            {
                isVisible = false;
                hideControls();
            }
            else
            {
                isVisible = true;
                unHideControls();
            }
        }

        private void hideControls()
        {
            distanceTextbox.Visibility = Visibility.Hidden;
            distanceLabel.Visibility = Visibility.Hidden;
            timeLabel.Visibility = Visibility.Hidden;
            timeTextbox.Visibility = Visibility.Hidden;
            saveButton.Visibility = Visibility.Hidden;
            hhmmssLabel.Visibility = Visibility.Hidden;

        }

        private void unHideControls()
        {
            distanceTextbox.Visibility = Visibility.Visible;
            distanceLabel.Visibility = Visibility.Visible;
            timeLabel.Visibility = Visibility.Visible;
            timeTextbox.Visibility = Visibility.Visible;
            saveButton.Visibility = Visibility.Visible;
            hhmmssLabel.Visibility = Visibility.Visible;

        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            window.Show();
            this.Close();
        }
    }
}
