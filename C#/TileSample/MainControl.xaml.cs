﻿using MetroSidebarTile;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Animation;

namespace TileSample
{
    /// <summary>
    /// Interaction logic for MainControl.xaml
    /// </summary>
    public partial class MainControl : UserControl
    {
        // Fields      
        SettingsManager _settingsManager = new SettingsManager();

        public MainControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //This line must be used in order to specify the main control
            _settingsManager.ID = this;
        }

        //Read stored settings
        //private void LoadSettings()
        //{
        //    string mySetting = _settingsManager.GetSetting("mySetting");
        //}

        //Store settings
        //private void SaveSettings()
        //{
        //    SettingsManager.SettingData mySetting = new SettingsManager.SettingData() { keyword = "mySetting", value = "settingValue" };
                     
        //    List<SettingsManager.SettingData> SettingsCollection = new List<SettingsManager.SettingData>();
        //    SettingsCollection.Add(mySetting);
        //     _settingsManager.SaveSettings(SettingsCollection);
        //}

        bool isAnimStarted = false;
        private void me_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!isAnimStarted)
            {
                Large_grd.Visibility = System.Windows.Visibility.Hidden;
                ((Storyboard)Resources["ResizingAnim"]).Begin();
                isAnimStarted = true;
            }
        }

        private void Storyboard_Completed_1(object sender, EventArgs e)
        {
            if (me.ActualHeight > 125)
            {
                Small_grd.Visibility = System.Windows.Visibility.Hidden;
                Large_grd.Visibility = System.Windows.Visibility.Visible;
                ((Storyboard)Resources["ResizingAnim2"]).Begin();
            }
            else
            {
                Small_grd.Visibility = System.Windows.Visibility.Visible;
            }
         
            ((Storyboard)Resources["ResizingAnim2"]).Begin();
        }

        private void Storyboard_Completed_2(object sender, EventArgs e)
        {
            isAnimStarted = false;
        }


    }
}