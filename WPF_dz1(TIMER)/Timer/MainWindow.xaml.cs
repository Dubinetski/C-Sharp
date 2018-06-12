using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;

namespace Timer {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		DispatcherTimer timerStopWatch;
		DispatcherTimer timerTimer;

		DateTime timeStart;
		TimeSpan totalSpan;
		TimeSpan circleSpan;
		DateTime circleStart;
		ObservableCollection<Tuple<string, string, string>> circlesInfo;

		TimeSpan timerTime;

		System.Windows.Forms.NotifyIcon ni;

		public MainWindow() {
			InitializeComponent();

			timerStopWatch = new DispatcherTimer();
			timerStopWatch.Tick += new EventHandler(timerStopWatch_Tick);
			timerStopWatch.Interval = TimeSpan.FromMilliseconds(10);

			circlesInfo = new ObservableCollection<Tuple<string, string, string>>();
			dgwCircles.ItemsSource = circlesInfo;

			timerTime = TimeSpan.Parse("00:00:00");
			timerTimer = new DispatcherTimer();
			timerTimer.Tick += new EventHandler(timerTimer_Tick);
			timerTimer.Interval = TimeSpan.FromSeconds(1);


			ni = new System.Windows.Forms.NotifyIcon();
			ni.Icon = new System.Drawing.Icon("Window.ico");
			ni.DoubleClick += new EventHandler(NotifyIcon_DoubleClick);
		}
		private void NotifyIcon_DoubleClick(object sender, EventArgs e) {
			this.Show();
			this.WindowState = WindowState.Normal;
			ni.Visible = false;
		}

		private void ButtonStart_Click(object sender, RoutedEventArgs e) {
			timeStart = DateTime.Now;
			circleStart = timeStart;
			timerStopWatch.Start();
			btnStopWatchStart.Visibility = Visibility.Collapsed;
			btnStopWatchPause.Visibility = Visibility.Visible;
			btnStopWatchCircle.Visibility = Visibility.Visible;
			statusBar.Items[0] = "Секундомер запущен";
		}
		private void ButtonPause_Click(object sender, RoutedEventArgs e) {
			timerStopWatch.Stop();
			btnStopWatchPause.Visibility = Visibility.Collapsed;
			btnStopWatchCircle.Visibility = Visibility.Collapsed;
			btnStopWatchContinue.Visibility = Visibility.Visible;
			btnStopWatchReset.Visibility = Visibility.Visible;
			statusBar.Items[0] = "Секундомер приостановлен";
		}
		private void ButtonContinue_Click(object sender, RoutedEventArgs e) {
			timeStart = DateTime.Now - totalSpan;
			circleStart = DateTime.Now - circleSpan;
			timerStopWatch.Start();
			btnStopWatchContinue.Visibility = Visibility.Collapsed;
			btnStopWatchReset.Visibility = Visibility.Collapsed;
			btnStopWatchPause.Visibility = Visibility.Visible;
			btnStopWatchCircle.Visibility = Visibility.Visible;
			statusBar.Items[0] = "Секундомер запущен";
		}
		private void ButtonThrow_Click(object sender, RoutedEventArgs e) {
			lbTime.Content = "00:00:00.00";
			btnStopWatchReset.Visibility = Visibility.Collapsed;
			btnStopWatchContinue.Visibility = Visibility.Collapsed;
			btnStopWatchStart.Visibility = Visibility.Visible;
			circlesInfo.Clear();
			statusBar.Items[0] = "Нажмите \"Старт\" для запуска";
		}
		private void ButtonCircle_Click(object sender, RoutedEventArgs e) {
			circlesInfo.Insert(0, new Tuple<string, string, string>((circlesInfo.Count + 1).ToString() + " круг", totalSpan.ToString(@"hh\:mm\:ss\:ff"), "+" + circleSpan.ToString(@"hh\:mm\:ss\:ff")));
			circleStart = DateTime.Now;
			statusBar.Items[0] = "Секундомер запущен (" + (circlesInfo.Count + 1).ToString() + " круг)";
		}

		private void timerStopWatch_Tick(object sender, EventArgs e) {
			totalSpan = DateTime.Now - timeStart;
			circleSpan = DateTime.Now - circleStart;
			lbTime.Content = totalSpan.ToString(@"hh\:mm\:ss\:ff");
		}
		private void timerTimer_Tick(object sender, EventArgs e) {
			timerTime -= TimeSpan.Parse("00:00:01");
			lbTimer.Content = timerTime.ToString(@"hh\:mm\:ss");
		}

		private void ToggleStopWatch_Checked(object sender, RoutedEventArgs e) {
			tabs.SelectedItem = tabs.Items[0];
		}
		private void ToggleTimer_Checked(object sender, RoutedEventArgs e) {
			tabs.SelectedItem = tabs.Items[1];
		}
		private void ToggleAlarm_Checked(object sender, RoutedEventArgs e) {
			tabs.SelectedItem = tabs.Items[2];
		}

		private void ButtonTimerTimeAdd_Click(object sender, RoutedEventArgs e) {
			timerTime += TimeSpan.Parse(((Button)sender).Tag.ToString());
			lbTimer.Content = timerTime.ToString();
		}

		private void ButtonTimerTimeDeduct_MouseRightButtonDown(object sender, MouseButtonEventArgs e) {
			timerTime -= TimeSpan.Parse(((Button)sender).Tag.ToString());
			timerTime = timerTime > TimeSpan.Parse("0") ? timerTime : TimeSpan.Parse("0");
			lbTimer.Content = timerTime.ToString();
		}

		private void ButtonStartTimer_Click(object sender, RoutedEventArgs e) {
			timerTimer.Start();
			btnTimerStart.Visibility = Visibility.Collapsed;
			btnTimerPause.Visibility = Visibility.Visible;
			statusBar.Items[0] = "Таймер запущен";
		}
		private void ButtonPauseTimer_Click(object sender, RoutedEventArgs e) {
			timerTimer.Stop();
			btnTimerPause.Visibility = Visibility.Collapsed;
			btnTimerContinue.Visibility = Visibility.Visible;
			btnTimerReset.Visibility = Visibility.Visible;
			statusBar.Items[0] = "Таймер приостановлен";
		}
		private void ButtonContinueTimer_Click(object sender, RoutedEventArgs e) {
			timerTimer.Start();
			btnTimerContinue.Visibility = Visibility.Collapsed;
			btnTimerReset.Visibility = Visibility.Collapsed;
			btnTimerPause.Visibility = Visibility.Visible;
			statusBar.Items[0] = "Таймер запущен";
		}
		private void ButtonResetTimer_Click(object sender, RoutedEventArgs e) {
			timerTime = TimeSpan.Parse("0");
			lbTimer.Content = timerTime.ToString();
			btnTimerReset.Visibility = Visibility.Collapsed;
			btnTimerContinue.Visibility = Visibility.Collapsed;
			btnTimerStart.Visibility = Visibility.Visible;
			statusBar.Items[0] = "Таймер сброшен. Установите время и нажмите \"Старт\" для запуска";
		}

		private void Close_Click(object sender, RoutedEventArgs e) {
			this.Close();
		}
		protected override void OnStateChanged(EventArgs e) {
			if (WindowState == WindowState.Minimized)
				this.Hide();
			ni.Visible = true;
			base.OnStateChanged(e);
		}
	}
}
