using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayer.Entities;

namespace VideoPlayer.Repository {
	public class MediaRepositori {
		private ObservableCollection<Media> medies;

		public ObservableCollection<Media> Medies {
			get { return medies ?? (medies = new ObservableCollection<Media>()); }
		}
		public void Add(Media newMedia) {
			foreach (var media in Medies)
				if (media.MediaPath == newMedia.MediaPath)
					return;
			medies.Add(newMedia);
		}

		public int GetItemIndex(string mediaPath) {
			for (int i = 0; i < medies.Count; i++) {
				if (medies[i].MediaPath == mediaPath) {
					return i;
				}
			}
			return -1;
		}
	}
}