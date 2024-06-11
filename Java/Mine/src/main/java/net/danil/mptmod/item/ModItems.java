package net.danil.mptmod.item;

import net.danil.mptmod.MptMod;
import net.danil.mptmod.item.armor.AmberArmorItem;
import net.danil.mptmod.item.armor.ModArmorMaterials;
import net.danil.mptmod.item.tools.*;
import net.minecraft.world.entity.EquipmentSlot;
import net.minecraft.world.item.Item;
import net.minecraftforge.eventbus.api.IEventBus;
import net.minecraftforge.registries.DeferredRegister;
import net.minecraftforge.registries.ForgeRegistries;
import net.minecraftforge.registries.RegistryObject;

public class ModItems {
    public static final DeferredRegister<Item> ITEMS =
            DeferredRegister.create(ForgeRegistries.ITEMS, MptMod.MOD_ID);

    public static final RegistryObject<Item> AMBER = ITEMS.register("amber",
            () -> new Item(new Item.Properties().tab(ModCreativeModeTab.MPT_TAB)));

    public static final RegistryObject<Item> AMBER_RAW = ITEMS.register("amber_raw",
            () -> new Item(new Item.Properties().tab(ModCreativeModeTab.MPT_TAB)));

    public static final RegistryObject<Item> AMBER_BOOTS = ITEMS.register("amber_boots",
            ()-> new AmberArmorItem(ModArmorMaterials.AMBER, EquipmentSlot.FEET, new Item.Properties().tab(ModCreativeModeTab.MPT_TAB)));

    public static final RegistryObject<Item> AMBER_HELMET = ITEMS.register("amber_helmet",
            ()-> new AmberArmorItem(ModArmorMaterials.AMBER, EquipmentSlot.HEAD, new Item.Properties().tab(ModCreativeModeTab.MPT_TAB)));

    public static final RegistryObject<Item> AMBER_CHESTPLATE = ITEMS.register("amber_chestplate",
            ()-> new AmberArmorItem(ModArmorMaterials.AMBER, EquipmentSlot.CHEST, new Item.Properties().tab(ModCreativeModeTab.MPT_TAB)));

    public static final RegistryObject<Item> AMBER_LEGGINS = ITEMS.register("amber_leggings",
            ()-> new AmberArmorItem(ModArmorMaterials.AMBER, EquipmentSlot.LEGS, new Item.Properties().tab(ModCreativeModeTab.MPT_TAB)));

    public static final RegistryObject<Item> AMBER_AXE = ITEMS.register("amber_axe",
            ()->new AmberAxeItem(ModTiers.AMBER, 6.0F, -3.1F, new Item.Properties().tab(ModCreativeModeTab.MPT_TAB)));

    public static final RegistryObject<Item> AMBER_PICKAXE = ITEMS.register("amber_pickaxe",
            ()->new AmberPickaxeItem(ModTiers.AMBER, 1, -2.8F, new Item.Properties().tab(ModCreativeModeTab.MPT_TAB)));

    public static final RegistryObject<Item> AMBER_SWORD = ITEMS.register("amber_sword",
            ()->new AmberSwordItem(ModTiers.AMBER, 3, -2.4F, new Item.Properties().tab(ModCreativeModeTab.MPT_TAB)));

    public static final RegistryObject<Item> AMBER_SHOVEL = ITEMS.register("amber_shovel",
            ()->new AmberShovelItem(ModTiers.AMBER, 6.0F, -3.1F, new Item.Properties().tab(ModCreativeModeTab.MPT_TAB)));

    public static final RegistryObject<Item> AMBER_HOE = ITEMS.register("amber_hoe",
            ()->new AmberHoeItem(ModTiers.AMBER, -3, 0.0F, new Item.Properties().tab(ModCreativeModeTab.MPT_TAB)));

    public static void register(IEventBus eventBus){
        ITEMS.register(eventBus);
    }
}
