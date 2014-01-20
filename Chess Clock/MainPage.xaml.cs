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
        private int activePlayer = 1;
        private bool firstTime = true;
        Player player1;
        Player player2;
        Player player3;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            player1 = new Player();
            player2 = new Player();
            player3 = new Player();
            InitiateTimePicker();
            InitiateClock();
        }

        private void InitiateClock()
        {
            player1.timer.Tick += time_Tick;
            player2.timer.Tick += time_Tick;
            player3.timer.Tick += time_Tick;
            ShowTimesForPlayers();
        }

        private void InitiateTimePicker()
        {
            var listWithTimes = PopulateListWithNumbers();
            listPickerChooseTime.ItemsSource = listWithTimes;
        }

        private List<int> PopulateListWithNumbers()
        {
            var listWithTimes = new List<int>() { 5, 10, 15, 20, 30, 45, 60 };
            return listWithTimes;
        }

        void time_Tick(object sender, object e)
        {
            if (ButtonDone.Content.Equals("Done"))
            {
                if (activePlayer == 1)
                {
                    textBlockTimerPlayer1.Text = ConvertSecondsToMinutesAndSeconds((player1.StopTime - player1.LastTime));
                    player1.LastTime++;

                    if (player1.LastTime > player1.StopTime)
                    {
                        player1.timer.Stop();
                        ShowWinnerPopup(1);
                    }
                }
                if (activePlayer == 2)
                {
                    textBlockTimerPlayer2.Text = ConvertSecondsToMinutesAndSeconds((player2.StopTime - player2.LastTime));
                    player2.LastTime++;

                    if (player2.LastTime > player2.StopTime)
                    {
                        player2.timer.Stop();
                        ShowWinnerPopup(2);
                    }
                }
                if (activePlayer == 3)
                {
                    textBlockTimerPlayer3.Text = ConvertSecondsToMinutesAndSeconds((player3.StopTime - player3.LastTime));
                    player3.LastTime++;

                    if (player3.LastTime > player3.StopTime)
                    {
                        player3.timer.Stop();
                        ShowWinnerPopup(3);
                    }
                }
            }
        }
        private void ShowWinnerPopup(int losingPlayer)
        {
            ShowTimesForPlayers();
            ButtonDone.Content = "Start";
            switch (losingPlayer)
            {
                case 1: MessageBox.Show("Player 1 lost!");
                    listPickerChooseTime.IsEnabled = true;
                    ResetPlayerHelpSettings();
                    break;
                case 2: MessageBox.Show("Player 2 lost!");
                    listPickerChooseTime.IsEnabled = true;
                    ResetPlayerHelpSettings();
                    break;
                case 3: MessageBox.Show("Player 3 lost!");
                    listPickerChooseTime.IsEnabled = true;
                    ResetPlayerHelpSettings();
                    break;
                default:
                    break;
            }
        }

        private void ResetPlayerHelpSettings()
        {
            firstTime = true;
            activePlayer = 1;
        }

        private void ButtonDone_Click(object sender, RoutedEventArgs e)
        {
            listPickerChooseTime.IsEnabled = false;
            if (activePlayer == 1)
            {
                player3.timer.Stop();
                player1.timer.Start();
                if (!firstTime)
                    activePlayer++;
                firstTime = false;
            }
            else if (activePlayer == 2)
            {
                player1.timer.Stop();
                player2.timer.Start();
                activePlayer++;
            }
            else if (activePlayer == 3)
            {
                player2.timer.Stop();
                player3.timer.Start();
                activePlayer = 1;
            }
            ButtonDone.Content = "Done";
        }
        private void listPickerChooseTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            player1.StopTime = Int16.Parse(listPickerChooseTime.SelectedItem.ToString())*60;
            player2.StopTime = Int16.Parse(listPickerChooseTime.SelectedItem.ToString())*60;
            player3.StopTime = Int16.Parse(listPickerChooseTime.SelectedItem.ToString())*60;
            ShowTimesForPlayers();
        }

        private void ShowTimesForPlayers()
        {
            player1.LastTime = player1.StartTime;
            player2.LastTime = player2.StartTime;
            player3.LastTime = player3.StartTime;
            textBlockTimerPlayer1.Text = ConvertSecondsToMinutesAndSeconds((player1.StopTime - player1.LastTime));
            textBlockTimerPlayer2.Text = ConvertSecondsToMinutesAndSeconds((player2.StopTime - player2.LastTime));
            textBlockTimerPlayer3.Text = ConvertSecondsToMinutesAndSeconds((player3.StopTime - player3.LastTime));
        }

        private string ConvertSecondsToMinutesAndSeconds(int seconds)
        {
            var minutesLeft = seconds / 60;
            var secondsLeft = seconds % 60;
   
            return string.Format("{0}m, {1}s", minutesLeft, secondsLeft);
        }
    }
}