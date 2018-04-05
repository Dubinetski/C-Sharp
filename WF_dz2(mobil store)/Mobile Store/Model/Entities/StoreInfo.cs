using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Mobile_Store.Model.Entities {
	[Serializable]
	class StoreInfo {
		private BindingList<PhoneInfo> phones;
		private BindingList<Option> options;
		private int phoneLastId;
		private int optionLastId;

		public int PhoneLastId { get => phoneLastId; private set => phoneLastId = value; }
		public int OptionLastId { get => optionLastId; private set => optionLastId = value; }

		public StoreInfo() {
			phones = new BindingList<PhoneInfo>();
			options = new BindingList<Option>();
		}

		public IReadOnlyList<PhoneInfo> GetPhones() {
			return phones;
		}

		public IReadOnlyList<Option> GetAllOptions() {
			return options;
		}
		public IReadOnlyList<Option> GetPhoneOptions(PhoneInfo phone) {
			BindingList<Option> phoneOptions = new BindingList<Option>();
			for (int i = 0; i < phone.OptionsId.Count; i++) {
				for (int j = 0; j < options.Count; j++) {
					if (phone.OptionsId[i] == options[j].Id) {
						phoneOptions.Add(options[j]);
						break;
					}
				}
			}
			return phoneOptions;
		}
		public void AddPhone(PhoneInfo phone) {
			phone.Id = ++PhoneLastId;
			phones.Add(phone);
		}
		public void DeletePhone(PhoneInfo phone) {
			phones.Remove(phone);
		}
		public void AddOption(string option) {
			for (int i = 0; i < options.Count; i++)
				if (options[i].Name == option)
					return;
			options.Add(new Option(++OptionLastId, option));
		}
		public void DeleteOption(Option option) {
			options.Remove(option);
		}
	}
}
