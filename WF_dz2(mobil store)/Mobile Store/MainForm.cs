using Mobile_Store.Model.Entities;
using Mobile_Store.Model.Repositories;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mobile_Store {
	public partial class MainForm : Form {
		public MainForm() {
			InitializeComponent();
		}
		PhoneInfo selPhone;
		private void MainForm_Load(object sender, EventArgs e) {
			PhoneRepository.Load();
			chlstEditOptions.DataSource = PhoneRepository.Store.GetAllOptions();
			lstPhoneList.DataSource = PhoneRepository.Store.GetPhones();
			try { picPhoto.ErrorImage = Image.FromFile(@".\Image\default_phone.jpg"); } catch (Exception) { }
		}
		private void AddNewPhone_Click(object sender, EventArgs e) {
			PhoneInfo phone = new PhoneInfo();
			GetPhoneFilds(phone);
			PhoneRepository.Store.AddPhone(phone);
		}

		private void GetPhoneFilds(PhoneInfo phone) {
			if (phone != null) {
				phone.Manufacturer = tbEditManufacturer.Text;
				phone.Model = tbEditModel.Text;
				phone.System = tbEditSystem.Text;
				phone.Photo = tbEditPhoto.Text;
				decimal tmp;
				if (Decimal.TryParse(tbEditScreen.Text, out tmp))
					phone.Screen = tmp;
				if (Decimal.TryParse(tbEditMemory.Text, out tmp))
					phone.Memory = tmp;
				if (Decimal.TryParse(tbPrice.Text, out tmp))
					phone.Price = tmp;
			}
		}
		private void btnDelPhone_Click(object sender, EventArgs e) {
			if (selPhone != null)
				PhoneRepository.Store.DeletePhone(selPhone);
		}
		private void btnSaveChanges_Click(object sender, EventArgs e) {
			if (selPhone != null) {
				GetPhoneFilds(selPhone);
				selPhone.OptionsId.Clear();
				foreach (Option option in chlstEditOptions.CheckedItems) {
					selPhone.OptionsId.Add(option.Id);
				}
				lstOptions.DataSource = PhoneRepository.Store.GetPhoneOptions(selPhone);
				lstPhoneList.DataSource = null;
				lstPhoneList.DataSource = PhoneRepository.Store.GetPhones();
			}
		}

		private void lstPhoneList_SelectedIndexChanged(object sender, EventArgs e) {
			selPhone = lstPhoneList.SelectedItem as PhoneInfo;
			if (selPhone != null) {
				tbManufacturer.Text = selPhone.Manufacturer;
				tbModel.Text = selPhone.Model;
				tbOc.Text = selPhone.System;
				tbMemory.Text = selPhone.Memory.ToString();
				tbScreen.Text = selPhone.Screen.ToString();
				tbPrice.Text = selPhone.Price.ToString();
				try {
					picPhoto.Image = Image.FromFile(selPhone.Photo);
				} catch (Exception) {
					picPhoto.Image = picPhoto.ErrorImage;
				}
				tbEditManufacturer.Text = selPhone.Manufacturer;
				tbEditModel.Text = selPhone.Model;
				tbEditSystem.Text = selPhone.System;
				tbEditMemory.Text = selPhone.Memory.ToString();
				tbEditScreen.Text = selPhone.Screen.ToString();
				tbEditPrice.Text = selPhone.Price.ToString();
				tbEditPhoto.Text = selPhone.Photo;

				CheckedOptions(selPhone);
			}
		}

		private void CheckedOptions(PhoneInfo selPhone) {
			lstOptions.DataSource = PhoneRepository.Store.GetPhoneOptions(selPhone);
			for (int i = 0; i < chlstEditOptions.Items.Count; i++) {
				chlstEditOptions.SetItemChecked(i, false);
				for (int j = 0; j < selPhone.OptionsId.Count; j++) {
					if ((chlstEditOptions.Items[i] as Option).Id == selPhone.OptionsId[j]) {
						chlstEditOptions.SetItemChecked(i, true);
						break;
					}
				}
			}
		}

		private void btnSavePhoneList_Click(object sender, EventArgs e) {
			PhoneRepository.Save();
		}

		private void btnLoadPhoneList_Click(object sender, EventArgs e) {
			PhoneRepository.Load();
			chlstEditOptions.DataSource = PhoneRepository.Store.GetAllOptions();
			lstPhoneList.DataSource = PhoneRepository.Store.GetPhones();
		}

		private void btnClearPhoneList_Click(object sender, EventArgs e) {
			lstPhoneList.DataSource = null;
		}
		private void btnClearPhoneFilds_Click(object sender, EventArgs e) {
			tbEditManufacturer.Text = null;
			tbEditModel.Text = null;
			tbEditSystem.Text = null;
			tbEditMemory.Text = null;
			tbEditScreen.Text = null;
			tbEditPrice.Text = null;
			tbEditPhoto.Text = null;
		}
		private void btnAddOption_Click(object sender, EventArgs e) {
			if (tbOption.Text != "") {
				PhoneRepository.Store.AddOption(tbOption.Text);
				CheckedOptions(selPhone);
			}
		}

		private void btnDelOption_Click(object sender, EventArgs e) {
			Option selOption = chlstEditOptions.SelectedItem as Option;
			if (selOption != null)
				PhoneRepository.Store.DeleteOption(selOption);
		}

		private void btbFind_Click(object sender, EventArgs e) {
			OpenFileDialog openFile = new OpenFileDialog();
			openFile.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
			openFile.Filter = "image files (*.jpg)|*.jpg|All files (*.*)|*.*";
			if (openFile.ShowDialog() == DialogResult.OK)
				tbEditPhoto.Text = openFile.FileName;
		}
	}
}
