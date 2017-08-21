using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using UnityEngine;

public static class EnumExtensions
{
    public static TAttribute GetAttribute<TAttribute>(this Enum value)
        where TAttribute : Attribute
    {
        var type = value.GetType();
        var name = Enum.GetName(type, value);
        return type.GetField(name) // I prefer to get attributes this way
            .GetCustomAttributes(false)
            .OfType<TAttribute>()
            .SingleOrDefault();
    }
}

public class SpeciesInfoAttribute : Attribute
{
    internal SpeciesInfoAttribute(LuxuryItems item, int food)
    {
        this.Item =  item;
        this.Food = food;
    }
    public LuxuryItems Item { get; private set; }
    public int Food { get; private set; }
}

public class ItemInfoAttribute : Attribute
{
    internal ItemInfoAttribute(int happiness, string name)
    {
        this.Name = name;
        this.Happiness = happiness;
    }
    public int Happiness { get; private set; }
    public string Name { get; private set; }
}


public enum Species
{
    [SpeciesInfo(LuxuryItems.Ivory, 50)] Elephant,
    [SpeciesInfo(LuxuryItems.TigerSkin, 20)] Tiger,
}

public enum LuxuryItems
{
    [ItemInfo(4, "Ivory")] Ivory,
    [ItemInfo(3, "Tiger Skin")] TigerSkin,
    
}

public static class SpeciesExtensions
{
    public static int GetFood(this Species p)
    {
        var attr = p.GetAttribute<SpeciesInfoAttribute>();
        return attr.Food;
    }

    public static LuxuryItems GetItem(this Species p)
    {
        var attr = p.GetAttribute<SpeciesInfoAttribute>();
        return attr.Item;
    }

    
}