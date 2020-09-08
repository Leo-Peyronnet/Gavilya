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
using Gavilya.UserControls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
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
    /// Logique d'interaction pour EditGame.xaml
    /// </summary>
    public partial class EditGame : Window
    {
        string fileLocation, iconLocation; // File (icon) location
        GameCard GameCard; // The game card
        /// <summary>
        /// Window where the user can edit a game
        /// </summary>
        public EditGame(GameCard gameCard)
        {
            InitializeComponent();
            GameCard = gameCard; // Pass the arg
            LoadInfos(GameCard.GameInfo); // Load the window
        }

        private void LoadInfos(GameInfo gameInfo)
        {
            nameTxt.Text = gameInfo.Name; // Name
            versionTxt.Text = gameInfo.Version; // Version
            locationTxt.Text = gameInfo.FileLocation; // File Location

            fileLocation = gameInfo.FileLocation; // File Location
            iconLocation = gameInfo.IconFileLocation; // Icon

            if (gameInfo.IconFileLocation != string.Empty) // If a custom image is used
            {
                GameImg.Source = new BitmapImage(new Uri(gameInfo.IconFileLocation)); // Show the image
            }
            else
            {
                Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(gameInfo.FileLocation); // Grab the icon of the game
                GameImg.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()); // Show the image
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            GameInfo oldGameInfo = GameCard.GameInfo; // Old game info
            GameCard.GameInfo = new GameInfo // Create a game info and set it
            {
                Name = nameTxt.Text,
                Version = versionTxt.Text,
                FileLocation = fileLocation,
                IconFileLocation = iconLocation,
                IsFavorite = GameCard.GameInfo.IsFavorite,
                LastTimePlayed = GameCard.GameInfo.LastTimePlayed,
                TotalTimePlayed = GameCard.GameInfo.TotalTimePlayed
            };

            foreach (GameInfo gameInfo in Definitions.Games.ToList()) // For each game
            {
                if (gameInfo == oldGameInfo) // Find the game in the list
                {
                    Definitions.Games[Definitions.Games.IndexOf(gameInfo)] = GameCard.GameInfo; // Set the new game
                }
            }

            GameCard.InitializeUI(GameCard.GameInfo, true); // Update the UI

            new GameSaver().Save(Definitions.Games);
            Close(); // Close the window
        }

        private void BrowseBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // OpenFileDialog
            openFileDialog.Filter = "EXE|*.exe"; // Filter

            if (openFileDialog.ShowDialog() ?? true) // If the user selected a file
            {
                nameTxt.Text = openFileDialog.SafeFileName.Remove(openFileDialog.SafeFileName.Length - 4); // Name of the file

                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(openFileDialog.FileName); // Get the version

                versionTxt.Text = fileVersionInfo.FileVersion; // Version of the file
                locationTxt.Text = openFileDialog.FileName; // Location of the file
                if (iconLocation == string.Empty) // If there is no image
                {
                    try
                    {
                        Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(openFileDialog.FileName); // Grab the icon of the game
                        GameImg.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()); // Show the image
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized; // Minimize the window
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close(); // Close the window
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // OpenFileDialog
            openFileDialog.Filter = "PNG|*.png|JPG|*.jpg|Bitmap|*.bmp|All Files|*.*"; // Filter

            if (openFileDialog.ShowDialog() ?? true) // If the user selected a file
            {
                try
                {
                    BitmapImage image = new BitmapImage(new Uri(openFileDialog.FileName)); // Create the image
                    GameImg.Source = image; // Set the GameImg's source to the image
                    iconLocation = openFileDialog.FileName; // Set the path to the image
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); // Show the error
                }
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close(); // Close the Window
        }
    }
}