﻿/*
MIT License

Copyright (c) Léo Corporation

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE. 
*/
using Gavilya.Classes;
using Gavilya.Enums;
using Gavilya.UserControls;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Gavilya.Windows
{
	/// <summary>
	/// Interaction logic for ProfilesPopupMneu.xaml
	/// </summary>
	public partial class ProfilesPopupMenu : Window
	{
		Profile CurrentProfile { get; init; }
		public ProfilesPopupMenu()
		{
			InitializeComponent();
			CurrentProfile = Definitions.Profiles[0]; //TODO: Get latest used profile

			InitUI(); // Load the UI
		}

		internal void InitUI()
		{
			ProfileDisplayer.Children.Clear(); // Clear all profile items

			if (CurrentProfile.PictureFilePath != "_default")
			{
				if (File.Exists(CurrentProfile.PictureFilePath))
				{
					var bitmap = new BitmapImage();
					var stream = File.OpenRead(CurrentProfile.PictureFilePath);

					bitmap.BeginInit();
					bitmap.CacheOption = BitmapCacheOption.OnLoad;
					bitmap.StreamSource = stream;
					bitmap.EndInit();
					stream.Close();
					stream.Dispose();
					bitmap.Freeze();

					ProfilePicture.ImageSource = bitmap; // Set image
				}
			}

			ProfileNameTxt.Text = CurrentProfile.Name; // Show name

			// Load the profile displayer
			for (int i = 0; i < Definitions.Profiles.Count; i++)
			{
				ProfileDisplayer.Children.Add(new ProfileItem(Definitions.Profiles[i])); // Add profile
			}
		}

		private void Window_Deactivated(object sender, EventArgs e)
		{
			if (Definitions.IsProfileMenuVisible)
			{
				Hide(); // Close
				Definitions.IsProfileMenuVisible = false; // Define
			}
		}

		private void AddProfileBtn_Click(object sender, RoutedEventArgs e)
		{
			new AddEditProfileWindow(EditMode.Add).Show(); // Add
		}

		private void EditProfileBtn_Click(object sender, RoutedEventArgs e)
		{
			new AddEditProfileWindow(EditMode.Edit, CurrentProfile).Show(); // Edit
		}
	}
}
