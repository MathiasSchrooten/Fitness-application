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
using System.Data.SQLite;
using System.Text.RegularExpressions;
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
            hhmmssLabel.Content = "(hh:mm:ss)";
            

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
            errorLabel.Visibility = Visibility.Hidden;

        }

        private void unHideControls()
        {
            distanceTextbox.Visibility = Visibility.Visible;
            distanceLabel.Visibility = Visibility.Visible;
            timeLabel.Visibility = Visibility.Visible;
            timeTextbox.Visibility = Visibility.Visible;
            saveButton.Visibility = Visibility.Visible;
            hhmmssLabel.Visibility = Visibility.Visible;
            errorLabel.Visibility = Visibility.Visible;

        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            window.Show();
            this.Close();
        }


        private  void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            errorLabel.Visibility = Visibility.Hidden;
            Run run = new Run();
            if (isValid())
            {
                run.time =  TransformTime(timeTextbox.Text);
                
                run.distance = Convert.ToDouble(distanceTextbox.Text);
                //TODO: IMPLEMENT THE DATE THAT THE RUN WAS COMPLETED WITH A CALENDAR
                try
                {
                    Database.InsertNewRun(run);
                    errorLabel.Content = "Run added!";
                    errorLabel.Foreground= new SolidColorBrush(Colors.Green);
                    errorLabel.Visibility = Visibility.Visible;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace, ex.Message);
                }
               
            } 
        }
        private Time TransformTime(string time)
        {
            Time t = new Time();
            if (timeTextbox.Text.Length > 5)
            {
                t.hours = Convert.ToInt32(timeTextbox.Text.Substring(0, 2));
                t.minutes = Convert.ToInt32(timeTextbox.Text.Substring(3, 5));
                t.seconds = Convert.ToInt32(timeTextbox.Text.Substring(6));
                return t;
            }
            else
            {
                t.minutes = Convert.ToInt32(timeTextbox.Text.Substring(0, 2));
                t.seconds = Convert.ToInt32(timeTextbox.Text.Substring(3));
                return t;
            }
        }

        private void setError()
        {
            errorLabel.Visibility = Visibility.Visible;
            errorLabel.Foreground = new SolidColorBrush(Colors.Red);
        }
        private Boolean isValid()
        {
            if (distanceTextbox.Text == ""){
               errorLabel.Content = "Gelieve een afstand in te vullen!";
               setError();
                return false;
            }
            if (distanceTextbox.Text.Contains('.') )
            {
                MessageBox.Show("contains a dot");
                string distance = distanceTextbox.Text;
                distance.Replace('.', ',');

                distanceTextbox.Text = distance;
            }
            if (timeTextbox.Text.Length > 8){
                errorLabel.Content = "Gelieve een geldige tijd in te vullen!";
                setError();               
                return false;
            }
            if (timeTextbox.Text.Any(x => !char.IsLetter(x)))
            {
                if (!timeTextbox.Text.Contains(':'))
                {
                    errorLabel.Content = "Gelieve enkel cijfers en ':' in te geven bij de tijd.";
                    setError();
                    return false;
                }
                //errorLabel.Content = "Gelieve enkel cijfers en ':' in te geven bij de tijd.";
                //setError();
                //return false;
                
            }
            if (!distanceTextbox.Text.Any(x => char.IsLetter(x)))
            {
                
                errorLabel.Content = "Gelieve enkel cijfers en eventueel een komma in te geven bij de distance.";
                setError();
                return false;
            }
            //if (Regex.Matches(timeTextbox.Text, @"a-zA-Z").Count > 0 || Regex.Matches(distanceTextbox.Text, @"a-zA-Z").Count > 0)
            //{
            //    errorLabel.Content = "Gelieve enkel cijfers en ':' in  te geven.";
            //    setError();
            //    return false;
            //}
            if (!timeTextbox.Text.Contains(':')){
                errorLabel.Content = "Gelieve de tijd te scheiden met een dubbele punt (:)";
                setError();
                return false;
            }
            

            return true;

        }

        private void showStatsButton_Click(object sender, RoutedEventArgs e)
        {

        }





    }
}

