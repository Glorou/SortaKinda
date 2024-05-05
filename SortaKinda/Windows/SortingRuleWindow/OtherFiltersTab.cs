﻿using System;
using Dalamud.Interface.Components;
using ImGuiNET;
using KamiLib.Classes;
using SortaKinda.Interfaces;
using SortaKinda.Models;
using SortaKinda.Models.Enums;

namespace SortaKinda.Views.Tabs;

public class OtherFiltersTab(SortingRule rule) : ITwoColumnRuleConfigurationTab {
    public string Name => "Other Filters";
    
    public bool Disabled => false;
    
    public SortingRule SortingRule { get; } = rule;
    
    public string FirstLabel => "Range Filters";
    
    public string SecondLabel => "Item Rarity Filter";

    public void DrawLeftSideContents() {
        SortingRule.ItemLevelFilter.DrawConfig();
        SortingRule.VendorPriceFilter.DrawConfig();
    }

    public void DrawRightSideContents() {
        foreach (var enumValue in Enum.GetValues<ItemRarity>()) {
            var enabled = SortingRule.AllowedItemRarities.Contains(enumValue);
            if (ImGuiComponents.ToggleButton($"{enumValue.GetDescription()}", ref enabled)) {
                if (enabled) SortingRule.AllowedItemRarities.Add(enumValue);
                if (!enabled) SortingRule.AllowedItemRarities.Remove(enumValue);
            }

            ImGui.SameLine();
            ImGui.SetCursorPosY(ImGui.GetCursorPosY() + 3.0f);
            ImGui.TextUnformatted(enumValue.GetDescription());
        }
    }
}