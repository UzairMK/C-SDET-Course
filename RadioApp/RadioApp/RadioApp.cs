using System.IO;

namespace RadioApp
{
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
}