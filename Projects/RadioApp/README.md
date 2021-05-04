# Radio App

## Aims

- [x] 4 channels that users can alternate between.
- [x] Ability to adjust volume.
- [x] On/Off button
- [x] Bonus: App starts where it left off.
- [x] Bonus: User can change what radio station is played on different channels.



## How to use

​	When the application is run, the user will see the window shown below. The power button controls if the radio is on or off. If the radio is off, then the coloured box to the left of the power button will be red and if the radio is on, then it will be coloured green. The volume of the radio is controlled by the slider. If the slider is all the way to the left, then the volume is 0 (min) and if the slider is all the way to the right, then the volume is 100 (max). The volume can be controlled regardless of whether the radio is on or off where as the channel can only be changed when the radio is on. There are two buttons on the sides of the channel section which are used to change the channel and the red pointer indicates the current channel. The app records the channel and volume every time the user makes a change so when the app is closed and re-opened, it will pick up from where it was left off but the power will be off.

![App](Images\App.png)

​	The user does have the option to change what radio station is played at each channel number by going to the Sources.txt file which is stored in the same location as the .exe file.

![SourceTextFile](Images\SourceTextFile.png)



## Radio Class

​	The radio class is in charge of keeping track of the channel, volume and whether the radio is on or off as well as reading the saved settings data and sources. It makes sure the channel and volume values stay within their required bounds and the constructor is responsible for reading the stored text files. The methods are only used to turn on and off the radio. 

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
            if (!File.Exists(sourceTextFileName))
                File.WriteAllText(sourceTextFileName, $"http://icy-e-bab-04-cr.sharp-stream.com/absoluteradio.mp3\nhttps://stream-al.planetradio.co.uk/kerrang.mp3\nhttp://46.10.150.243/jazz-fm-lounge.mp3\nhttp://live-bauer-mz.sharp-stream.com/viking.mp3");
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

##### Global variables

​	The global variables are `radio` which stores an instance of the radio class, `mediaElements` which is a list of the Media Elements that use Uris and play the sound from the stream, and `pointers` which is a list of the labels that act as the channel pointer.

```csharp
		readonly Radio radio = new();
        readonly List<MediaElement> mediaElements = new();
        readonly List<Label> pointers = new();
```



##### Initialising the app

​	The `MainWindow` method is what initialises the app. It sets the slider to the right volume, adds the four Media Elements to `mediaElement`, adds the labels the acts as pointers to `pointers`, sets the source of each Media Element, and finally runs the `PlayChannel` method which makes sure all the settings are visualised on the app.

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
                for (int i = 0; i < mediaElements.Count; i++)
                {
                    mediaElements[i].Source = new Uri(radio.Sources[i]);
                }
            }
            PlayChannel();
        }
```



##### Power button

​	The `ButtonOnOff_Click` method is responsible for turning the radio on or off, changing the colour of the label, next to the power button, to show the power status of the radio. `PlayChannel` is run, so the colour change is visualised on the app.

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



##### Changing channel buttons

​	The `ChangeChannel` method is responsible for changing  the channel number. The `PlayChannel` method is run, so the pointer's location can be updated to the new channel number.

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



##### Play channel method

​	This method is used to make sure the right channel is playing. It sets all the media elements' volumes to 0 and makes all the pointers transparent. Then makes the correct pointer visible and, if the radio is on, sets the volume of the correct media element to the volume stored in the radio class. `SaveSettings` is run at the end to save the channel number.

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



##### Volume slider

​	The `SliderVolume_ValueChanged` method is called every time the slider changes value. It makes sure the volume recorded in the radio class is updated, changes the volume of the Media Element, and calls the `SaveSettings` method to save the volume value.

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



##### Save settings method

​	This method just writes the Settings.txt file and the output can be seen in the image below.

```csharp
        private void SaveSettings()
        {
            File.WriteAllText(radio.settingsTextFileName, $"{radio.Volume}\n{radio.Channel}");
        }
```

![SettingTextFile](Images\SettingTextFile.png)
