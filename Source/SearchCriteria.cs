
namespace LogViewer
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchCriteria
    {
        public bool Enabled { get; set; } = false;
        public ushort Id { get; set; } = 0;
        public Global.SearchType Type { get; set; }
        public string Pattern { get; set; } = "";
    }
}
