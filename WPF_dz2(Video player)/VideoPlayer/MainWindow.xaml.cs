using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using VideoPlayer.Entities;
using VideoPlayer.Repository;

namespace VideoPlayer {
	public partial class MainWindow {
		private DispatcherTimer timerVideoTime;
		private Rect normSize;
		private double currentVolume;
		private int selIndex;

		private MediaRepositori repositori;

		public MainWindow() {
			InitializeComponent();
			repositori = new MediaRepositori();
			dgFileList.ItemsSource = repositori.Medies;
			normSize = new Rect(Left, Top, Width, Height);
			currentVolume = 100;
			sbarVolume.Value = currentVolume;
		}
		// Play
		private void play_Click(object sender, RoutedEventArgs e) {
			if (media_scren.Source == null && dgFileList.SelectedIndex >= 0) {
				media_scren.Source = new Uri(((Media)dgFileList.SelectedItem).MediaPath);
			}
			if (media_scren.Source != null) {
				media_scren.Play();
				btnPlay.Visibility = Visibility.Collapsed;
				btnPause.Visibility = Visibility.Visible;
				timerVideoTime.Start();
			}
		}
		// Stop
		private void stop_Click(object sender, RoutedEventArgs e) {
			media_scren.Stop();
			sbarPosition.Value = 0;
			btnPlay.Visibility = Visibility.Visible;
			btnPause.Visibility = Visibility.Collapsed;
			timerVideoTime.Stop();
		}
		//Pause
		private void pause_Click(object sender, RoutedEventArgs e) {
			media_scren.Pause();
			btnPlay.Visibility = Visibility.Visible;
			btnPause.Visibility = Visibility.Collapsed;
			timerVideoTime.Stop();
		}
		//File open
		private void btnFileOpen_Click(object sender, RoutedEventArgs e) {
			dgFileList.SelectedIndex = AddFilesAndGetIndexOfFirst();
			if (dgFileList.SelectedIndex >= 0) {
				media_scren.Source = new Uri(((Media)dgFileList.SelectedItem).MediaPath);
				play_Click(sender, e);
			}
		}
		// Открыть плейлист
		private void ChFileListOpen_OnChecked(object sender, RoutedEventArgs e) {
			Grid.SetColumnSpan(bMedia, 1);
			grSplit.Visibility = Visibility.Visible;
			dpList.Visibility = Visibility.Visible;
		}
		// Спрятать плейлист
		private void ChFileListOpen_OnUnchecked(object sender, RoutedEventArgs e) {
			Grid.SetColumnSpan(bMedia, 3);
			grSplit.Visibility = Visibility.Collapsed;
			dpList.Visibility = Visibility.Collapsed;
		}
		// Добавление новой строки в плейлист (нумерация)
		private void dgFileList_LoadingRow(object sender, DataGridRowEventArgs e) {
			e.Row.Header = e.Row.GetIndex() + 1;
		}
		// Добавление новых файлов в плейлист
		private void BtnAdd_OnClick(object sender, RoutedEventArgs e) {
			AddFilesAndGetIndexOfFirst();
			if (dgFileList.Items.Count > 0 && dgFileList.SelectedIndex == -1) {
				dgFileList.SelectedIndex = 0;
			}
		}
		/// <summary>
		/// Добавление новых файлов в репозиторий
		/// </summary>
		/// <returns>Индекс первого добавленного файла</returns>
		private int AddFilesAndGetIndexOfFirst() {
			OpenFileDialog dlg = new OpenFileDialog {
				FileName = "Media file",
				Filter = "Video file (.avi;.wmv;.mpg;.mpeg;.mp4;.3gp)|*.avi;*.wmv;*.mpg;*.mpeg;*.mp4;*.3gp",
				Multiselect = true
			};
			bool? result = dlg.ShowDialog();
			if (result == true) {
				foreach (var fileName in dlg.FileNames) {
					repositori.Add(new Media(fileName));
				}
			}
			return repositori.GetItemIndex(dlg.FileNames[0]);
		}
		// Удаление фильма с плейлиста
		private void BtnRem_OnClick(object sender, RoutedEventArgs e) {
			if (dgFileList.SelectedIndex >= 0) {
				selIndex = dgFileList.SelectedIndex;
				repositori.Medies.RemoveAt(dgFileList.SelectedIndex);
				dgFileList.ItemsSource = null;
				dgFileList.ItemsSource = repositori.Medies;
				dgFileList.SelectedIndex = selIndex;
			}
		}
		// Запуск файла в плейлисте по двойному щелчку мыши
		private void DgFileList_OnMouseDoubleClick(object sender, MouseButtonEventArgs e) {
			media_scren.Source = new Uri(((Media)dgFileList.SelectedItem).MediaPath);
			play_Click(sender, e);
		}
		// Действие по окончанию файла - переход на следующий файл
		private void media_scren_MediaEnded(object sender, RoutedEventArgs e) {
			sbarPosition.Value = 0;
			if (dgFileList.SelectedIndex >= 0) {
				if (dgFileList.SelectedIndex < dgFileList.Items.Count - 1) {
					dgFileList.SelectedIndex += 1;
				} else {
					dgFileList.SelectedIndex = 0;
				}
				media_scren.Source = new Uri(((Media)dgFileList.SelectedItem).MediaPath);
			} else {
				media_scren.Stop();
			}
		}
		// Поднять выделенный элемент в плейлисте вверх
		private void BtnUp_OnClick(object sender, RoutedEventArgs e) {
			selIndex = dgFileList.SelectedIndex;
			if (selIndex > 0) {
				Media tmpMedia = repositori.Medies[selIndex - 1];
				repositori.Medies[selIndex - 1] = repositori.Medies[selIndex];
				repositori.Medies[selIndex] = tmpMedia;
				dgFileList.SelectedIndex = selIndex - 1;
			}
		}
		// Опустить выделенный элемент в плейлисте вниз
		private void BtnDown_OnClick(object sender, RoutedEventArgs e) {
			selIndex = dgFileList.SelectedIndex;
			if (selIndex < dgFileList.Items.Count - 1 && selIndex >= 0) {
				Media tmpMedia = repositori.Medies[selIndex + 1];
				repositori.Medies[selIndex + 1] = repositori.Medies[selIndex];
				repositori.Medies[selIndex] = tmpMedia;
				dgFileList.SelectedIndex = selIndex + 1;
			}
		}
		// Запустить предыдущий файл
		private void BtnPrevFile_OnClick(object sender, RoutedEventArgs e) {
			selIndex = dgFileList.SelectedIndex;
			if (selIndex > 0) {
				dgFileList.SelectedIndex -= 1;
			} else {
				dgFileList.SelectedIndex = dgFileList.Items.Count - 1;
			}

			if (dgFileList.SelectedIndex >= 0) {
				media_scren.Source = new Uri(((Media)dgFileList.SelectedItem).MediaPath);
			}
		}
		// Запустить следующий файл 
		private void BtnNextFile_OnClick(object sender, RoutedEventArgs e) {
			selIndex = dgFileList.SelectedIndex;
			if (selIndex >= 0) {
				sbarPosition.Value = 0;
				if (selIndex < dgFileList.Items.Count - 1) {
					dgFileList.SelectedIndex += 1;
				} else {
					dgFileList.SelectedIndex = 0;
				}
				media_scren.Source = new Uri(((Media)dgFileList.SelectedItem).MediaPath);
			}
		}
		// Действия после загрузки файла в медиа-элемент
		private void Media_scren_OnMediaOpened(object sender, RoutedEventArgs e) {
			sbarPosition.Maximum = media_scren.NaturalDuration.TimeSpan.TotalSeconds;
			tbDutation.Text = media_scren.NaturalDuration.TimeSpan.ToString(@"hh\:mm\:ss");
			media_scren.Volume = sbarVolume.Value;
		}
		private void MainWindow_OnLoaded(object sender, RoutedEventArgs e) {
			timerVideoTime = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
			timerVideoTime.Tick += timer_Tick;
		}
		private void timer_Tick(object sender, EventArgs e) {
			sbarPosition.Value = media_scren.Position.TotalSeconds;
			tbPosition.Text = media_scren.Position.ToString(@"hh\:mm\:ss");
		}
		// Закрытие окна
		private void BtnClose_OnClick(object sender, RoutedEventArgs e) {
			Close();
		}
		// Развернуть окно
		private void BtnMaximize_OnClick(object sender, RoutedEventArgs e) {
			btnMaximize.Visibility = Visibility.Collapsed;
			btnRestoreDown.Visibility = Visibility.Visible;

			normSize.Y = Top;
			normSize.X = Left;
			normSize.Width = Width;
			normSize.Height = Height;

			Rect rect = SystemParameters.WorkArea;
			this.Width = rect.Width;
			this.Height = rect.Height;
			this.Top = rect.Top;
			this.Left = rect.Left;
		}
		// Восстановить окно до нормального	размера
		private void BtnRestoreDown_OnClick(object sender, RoutedEventArgs e) {
			this.Width = normSize.Width;
			this.Height = normSize.Height;
			this.Top = normSize.Y;
			this.Left = normSize.X;

			btnMaximize.Visibility = Visibility.Visible;
			btnRestoreDown.Visibility = Visibility.Collapsed;
		}
		// Свернуть окно
		private void BtnMinimize_OnClick(object sender, RoutedEventArgs e) {
			this.WindowState = WindowState.Minimized;
		}
		// Убрать статус "поверх всех окон"
		private void BtnUnPined_OnClick(object sender, RoutedEventArgs e) {
			this.Topmost = true;
			btnUnPined.Visibility = Visibility.Collapsed;
			btnPined.Visibility = Visibility.Visible;
		}
		// Установить поверх всех окон
		private void BtnPined_OnClick(object sender, RoutedEventArgs e) {
			this.Topmost = false;
			btnUnPined.Visibility = Visibility.Visible;
			btnPined.Visibility = Visibility.Collapsed;
		}
		// Развернуть на весь экран
		private void BtnFullScreen_OnClick(object sender, RoutedEventArgs e) {
			this.WindowState = WindowState.Maximized;
			btnFullScreen.Visibility = Visibility.Collapsed;
			btnNoFullScreen.Visibility = Visibility.Visible;
			btnMaximize.Visibility = Visibility.Collapsed;
		}
		// Восстановить нормальный размер окна
		private void BtnNoFullScreen_OnClick(object sender, RoutedEventArgs e) {
			this.WindowState = WindowState.Normal;
			btnFullScreen.Visibility = Visibility.Visible;
			btnNoFullScreen.Visibility = Visibility.Collapsed;
		}
		// Перетаскивание окна за заголовок
		private void Title_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
			this.DragMove();
		}
		// Изменение значения громкости
		private void SbarVolume_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
			if (media_scren != null) {
				media_scren.Volume = sbarVolume.Value;
			}
		}
		// Изменение позиции в проигрываемом файле
		private void SbarPosition_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
			media_scren.Position = TimeSpan.FromSeconds(sbarPosition.Value);
			tbPosition.Text = media_scren.Position.ToString(@"hh\:mm\:ss");
		}
		// Выключить/включить звук
		private void LbVolume_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
			if (sbarVolume.Value == 0) {
				sbarVolume.Value = currentVolume;
			} else {
				currentVolume = sbarVolume.Value;
				sbarVolume.Value = 0;
			}
		}
		// Очистка плейлиста
		private void BtnClear_OnClick(object sender, RoutedEventArgs e) {
			repositori.Medies.Clear();
		}
		// Действия при ошибке кодека
		private void Media_scren_OnMediaFailed(object sender, ExceptionRoutedEventArgs e) {
			media_scren.Stop();
		}
	}
}
