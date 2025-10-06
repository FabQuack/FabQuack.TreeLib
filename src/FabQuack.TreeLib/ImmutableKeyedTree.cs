using System.Collections.Concurrent;

namespace FabQuack.TreeLib;

public class ImmutableKeyedTree<TKey, TValue>
    where TKey : notnull
{
    private readonly ConcurrentDictionary<TKey, ImmutableKeyedNode<TKey, TValue>> _allNodes;

    internal ImmutableKeyedTree(ConcurrentDictionary<TKey, ImmutableKeyedNode<TKey, TValue>> allNodes, ImmutableKeyedNodes<TKey, TValue> rootNodes)
    {
        _allNodes = allNodes;
        Nodes = rootNodes;
    }

    public ImmutableKeyedNodes<TKey, TValue> Nodes { get; }

    public bool TryGetNode(TKey key, out ImmutableKeyedNode<TKey, TValue> node)
    {
        node = null!;

        return _allNodes.TryGetValue(key, out node!);
    }
}