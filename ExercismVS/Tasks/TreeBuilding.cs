using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

public class TreeBuildingRecord
{
    public int ParentId { get; set; }
    public int RecordId { get; set; }
}

public class Tree
{
    public int Id { get; set; }
    public int ParentId { get; set; }

    public List<Tree> Children { get; set; }

    public bool IsLeaf => Children.Count == 0;
}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        Tree? tree = null;
        var parents = new List<int>();
        var ids = new List<int>();
        var _r = records.GroupBy(_ => _.ParentId).OrderBy(_ => _.Key).ToDictionary(_ => _.Key, _ => _.ToList());
        var rootFound = false;
        foreach (var branch in _r)
        {
            if (parents.Exists(_ => _ == branch.Key))
            {
                throw new ArgumentException();
            }
            parents.Add(branch.Key);
            tree ??= new Tree() { Id = branch.Key, ParentId = branch.Key, Children = new List<Tree>() };

            var _tree = GetLocalTree(tree, branch.Key);
            if (_tree == null)
            {
                throw new ArgumentException();
            }
            foreach (var record in branch.Value)
            {
                ids.Add(record.RecordId);
                
                if (record.RecordId < record.ParentId)
                {
                    throw new ArgumentException();
                }

                if (record.RecordId == record.ParentId)
                {
                    rootFound = true;
                    continue;
                }
                
                var t = new Tree() { Id = record.RecordId, ParentId = record.ParentId, Children = new List<Tree>() };
                _tree.Children.Add(t);

            }
        }
        if (tree == null || !rootFound || ids.Count != ids.Distinct().Count() || ids.Count != ids.Max() + 1)
        {
            throw new ArgumentException();
        }
        
        return tree.Sort();
    }

    private static Tree Sort(this Tree tree)
    {
        tree.Children = tree.Children.OrderBy(_ => _.Id).ToList();
        foreach (var branch in tree.Children)
        {
            branch.Sort();
        }

        return tree;
    }
    public static Tree? GetLocalTree(Tree tree, int id)
    {
        if (tree.Id == id)
        {
            return tree;
        }

        foreach (var child in tree.Children)
        {
            var t = GetLocalTree(child, id);
            if (t == null)
            {
                continue;
            }
            if (t.Id == id)
            {
                return t;
            }
        }

        return null;
    }
}

public static class TreeBuilderOld
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        var ordered = new SortedList<int, TreeBuildingRecord>();

        foreach (var record in records)
        {
            ordered.Add(record.RecordId, record);
        }

        records = ordered.Values;

        var trees = new List<Tree>();
        var previousRecordId = -1;

        foreach (var record in records)
        {   
            var t = new Tree { Children = new List<Tree>(), Id = record.RecordId, ParentId = record.ParentId };
            trees.Add(t);

            if ((t.Id == 0 && t.ParentId != 0) ||
                (t.Id != 0 && t.ParentId >= t.Id) ||
                (t.Id != 0 && t.Id != previousRecordId + 1))
            {
                throw new ArgumentException();
            }

            ++previousRecordId;
        }
        
        if (trees.Count == 0)
        {
            throw new ArgumentException();
        }

        for (int i = 1; i < trees.Count; i++)
        {
            var t = trees.First(x => x.Id == i);
            var parent = trees.First(x => x.Id == t.ParentId);
            parent.Children.Add(t);
        }

        var r = trees.First(t => t.Id == 0);
        return r;
    }
}