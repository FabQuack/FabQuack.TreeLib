using Shouldly;

namespace FabQuack.TreeLib.Tests
{
    public class ImmutableKeyedTreeTests
    {
        public ImmutableKeyedTreeTests()
        {
            var items = new[]
            {
                new TestItem
                {
                    Id = "1",
                    Message = "Node 1"
                },
                new TestItem
                {
                    Id = "2",
                    Message = "Node 2"
                },
                new TestItem
                {
                    Id = "1.1" ,
                    ParentId = "1",
                    Message = "Node 1.1"
                },
            };

            Tree = items.Select(i => new KeyValuePair<string, TestItem>(i.Id, i))
                .ToImmutableKeyedTree(i => i.Value.ParentId);
        }

        private ImmutableKeyedTree<string, TestItem> Tree { get; }

        [Fact]
        public void Simple()
        {
            Tree.Nodes.Count.ShouldBe(2);
        }

        [Fact]
        public void Path()
        {
            Tree.TryGetNode("1.1", out var node).ShouldBeTrue();

            node.GetPath(true).ShouldBe(["1", "1.1"]);
        }

        [Fact]
        public void GetChildKeysInclusive()
        {
            Tree.TryGetNode("1", out var node).ShouldBeTrue();

            node.GetChildKeys(true).ShouldBe(["1", "1.1"], ignoreOrder: true);
        }

        [Fact]
        public void GetChildKeysExclusive()
        {
            Tree.TryGetNode("1", out var node).ShouldBeTrue();

            node.GetChildKeys(false).ShouldBe(["1.1"], ignoreOrder: true);
        }

        [Fact]
        public void GetParentValuesInclusive()
        {
            Tree.TryGetNode("1.1", out var node).ShouldBeTrue();

            var parentValues = node.GetParentValues(true);

            parentValues.Select(n => n.Message).ShouldBe(["Node 1", "Node 1.1"]);
        }

        [Fact]
        public void GetParentValuesExclusive()
        {
            Tree.TryGetNode("1.1", out var node).ShouldBeTrue();

            var parentValues = node.GetParentValues(false);

            parentValues.Select(n => n.Message).ShouldBe(["Node 1"]);
        }
    }

    public class TestItem
    {
        public required string Id { get; init; }

        public string? ParentId { get; init; }

        public required string Message { get; init; }
    }
}