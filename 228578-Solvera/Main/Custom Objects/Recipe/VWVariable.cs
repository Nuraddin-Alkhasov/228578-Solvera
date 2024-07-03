namespace HMI.CO.Recipe
{
    public class VWVariable
    {
        public VWVariable(object _s, object _t, object _v)
        {
            Item = _s;
            Type = _t;
            Value = _v;
        }
        public object Item { get; set; } = null;
        public object Type { get; set; } = null;
        public object Value { get; set; } = null;
        public override string ToString() { return Item.ToString(); }
    }
}
