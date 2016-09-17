using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TimeManagement.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TimeManagement
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private TimedProject timeProject = new TimedProject();

        public MainPage()
        {
            this.InitializeComponent();

            NewSession();

            ListView.ItemsSource = timeProject.Sessions;
        }

        private void AddNewTimedSession(object sender, RoutedEventArgs e)
        {
            NewSession();
        }

        private void NewSession()
        {
            TimeProject.Sessions.Add(new TimedSession());

            txtDisplay.Text = TimeProject.TotalTime;
        }

        public TimedProject TimeProject
        {
            get
            {
                if (timeProject == null)
                {
                    timeProject = new TimedProject();
                }
                return timeProject;
            }
            set
            {
                timeProject = value;
            }
        }

        private void TimeChanged(object sender, TimePickerValueChangedEventArgs e)
        {
            txtDisplay.Text = TimeProject.TotalTime;
        }

        private void ClearSessions(object sender, RoutedEventArgs e)
        {
            TimeProject.Sessions.Clear();

            TimeProject.Sessions.Add(new TimedSession());
        }
    }
}
