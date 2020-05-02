namespace Warframe
{
    public class Item
    {
        public virtual string Name { get; set; }
        public virtual string UniqueName { get; set; }
        public virtual bool CodexSecret { get; set; }
 
        public virtual string Type { get; set; }
        public virtual ItemType TypedType { get; set; }
        public virtual string Description { get; set; }
    }
}