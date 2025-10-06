using System.Collections;
using System.Collections.Immutable;

namespace FabQuack.TreeLib;

public class ImmutableKeyedNodes<TKey, TValue> : IImmutableList<ImmutableKeyedNode<TKey, TValue>>
    where TKey : notnull
{
    private readonly ImmutableList<ImmutableKeyedNode<TKey, TValue>> _items;

    internal ImmutableKeyedNodes(ImmutableKeyedNode<TKey, TValue>? parent, IEnumerable<KeyValuePair<TKey, TValue>> items)
    {
        _items = items
            .Select(i => new ImmutableKeyedNode<TKey, TValue>(this, i.Key, i.Value))
            .ToImmutableList();

        Parent = parent;
    }

    public static ImmutableKeyedNodes<TKey, TValue> Empty() => new ImmutableKeyedNodes<TKey, TValue>(null, []);

    public ImmutableKeyedNode<TKey, TValue> this[int index] => _items[index];

    public int Count => _items.Count;

    public ImmutableKeyedNode<TKey, TValue>? Parent { get; }

    public IImmutableList<ImmutableKeyedNode<TKey, TValue>> Add(ImmutableKeyedNode<TKey, TValue> value)
    {
        throw new NotSupportedException();
    }

    public IImmutableList<ImmutableKeyedNode<TKey, TValue>> AddRange(IEnumerable<ImmutableKeyedNode<TKey, TValue>> items)
    {
        throw new NotSupportedException();
    }

    public IImmutableList<ImmutableKeyedNode<TKey, TValue>> Clear()
    {
        throw new NotSupportedException();
    }

    public IEnumerator<ImmutableKeyedNode<TKey, TValue>> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    public int IndexOf(ImmutableKeyedNode<TKey, TValue> item, int index, int count, IEqualityComparer<ImmutableKeyedNode<TKey, TValue>>? equalityComparer)
    {
        throw new NotSupportedException();
    }

    public IImmutableList<ImmutableKeyedNode<TKey, TValue>> Insert(int index, ImmutableKeyedNode<TKey, TValue> element)
    {
        throw new NotSupportedException();
    }

    public IImmutableList<ImmutableKeyedNode<TKey, TValue>> InsertRange(int index, IEnumerable<ImmutableKeyedNode<TKey, TValue>> items)
    {
        throw new NotSupportedException();
    }

    public int LastIndexOf(ImmutableKeyedNode<TKey, TValue> item, int index, int count, IEqualityComparer<ImmutableKeyedNode<TKey, TValue>>? equalityComparer)
    {
        throw new NotSupportedException();
    }

    public IImmutableList<ImmutableKeyedNode<TKey, TValue>> Remove(ImmutableKeyedNode<TKey, TValue> value, IEqualityComparer<ImmutableKeyedNode<TKey, TValue>>? equalityComparer)
    {
        throw new NotSupportedException();
    }

    public IImmutableList<ImmutableKeyedNode<TKey, TValue>> RemoveAll(Predicate<ImmutableKeyedNode<TKey, TValue>> match)
    {
        throw new NotSupportedException();
    }

    public IImmutableList<ImmutableKeyedNode<TKey, TValue>> RemoveAt(int index)
    {
        throw new NotSupportedException();
    }

    public IImmutableList<ImmutableKeyedNode<TKey, TValue>> RemoveRange(IEnumerable<ImmutableKeyedNode<TKey, TValue>> items, IEqualityComparer<ImmutableKeyedNode<TKey, TValue>>? equalityComparer)
    {
        throw new NotSupportedException();
    }

    public IImmutableList<ImmutableKeyedNode<TKey, TValue>> RemoveRange(int index, int count)
    {
        throw new NotSupportedException();
    }

    public IImmutableList<ImmutableKeyedNode<TKey, TValue>> Replace(ImmutableKeyedNode<TKey, TValue> oldValue, ImmutableKeyedNode<TKey, TValue> newValue, IEqualityComparer<ImmutableKeyedNode<TKey, TValue>>? equalityComparer)
    {
        throw new NotSupportedException();
    }

    public IImmutableList<ImmutableKeyedNode<TKey, TValue>> SetItem(int index, ImmutableKeyedNode<TKey, TValue> value)
    {
        throw new NotSupportedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _items.GetEnumerator();
    }
}





