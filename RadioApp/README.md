# Radio App

## Aims

- [x] 4 channels that users can alternate between.
- [x] Ability to adjust volume.
- [x] On/Off button
- [x] Bonus: App starts where it left off.
- [x] Bonus: User can change what radio station is played on different channels.



## How to use



![App](Images\App.png)





## Radio Class



```csharp
	public class Radio
    {
        public readonly string sourceTextFileName = "Sources.txt";
        public readonly string settingsTextFileName = "Settings.txt";
        private bool _on;
        private int _channel = 1;
        private float _volume;

        public bool On { get { return _on; } }
        public int Channel 
        {
            get { return _channel; }
            set { _channel = value > 0 && value <= 4 && _on ? value : _channel; } 
        }
        public float Volume 
        {
            get { return _volume; }
            set { _volume = value < 0 ? 0 : value > 1 ? 1 : value; }
        }
        public string[] Sources { get; set; }

        public Radio()
        {
            if (File.Exists(sourceTextFileName))
                Sources = File.ReadAllLines(sourceTextFileName);
            if (File.Exists(settingsTextFileName))
            {
                var setting = File.ReadAllLines(settingsTextFileName);
                _volume = float.Parse(setting[0]);
                _channel = int.Parse(setting[1]);
            }
        }

        public string Play()
        {
            return _on ? $"Playing channel {_channel}" : "Radio is off";
        }

        public void TurnOn()
        {
            _on = true;
        }
        public void TurnOff()
        {
            _on = false;
        }

        public void ToggleOnOff()
        {
            if (_on)
                TurnOff();
            else
                TurnOn();
        }
    }
```





## Code Behind 





```csharp
		readonly Radio radio = new();
        readonly List<MediaElement> mediaElements = new();
        readonly List<Label> pointers = new();
```





```csharp
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
```







```csharp
		private void ButtonOnOff_Click(object sender, RoutedEventArgs e)
        {
            radio.ToggleOnOff();
            if (radio.On)
                LabelOnOff.Background = Brushes.Green;
            else
                LabelOnOff.Background = Brushes.Red;
            PlayChannel();
        }
```





```csharp
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
```





```csharp
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
```





```csharp
        private void SliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = sender as Slider;
            radio.Volume = (float)slider.Value / 10;
            if (radio.On)
                mediaElements[radio.Channel - 1].Volume = radio.Volume;
            SaveSettings();
        }
```





```csharp
        private void SaveSettings()
        {
            File.WriteAllText(radio.settingsTextFileName, $"{radio.Volume}\n{radio.Channel}");
        }
```



![SettingTextFile](Images\SettingTextFile.png)





![SourceTextFile](Images\SourceTextFile.png)