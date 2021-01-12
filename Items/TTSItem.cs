namespace SpeechAgent.Items
{
    public class TTSItem
    {
        public TTSItem(string description, object _obj)
        {
            this.Description = description;
            this.ItemObj = _obj;
        }
        public string Description { get; set; }
        public object ItemObj { get; set; }
        public override string ToString()
        {
            return Description;
        }
    }
}
