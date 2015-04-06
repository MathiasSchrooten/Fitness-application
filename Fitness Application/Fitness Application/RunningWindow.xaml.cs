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


        private  void Button_Click(object sender, RoutedEventArgs e)
        {
            // //Data_connection dbobject = new Data_connection();
            // SQLiteConnection sqlConnection;
            // SQLiteCommand sqlCommand;
            string createTableQuery = @"CREATE TABLE IF NOT EXISTS [RunningTable](
                            [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            [Time] NVARCHAR(20) NULL, [Distance] REAL NULL)";

            SQLiteConnection.CreateFile("FitnessApplication.sqlite");
            SQLiteConnection connection = new SQLiteConnection("data source=FitnessApplication.sqlite");

            SQLiteCommand command = new SQLiteCommand(connection);
            connection.Open();
            command.CommandText = createTableQuery;
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO RunningTable (Time, Distance) Values ('22:14', 5.22)";
            command.ExecuteNonQuery();
            command.CommandText = "Select * FROM RunningTable";
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["Time"] + ", distance: " + reader["Distance"]);
                }
            }
            connection.Close();

        }



    }
}

