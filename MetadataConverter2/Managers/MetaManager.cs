﻿using MetadataConverter2.MetaTypes;
using static MetadataConverter2.Crypto.CryptoHelper;

namespace MetadataConverter2.Managers;
public static class MetaManager
{
    private static readonly Dictionary<int, MetaBase> Metas = new();
    static MetaManager()
    {
        int index = 0;
        Metas.Add(index++, new Mark(MetaType.GICB1, 24));
        Metas.Add(index++, new Struct(MetaType.ZZZ, 24.5));
        Metas.Add(index++, new Blocks(MetaType.GI, GIInitVector, 24));
        Metas.Add(index++, new Blocks(MetaType.GICBX, GICBXInitVector, 24));
        Metas.Add(index++, new Blocks(MetaType.BH3, BH3InitVector, 24));
        Metas.Add(index++, new Blocks(MetaType.SR, SRInitVector, 24));
        Metas.Add(index++, new Usages(MetaType.GI_V2, GIInitVector, 24.5));

    }
    public static MetaBase GetMeta(MetaType metaType)
    {
        return GetMeta((int)metaType);
    }

    public static MetaBase GetMeta(int index)
    {
        return !Metas.TryGetValue(index, out MetaBase? meta) ? throw new ArgumentException("Invalid meta !!") : meta;
    }

    public static MetaBase GetMeta(string name)
    {
        return Metas.FirstOrDefault(x => x.Value.Name == name).Value;
    }

    public static MetaBase[] GetMetas()
    {
        return Metas.Values.ToArray();
    }

    public static string[] GetMetaNames()
    {
        return Metas.Values.Select(x => x.Name).ToArray();
    }

    public static string SupportedMetas()
    {
        return $"Supported Metas:\n{string.Join("\n", Metas.Values.Select(x => x.Name))}";
    }
}