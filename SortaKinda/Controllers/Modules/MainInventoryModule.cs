﻿using System.Collections.Generic;
using System.Numerics;
using FFXIVClientStructs.FFXIV.Client.Game;
using SortaKinda.Interfaces;
using SortaKinda.Models.Configuration;
using SortaKinda.Models.Enum;
using SortaKinda.Views.SortControllerViews;

namespace SortaKinda.System.Modules;

public class MainInventoryModule : ModuleBase
{
    public override ModuleName ModuleName { get; protected set; } = ModuleName.MainInventory;
    protected override IModuleConfig ModuleConfig { get; set; } = new MainInventoryConfig();

    private List<IInventoryGrid>? inventories;
    private QuadInventoryView? view;
    
    protected override void Load()
    {
        inventories = new List<IInventoryGrid>
        {
            new InventoryGrid(InventoryType.Inventory1, ModuleConfig.InventoryConfigs[0]),
            new InventoryGrid(InventoryType.Inventory2, ModuleConfig.InventoryConfigs[1]),
            new InventoryGrid(InventoryType.Inventory3, ModuleConfig.InventoryConfigs[2]),
            new InventoryGrid(InventoryType.Inventory4, ModuleConfig.InventoryConfigs[3]),
        };

        view = new QuadInventoryView(inventories, Vector2.Zero);
    }

    public override void Draw()
    {
        view?.Draw();
    }
    
    protected override void Update()
    {

    }

    protected override void Sort()
    {
        
    }
}