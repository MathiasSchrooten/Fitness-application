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
//            // //Data_connection dbobject = new Data_connection();
//            // SQLiteConnection sqlConnection;
//            // SQLiteCommand sqlCommand;
//            string createTableQuery = @"CREATE TABLE IF NOT EXISTS [RunningTable](
//                            [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
//                            [Time] NVARCHAR(20) NULL, [Distance] REAL NULL)";

//            //SQLiteConnection.CreateFile("FitnessApplication.sqlite");
//            SQLiteConnection connection = new SQLiteConnection("data source=FitnessApplication.sqlite");

//            SQLiteCommand command = new SQLiteCommand(connection);
//            connection.Open();
//            //command.CommandText = createTableQuery;
//            //command.ExecuteNonQuery();
//            //command.CommandText = "INSERT INTO RunningTable (Time, Distance) Values ('22:14', 5.22)";
//            //command.ExecuteNonQuery();
//            command.CommandText = "Select * FROM RunningTable";
//            using (SQLiteDataReader reader = command.ExecuteReader())
//            {
//                while (reader.Read())
//                {
//                    Console.WriteLine(reader["Time"] + ", distance: " + reader["Distance"]);
//                }
//            }
//            connection.Close();

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
        private Boolean isValid()
        {
            if (distanceTextbox.Text == ""){
               errorLabel.Content = "Gelieve een afstand in te vullen!";
                errorLabel.Visibility = Visibility.Visible;
                return false;
            }
            if (distanceTextbox.Text.Contains(',') || distanceTextbox.Text.Contains('.'))
            {
                distanceTextbox.Text.Replace('.', ':');
                distanceTextbox.Text.Replace(',', ':');
            }
            if (timeTextbox.Text.Length > 8){
                errorLabel.Content = "Gelieve een geldige tijd in te vullen!";
                 errorLabel.Visibility = Visibility.Visible;
                return false;
            }
            if (!timeTextbox.Text.Contains(':')){
                errorLabel.Content = "Gelieve de tijd te scheiden met een dubbele punt (:)";
                errorLabel.Visibility = Visibility.Visible;
                return false;
            }
            if (Regex.Matches(timeTextbox.Text, @"a-zA-Z").Count > 0)
            {
                errorLabel.Content = "Gelieve enkel cijfers en ':' in  te geven in de tijd.";
                errorLabel.Visibility = Visibility.Visible;
                return false;
            }

            return true;

        }





    }
}

