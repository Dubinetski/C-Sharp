﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VideoPlayer.Annotations;

namespace VideoPlayer.Entities {
	public class Media:INotifyPropertyChanged {
		public Media() {
		}

		public Media(string filePath) {
			MediaPath = filePath;
			Name = Path.GetFileName(new Uri(filePath).LocalPath);
		}
		public string MediaPath { get; set; }
		public string Name { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
