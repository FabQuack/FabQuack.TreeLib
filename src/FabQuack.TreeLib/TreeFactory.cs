using System.Collections.Concurrent;

namespace FabQuack.TreeLib;

public static class TreeFactory
{
    /// <summary>
    /// Creates an <see cref="ImmutableKeyedTree{TKey, TValue}"/> instance for the supplied values.
    /// </summary>
    /// <typeparam name="TKey">The type of key. These must be unique throughout the entire tree.</typeparam>
    /// <typeparam name="TValue">The type of object to store in the tree.</typeparam>
    /// <param name="items">The key value pairs to use.</param>
    /// <param name="hasParentKey"></param>
    /// <param name="getParentKey">The function which gets the parent key from each item in <paramref name="items"/>.</param>
    /// <returns></returns>
    public static ImmutableKeyedTree<TKey, TValue> ToImmutableKeyedTree<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> items,
        Func<KeyValuePair<TKey, TValue>, bool> hasParentKey,
        Func<KeyValuePair<TKey, TValue>, TKey> getParentKey)
        where TKey : notnull
    {
        var rootItems = new List<KeyValuePair<TKey, TValue>>();

        var byParent = new ConcurrentDictionary<TKey, List<KeyValuePair<TKey, TValue>>>();

        var allNodes = new ConcurrentDictionary<TKey, ImmutableKeyedNode<TKey, TValue>>();

        foreach (var item in items)
        {
            if (hasParentKey(item))
            {
                var parentKey = getParentKey(item);

                var byParentList = byParent.GetOrAdd(parentKey, key => []);

                byParentList.Add(item);
            }
            else
            {
                rootItems.Add(item);
            }
        }

        var rootNodes = new ImmutableKeyedNodes<TKey, TValue>(null, rootItems);

        AddChildren(rootNodes, byParent, allNodes);

        return new ImmutableKeyedTree<TKey, TValue>(allNodes, rootNodes);
    }

    private static void AddChildren<TKey, TValue>(ImmutableKeyedNodes<TKey, TValue> nodes,
        ConcurrentDictionary<TKey, List<KeyValuePair<TKey, TValue>>> byParent,
        ConcurrentDictionary<TKey, ImmutableKeyedNode<TKey, TValue>> allNodes)
        where TKey : notnull
    {
        foreach (var node in nodes)
        {
            if (!allNodes.TryAdd(node.Key, node))
                throw new InvalidOperationException($"Key {node.Key} has already been added.");

            if (byParent.TryGetValue(node.Key, out var list))
            {
                node.SetNodes(list);

                AddChildren(node.Nodes, byParent, allNodes);
            }
        }
    }
}





