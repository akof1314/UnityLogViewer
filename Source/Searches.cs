using System.Collections.Generic;
using System.Linq;

namespace LogViewer
{
    /// <summary>
    /// 
    /// </summary>
    public class Searches
    {
        #region Member Variables
        public List<SearchCriteria> Items { get; private set; }
        private ushort counter = 0; // Basically a counter 
        public bool Changed { get; set; }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public Searches()
        {
            Reset();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sc"></param>
        /// <returns>The Id of the search criteria object</returns>
        public ushort Add(SearchCriteria sc)
        {
            // If the SearchCriteria already exists then just enable it
            if (sc.Type == Global.SearchType.RegexCaseInsensitive || sc.Type == Global.SearchType.SubStringCaseInsensitive)
            {
                var ret = this.Items.SingleOrDefault(x => x.Pattern.ToLower() == sc.Pattern.ToLower());
                if (ret != null)
                {
                    ret.Enabled = true;
                    return 0;
                }
            }
            else
            {
                var ret = this.Items.SingleOrDefault(x => x.Pattern == sc.Pattern);
                if (ret != null)
                {
                    ret.Enabled = true;
                    return 0;
                }
            }

            counter++;
            sc.Enabled = true;
            sc.Id = counter;
            this.Items.Add(sc);

            return sc.Id;
        }

        public bool IsEnabledNewAdd(Global.SearchType searchType, string searchPattern)
        {
            if (searchType == Global.SearchType.RegexCaseInsensitive || searchType == Global.SearchType.SubStringCaseInsensitive)
            {
                var ret = this.Items.SingleOrDefault(x => x.Pattern.ToLower() == searchPattern.ToLower());
                if (ret != null)
                {
                    return ret.Enabled;
                }
            }
            else
            {
                var ret = this.Items.SingleOrDefault(x => x.Pattern == searchPattern);
                if (ret != null)
                {
                    return ret.Enabled;
                }
            }

            SearchCriteria sc = new SearchCriteria();
            sc.Type = searchType;
            sc.Pattern = searchPattern;
            counter++;
            sc.Id = counter;
            this.Items.Add(sc);
            return sc.Enabled;
        }

        public void SetEnabled(Global.SearchType searchType, string searchPattern, bool isEnabled)
        {
            if (searchType == Global.SearchType.RegexCaseInsensitive || searchType == Global.SearchType.SubStringCaseInsensitive)
            {
                var ret = this.Items.SingleOrDefault(x => x.Pattern.ToLower() == searchPattern.ToLower());
                if (ret != null && ret.Enabled != isEnabled)
                {
                    ret.Enabled = isEnabled;
                    Changed = true;
                }
            }
            else
            {
                var ret = this.Items.SingleOrDefault(x => x.Pattern == searchPattern);
                if (ret != null && ret.Enabled != isEnabled)
                {
                    ret.Enabled = isEnabled;
                    Changed = true;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Reset()
        {
            counter = 0;
            this.Items = new List<SearchCriteria>();
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get
            {
                return this.Items.Count;
            }
        }
    }
}
