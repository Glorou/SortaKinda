﻿using System.Collections.Generic;
using System.Linq;
using FFXIVClientStructs.FFXIV.Client.Game;
using SortaKinda.Models.Configuration;
using SortaKinda.Models.Inventory;

namespace SortaKinda.System;

public class InventoryGrid {
    public InventoryGrid(InventoryType type, InventoryConfig config) {
        Type = type;
        Config = config;
        Inventory = [];

        foreach (var index in Enumerable.Range(0, InventoryController.GetInventoryPageSize(Type))) {
            Inventory.Add(new InventorySlot(Type, config.SlotConfigs[index], index));
        }
    }

    public InventoryConfig Config { get; init; }
    
    public InventoryType Type { get; }
    
    public List<InventorySlot> Inventory { get; set; }
}