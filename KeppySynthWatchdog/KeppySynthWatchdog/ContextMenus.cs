﻿using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace KeppySynthWatchdog
{
    class ContextMenus
    {
        MenuItem itemR;
        MenuItem item0;
        MenuItem item1;
        MenuItem itemline1;
        MenuItem itemline2;
        MenuItem item2;
        MenuItem item3;
        MenuItem item4;
        MenuItem item5;
        MenuItem item6;
        MenuItem item7;
        MenuItem item8;
        MenuItem item9;
        MenuItem item10;
        MenuItem item11;
        MenuItem item12;
        MenuItem item13;
        MenuItem item14;
        MenuItem item15;
        MenuItem item16;
        MenuItem item17;
        MenuItem item18;

        public ContextMenu Create()
        {
            ContextMenu menu = new ContextMenu();
            RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's Synthesizer\\Settings", true);
            RegistryKey Watchdog = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's Synthesizer\\Watchdog", true);

            item0 = new MenuItem();
            item0.Index = 0;
            item0.Text = "Open the configurator";
            item0.DefaultItem = true;
            item0.Click += new EventHandler(OpenConf_Click);

            item1 = new MenuItem();
            item1.Index = 1;
            item1.Text = "Open the mixer";
            item1.Click += new EventHandler(OpenMixer_Click);

            item2 = new MenuItem();
            item2.Index = 2;
            item2.Text = "Open the debug window";
            item2.Click += new EventHandler(OpenDbg_Click);

            itemline1 = new MenuItem();
            itemline1.Index = 3;
            itemline1.Text = "-";

            itemR = new MenuItem();
            itemR.Index = 4;
            itemR.Text = "Send a MIDI reset event to all the channels";
            itemR.Click += new EventHandler(ResetChannels_Click);

            itemline2 = new MenuItem();
            itemline2.Index = 5;
            itemline2.Text = "-";

            item3 = new MenuItem();
            item3.Index = 6;
            item3.Text = "Reload list 1";
            item3.Click += new EventHandler(SoundfontReload1);

            item4 = new MenuItem();
            item4.Index = 7;
            item4.Text = "Reload list 2";
            item4.Click += new EventHandler(SoundfontReload2);

            item5 = new MenuItem();
            item5.Index = 8;
            item5.Text = "Reload list 3";
            item5.Click += new EventHandler(SoundfontReload3);

            item6 = new MenuItem();
            item6.Index = 9;
            item6.Text = "Reload list 4";
            item6.Click += new EventHandler(SoundfontReload4);

            item7 = new MenuItem();
            item7.Index = 10;
            item7.Text = "Reload list 5";
            item7.Click += new EventHandler(SoundfontReload5);

            item8 = new MenuItem();
            item8.Index = 11;
            item8.Text = "Reload list 6";
            item8.Click += new EventHandler(SoundfontReload6);

            item9 = new MenuItem();
            item9.Index = 12;
            item9.Text = "Reload list 7";
            item9.Click += new EventHandler(SoundfontReload7);

            item10 = new MenuItem();
            item10.Index = 13;
            item10.Text = "Reload list 8";
            item10.Click += new EventHandler(SoundfontReload8);

            if (Convert.ToInt32(Settings.GetValue("extra8lists", 0)) == 1)
            {
                item11 = new MenuItem();
                item11.Index = 14;
                item11.Text = "Reload list 9";
                item11.Click += new EventHandler(SoundfontReload9);

                item12 = new MenuItem();
                item12.Index = 15;
                item12.Text = "Reload list 10";
                item12.Click += new EventHandler(SoundfontReload10);

                item13 = new MenuItem();
                item13.Index = 16;
                item13.Text = "Reload list 11";
                item13.Click += new EventHandler(SoundfontReload11);

                item14 = new MenuItem();
                item14.Index = 17;
                item14.Text = "Reload list 12";
                item14.Click += new EventHandler(SoundfontReload12);

                item15 = new MenuItem();
                item15.Index = 18;
                item15.Text = "Reload list 13";
                item15.Click += new EventHandler(SoundfontReload13);

                item16 = new MenuItem();
                item16.Index = 19;
                item16.Text = "Reload list 14";
                item16.Click += new EventHandler(SoundfontReload14);

                item17 = new MenuItem();
                item17.Index = 20;
                item17.Text = "Reload list 15";
                item17.Click += new EventHandler(SoundfontReload15);

                item18 = new MenuItem();
                item18.Index = 21;
                item18.Text = "Reload list 16";
                item18.Click += new EventHandler(SoundfontReload16);

                menu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            item0,
            item1,
            item2,
            itemline1,
            itemR,
            itemline2,
            item3,
            item4,
            item5,
            item6,
            item7,
            item8,
            item9,
            item10,
            item11,
            item12,
            item13,
            item14,
            item15,
            item16,
            item17,
            item18});
            }
            else
            {
                menu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            item0,
            item1,
            item2,
            itemline1,
            itemR,
            itemline2,
            item3,
            item4,
            item5,
            item6,
            item7,
            item8,
            item9,
            item10});
            }

            Settings.Close();
            Watchdog.Close();
            return menu;
        }

        void OpenConf_Click(object sender, EventArgs e)
        {
            string currentpath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Process.Start(currentpath + "\\KeppySynthConfigurator.exe", null);
        }

        void OpenMixer_Click(object sender, EventArgs e)
        {
            string currentpath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Process.Start(currentpath + "\\KeppySynthConfigurator.exe", "/MIX");
        }

        void OpenDbg_Click(object sender, EventArgs e)
        {
            string currentpath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Process.Start(currentpath + "\\KeppySynthDebugWindow.exe", null);
        }

        void ResetChannels_Click(object sender, EventArgs e)
        {
            RegistryKey Watchdog = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's Synthesizer\\Watchdog", true);
            Watchdog.SetValue("resetchannels", 1, RegistryValueKind.DWord);
            Watchdog.Close();
        }

        void SoundfontReload1(object sender, EventArgs e)
        {
            LoadSoundfont(1);
        }

        void SoundfontReload2(object sender, EventArgs e)
        {
            LoadSoundfont(2);
        }

        void SoundfontReload3(object sender, EventArgs e)
        {
            LoadSoundfont(3);
        }

        void SoundfontReload4(object sender, EventArgs e)
        {
            LoadSoundfont(4);
        }

        void SoundfontReload5(object sender, EventArgs e)
        {
            LoadSoundfont(5);
        }

        void SoundfontReload6(object sender, EventArgs e)
        {
            LoadSoundfont(6);
        }

        void SoundfontReload7(object sender, EventArgs e)
        {
            LoadSoundfont(7);
        }

        void SoundfontReload8(object sender, EventArgs e)
        {
            LoadSoundfont(8);
        }

        void SoundfontReload9(object sender, EventArgs e)
        {
            LoadSoundfont(9);
        }

        void SoundfontReload10(object sender, EventArgs e)
        {
            LoadSoundfont(10);
        }

        void SoundfontReload11(object sender, EventArgs e)
        {
            LoadSoundfont(11);
        }

        void SoundfontReload12(object sender, EventArgs e)
        {
            LoadSoundfont(12);
        }

        void SoundfontReload13(object sender, EventArgs e)
        {
            LoadSoundfont(13);
        }

        void SoundfontReload14(object sender, EventArgs e)
        {
            LoadSoundfont(14);
        }

        void SoundfontReload15(object sender, EventArgs e)
        {
            LoadSoundfont(15);
        }

        void SoundfontReload16(object sender, EventArgs e)
        {
            LoadSoundfont(16);
        }

        public static void CheckPop(object source, EventArgs e)
        {
            RegistryKey Watchdog = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's Synthesizer\\Watchdog", true);
            if (Convert.ToInt32(Watchdog.GetValue("closewatchdog")) == 1 | Convert.ToInt32(Watchdog.GetValue("wdrun")) == 0)
            {
                Watchdog.SetValue("closewatchdog", "0", RegistryValueKind.DWord);
                Application.Exit();
            }
            Watchdog.Close();
        }

        void LoadSoundfont(int whichone)
        {
            RegistryKey Watchdog = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's Synthesizer\\Watchdog", true);
            Watchdog.SetValue("currentsflist", whichone, RegistryValueKind.DWord);
            Watchdog.SetValue("rel" + whichone.ToString(), "1", RegistryValueKind.DWord);
            Watchdog.Close();
        }
    }
}