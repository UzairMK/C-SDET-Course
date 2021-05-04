using System;
using System.IO;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RadioApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Radio radio = new();
        readonly List<MediaElement> mediaElements = new();
        readonly List<Label> pointers = new();
        public MainWindow()
        {
            InitializeComponent();
            SliderVolume.Value = radio.Volume * 10;
            mediaElements.Add(Ch1);
            mediaElements.Add(Ch2);
            mediaElements.Add(Ch3);
            mediaElements.Add(Ch4);
            pointers.Add(P1);
            pointers.Add(P2);
            pointers.Add(P3);
            pointers.Add(P4);
            if (radio.Sources != null)
            {
                for (int i = 0; i < radio.Sources.Length; i++)
                {
                    mediaElements[i].Source = new Uri(radio.Sources[i]);
                }
            }
            PlayChannel();
        }

        private void ButtonOnOff_Click(object sender, RoutedEventArgs e)
        {
            radio.ToggleOnOff();
            if (radio.On)
                LabelOnOff.Background = Brushes.Green;
            else
                LabelOnOff.Background = Brushes.Red;
            PlayChannel();
        }

        private void ChangeChannel(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            switch (button.Content)
            {
                case ">":
                    radio.Channel += 1;
                    break;
                case "<":
                    radio.Channel -= 1;
                    break;
            }

            PlayChannel();
        }

        private void PlayChannel()
        {
            for (int i = 0; i < mediaElements.Count; i++)
            {
                mediaElements[i].Volume = 0;
                pointers[i].Background = Brushes.Transparent;
            }

            pointers[radio.Channel - 1].Background = Brushes.Red;
            if (radio.On)
                mediaElements[radio.Channel - 1].Volume = radio.Volume;
            SaveSettings();
        }

        private void SliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = sender as Slider;
            radio.Volume = (float)slider.Value / 10;
            if (radio.On)
                mediaElements[radio.Channel - 1].Volume = radio.Volume;
            SaveSettings();
        }

        private void SaveSettings()
        {
            File.WriteAllText(radio.settingsTextFileName, $"{radio.Volume}\n{radio.Channel}");
        }
    }
}
