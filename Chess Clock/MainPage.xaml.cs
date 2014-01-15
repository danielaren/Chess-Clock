using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Threading;
using System.Windows.Controls.Primitives;

namespace Chess_Clock
{
    public partial class MainPage : PhoneApplicationPage
    {
        private bool firstPlayer = false;
        Player player1;
        Player player2;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            player1 = new Player();
            player2 = new Player();
            InitiateTimePicker();
            InitiateClock();
        }

        private void InitiateClock()
        {
            player1.timer.Tick += time_Tick;
            player2.timer.Tick += time_Tick;
            ShowTimesForPlayers();
        }

        private void InitiateTimePicker()
        {
            var listWithTimes = PopulateListWithNumbers(30);
            listPickerChooseTime.ItemsSource = listWithTimes;
        }

        private List<int> PopulateListWithNumbers(int numbers)
        {
            var listWithTimes = new List<int>();
            for (int i = 1; i < numbers; i++)
            {
                listWithTimes.Add(i);
            }
            return listWithTimes;
        }

        void time_Tick(object sender, object e)
        {
            if (firstPlayer)
            {
                textBlockTimerPlayer1.Text = (player1.StopTime - player1.LastTime).ToString();
                player1.LastTime++;

                if (player1.LastTime > player1.StopTime)
                {
                    player1.timer.Stop();
                    ShowWinnerPopup(false);
                }
            }
            else
            {
                textBlockTimerPlayer2.Text = (player2.StopTime - player2.LastTime).ToString();
                player2.LastTime++;

                if (player2.LastTime > player2.StopTime)
                {
                    player2.timer.Stop();
                    ShowWinnerPopup(true);
                }
            }
        }

        private void ShowWinnerPopup(bool firstPlayer)
        {
            ShowTimesForPlayers();
            ButtonDone.Content = "Start";
            switch (firstPlayer)
            {
                case true: MessageBox.Show("Winner is player 1");
                    break;
                case false: MessageBox.Show("Winner is player 2");
                    break;
                default:
                    break;
            }
        }

        private void ButtonDone_Click(object sender, RoutedEventArgs e)
        {
            if (firstPlayer)
            {
                player1.timer.Stop();
                player2.timer.Start();
                firstPlayer = false;
            }
            else
            {
                player2.timer.Stop();
                player1.timer.Start();
                firstPlayer = true;
                ButtonDone.Content = "Done";
            }
        }

        private void listPickerChooseTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            player1.StopTime = Int16.Parse(listPickerChooseTime.SelectedItem.ToString());
            player2.StopTime = Int16.Parse(listPickerChooseTime.SelectedItem.ToString());
            ShowTimesForPlayers();
        }

        private void ShowTimesForPlayers()
        {
            player1.LastTime = player1.StartTime;
            player1.LastTime = player2.StartTime;
            textBlockTimerPlayer1.Text = (player1.StopTime - player1.LastTime).ToString();
            textBlockTimerPlayer2.Text = (player1.StopTime - player2.LastTime).ToString();
        }
    }
}