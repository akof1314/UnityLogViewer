﻿using System;
using System.IO;
using System.Drawing;
using Nett;
using woanware;

namespace LogViewer
{
    /// <summary>
    /// Allows us to save/load the configuration file to/from TOML
    /// </summary>
    public class Configuration
    {
        #region Member Variables
        public string HighlightColour { get; set; } = "Lime";
        public string ContextColour { get; set; } = "LightGray";
        public string MatchColour { get; set; } = "DarkOrange";
        public int MultiSelectLimit { get; set; } = 1000;
        public int NumContextLines { get; set; } = 0; // 上下文的最大数
        public string[] SearchTerms { get; set; } = new string[0];
        public int[] SearchTypes { get; set; } = new int[0];
        public int[] FormSize { get; set; } = new int[0];
        public bool FormMaximized { get; set; } = false;
        public int SplitterDistance { get; set; } = 0;
        private const string FILENAME = "LogViewer.toml";
        #endregion

        #region Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Load()
        {
            try
            {
                if (File.Exists(this.GetPath()) == false)
                {
                    return string.Empty;
                }

                Configuration c = Toml.ReadFile<Configuration>(this.GetPath());
                this.HighlightColour = c.HighlightColour;
                this.ContextColour = c.ContextColour;
                this.MatchColour = c.MatchColour;
                this.MultiSelectLimit = c.MultiSelectLimit;
                this.NumContextLines = c.NumContextLines;
                this.SearchTerms = c.SearchTerms;
                this.SearchTypes = c.SearchTypes;
                this.FormSize = c.FormSize;
                this.FormMaximized = c.FormMaximized;
                this.SplitterDistance = c.SplitterDistance;

                if (this.MultiSelectLimit > 10000)
                {
                    this.MultiSelectLimit = 10000;
                    return "The multiselect limit is 10000";
                }

                if (this.NumContextLines > 10)
                {
                    this.NumContextLines = 10;
                    return "The maximum number of context lines is 10";
                }
                return string.Empty;
            }
            catch (FileNotFoundException fileNotFoundEx)
            {
                return fileNotFoundEx.Message;
            }
            catch (UnauthorizedAccessException unauthAccessEx)
            {
                return unauthAccessEx.Message;
            }
            catch (IOException ioEx)
            {
                return ioEx.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            try
            {
                Toml.WriteFile(this, this.GetPath());
                return string.Empty;
            }
            catch (FileNotFoundException fileNotFoundEx)
            {
                return fileNotFoundEx.Message;
            }
            catch (UnauthorizedAccessException unauthAccessEx)
            {
                return unauthAccessEx.Message;
            }
            catch (IOException ioEx)
            {
                return ioEx.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Color GetHighlightColour()
        {
            Color temp = Color.FromName(this.HighlightColour);
            if (temp.IsKnownColor == false)
            {
                return Color.Lime;
            }

            return temp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Color GetContextColour()
        {
            Color temp = Color.FromName(this.ContextColour);
            if (temp.IsKnownColor == false)
            {
                return Color.LightGray;
            }

            return temp;
        }

        public Color GetMatchColour()
        {
            Color temp = Color.FromName(this.MatchColour);
            if (temp.IsKnownColor == false)
            {
                return Color.DarkOrange;
            }

            return temp;
        }
        #endregion

        #region Misc Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetPath()
        {
            return System.IO.Path.Combine(Misc.GetApplicationDirectory(), FILENAME);
        }
        #endregion
    }
}