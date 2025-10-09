using System.Collections.Immutable;

namespace FabQuack.TreeLib;

public static class TreeExtensions
{
    /// <summary>
    /// Gets the path (keys) in root first order.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="node"></param>
    /// <param name="inclusive">True to include <paramref name="node"/> in the result, false otherwise.</param>
    /// <returns></returns>
    public static ImmutableList<TKey> GetPath<TKey, TValue>(this ImmutableKeyedNode<TKey, TValue> node, bool inclusive)
       where TKey : notnull
    {
        var pathElements = new List<TKey>();

        var current = inclusive ? node : node.Parent;

        while (current != null)
        {
            pathElements.Add(current.Key);

            current = current.Parent;
        }

        pathElements.Reverse();

        return pathElements.ToImmutableList();
    }

    /// <summary>
    /// Gets child keys.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="node"></param>
    /// <param name="inclusive"></param>
    /// <returns></returns>
    public static ImmutableHashSet<TKey> GetChildKeys<TKey, TValue>(this ImmutableKeyedNode<TKey, TValue> node, bool inclusive)
        where TKey : notnull
    {
        var hashset = new HashSet<TKey>();

        if (inclusive)
        {
            hashset.Add(node.Key);
        }

        AddChildKeysRecursive(hashset, node);

        return hashset.ToImmutableHashSet();
    }

    private static void AddChildKeysRecursive<TKey, TValue>(HashSet<TKey> hashset, ImmutableKeyedNode<TKey, TValue> node)
        where TKey : notnull
    {
        foreach (var childNode in node.Nodes)
        {
            hashset.Add(childNode.Key);

            AddChildKeysRecursive(hashset, childNode);
        }
    }

    /// <summary>
    /// Returns parent values in root first order.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="node"></param>
    /// <param name="inclusive"></param>
    /// <returns></returns>
    public static ImmutableList<TValue> GetParentValues<TKey, TValue>(this ImmutableKeyedNode<TKey, TValue> node, bool inclusive)
        where TKey : notnull
    {
        var values = new List<TValue>();

        var current = inclusive ? node : node.Parent;

        while (current != null)
        {
            values.Add(current.Value);

            current = current.Parent;
        }

        values.Reverse();

        return values.ToImmutableList();
    }
}





