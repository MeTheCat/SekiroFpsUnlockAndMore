﻿using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace SekiroFpsUnlockAndMore
{
    [XmlRoot("SekiroFpsUnlockAndMore")]
    [Serializable]
    public class SettingsService
    {
        private readonly string sConfigurationPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + @"\config.xml";

        /// <summary>
        /// Read and store settings here.
        /// </summary>
        public SettingsService settings;


        /**
         * Settings definition
         */
        [XmlElement]
        public bool cbFramelock { get; set; }
        [XmlElement]
        public int tbFramelock { get; set; }
        [XmlElement]
        public bool cbAddResolution { get; set; }
        [XmlElement]
        public int tbWidth { get; set; }
        [XmlElement]
        public int tbHeight { get; set; }
        [XmlElement]
        public bool cbFov { get; set; }
        [XmlElement]
        public int cbSelectFov { get; set; }
        [XmlElement]
        public bool cbBorderless { get; set; }
        [XmlElement]
        public bool cbBorderlessStretch { get; set; }
        [XmlElement]
        public bool exGameMods { get; set; }
        [XmlElement]
        public bool cbGameSpeed { get; set; }
        [XmlElement]
        public int tbGameSpeed { get; set; }
        [XmlElement]
        public bool cbPlayerSpeed { get; set; }
        [XmlElement]
        public int tbPlayerSpeed { get; set; }
		[XmlElement]
		public bool cbLogStats { get; set; }

		public SettingsService() { }

        /// <summary>
        /// Create a settings provider to load and save settings.
        /// </summary>
        /// <param name="settingsFilePath">The file path to the settings file.</param>
        public SettingsService(string settingsFilePath = null)
        {
            if (settingsFilePath != null)
            {
                sConfigurationPath = settingsFilePath;
                settings = new SettingsService();
            }
        }

        /// <summary>
        /// Load settings from file into settings property.
        /// </summary>
        /// <returns></returns>
        internal bool Load()
        {
            if (!File.Exists(sConfigurationPath)) return false;
            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SettingsService));
            using (StreamReader streamReader = new StreamReader(sConfigurationPath))
            {
                try
                {
                    settings = (SettingsService)xmlSerializer.Deserialize(streamReader);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while loading configuration file:\n" + ex.Message, "Sekiro FPS Unlocker and more");
                }
            }
            return false;
        }

        /// <summary>
        /// Save settings from settings property to file.
        /// </summary>
        internal void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SettingsService));
            using (StreamWriter streamReader = new StreamWriter(sConfigurationPath))
            { 
                try
                {
                    xmlSerializer.Serialize(streamReader, settings);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while writing configuration file:\n" + ex.Message, "Sekiro FPS Unlocker and more");
                }
            }
        }
    }
}
