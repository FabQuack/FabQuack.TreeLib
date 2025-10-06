namespace FabQuack.TreeLib;

public class ImmutableKeyedNode<TKey, TValue>
    where TKey : notnull
{
    private ImmutableKeyedNodes<TKey, TValue>? _nodes;

    internal ImmutableKeyedNode(
        ImmutableKeyedNodes<TKey, TValue>? parent, 
        TKey key, 
        TValue value)
    {
        ParentList = parent;
        Key = key;
        Value = value;
    }

    public TKey Key { get; }

    public TValue Value { get; }

    internal ImmutableKeyedNodes<TKey, TValue>? ParentList { get; }

    public ImmutableKeyedNode<TKey, TValue>? Parent => ParentList?.Parent;

    internal void SetNodes(IEnumerable<KeyValuePair<TKey, TValue>> values)
    {
        if (values is null)
        {
            throw new ArgumentNullException(nameof(values));
        }

        _nodes = new ImmutableKeyedNodes<TKey, TValue>(this, values);
    }

    public ImmutableKeyedNodes<TKey, TValue> Nodes
    {
        get
        {
            if (_nodes == null)
                return ImmutableKeyedNodes<TKey, TValue>.Empty();

            return _nodes; 
        }
    }

    public override string? ToString()
    {
        return Key.ToString();
    }
}





