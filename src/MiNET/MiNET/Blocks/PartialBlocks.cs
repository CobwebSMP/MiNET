#region LICENSE

// The contents of this file are subject to the Common Public Attribution
// License Version 1.0. (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
// https://github.com/NiclasOlofsson/MiNET/blob/master/LICENSE.
// The License is based on the Mozilla Public License Version 1.1, but Sections 14
// and 15 have been added to cover use of software over a computer network and
// provide for limited attribution for the Original Developer. In addition, Exhibit A has
// been modified to be consistent with Exhibit B.
// 
// Software distributed under the License is distributed on an "AS IS" basis,
// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for
// the specific language governing rights and limitations under the License.
// 
// The Original Code is MiNET.
// 
// The Original Developer is the Initial Developer.  The Initial Developer of
// the Original Code is Niclas Olofsson.
// 
// All portions of the code written by Niclas Olofsson are Copyright (c) 2014-2023 Niclas Olofsson.
// All Rights Reserved.

#endregion

using System;
using System.Collections.Generic;
using MiNET.Utils;

#pragma warning disable 1522

namespace MiNET.Blocks
{
	//Minecraft Bedrock Edition 1.13.0 Blockstates
    public partial class StoneSlab // 44 typeof=StoneSlab
    {
        public override string Name => "minecraft:stone_slab";

        [StateEnum("brick","cobblestone","wood","stone_brick","sandstone","quartz","smooth_stone","nether_brick")]
        public string StoneSlabType { get; set; } = "smooth_stone";
        [StateBit] public bool TopSlotBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "stone_slab_type":
                        StoneSlabType = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "top_slot_bit":
                        TopSlotBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:stone_slab";
            record.Id = 44;
            record.States.Add(new BlockStateString {Name = "stone_slab_type", Value = StoneSlabType});
            record.States.Add(new BlockStateByte {Name = "top_slot_bit", Value = Convert.ToByte(TopSlotBit)});
            return record;
        } // method
    } // class

	public partial class StoneSlab2 // 182 typeof=StoneSlab2
	{
		public override string Name => "minecraft:stone_slab2";

		[StateEnum("red_sandstone", "red_nether_brick", "mossy_cobblestone", "prismarine_dark", "prismarine_rough", "smooth_sandstone", "prismarine_brick", "purpur")]
		public string StoneSlabType2 { get; set; } = "red_sandstone";
		[StateBit] public bool TopSlotBit { get; set; } = false;

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "stone_slab_type_2":
						StoneSlabType2 = s.Value;
						break;
					case BlockStateByte s when s.Name == "top_slot_bit":
						TopSlotBit = Convert.ToBoolean(s.Value);
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:stone_slab2";
			record.Id = 182;
			record.States.Add(new BlockStateString { Name = "stone_slab_type_2", Value = StoneSlabType2 });
			record.States.Add(new BlockStateByte { Name = "top_slot_bit", Value = Convert.ToByte(TopSlotBit) });
			return record;
		} // method
	} // class

	public partial class StoneSlab3 // 417 typeof=StoneSlab3
	{
		public override string Name => "minecraft:stone_slab3";

		[StateEnum("end_stone_brick", "granite", "andesite", "polished_granite", "diorite", "polished_andesite", "smooth_red_sandstone", "polished_diorite")]
		public string StoneSlabType3 { get; set; } = "end_stone_brick";
		[StateBit] public bool TopSlotBit { get; set; } = false;

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "stone_slab_type_3":
						StoneSlabType3 = s.Value;
						break;
					case BlockStateByte s when s.Name == "top_slot_bit":
						TopSlotBit = Convert.ToBoolean(s.Value);
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:stone_slab3";
			record.Id = 417;
			record.States.Add(new BlockStateString { Name = "stone_slab_type_3", Value = StoneSlabType3 });
			record.States.Add(new BlockStateByte { Name = "top_slot_bit", Value = Convert.ToByte(TopSlotBit) });
			return record;
		} // method
	} // class

	public partial class StoneSlab4 // 421 typeof=StoneSlab4
	{
		public override string Name => "minecraft:stone_slab4";

		[StateEnum("cut_sandstone", "stone", "smooth_quartz", "cut_red_sandstone", "mossy_stone_brick")]
		public string StoneSlabType4 { get; set; } = "mossy_stone_brick";
		[StateBit] public bool TopSlotBit { get; set; } = false;

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "stone_slab_type_4":
						StoneSlabType4 = s.Value;
						break;
					case BlockStateByte s when s.Name == "top_slot_bit":
						TopSlotBit = Convert.ToBoolean(s.Value);
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:stone_slab4";
			record.Id = 421;
			record.States.Add(new BlockStateString { Name = "stone_slab_type_4", Value = StoneSlabType4 });
			record.States.Add(new BlockStateByte { Name = "top_slot_bit", Value = Convert.ToByte(TopSlotBit) });
			return record;
		} // method
	} // class

	public partial class DoubleStoneSlab // 43 typeof=DoubleStoneSlab
	{
		public override string Name => "minecraft:double_stone_slab";

		[StateEnum("brick", "cobblestone", "wood", "stone_brick", "quartz", "nether_brick", "smooth_stone", "sandstone")]
		public string StoneSlabType { get; set; } = "smooth_stone";
		[StateBit] public bool TopSlotBit { get; set; } = false;

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "stone_slab_type":
						StoneSlabType = s.Value;
						break;
					case BlockStateByte s when s.Name == "top_slot_bit":
						TopSlotBit = Convert.ToBoolean(s.Value);
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:double_stone_slab";
			record.Id = 43;
			record.States.Add(new BlockStateString { Name = "stone_slab_type", Value = StoneSlabType });
			record.States.Add(new BlockStateByte { Name = "top_slot_bit", Value = Convert.ToByte(TopSlotBit) });
			return record;
		} // method
	} // class

	public partial class DoubleStoneSlab2 // 181 typeof=DoubleStoneSlab2
	{
		public override string Name => "minecraft:double_stone_slab2";

		[StateEnum("red_nether_brick", "prismarine_rough", "red_sandstone", "purpur", "mossy_cobblestone", "prismarine_dark", "prismarine_brick", "smooth_sandstone")]
		public string StoneSlabType2 { get; set; } = "red_sandstone";
		[StateBit] public bool TopSlotBit { get; set; } = false;

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "stone_slab_type_2":
						StoneSlabType2 = s.Value;
						break;
					case BlockStateByte s when s.Name == "top_slot_bit":
						TopSlotBit = Convert.ToBoolean(s.Value);
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:double_stone_slab2";
			record.Id = 181;
			record.States.Add(new BlockStateString { Name = "stone_slab_type_2", Value = StoneSlabType2 });
			record.States.Add(new BlockStateByte { Name = "top_slot_bit", Value = Convert.ToByte(TopSlotBit) });
			return record;
		} // method
	} // class

	public partial class DoubleStoneSlab3 // 422 typeof=DoubleStoneSlab3
	{
		public override string Name => "minecraft:double_stone_slab3";

		[StateEnum("granite", "polished_diorite", "end_stone_brick", "polished_granite", "andesite", "polished_andesite", "diorite", "smooth_red_sandstone")]
		public string StoneSlabType3 { get; set; } = "end_stone_brick";
		[StateBit] public bool TopSlotBit { get; set; } = false;

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "stone_slab_type_3":
						StoneSlabType3 = s.Value;
						break;
					case BlockStateByte s when s.Name == "top_slot_bit":
						TopSlotBit = Convert.ToBoolean(s.Value);
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:double_stone_slab3";
			record.Id = 422;
			record.States.Add(new BlockStateString { Name = "stone_slab_type_3", Value = StoneSlabType3 });
			record.States.Add(new BlockStateByte { Name = "top_slot_bit", Value = Convert.ToByte(TopSlotBit) });
			return record;
		} // method
	} // class

	public partial class DoubleStoneSlab4 // 423 typeof=DoubleStoneSlab4
	{
		public override string Name => "minecraft:double_stone_slab4";

		[StateEnum("mossy_stone_brick", "stone", "smooth_quartz", "cut_sandstone", "cut_red_sandstone")]
		public string StoneSlabType4 { get; set; } = "mossy_stone_brick";
		[StateBit] public bool TopSlotBit { get; set; } = false;

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "stone_slab_type_4":
						StoneSlabType4 = s.Value;
						break;
					case BlockStateByte s when s.Name == "top_slot_bit":
						TopSlotBit = Convert.ToBoolean(s.Value);
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:double_stone_slab4";
			record.Id = 423;
			record.States.Add(new BlockStateString { Name = "stone_slab_type_4", Value = StoneSlabType4 });
			record.States.Add(new BlockStateByte { Name = "top_slot_bit", Value = Convert.ToByte(TopSlotBit) });
			return record;
		} // method
	} // class

	public partial class Fence // 85 typeof=Fence
	{
		public override string Name => "minecraft:fence";

		[StateEnum("jungle", "spruce", "birch", "dark_oak", "acacia", "oak")]
		public string WoodType { get; set; } = "oak";

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "wood_type":
						WoodType = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:fence";
			record.Id = 85;
			record.States.Add(new BlockStateString { Name = "wood_type", Value = WoodType });
			return record;
		} // method
	} // class

	public partial class Concrete // 236 typeof=Concrete
	{
		public override string Name => "minecraft:concrete";

		[StateEnum("green", "orange", "light_blue", "black", "red", "yellow", "blue", "brown", "lime", "pink", "gray", "purple", "magenta", "cyan", "white", "silver")]
		public string Color { get; set; } = "white";

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "color":
						Color = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:concrete";
			record.Id = 236;
			record.States.Add(new BlockStateString { Name = "color", Value = Color });
			return record;
		} // method
	} // class

	public partial class ConcretePowder // 237 typeof=ConcretePowder
	{
		public override string Name => "minecraft:concrete_powder";

		[StateEnum("light_blue", "gray", "pink", "red", "silver", "white", "cyan", "magenta", "brown", "lime", "purple", "orange", "yellow", "blue", "black", "green")]
		public string Color { get; set; } = "white";

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "color":
						Color = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:concretePowder";
			record.Id = 237;
			record.States.Add(new BlockStateString { Name = "color", Value = Color });
			return record;
		} // method
	} // class

	public partial class Wool // 35 typeof=Wool
	{
		public override string Name => "minecraft:wool";

		[StateEnum("light_blue", "gray", "orange", "red", "silver", "green", "pink", "black", "yellow", "brown", "blue", "cyan", "purple", "white", "lime", "magenta")]
		public string Color { get; set; } = "white";

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "color":
						Color = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:wool";
			record.Id = 35;
			record.States.Add(new BlockStateString { Name = "color", Value = Color });
			return record;
		} // method
	} // class

	public partial class StainedGlass // 241 typeof=StainedGlass
	{
		public override string Name => "minecraft:stained_glass";

		[StateEnum("brown", "purple", "light_blue", "cyan", "silver", "black", "pink", "orange", "white", "green", "magenta", "gray", "blue", "lime", "red", "yellow")]
		public string Color { get; set; } = "white";

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "color":
						Color = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:stained_glass";
			record.Id = 241;
			record.States.Add(new BlockStateString { Name = "color", Value = Color });
			return record;
		} // method
	} // class

	public partial class StainedGlassPane // 160 typeof=StainedGlassPane
	{
		public override string Name => "minecraft:stained_glass_pane";

		[StateEnum("black", "lime", "yellow", "light_blue", "white", "purple", "pink", "red", "magenta", "orange", "green", "silver", "gray", "blue", "cyan", "brown")]
		public string Color { get; set; } = "white";

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "color":
						Color = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:stained_glass_pane";
			record.Id = 160;
			record.States.Add(new BlockStateString { Name = "color", Value = Color });
			return record;
		} // method
	} // class

	public partial class Carpet // 171 typeof=Carpet
	{
		public override string Name => "minecraft:carpet";

		[StateEnum("magenta", "blue", "silver", "red", "yellow", "light_blue", "white", "lime", "pink", "green", "purple", "black", "cyan", "gray", "orange", "brown")]
		public string Color { get; set; } = "white";

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "color":
						Color = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:carpet";
			record.Id = 171;
			record.States.Add(new BlockStateString { Name = "color", Value = Color });
			return record;
		} // method
	} // class

	public partial class StainedHardenedClay // 159 typeof=StainedHardenedClay
	{
		public override string Name => "minecraft:stained_hardened_clay";

		[StateEnum("pink", "gray", "lime", "red", "blue", "cyan", "green", "light_blue", "orange", "black", "yellow", "magenta", "brown", "white", "silver", "purple")]
		public string Color { get; set; } = "white";

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "color":
						Color = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:stained_hardened_clay";
			record.Id = 159;
			record.States.Add(new BlockStateString { Name = "color", Value = Color });
			return record;
		} // method
	} // class

	public partial class Wood // 467 typeof=Wood
	{
		public override string Name => "minecraft:wood";
		public string woodType { get; set; } = "oak";
		public string PillarAxis { get; set; } = "y";
		public bool StrippedBit { get; set; } = false;
		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "wood_type":
						woodType = s.Value;
						break;
					case BlockStateString s when s.Name == "pillar_axis":
						PillarAxis = s.Value;
						break;
					case BlockStateByte s when s.Name == "stripped_bit":
						StrippedBit = Convert.ToBoolean(s.Value);
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:wood";
			record.Id = 467;
			record.States.Add(new BlockStateString { Name = "pillar_axis", Value = PillarAxis });
			record.States.Add(new BlockStateByte { Name = "stripped_bit", Value = Convert.ToByte(StrippedBit) });
			record.States.Add(new BlockStateString { Name = "wood_type", Value = woodType });
			return record;
		} // method
	} // class

	public partial class Log // 17 typeof=Log
	{
		public override string Name => "minecraft:log";

		[StateEnum("spruce", "birch", "jungle", "oak")]
		public string OldLogType { get; set; } = "oak";
		[StateEnum("y", "x", "z")]
		public string PillarAxis { get; set; } = "y";

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "old_log_type":
						OldLogType = s.Value;
						break;
					case BlockStateString s when s.Name == "pillar_axis":
						PillarAxis = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:log";
			record.Id = 17;
			record.States.Add(new BlockStateString { Name = "old_log_type", Value = OldLogType });
			record.States.Add(new BlockStateString { Name = "pillar_axis", Value = PillarAxis });
			return record;
		} // method
	} // class

	public partial class Log2 // 162 typeof=Log2
	{
		public override string Name => "minecraft:log2";

		[StateEnum("dark_oak", "acacia")]
		public string NewLogType { get; set; } = "acacia";
		[StateEnum("y", "z", "x")]
		public string PillarAxis { get; set; } = "y";

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "new_log_type":
						NewLogType = s.Value;
						break;
					case BlockStateString s when s.Name == "pillar_axis":
						PillarAxis = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:log2";
			record.Id = 162;
			record.States.Add(new BlockStateString { Name = "new_log_type", Value = NewLogType });
			record.States.Add(new BlockStateString { Name = "pillar_axis", Value = PillarAxis });
			return record;
		} // method
	} // class

	public partial class ShulkerBox // 218 typeof=ShulkerBox
	{
		public override string Name => "minecraft:shulker_box";

		[StateEnum("light_blue", "pink", "lime", "orange", "purple", "brown", "white", "black", "magenta", "yellow", "cyan", "green", "gray", "blue", "silver", "red")]
		public string Color { get; set; } = "white";

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "color":
						Color = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:shulker_box";
			record.Id = 218;
			record.States.Add(new BlockStateString { Name = "color", Value = Color });
			return record;
		} // method
	} // class

	public partial class UndyedShulkerBox // 205 typeof=UndyedShulkerBox
	{
		public override string Name => "minecraft:undyed_shulker_box";
		public string blockName { get; set; } = "minecraft:undyed_shulker_box";
		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = blockName;
			record.Id = 205;
			return record;
		} // method
	} // class


	public partial class AcaciaButton  // 395 typeof=AcaciaButton
    {
		public override string Name => "minecraft:acacia_button";
		[StateBit] public override bool ButtonPressedBit { get; set; } = false;
        [StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "button_pressed_bit":
                        ButtonPressedBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "facing_direction":
						FacingDirection = s.Value;
						Direction = s.Value;
						break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:acacia_button";
            record.Id = 395;
            record.States.Add(new BlockStateByte {Name = "button_pressed_bit", Value = Convert.ToByte(ButtonPressedBit)});
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class AcaciaDoor  // 196 typeof=AcaciaDoor
    {
		public override string Name => "minecraft:acacia_door";
		[StateRange(0, 3)] public override int Direction { get; set; } = 0;
        [StateBit] public override bool DoorHingeBit { get; set; } = false;
        [StateBit] public override bool OpenBit { get; set; } = false;
        [StateBit] public override bool UpperBlockBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
						fDirection = s.Value;
						break;
                    case BlockStateByte s when s.Name == "door_hinge_bit":
                        DoorHingeBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "open_bit":
                        OpenBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "upper_block_bit":
                        UpperBlockBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:acacia_door";
            record.Id = 196;
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "door_hinge_bit", Value = Convert.ToByte(DoorHingeBit)});
            record.States.Add(new BlockStateByte {Name = "open_bit", Value = Convert.ToByte(OpenBit)});
            record.States.Add(new BlockStateByte {Name = "upper_block_bit", Value = Convert.ToByte(UpperBlockBit)});
            return record;
        } // method
    } // class

    public partial class AcaciaFenceGate  // 187 typeof=AcaciaFenceGate
    {
		public override string Name => "minecraft:acacia_fence_gate";
		[StateRange(0, 3)] public override int Direction { get; set; } = 0;
        [StateBit] public  bool InWallBit { get; set; } = false;
        [StateBit] public override bool OpenBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "in_wall_bit":
                        InWallBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "open_bit":
                        OpenBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:acacia_fence_gate";
            record.Id = 187;
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "in_wall_bit", Value = Convert.ToByte(InWallBit)});
            record.States.Add(new BlockStateByte {Name = "open_bit", Value = Convert.ToByte(OpenBit)});
            return record;
        } // method
    } // class

    public partial class AcaciaPressurePlate : PressurePlateBase // 405 typeof=AcaciaPressurePlate
	{
		public override string Name => "minecraft:acacia_pressure_plate";
		public override int RedstoneSignal { get; set; } = 0;
        
        public AcaciaPressurePlate() : base(405)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "redstone_signal":
                        RedstoneSignal = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:acacia_pressure_plate";
            record.Id = 405;
            record.States.Add(new BlockStateInt {Name = "redstone_signal", Value = RedstoneSignal});
            return record;
        } // method
    } // class

    public partial class AcaciaStairs  // 163 typeof=AcaciaStairs
    {
		public override string Name => "minecraft:acacia_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:acacia_stairs";
            record.Id = 163;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class AcaciaStandingSign  // 445 typeof=AcaciaStandingSign
    {
		public override string Name => "minecraft:acacia_standing_sign";
		[StateRange(0, 15)] public  int GroundSignDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "ground_sign_direction":
                        GroundSignDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:acacia_standing_sign";
            record.Id = 445;
            record.States.Add(new BlockStateInt {Name = "ground_sign_direction", Value = GroundSignDirection});
            return record;
        } // method
    } // class

    public partial class AcaciaTrapdoor  // 400 typeof=AcaciaTrapdoor
    {
		public override string Name => "minecraft:acacia_trapdoor";
		[StateRange(0, 3)] public override int Direction { get; set; } = 0;
        [StateBit] public override bool OpenBit { get; set; } = false;
        [StateBit] public override bool UpsideDownBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "open_bit":
                        OpenBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:acacia_trapdoor";
            record.Id = 400;
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "open_bit", Value = Convert.ToByte(OpenBit)});
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            return record;
        } // method
    } // class

    public partial class AcaciaWallSign  // 446 typeof=AcaciaWallSign
    {
		public override string Name => "minecraft:acacia_wall_sign";
		[StateRange(0, 5)] public  int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:acacia_wall_sign";
            record.Id = 446;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class ActivatorRail  // 126 typeof=ActivatorRail
    {
		public override string Name => "minecraft:activator_rail";
		[StateBit] public  bool RailDataBit { get; set; } = false;
        [StateRange(0, 5)] public  int RailDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "rail_data_bit":
                        RailDataBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "rail_direction":
                        RailDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:activator_rail";
            record.Id = 126;
            record.States.Add(new BlockStateByte {Name = "rail_data_bit", Value = Convert.ToByte(RailDataBit)});
            record.States.Add(new BlockStateInt {Name = "rail_direction", Value = RailDirection});
            return record;
        } // method
    } // class

    public partial class Air  // 0 typeof=Air
    {
		public override string Name => "minecraft:air";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:air";
            record.Id = 0;
            return record;
        } // method
    } // class

    public partial class Allow : Block // 210 typeof=Allow
	{
		public override string Name => "minecraft:allow";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:allow";
            record.Id = 210;
            return record;
        } // method
    } // class

    public partial class AndesiteStairs  // 426 typeof=AndesiteStairs
    {
		public override string Name => "minecraft:andesite_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:andesite_stairs";
            record.Id = 426;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class Anvil  // 145 typeof=Anvil
    {
		public override string Name => "minecraft:anvil";
		public  string Damage { get; set; } = "undamaged";
		[StateRange(0, 3)] public int Direction { get; set; } = 0;

		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "damage":
                        Damage = s.Value;
                        break;
					case BlockStateInt s when s.Name == "direction":
						Direction = s.Value;
						break;
				} // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:anvil";
            record.Id = 145;
            record.States.Add(new BlockStateString {Name = "damage", Value = Damage});
			record.States.Add(new BlockStateInt { Name = "direction", Value = Direction });
			return record;
        } // method
    } // class

    public partial class Bamboo : Block // 418 typeof=Bamboo
    {
		public override string Name => "minecraft:bamboo";
		[StateBit] public  bool AgeBit { get; set; } = false;
        [StateEnum("small_leaves","large_leaves","no_leaves")]
        public  string BambooLeafSize { get; set; } = "";
        [StateEnum("thin","thick")]
        public  string BambooStalkThickness { get; set; } = "";
        
        public Bamboo() : base(418)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "age_bit":
                        AgeBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateString s when s.Name == "bamboo_leaf_size":
                        BambooLeafSize = s.Value;
                        break;
                    case BlockStateString s when s.Name == "bamboo_stalk_thickness":
                        BambooStalkThickness = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:bamboo";
            record.Id = 418;
            record.States.Add(new BlockStateByte {Name = "age_bit", Value = Convert.ToByte(AgeBit)});
            record.States.Add(new BlockStateString {Name = "bamboo_leaf_size", Value = BambooLeafSize});
            record.States.Add(new BlockStateString {Name = "bamboo_stalk_thickness", Value = BambooStalkThickness});
            return record;
        } // method
    } // class

    public partial class BambooSapling : Block // 419 typeof=BambooSapling
    {
		public override string Name => "minecraft:bamboo_sapling";
		[StateBit] public  bool AgeBit { get; set; } = false;
        [StateEnum("spruce","birch","jungle","acacia","dark_oak","oak")]
        public  string SaplingType { get; set; } = "";
        
        public BambooSapling() : base(419)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "age_bit":
                        AgeBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateString s when s.Name == "sapling_type":
                        SaplingType = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:bamboo_sapling";
            record.Id = 419;
            record.States.Add(new BlockStateByte {Name = "age_bit", Value = Convert.ToByte(AgeBit)});
            record.States.Add(new BlockStateString {Name = "sapling_type", Value = SaplingType});
            return record;
        } // method
    } // class

    public partial class Barrel : Block // 458 typeof=Barrel
    {
		public override string Name => "minecraft:barrel";
		public int FacingDirection { get; set; } = 2;
        public bool OpenBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
					case BlockStateInt s when s.Name == "facing_direction":
						FacingDirection = s.Value;
						break;
					case BlockStateByte s when s.Name == "open_bit":
						OpenBit = Convert.ToBoolean(s.Value);
						break;
				} // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:barrel";
            record.Id = 458;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            record.States.Add(new BlockStateByte {Name = "open_bit", Value = Convert.ToByte(OpenBit)});
            return record;
        } // method
    } // class

    public partial class Barrier : Block // 416 typeof=Barrier
    {
		public override string Name => "minecraft:barrier";
		public Barrier() : base(416)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:barrier";
            record.Id = 416;
            return record;
        } // method
    } // class

    public partial class Beacon  // 138 typeof=Beacon
    {
		public override string Name => "minecraft:beacon";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:beacon";
            record.Id = 138;
            return record;
        } // method
    } // class

    public partial class Bed  // 26 typeof=Bed
    {
		public override string Name => "minecraft:bed";
		[StateRange(0, 3)] public  int Direction { get; set; } = 0;
        [StateBit] public  bool HeadPieceBit { get; set; } = false;
        [StateBit] public  bool OccupiedBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "head_piece_bit":
                        HeadPieceBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "occupied_bit":
                        OccupiedBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:bed";
            record.Id = 26;
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "head_piece_bit", Value = Convert.ToByte(HeadPieceBit)});
            record.States.Add(new BlockStateByte {Name = "occupied_bit", Value = Convert.ToByte(OccupiedBit)});
            return record;
        } // method
    } // class

    public partial class Bedrock  // 7 typeof=Bedrock
    {
		public override string Name => "minecraft:bedrock";
		[StateBit] public  bool InfiniburnBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "infiniburn_bit":
                        InfiniburnBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:bedrock";
            record.Id = 7;
            record.States.Add(new BlockStateByte {Name = "infiniburn_bit", Value = Convert.ToByte(InfiniburnBit)});
            return record;
        } // method
    } // class

    public partial class Beetroot  // 244 typeof=Beetroot
    {
		public override string Name => "minecraft:beetroot";
		[StateRange(0, 7)] public override int Growth { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "growth":
                        Growth = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:beetroot";
            record.Id = 244;
            record.States.Add(new BlockStateInt {Name = "growth", Value = Growth});
            return record;
        } // method
    } // class

    public partial class Bell : Block // 461 typeof=Bell
    {
		public override string Name => "minecraft:bell";
		[StateEnum("standing","hanging","side","multiple")]
        public  string Attachment { get; set; } = "standing";
        [StateRange(0, 3)] public  int Direction { get; set; } = 0;
        [StateBit] public  bool ToggleBit { get; set; } = false;
        
        public Bell() : base(461)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "attachment":
                        Attachment = s.Value;
                        break;
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "toggle_bit":
                        ToggleBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:bell";
            record.Id = 461;
            record.States.Add(new BlockStateString {Name = "attachment", Value = Attachment});
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "toggle_bit", Value = Convert.ToByte(ToggleBit)});
            return record;
        } // method
    } // class

    public partial class BirchButton  // 396 typeof=BirchButton
    {
		public override string Name => "minecraft:birch_button";
		[StateBit] public override bool ButtonPressedBit { get; set; } = false;
        [StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "button_pressed_bit":
                        ButtonPressedBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
						Direction = s.Value;
						break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:birch_button";
            record.Id = 396;
            record.States.Add(new BlockStateByte {Name = "button_pressed_bit", Value = Convert.ToByte(ButtonPressedBit)});
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class BirchDoor  // 194 typeof=BirchDoor
    {
		public override string Name => "minecraft:birch_door";
		[StateRange(0, 3)] public override int Direction { get; set; } = 0;
        [StateBit] public override bool DoorHingeBit { get; set; } = false;
        [StateBit] public override bool OpenBit { get; set; } = false;
        [StateBit] public override bool UpperBlockBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
						fDirection = s.Value;
						break;
                    case BlockStateByte s when s.Name == "door_hinge_bit":
                        DoorHingeBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "open_bit":
                        OpenBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "upper_block_bit":
                        UpperBlockBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:birch_door";
            record.Id = 194;
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "door_hinge_bit", Value = Convert.ToByte(DoorHingeBit)});
            record.States.Add(new BlockStateByte {Name = "open_bit", Value = Convert.ToByte(OpenBit)});
            record.States.Add(new BlockStateByte {Name = "upper_block_bit", Value = Convert.ToByte(UpperBlockBit)});
            return record;
        } // method
    } // class

    public partial class BirchFenceGate  // 184 typeof=BirchFenceGate
    {
		public override string Name => "minecraft:birch_fence_gate";
		[StateRange(0, 3)] public override int Direction { get; set; } = 0;
        [StateBit] public  bool InWallBit { get; set; } = false;
        [StateBit] public override bool OpenBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "in_wall_bit":
                        InWallBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "open_bit":
                        OpenBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:birch_fence_gate";
            record.Id = 184;
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "in_wall_bit", Value = Convert.ToByte(InWallBit)});
            record.States.Add(new BlockStateByte {Name = "open_bit", Value = Convert.ToByte(OpenBit)});
            return record;
        } // method
    } // class

    public partial class BirchPressurePlate : PressurePlateBase // 406 typeof=BirchPressurePlate
	{
		public override string Name => "minecraft:birch_pressure_plate";
		public override int RedstoneSignal { get; set; } = 0;
        
        public BirchPressurePlate() : base(406)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "redstone_signal":
                        RedstoneSignal = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:birch_pressure_plate";
            record.Id = 406;
            record.States.Add(new BlockStateInt {Name = "redstone_signal", Value = RedstoneSignal});
            return record;
        } // method
    } // class

    public partial class BirchStairs  // 135 typeof=BirchStairs
    {
		public override string Name => "minecraft:birch_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:birch_stairs";
            record.Id = 135;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class BirchStandingSign  // 441 typeof=BirchStandingSign
    {
		public override string Name => "minecraft:birch_standing_sign";
		[StateRange(0, 15)] public  int GroundSignDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "ground_sign_direction":
                        GroundSignDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:birch_standing_sign";
            record.Id = 441;
            record.States.Add(new BlockStateInt {Name = "ground_sign_direction", Value = GroundSignDirection});
            return record;
        } // method
    } // class

    public partial class BirchTrapdoor  // 401 typeof=BirchTrapdoor
    {
		public override string Name => "minecraft:birch_trapdoor";
		[StateRange(0, 3)] public override int Direction { get; set; } = 0;
        [StateBit] public override bool OpenBit { get; set; } = false;
        [StateBit] public override bool UpsideDownBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "open_bit":
                        OpenBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:birch_trapdoor";
            record.Id = 401;
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "open_bit", Value = Convert.ToByte(OpenBit)});
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            return record;
        } // method
    } // class

    public partial class BirchWallSign  // 442 typeof=BirchWallSign
    {
		public override string Name => "minecraft:birch_wall_sign";
		[StateRange(0, 5)] public  int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:birch_wall_sign";
            record.Id = 442;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class BlackGlazedTerracotta  // 235 typeof=BlackGlazedTerracotta
    {
		public override string Name => "minecraft:black_glazed_terracotta";
		[StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:black_glazed_terracotta";
            record.Id = 235;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class BlastFurnace  // 451 typeof=BlastFurnace
    {
		public override string Name => "minecraft:blast_furnace";
		[StateRange(0, 5)] public int Direction { get; set; } = 2;

		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
					case BlockStateInt s when s.Name == "facing_direction":
						Direction = s.Value;
						break;
				} // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:blast_furnace";
            record.Id = 451;
			record.States.Add(new BlockStateInt { Name = "facing_direction", Value = Direction });
			return record;
        } // method
    } // class

    public partial class BlueGlazedTerracotta  // 231 typeof=BlueGlazedTerracotta
    {
		public override string Name => "minecraft:blue_glazed_terracotta";
		[StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:blue_glazed_terracotta";
            record.Id = 231;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class BlueIce : Block // 266 typeof=BlueIce
    {
		public override string Name => "minecraft:blue_ice";
		public BlueIce() : base(266)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:blue_ice";
            record.Id = 266;
            return record;
        } // method
    } // class

    public partial class BoneBlock : Block // 216 typeof=BoneBlock
    {
		public override string Name => "minecraft:bone_block";
		[StateRange(0, 3)] public  int Deprecated { get; set; } = 0;
        [StateEnum("x","z","y")]
        public  string PillarAxis { get; set; } = "x";
        
        public BoneBlock() : base(216)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "deprecated":
                        Deprecated = s.Value;
                        break;
                    case BlockStateString s when s.Name == "pillar_axis":
                        PillarAxis = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:bone_block";
            record.Id = 216;
            record.States.Add(new BlockStateInt {Name = "deprecated", Value = Deprecated});
            record.States.Add(new BlockStateString {Name = "pillar_axis", Value = PillarAxis});
            return record;
        } // method
    } // class

    public partial class Bookshelf  // 47 typeof=Bookshelf
    {
		public override string Name => "minecraft:bookshelf";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:bookshelf";
            record.Id = 47;
            return record;
        } // method
    } // class

    public partial class BorderBlock  // 212 typeof=BorderBlock
	{
		public override string Name => "minecraft:border_block";
		[StateEnum("none","short","tall")]
        public  string WallConnectionTypeEast { get; set; } = "none";
        [StateEnum("none","short","tall")]
        public  string WallConnectionTypeNorth { get; set; } = "none";
        [StateEnum("none","short","tall")]
        public  string WallConnectionTypeSouth { get; set; } = "none";
        [StateEnum("none","short","tall")]
        public  string WallConnectionTypeWest { get; set; } = "none";
        [StateBit] public  bool WallPostBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "wall_connection_type_east":
                        WallConnectionTypeEast = s.Value;
                        break;
                    case BlockStateString s when s.Name == "wall_connection_type_north":
                        WallConnectionTypeNorth = s.Value;
                        break;
                    case BlockStateString s when s.Name == "wall_connection_type_south":
                        WallConnectionTypeSouth = s.Value;
                        break;
                    case BlockStateString s when s.Name == "wall_connection_type_west":
                        WallConnectionTypeWest = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "wall_post_bit":
                        WallPostBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:border_block";
            record.Id = 0;
            record.States.Add(new BlockStateString {Name = "wall_connection_type_east", Value = WallConnectionTypeEast});
            record.States.Add(new BlockStateString {Name = "wall_connection_type_north", Value = WallConnectionTypeNorth});
            record.States.Add(new BlockStateString {Name = "wall_connection_type_south", Value = WallConnectionTypeSouth});
            record.States.Add(new BlockStateString {Name = "wall_connection_type_west", Value = WallConnectionTypeWest});
            record.States.Add(new BlockStateByte {Name = "wall_post_bit", Value = Convert.ToByte(WallPostBit)});
            return record;
        } // method
    } // class

    public partial class BrewingStand  // 379 typeof=BrewingStand
	{
		public override string Name => "minecraft:brewing_stand";
		[StateBit] public  bool BrewingStandSlotABit { get; set; } = false;
        [StateBit] public  bool BrewingStandSlotBBit { get; set; } = false;
        [StateBit] public  bool BrewingStandSlotCBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "brewing_stand_slot_a_bit":
                        BrewingStandSlotABit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "brewing_stand_slot_b_bit":
                        BrewingStandSlotBBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "brewing_stand_slot_c_bit":
                        BrewingStandSlotCBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:brewing_stand";
            record.Id = 117;
            record.States.Add(new BlockStateByte {Name = "brewing_stand_slot_a_bit", Value = Convert.ToByte(BrewingStandSlotABit)});
            record.States.Add(new BlockStateByte {Name = "brewing_stand_slot_b_bit", Value = Convert.ToByte(BrewingStandSlotBBit)});
            record.States.Add(new BlockStateByte {Name = "brewing_stand_slot_c_bit", Value = Convert.ToByte(BrewingStandSlotCBit)});
            return record;
        } // method
    } // class

    public partial class BrickBlock  // 45 typeof=BrickBlock
    {
		public override string Name => "minecraft:brick_block";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:brick_block";
            record.Id = 45;
            return record;
        } // method
    } // class

    public partial class BrickStairs  // 108 typeof=BrickStairs
    {
		public override string Name => "minecraft:brick_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:brick_stairs";
            record.Id = 108;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class BrownGlazedTerracotta  // 232 typeof=BrownGlazedTerracotta
    {
		public override string Name => "minecraft:brown_glazed_terracotta";
		[StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:brown_glazed_terracotta";
            record.Id = 232;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class BrownMushroom  // 39 typeof=BrownMushroom
    {
		public override string Name => "minecraft:brown_mushroom";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:brown_mushroom";
            record.Id = 39;
            return record;
        } // method
    } // class

    public partial class BrownMushroomBlock  // 99 typeof=BrownMushroomBlock
    {
		public override string Name => "minecraft:brown_mushroom_block";
		[StateRange(0, 15)] public  int HugeMushroomBits { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "huge_mushroom_bits":
                        HugeMushroomBits = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:brown_mushroom_block";
            record.Id = 99;
            record.States.Add(new BlockStateInt {Name = "huge_mushroom_bits", Value = HugeMushroomBits});
            return record;
        } // method
    } // class

    public partial class BubbleColumn : Block // 415 typeof=BubbleColumn
    {
		[StateBit] public  bool DragDown { get; set; } = false;
        
        public BubbleColumn() : base(415)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "drag_down":
                        DragDown = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:bubble_column";
            record.Id = 415;
            record.States.Add(new BlockStateByte {Name = "drag_down", Value = Convert.ToByte(DragDown)});
            return record;
        } // method
    } // class

    public partial class Cactus  // 81 typeof=Cactus
    {
		public override string Name => "minecraft:cactus";
		[StateRange(0, 15)] public  int Age { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "age":
                        Age = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:cactus";
            record.Id = 81;
            record.States.Add(new BlockStateInt {Name = "age", Value = Age});
            return record;
        } // method
    } // class

    public partial class Cake  // 92 typeof=Cake
    {
		public override string Name => "minecraft:cake";
		[StateRange(0, 6)] public  int BiteCounter { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "bite_counter":
                        BiteCounter = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:cake";
            record.Id = 92;
            record.States.Add(new BlockStateInt {Name = "bite_counter", Value = BiteCounter});
            return record;
        } // method
    } // class

    public partial class Campfire : Block // 464 typeof=Campfire
    {
		public override string Name => "minecraft:campfire";
		[StateBit] public  bool Extinguished { get; set; } = false;
        [StateEnum("south","west","north","east")]
		[StateRange(0, 3)] public int Direction { get; set; } = 0;

		public Campfire() : base(464)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "extinguished":
                        Extinguished = Convert.ToBoolean(s.Value);
                        break;
					case BlockStateInt s when s.Name == "direction":
						Direction = s.Value;
						break;
				} // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:campfire";
            record.Id = 464;
            record.States.Add(new BlockStateByte {Name = "extinguished", Value = Convert.ToByte(Extinguished)});
			record.States.Add(new BlockStateInt { Name = "direction", Value = Direction });
			return record;
        } // method
    } // class

    public partial class Carrots  // 141 typeof=Carrots
    {
		public override string Name => "minecraft:carrots";
		[StateRange(0, 7)] public override int Growth { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "growth":
                        Growth = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:carrots";
            record.Id = 141;
            record.States.Add(new BlockStateInt {Name = "growth", Value = Growth});
            return record;
        } // method
    } // class

    public partial class CartographyTable : Block // 455 typeof=CartographyTable
    {
		public override string Name => "minecraft:cartography_table";
		public CartographyTable() : base(455)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:cartography_table";
            record.Id = 455;
            return record;
        } // method
    } // class

    public partial class CarvedPumpkin // 410 typeof=CarvedPumpkin
    {
		public override string Name => "minecraft:carved_pumpkin";
		[StateRange(0, 3)] public int Direction { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
					case BlockStateInt s when s.Name == "direction":
						Direction = s.Value;
						break;
				} // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:carved_pumpkin";
            record.Id = 410;
			record.States.Add(new BlockStateInt { Name = "direction", Value = Direction });
			return record;
        } // method
    } // class

    public partial class Cauldron : Block // 465 typeof=Block
    {
		public override string Name => "minecraft:cauldron";
		[StateEnum("water","powder_snow","lava")]
        public  string CauldronLiquid { get; set; } = "water";
        [StateRange(0, 6)] public  int FillLevel { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "cauldron_liquid":
                        CauldronLiquid = s.Value;
                        break;
                    case BlockStateInt s when s.Name == "fill_level":
                        FillLevel = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:cauldron";
            record.Id = 465;
            record.States.Add(new BlockStateString {Name = "cauldron_liquid", Value = CauldronLiquid});
            record.States.Add(new BlockStateInt {Name = "fill_level", Value = FillLevel});
            return record;
        } // method
    } // class

    public partial class Chain  // 541 typeof=Chain
	{
		public override string Name => "minecraft:chain";
		[StateEnum("y","x","z")]
        public  string PillarAxis { get; set; } = "y";

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "pillar_axis":
                        PillarAxis = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:chain";
            record.Id = 0;
            record.States.Add(new BlockStateString {Name = "pillar_axis", Value = PillarAxis});
            return record;
        } // method
    } // class

    public partial class ChainCommandBlock : Block // 189 typeof=ChainCommandBlock
    {
		public override string Name => "minecraft:chain_command_block";
		[StateBit] public  bool ConditionalBit { get; set; } = false;
        [StateRange(0, 5)] public  int FacingDirection { get; set; } = 2;
        
        public ChainCommandBlock() : base(189)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "conditional_bit":
                        ConditionalBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:chain_command_block";
            record.Id = 189;
            record.States.Add(new BlockStateByte {Name = "conditional_bit", Value = Convert.ToByte(ConditionalBit)});
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class Chest  // 54 typeof=Chest
    {
		public override string Name => "minecraft:chest";
		[StateRange(0, 5)] public int FacingDirection { get; set; } = 2;

		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
					case BlockStateInt s when s.Name == "facing_direction":
						FacingDirection = s.Value;
						break;
				} // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:chest";
            record.Id = 54;
			record.States.Add(new BlockStateInt { Name = "facing_direction", Value = FacingDirection });
			return record;
        } // method
    } // class


    public partial class ChorusFlower  // 200 typeof=ChorusFlower
    {
		public override string Name => "minecraft:chorus_flower";
		[StateRange(0, 5)] public  int Age { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "age":
                        Age = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:chorus_flower";
            record.Id = 200;
            record.States.Add(new BlockStateInt {Name = "age", Value = Age});
            return record;
        } // method
    } // class

    public partial class ChorusPlant  // 240 typeof=ChorusPlant
    {
		public override string Name => "minecraft:chorus_plant";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:chorus_plant";
            record.Id = 240;
            return record;
        } // method
    } // class

    public partial class Clay  // 82 typeof=Clay
    {
		public override string Name => "minecraft:clay";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:clay";
            record.Id = 82;
            return record;
        } // method
    } // class

    public partial class CoalBlock  // 173 typeof=CoalBlock
    {
		public override string Name => "minecraft:coal_block";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:coal_block";
            record.Id = 173;
            return record;
        } // method
    } // class

    public partial class CoalOre  // 16 typeof=CoalOre
    {
		public override string Name => "minecraft:coal_ore";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:coal_ore";
            record.Id = 16;
            return record;
        } // method
    } // class

    public partial class Cobblestone  // 4 typeof=Cobblestone
    {
		public override string Name => "minecraft:cobblestone";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:cobblestone";
            record.Id = 4;
            return record;
        } // method
    } // class

	public partial class CobblestoneWall // 139 typeof=CobblestoneWall
	{
		public override string Name => "minecraft:cobblestone_wall";

		[StateEnum("mossy_cobblestone", "mossy_stone_brick", "andesite", "stone_brick", "granite", "red_nether_brick", "end_brick", "nether_brick", "diorite", "cobblestone", "prismarine", "brick", "red_sandstone", "sandstone")]
		public string WallBlockType { get; set; } = "cobblestone";

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "wall_block_type":
						WallBlockType = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:cobblestone_wall";
			record.Id = 139;
			record.States.Add(new BlockStateString { Name = "wall_block_type", Value = WallBlockType });
			return record;
		} // method
	} // class

	public partial class Cocoa  // 127 typeof=Cocoa
    {
		public override string Name => "minecraft:cocoa";
		[StateRange(0, 2)] public  int Age { get; set; } = 0;
        [StateRange(0, 3)] public  int Direction { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "age":
                        Age = s.Value;
                        break;
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:cocoa";
            record.Id = 127;
            record.States.Add(new BlockStateInt {Name = "age", Value = Age});
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            return record;
        } // method
    } // class

    public partial class CommandBlock : Block // 137 typeof=CommandBlock
    {
		public override string Name => "minecraft:command_block";
		[StateBit] public  bool ConditionalBit { get; set; } = false;
        [StateRange(0, 5)] public  int FacingDirection { get; set; } = 2;
        
        public CommandBlock() : base(137)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "conditional_bit":
                        ConditionalBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:command_block";
            record.Id = 137;
            record.States.Add(new BlockStateByte {Name = "conditional_bit", Value = Convert.ToByte(ConditionalBit)});
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class Composter : Block // 468 typeof=Composter
    {
		public override string Name => "minecraft:composter";
		[StateRange(0, 8)] public int ComposterFillLevel { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "composter_fill_level":
                        ComposterFillLevel = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:composter";
            record.Id = 468;
            record.States.Add(new BlockStateInt {Name = "composter_fill_level", Value = ComposterFillLevel});
            return record;
        } // method
    } // class

    public partial class Conduit : Block // 412 typeof=Conduit
    {
		public override string Name => "minecraft:conduit";
		public Conduit() : base(412)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:conduit";
            record.Id = 412;
            return record;
        } // method
    } // class

    public partial class CoralBlock : Block // 387 typeof=CoralBlock
    {
		public override string Name => "minecraft:coral_block";
		[StateEnum("pink","purple","red","yellow","blue")]
        public  string CoralColor { get; set; } = "";
        [StateBit] public  bool DeadBit { get; set; } = false;
        
        public CoralBlock() : base(387)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "coral_color":
                        CoralColor = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "dead_bit":
                        DeadBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:coral_block";
            record.Id = 387;
            record.States.Add(new BlockStateString {Name = "coral_color", Value = CoralColor});
            record.States.Add(new BlockStateByte {Name = "dead_bit", Value = Convert.ToByte(DeadBit)});
            return record;
        } // method
    } // class

    public partial class CoralFan : Block // 388 typeof=CoralFan
    {
		public override string Name => "minecraft:coral_fan";
		[StateEnum("pink","purple","red","yellow","blue")]
        public  string CoralColor { get; set; } = "";
        [StateRange(0, 1)] public  int CoralFanDirection { get; set; } = 0;
        
        public CoralFan() : base(388)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "coral_color":
                        CoralColor = s.Value;
                        break;
                    case BlockStateInt s when s.Name == "coral_fan_direction":
                        CoralFanDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:coral_fan";
            record.Id = 388;
            record.States.Add(new BlockStateString {Name = "coral_color", Value = CoralColor});
            record.States.Add(new BlockStateInt {Name = "coral_fan_direction", Value = CoralFanDirection});
            return record;
        } // method
    } // class

    public partial class CoralFanDead : Block // 389 typeof=CoralFanDead
    {
		public override string Name => "minecraft:coral_fan_dead";
		[StateEnum("pink","purple","red","yellow","blue")]
        public  string CoralColor { get; set; } = "";
        [StateRange(0, 1)] public  int CoralFanDirection { get; set; } = 0;
        
        public CoralFanDead() : base(389)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "coral_color":
                        CoralColor = s.Value;
                        break;
                    case BlockStateInt s when s.Name == "coral_fan_direction":
                        CoralFanDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:coral_fan_dead";
            record.Id = 389;
            record.States.Add(new BlockStateString {Name = "coral_color", Value = CoralColor});
            record.States.Add(new BlockStateInt {Name = "coral_fan_direction", Value = CoralFanDirection});
            return record;
        } // method
    } // class

    public partial class CoralFanHang : Block // 390 typeof=CoralFanHang
    {
		public override string Name => "minecraft:coral_fan_hang";
		[StateRange(0, 3)] public  int CoralDirection { get; set; } = 0;
        [StateBit] public  bool CoralHangTypeBit { get; set; } = false;
        [StateBit] public  bool DeadBit { get; set; } = false;
        
        public CoralFanHang() : base(390)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "coral_direction":
                        CoralDirection = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "coral_hang_type_bit":
                        CoralHangTypeBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "dead_bit":
                        DeadBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:coral_fan_hang";
            record.Id = 390;
            record.States.Add(new BlockStateInt {Name = "coral_direction", Value = CoralDirection});
            record.States.Add(new BlockStateByte {Name = "coral_hang_type_bit", Value = Convert.ToByte(CoralHangTypeBit)});
            record.States.Add(new BlockStateByte {Name = "dead_bit", Value = Convert.ToByte(DeadBit)});
            return record;
        } // method
    } // class

    public partial class CoralFanHang2 : Block // 391 typeof=CoralFanHang2
    {
		public override string Name => "minecraft:coral_fan_hang2";
		[StateRange(0, 3)] public  int CoralDirection { get; set; } = 0;
        [StateBit] public  bool CoralHangTypeBit { get; set; } = false;
        [StateBit] public  bool DeadBit { get; set; } = false;
        
        public CoralFanHang2() : base(391)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "coral_direction":
                        CoralDirection = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "coral_hang_type_bit":
                        CoralHangTypeBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "dead_bit":
                        DeadBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:coral_fan_hang2";
            record.Id = 391;
            record.States.Add(new BlockStateInt {Name = "coral_direction", Value = CoralDirection});
            record.States.Add(new BlockStateByte {Name = "coral_hang_type_bit", Value = Convert.ToByte(CoralHangTypeBit)});
            record.States.Add(new BlockStateByte {Name = "dead_bit", Value = Convert.ToByte(DeadBit)});
            return record;
        } // method
    } // class

    public partial class CoralFanHang3 : Block // 392 typeof=CoralFanHang3
    {
		public override string Name => "minecraft:coral_fan_hang3";
		[StateRange(0, 3)] public  int CoralDirection { get; set; } = 0;
        [StateBit] public  bool CoralHangTypeBit { get; set; } = false;
        [StateBit] public  bool DeadBit { get; set; } = false;
        
        public CoralFanHang3() : base(392)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "coral_direction":
                        CoralDirection = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "coral_hang_type_bit":
                        CoralHangTypeBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "dead_bit":
                        DeadBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:coral_fan_hang3";
            record.Id = 392;
            record.States.Add(new BlockStateInt {Name = "coral_direction", Value = CoralDirection});
            record.States.Add(new BlockStateByte {Name = "coral_hang_type_bit", Value = Convert.ToByte(CoralHangTypeBit)});
            record.States.Add(new BlockStateByte {Name = "dead_bit", Value = Convert.ToByte(DeadBit)});
            return record;
        } // method
    } // class


    public partial class CraftingTable  // 58 typeof=CraftingTable
    {
		public override string Name => "minecraft:crafting_table";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:crafting_table";
            record.Id = 58;
            return record;
        } // method
    } // class

    public partial class CyanGlazedTerracotta  // 229 typeof=CyanGlazedTerracotta
    {
		public override string Name => "minecraft:cyan_glazed_terracotta";
		[StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:cyan_glazed_terracotta";
            record.Id = 229;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class DarkOakButton  // 397 typeof=DarkOakButton
    {
		public override string Name => "minecraft:dark_oak_button";
		[StateBit] public override bool ButtonPressedBit { get; set; } = false;
        [StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "button_pressed_bit":
                        ButtonPressedBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
						Direction = s.Value;
						break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:dark_oak_button";
            record.Id = 397;
            record.States.Add(new BlockStateByte {Name = "button_pressed_bit", Value = Convert.ToByte(ButtonPressedBit)});
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class DarkOakDoor  // 197 typeof=DarkOakDoor
    {
		public override string Name => "minecraft:dark_oak_door";
		[StateRange(0, 3)] public override int Direction { get; set; } = 0;
        [StateBit] public override bool DoorHingeBit { get; set; } = false;
        [StateBit] public override bool OpenBit { get; set; } = false;
        [StateBit] public override bool UpperBlockBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
						fDirection = s.Value;
						break;
                    case BlockStateByte s when s.Name == "door_hinge_bit":
                        DoorHingeBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "open_bit":
                        OpenBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "upper_block_bit":
                        UpperBlockBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:dark_oak_door";
            record.Id = 197;
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "door_hinge_bit", Value = Convert.ToByte(DoorHingeBit)});
            record.States.Add(new BlockStateByte {Name = "open_bit", Value = Convert.ToByte(OpenBit)});
            record.States.Add(new BlockStateByte {Name = "upper_block_bit", Value = Convert.ToByte(UpperBlockBit)});
            return record;
        } // method
    } // class

    public partial class DarkOakFenceGate  // 186 typeof=DarkOakFenceGate
    {
		public override string Name => "minecraft:dark_oak_fence_gate";
		[StateRange(0, 3)] public override int Direction { get; set; } = 0;
        [StateBit] public  bool InWallBit { get; set; } = false;
        [StateBit] public override bool OpenBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "in_wall_bit":
                        InWallBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "open_bit":
                        OpenBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:dark_oak_fence_gate";
            record.Id = 186;
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "in_wall_bit", Value = Convert.ToByte(InWallBit)});
            record.States.Add(new BlockStateByte {Name = "open_bit", Value = Convert.ToByte(OpenBit)});
            return record;
        } // method
    } // class

    public partial class DarkOakPressurePlate : PressurePlateBase // 407 typeof=DarkOakPressurePlate
	{
		public override string Name => "minecraft:dark_oak_pressure_plate";
		public override int RedstoneSignal { get; set; } = 0;
        
        public DarkOakPressurePlate() : base(407)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "redstone_signal":
                        RedstoneSignal = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:dark_oak_pressure_plate";
            record.Id = 407;
            record.States.Add(new BlockStateInt {Name = "redstone_signal", Value = RedstoneSignal});
            return record;
        } // method
    } // class

    public partial class DarkOakStairs  // 164 typeof=DarkOakStairs
    {
		public override string Name => "minecraft:dark_oak_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:dark_oak_stairs";
            record.Id = 164;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class DarkOakTrapdoor  // 402 typeof=DarkOakTrapdoor
    {
		public override string Name => "minecraft:dark_oak_trapdoor";
		[StateRange(0, 3)] public override int Direction { get; set; } = 0;
        [StateBit] public override bool OpenBit { get; set; } = false;
        [StateBit] public override bool UpsideDownBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "open_bit":
                        OpenBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:dark_oak_trapdoor";
            record.Id = 402;
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "open_bit", Value = Convert.ToByte(OpenBit)});
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            return record;
        } // method
    } // class

    public partial class DarkPrismarineStairs  // 258 typeof=DarkPrismarineStairs
    {
		public override string Name => "minecraft:dark_prismarine_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:dark_prismarine_stairs";
            record.Id = 258;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class DarkoakStandingSign  // 447 typeof=DarkoakStandingSign
    {
		public override string Name => "minecraft:darkoak_standing_sign";
		[StateRange(0, 15)] public  int GroundSignDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "ground_sign_direction":
                        GroundSignDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:darkoak_standing_sign";
            record.Id = 447;
            record.States.Add(new BlockStateInt {Name = "ground_sign_direction", Value = GroundSignDirection});
            return record;
        } // method
    } // class

    public partial class DarkoakWallSign  // 448 typeof=DarkoakWallSign
    {
		public override string Name => "minecraft:darkoak_wall_sign";
		[StateRange(0, 5)] public  int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:darkoak_wall_sign";
            record.Id = 448;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class DaylightDetector  // 151 typeof=DaylightDetector
    {
		public override string Name => "minecraft:daylight_detector";
		[StateRange(0, 15)] public  int RedstoneSignal { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "redstone_signal":
                        RedstoneSignal = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:daylight_detector";
            record.Id = 151;
            record.States.Add(new BlockStateInt {Name = "redstone_signal", Value = RedstoneSignal});
            return record;
        } // method
    } // class

    public partial class DaylightDetectorInverted  // 178 typeof=DaylightDetectorInverted
    {
		public override string Name => "minecraft:daylight_detector_inverted";
		[StateRange(0, 15)] public  int RedstoneSignal { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "redstone_signal":
                        RedstoneSignal = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:daylight_detector_inverted";
            record.Id = 178;
            record.States.Add(new BlockStateInt {Name = "redstone_signal", Value = RedstoneSignal});
            return record;
        } // method
    } // class

    public partial class Deadbush  // 32 typeof=Deadbush
    {
		public override string Name => "minecraft:deadbush";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:deadbush";
            record.Id = 32;
            return record;
        } // method
    } // class

    public partial class Deny  // 211 typeof=Deny
    {
		public override string Name => "minecraft:deny";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:deny";
            record.Id = 211;
            return record;
        } // method
    } // class

    public partial class DetectorRail  // 28 typeof=DetectorRail
    {
		public override string Name => "minecraft:detector_rail";
		[StateBit] public  bool RailDataBit { get; set; } = false;
        [StateRange(0, 5)] public  int RailDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "rail_data_bit":
                        RailDataBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "rail_direction":
                        RailDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:detector_rail";
            record.Id = 28;
            record.States.Add(new BlockStateByte {Name = "rail_data_bit", Value = Convert.ToByte(RailDataBit)});
            record.States.Add(new BlockStateInt {Name = "rail_direction", Value = RailDirection});
            return record;
        } // method
    } // class

    public partial class DiamondBlock  // 57 typeof=DiamondBlock
    {
		public override string Name => "minecraft:diamond_block";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:diamond_block";
            record.Id = 57;
            return record;
        } // method
    } // class

    public partial class DiamondOre  // 56 typeof=DiamondOre
    {
		public override string Name => "minecraft:diamond_ore";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:diamond_ore";
            record.Id = 56;
            return record;
        } // method
    } // class

    public partial class DioriteStairs  // 425 typeof=DioriteStairs
    {
		public override string Name => "minecraft:diorite_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:diorite_stairs";
            record.Id = 425;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class Dirt  // 3 typeof=Dirt
    {
		public override string Name => "minecraft:dirt";
		[StateEnum("normal","coarse")]
        public  string DirtType { get; set; } = "normal";

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "dirt_type":
                        DirtType = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:dirt";
            record.Id = 3;
            record.States.Add(new BlockStateString {Name = "dirt_type", Value = DirtType});
            return record;
        } // method
    } // class

    public partial class Dispenser  // 23 typeof=Dispenser
    {
		public override string Name => "minecraft:dispenser";
		public int FacingDirection { get; set; } = 2;
        public bool TriggeredBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "triggered_bit":
                        TriggeredBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:dispenser";
            record.Id = 23;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            record.States.Add(new BlockStateByte {Name = "triggered_bit", Value = Convert.ToByte(TriggeredBit)});
            return record;
        } // method
    } // class

    public partial class DoublePlant  // 175 typeof=DoublePlant
    {
		public override string Name => "minecraft:double_plant";
		[StateEnum("syringa","grass","fern","rose","paeonia","sunflower")]
        public  string DoublePlantType { get; set; } = "grass";
        [StateBit] public bool UpperBlockBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "double_plant_type":
                        DoublePlantType = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "upper_block_bit":
                        UpperBlockBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:double_plant";
            record.Id = 175;
            record.States.Add(new BlockStateString {Name = "double_plant_type", Value = DoublePlantType});
            record.States.Add(new BlockStateByte {Name = "upper_block_bit", Value = Convert.ToByte(UpperBlockBit)});
            return record;
        } // method
    } // class

	public partial class DoubleWoodenSlab // 157 typeof=DoubleWoodenSlab
	{
		public override string Name => "minecraft:double_wooden_slab";

		[StateBit] public bool TopSlotBit { get; set; } = false;
		[StateEnum("dark_oak", "spruce", "jungle", "oak", "acacia", "birch")]
		public string WoodType { get; set; } = "oak";

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateByte s when s.Name == "top_slot_bit":
						TopSlotBit = Convert.ToBoolean(s.Value);
						break;
					case BlockStateString s when s.Name == "wood_type":
						WoodType = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:double_wooden_slab";
			record.Id = 157;
			record.States.Add(new BlockStateByte { Name = "top_slot_bit", Value = Convert.ToByte(TopSlotBit) });
			record.States.Add(new BlockStateString { Name = "wood_type", Value = WoodType });
			return record;
		} // method
	} // class

	public partial class DragonEgg  // 122 typeof=DragonEgg
    {
		public override string Name => "minecraft:dragon_egg";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:dragon_egg";
            record.Id = 122;
            return record;
        } // method
    } // class

    public partial class DriedKelpBlock : Block // 394 typeof=DriedKelpBlock
    {
		public override string Name => "minecraft:dried_kelp";
		public DriedKelpBlock() : base(394)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:dried_kelp_block";
            record.Id = 394;
            return record;
        } // method
    } // class

    public partial class Dropper  // 125 typeof=Dropper
    {
		public override string Name => "minecraft:dropper";
		public int FacingDirection { get; set; } = 2;
        public bool TriggeredBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "triggered_bit":
                        TriggeredBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:dropper";
            record.Id = 125;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            record.States.Add(new BlockStateByte {Name = "triggered_bit", Value = Convert.ToByte(TriggeredBit)});
            return record;
        } // method
    } // class

	public partial class EmeraldBlock  // 133 typeof=EmeraldBlock
    {
		public override string Name => "minecraft:emerald_block";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:emerald_block";
            record.Id = 133;
            return record;
        } // method
    } // class

    public partial class EmeraldOre  // 129 typeof=EmeraldOre
    {
		public override string Name => "minecraft:emerald_ore";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:emerald_ore";
            record.Id = 129;
            return record;
        } // method
    } // class

    public partial class EnchantingTable  // 116 typeof=EnchantingTable
    {
		public override string Name => "minecraft:enchanting_table";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:enchanting_table";
            record.Id = 116;
            return record;
        } // method
    } // class

    public partial class EndBrickStairs  // 433 typeof=EndBrickStairs
    {
		public override string Name => "minecraft:end_brick_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:end_brick_stairs";
            record.Id = 433;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class EndBricks  // 206 typeof=EndBricks
    {
		public override string Name => "minecraft:end_bricks";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:end_bricks";
            record.Id = 206;
            return record;
        } // method
    } // class

    public partial class EndGateway  // 209 typeof=EndGateway
    {
		public override string Name => "minecraft:end_gateway";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:end_gateway";
            record.Id = 209;
            return record;
        } // method
    } // class

    public partial class EndPortal  // 119 typeof=EndPortal
    {
		public override string Name => "minecraft:end_portal";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:end_portal";
            record.Id = 119;
            return record;
        } // method
    } // class

    public partial class EndPortalFrame  // 120 typeof=EndPortalFrame
    {
		public override string Name => "minecraft:end_portal_frame";
		public  bool EndPortalEyeBit { get; set; } = false;
		[StateRange(0, 3)] public int Direction { get; set; } = 0;

		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
					case BlockStateInt s when s.Name == "direction":
						Direction = s.Value;
						break;
					case BlockStateByte s when s.Name == "end_portal_eye_bit":
						EndPortalEyeBit = Convert.ToBoolean(s.Value);
						break;
				} // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:end_portal_frame";
            record.Id = 120;
			record.States.Add(new BlockStateInt { Name = "direction", Value = Direction });
			record.States.Add(new BlockStateByte {Name = "end_portal_eye_bit", Value = Convert.ToByte(EndPortalEyeBit)});
			return record;
        } // method
    } // class

    public partial class EndRod  // 208 typeof=EndRod
    {
		public override string Name => "minecraft:end_rod";

		public int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:end_rod";
            record.Id = 208;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class EndStone  // 121 typeof=EndStone
    {
		public override string Name => "minecraft:end_stone";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:end_stone";
            record.Id = 121;
            return record;
        } // method
    } // class

    public partial class EnderChest  // 130 typeof=EnderChest
    {
		public override string Name => "minecraft:ender_chest";
		[StateRange(0, 5)] public int FacingDirection { get; set; } = 2;

		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
					case BlockStateInt s when s.Name == "facing_direction":
						FacingDirection = s.Value;
						break;
				} // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:ender_chest";
            record.Id = 130;
			record.States.Add(new BlockStateInt { Name = "facing_direction", Value = FacingDirection });
			return record;
        } // method
    } // class

    public partial class Farmland  // 60 typeof=Farmland
    {
		public override string Name => "minecraft:farmland";
		[StateRange(0, 7)] public  int MoisturizedAmount { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "moisturized_amount":
                        MoisturizedAmount = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:farmland";
            record.Id = 60;
            record.States.Add(new BlockStateInt {Name = "moisturized_amount", Value = MoisturizedAmount});
            return record;
        } // method
    } // class

    public partial class FenceGate  // 107 typeof=FenceGate
    {
		public override string Name => "minecraft:fence_gate";
		[StateRange(0, 3)] public override int Direction { get; set; } = 0;
        [StateBit] public  bool InWallBit { get; set; } = false;
        [StateBit] public override bool OpenBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "in_wall_bit":
                        InWallBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "open_bit":
                        OpenBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:fence_gate";
            record.Id = 107;
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "in_wall_bit", Value = Convert.ToByte(InWallBit)});
            record.States.Add(new BlockStateByte {Name = "open_bit", Value = Convert.ToByte(OpenBit)});
            return record;
        } // method
    } // class

    public partial class Fire  // 51 typeof=Fire
    {
		public override string Name => "minecraft:fire";
		[StateRange(0, 15)] public  int Age { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "age":
                        Age = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:fire";
            record.Id = 51;
            record.States.Add(new BlockStateInt {Name = "age", Value = Age});
            return record;
        } // method
    } // class

    public partial class FletchingTable : Block // 456 typeof=FletchingTable
    {
		public override string Name => "minecraft:fletching_table";
		public FletchingTable() : base(456)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:fletching_table";
            record.Id = 456;
            return record;
        } // method
    } // class

    public partial class FlowerPot  // 140 typeof=FlowerPot
    {
		public override string Name => "minecraft:flower_pot";
		[StateBit] public  bool UpdateBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "update_bit":
                        UpdateBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:flower_pot";
            record.Id = 140;
            record.States.Add(new BlockStateByte {Name = "update_bit", Value = Convert.ToByte(UpdateBit)});
            return record;
        } // method
    } // class

    public partial class FlowingLava  // 10 typeof=FlowingLava
    {
		public override string Name => "minecraft:flowing_lava";
		[StateRange(0, 15)] public override int LiquidDepth { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "liquid_depth":
                        LiquidDepth = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:flowing_lava";
            record.Id = 10;
            record.States.Add(new BlockStateInt {Name = "liquid_depth", Value = LiquidDepth});
            return record;
        } // method
    } // class

    public partial class FlowingWater  // 8 typeof=FlowingWater
    {
		public override string Name => "minecraft:flowing_water";
		[StateRange(0, 15)] public override int LiquidDepth { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "liquid_depth":
                        LiquidDepth = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:flowing_water";
            record.Id = 8;
            record.States.Add(new BlockStateInt {Name = "liquid_depth", Value = LiquidDepth});
            return record;
        } // method
    } // class

    public partial class Frame  // 199 typeof=Frame
	{
		public override string Name => "minecraft:frame";
		[StateRange(0, 5)] public  int FacingDirection { get; set; } = 2;
        [StateBit] public  bool ItemFrameMapBit { get; set; } = false;
        [StateBit] public  bool ItemFramePhotoBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "item_frame_map_bit":
                        ItemFrameMapBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "item_frame_photo_bit":
                        ItemFramePhotoBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:frame";
            record.Id = 199;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            record.States.Add(new BlockStateByte {Name = "item_frame_map_bit", Value = Convert.ToByte(ItemFrameMapBit)});
            record.States.Add(new BlockStateByte {Name = "item_frame_photo_bit", Value = Convert.ToByte(ItemFramePhotoBit)});
            return record;
        } // method
    } // class

    public partial class FrostedIce  // 207 typeof=FrostedIce
    {
		public override string Name => "minecraft:frosted_ice";
		[StateRange(0, 3)] public  int Age { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "age":
                        Age = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:frosted_ice";
            record.Id = 207;
            record.States.Add(new BlockStateInt {Name = "age", Value = Age});
            return record;
        } // method
    } // class

    public partial class Furnace  // 61 typeof=Furnace
    {
		public override string Name => "minecraft:furnace";
		[StateRange(0, 5)] public int Direction { get; set; } = 2;

		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
					case BlockStateInt s when s.Name == "facing_direction":
						Direction = s.Value;
						break;
				} // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:furnace";
            record.Id = 61;
			record.States.Add(new BlockStateInt { Name = "facing_direction", Value = Direction });
			return record;
        } // method
    } // class

    public partial class Glass  // 20 typeof=Glass
    {
		public override string Name => "minecraft:glass";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:glass";
            record.Id = 20;
            return record;
        } // method
    } // class

    public partial class GlassPane  // 102 typeof=GlassPane
    {
		public override string Name => "minecraft:glass_pane";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:glass_pane";
            record.Id = 102;
            return record;
        } // method
    } // class

    public partial class Glowingobsidian  // 246 typeof=Glowingobsidian
    {
		public override string Name => "minecraft:glowingobsidian";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:glowingobsidian";
            record.Id = 246;
            return record;
        } // method
    } // class

    public partial class Glowstone  // 89 typeof=Glowstone
    {
		public override string Name => "minecraft:glowstone";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:glowstone";
            record.Id = 89;
            return record;
        } // method
    } // class

    public partial class GoldBlock  // 41 typeof=GoldBlock
    {
		public override string Name => "minecraft:gold_block";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:gold_block";
            record.Id = 41;
            return record;
        } // method
    } // class

    public partial class GoldOre  // 14 typeof=GoldOre
    {
		public override string Name => "minecraft:gold_ore";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:gold_ore";
            record.Id = 14;
            return record;
        } // method
    } // class

    public partial class GoldenRail  // 27 typeof=GoldenRail
    {
		public override string Name => "minecraft:golden_rail";
		[StateBit] public  bool RailDataBit { get; set; } = false;
        [StateRange(0, 5)] public  int RailDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "rail_data_bit":
                        RailDataBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "rail_direction":
                        RailDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:golden_rail";
            record.Id = 27;
            record.States.Add(new BlockStateByte {Name = "rail_data_bit", Value = Convert.ToByte(RailDataBit)});
            record.States.Add(new BlockStateInt {Name = "rail_direction", Value = RailDirection});
            return record;
        } // method
    } // class

    public partial class GraniteStairs  // 424 typeof=GraniteStairs
    {
		public override string Name => "minecraft:granite_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:granite_stairs";
            record.Id = 424;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class Grass  // 2 typeof=Grass
    {
		public override string Name => "minecraft:grass";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:grass";
            record.Id = 2;
            return record;
        } // method
    } // class

    public partial class GrassPath  // 198 typeof=GrassPath
    {
		public override string Name => "minecraft:grass_path";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:grass_path";
            record.Id = 198;
            return record;
        } // method
    } // class

    public partial class Gravel  // 13 typeof=Gravel
    {
		public override string Name => "minecraft:gravel";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:gravel";
            record.Id = 13;
            return record;
        } // method
    } // class

    public partial class GrayGlazedTerracotta  // 227 typeof=GrayGlazedTerracotta
    {
		public override string Name => "minecraft:gray_glazed_terracotta";
		[StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:gray_glazed_terracotta";
            record.Id = 227;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class GreenGlazedTerracotta  // 233 typeof=GreenGlazedTerracotta
    {
		public override string Name => "minecraft:green_glazed_terracotta";
		[StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:green_glazed_terracotta";
            record.Id = 233;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class Grindstone : Block // 450 typeof=Grindstone
    {
		public override string Name => "minecraft:grindstone";
		[StateEnum("standing","hanging","side","multiple")]
        public  string Attachment { get; set; } = "standing";
        [StateRange(0, 3)] public  int Direction { get; set; } = 0;
        
        public Grindstone() : base(450)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "attachment":
                        Attachment = s.Value;
                        break;
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:grindstone";
            record.Id = 450;
            record.States.Add(new BlockStateString {Name = "attachment", Value = Attachment});
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            return record;
        } // method
    } // class

    public partial class HardenedClay  // 172 typeof=HardenedClay
    {
		public override string Name => "minecraft:hardened_clay";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:hardened_clay";
            record.Id = 172;
            return record;
        } // method
    } // class

    public partial class HayBlock  // 170 typeof=HayBlock
    {
		public override string Name => "minecraft:hay_block";
		[StateRange(0, 3)] public  int Deprecated { get; set; } = 0;
        [StateEnum("x","z","y")]
        public string PillarAxis { get; set; } = "x";

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "deprecated":
                        Deprecated = s.Value;
                        break;
                    case BlockStateString s when s.Name == "pillar_axis":
                        PillarAxis = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:hay_block";
            record.Id = 170;
            record.States.Add(new BlockStateInt {Name = "deprecated", Value = Deprecated});
            record.States.Add(new BlockStateString {Name = "pillar_axis", Value = PillarAxis});
            return record;
        } // method
    } // class

    public partial class HeavyWeightedPressurePlate  // 148 typeof=HeavyWeightedPressurePlate
    {
		public override string Name => "minecraft:heavy_weighted_pressure_plate";
		[StateRange(0, 15)] public override int RedstoneSignal { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "redstone_signal":
                        RedstoneSignal = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:heavy_weighted_pressure_plate";
            record.Id = 148;
            record.States.Add(new BlockStateInt {Name = "redstone_signal", Value = RedstoneSignal});
            return record;
        } // method
    } // class

    public partial class Hopper  // 154 typeof=Hopper
    {
		public override string Name => "minecraft:hopper";
		[StateRange(0, 5)] public  int FacingDirection { get; set; } = 2;
        [StateBit] public  bool ToggleBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "toggle_bit":
                        ToggleBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:hopper";
            record.Id = 154;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            record.States.Add(new BlockStateByte {Name = "toggle_bit", Value = Convert.ToByte(ToggleBit)});
            return record;
        } // method
    } // class

    public partial class Ice  // 79 typeof=Ice
    {
		public override string Name => "minecraft:ice";

		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:ice";
            record.Id = 79;
            return record;
        } // method
    } // class

    public partial class InfoUpdate : Block // 248 typeof=InfoUpdate
    {
		public override string Name => "minecraft:infoupdate";
		public InfoUpdate() : base(248)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:info_update";
            record.Id = 248;
            return record;
        } // method
    } // class

    public partial class InfoUpdate2 : Block // 249 typeof=InfoUpdate2
    {
		public override string Name => "minecraft:infoupdate2";
		public InfoUpdate2() : base(249)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:info_update2";
            record.Id = 249;
            return record;
        } // method
    } // class

    public partial class InvisibleBedrock  // 95 typeof=InvisibleBedrock
    {
		public override string Name => "minecraft:invisible_bedrock";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:invisible_bedrock";
            record.Id = 95;
            return record;
        } // method
    } // class

    public partial class IronBars  // 101 typeof=IronBars
    {
		public override string Name => "minecraft:iron_bars";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:iron_bars";
            record.Id = 101;
            return record;
        } // method
    } // class

    public partial class IronBlock  // 42 typeof=IronBlock
    {
		public override string Name => "minecraft:iron_block";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:iron_block";
            record.Id = 42;
            return record;
        } // method
    } // class

    public partial class IronDoor  // 71 typeof=IronDoor
    {
		public override string Name => "minecraft:iron_door";
		[StateRange(0, 3)] public override int Direction { get; set; } = 0;
        [StateBit] public override bool DoorHingeBit { get; set; } = false;
        [StateBit] public override bool OpenBit { get; set; } = false;
        [StateBit] public override bool UpperBlockBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
						break;
                    case BlockStateByte s when s.Name == "door_hinge_bit":
                        DoorHingeBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "open_bit":
                        OpenBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "upper_block_bit":
                        UpperBlockBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:iron_door";
            record.Id = 71;
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "door_hinge_bit", Value = Convert.ToByte(DoorHingeBit)});
            record.States.Add(new BlockStateByte {Name = "open_bit", Value = Convert.ToByte(OpenBit)});
            record.States.Add(new BlockStateByte {Name = "upper_block_bit", Value = Convert.ToByte(UpperBlockBit)});
            return record;
        } // method
    } // class

    public partial class IronOre  // 15 typeof=IronOre
    {
		public override string Name => "minecraft:iron_ore";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:iron_ore";
            record.Id = 15;
            return record;
        } // method
    } // class

    public partial class IronTrapdoor  // 167 typeof=IronTrapdoor
    {
		public override string Name => "minecraft:iron_trapdoor";
		[StateRange(0, 3)] public override int Direction { get; set; } = 0;
        [StateBit] public override bool OpenBit { get; set; } = false;
        [StateBit] public override bool UpsideDownBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "open_bit":
                        OpenBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:iron_trapdoor";
            record.Id = 167;
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "open_bit", Value = Convert.ToByte(OpenBit)});
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            return record;
        } // method
    } // class

    public partial class Jukebox  // 84 typeof=Jukebox
    {
		public override string Name => "minecraft:jukebox";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:jukebox";
            record.Id = 84;
            return record;
        } // method
    } // class

    public partial class JungleButton  // 398 typeof=JungleButton
    {
		public override string Name => "minecraft:jungle_button";
		[StateBit] public override bool ButtonPressedBit { get; set; } = false;
        [StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "button_pressed_bit":
                        ButtonPressedBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
						Direction = s.Value;
						break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:jungle_button";
            record.Id = 398;
            record.States.Add(new BlockStateByte {Name = "button_pressed_bit", Value = Convert.ToByte(ButtonPressedBit)});
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class JungleDoor  // 195 typeof=JungleDoor
    {
		public override string Name => "minecraft:jungle_door";
		[StateRange(0, 3)] public override int Direction { get; set; } = 0;
        [StateBit] public override bool DoorHingeBit { get; set; } = false;
        [StateBit] public override bool OpenBit { get; set; } = false;
        [StateBit] public override bool UpperBlockBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
						fDirection = s.Value;
						break;
                    case BlockStateByte s when s.Name == "door_hinge_bit":
                        DoorHingeBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "open_bit":
                        OpenBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "upper_block_bit":
                        UpperBlockBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:jungle_door";
            record.Id = 195;
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "door_hinge_bit", Value = Convert.ToByte(DoorHingeBit)});
            record.States.Add(new BlockStateByte {Name = "open_bit", Value = Convert.ToByte(OpenBit)});
            record.States.Add(new BlockStateByte {Name = "upper_block_bit", Value = Convert.ToByte(UpperBlockBit)});
            return record;
        } // method
    } // class

    public partial class JungleFenceGate  // 185 typeof=JungleFenceGate
    {
		public override string Name => "minecraft:jungle_fence_gate";
		[StateRange(0, 3)] public override int Direction { get; set; } = 0;
        [StateBit] public  bool InWallBit { get; set; } = false;
        [StateBit] public override bool OpenBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "in_wall_bit":
                        InWallBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "open_bit":
                        OpenBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:jungle_fence_gate";
            record.Id = 185;
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "in_wall_bit", Value = Convert.ToByte(InWallBit)});
            record.States.Add(new BlockStateByte {Name = "open_bit", Value = Convert.ToByte(OpenBit)});
            return record;
        } // method
    } // class

    public partial class JunglePressurePlate : PressurePlateBase // 408 typeof=JunglePressurePlate
	{
		public override string Name => "minecraft:jungle_pressure_plate";
		public override int RedstoneSignal { get; set; } = 0;
        
        public JunglePressurePlate() : base(408)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "redstone_signal":
                        RedstoneSignal = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:jungle_pressure_plate";
            record.Id = 408;
            record.States.Add(new BlockStateInt {Name = "redstone_signal", Value = RedstoneSignal});
            return record;
        } // method
    } // class

    public partial class JungleStairs  // 136 typeof=JungleStairs
    {
		public override string Name => "minecraft:jungle_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:jungle_stairs";
            record.Id = 136;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class JungleStandingSign  // 443 typeof=JungleStandingSign
    {
		public override string Name => "minecraft:jungle_standing_sign";
		[StateRange(0, 15)] public  int GroundSignDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "ground_sign_direction":
                        GroundSignDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:jungle_standing_sign";
            record.Id = 443;
            record.States.Add(new BlockStateInt {Name = "ground_sign_direction", Value = GroundSignDirection});
            return record;
        } // method
    } // class

    public partial class JungleTrapdoor  // 403 typeof=JungleTrapdoor
    {
		public override string Name => "minecraft:jungle_trapdoor";
		[StateRange(0, 3)] public override int Direction { get; set; } = 0;
        [StateBit] public override bool OpenBit { get; set; } = false;
        [StateBit] public override bool UpsideDownBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "open_bit":
                        OpenBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:jungle_trapdoor";
            record.Id = 403;
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "open_bit", Value = Convert.ToByte(OpenBit)});
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            return record;
        } // method
    } // class

    public partial class JungleWallSign  // 444 typeof=JungleWallSign
    {
		public override string Name => "minecraft:jungle_wall_sign";
		[StateRange(0, 5)] public  int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:jungle_wall_sign";
            record.Id = 444;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class Kelp : Block // 393 typeof=Kelp
    {
		public override string Name => "minecraft:kelp";
		[StateRange(0, 25)] public  int KelpAge { get; set; } = 0;
        
        public Kelp() : base(393)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "kelp_age":
                        KelpAge = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:kelp";
            record.Id = 393;
            record.States.Add(new BlockStateInt {Name = "kelp_age", Value = KelpAge});
            return record;
        } // method
    } // class

    public partial class Ladder  // 65 typeof=Ladder
    {
		public override string Name => "minecraft:ladder";
		[StateRange(0, 5)] public  int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:ladder";
            record.Id = 65;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class Lantern : Block // 463 typeof=Lantern
    {
		public override string Name => "minecraft:lantern";
		[StateBit] public  bool Hanging { get; set; } = false;
        
        public Lantern() : base(463)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "hanging":
                        Hanging = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:lantern";
            record.Id = 463;
            record.States.Add(new BlockStateByte {Name = "hanging", Value = Convert.ToByte(Hanging)});
            return record;
        } // method
    } // class

    public partial class LapisBlock  // 22 typeof=LapisBlock
    {
		public override string Name => "minecraft:lapis_block";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:lapis_block";
            record.Id = 22;
            return record;
        } // method
    } // class

    public partial class LapisOre  // 21 typeof=LapisOre
    {
		public override string Name => "minecraft:lapis_ore";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:lapis_ore";
            record.Id = 21;
            return record;
        } // method
    } // class

    public partial class Lava  // 11 typeof=Lava
    {
		public override string Name => "minecraft:lava";
		[StateRange(0, 15)] public override int LiquidDepth { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "liquid_depth":
                        LiquidDepth = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:lava";
            record.Id = 11;
            record.States.Add(new BlockStateInt {Name = "liquid_depth", Value = LiquidDepth});
            return record;
        } // method
    } // class

    public partial class Leaves  // 18 typeof=Leaves
    {
		public override string Name => "minecraft:leaves";

		[StateEnum("oak","spruce","birch","jungle")]
        public  string OldLeafType { get; set; } = "oak";
        [StateBit] public  bool PersistentBit { get; set; } = false;
        [StateBit] public  bool UpdateBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "old_leaf_type":
                        OldLeafType = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "persistent_bit":
                        PersistentBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "update_bit":
                        UpdateBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:leaves";
            record.Id = 18;
            record.States.Add(new BlockStateString {Name = "old_leaf_type", Value = OldLeafType});
            record.States.Add(new BlockStateByte {Name = "persistent_bit", Value = Convert.ToByte(PersistentBit)});
            record.States.Add(new BlockStateByte {Name = "update_bit", Value = Convert.ToByte(UpdateBit)});
            return record;
        } // method
    } // class

    public partial class Leaves2  // 161 typeof=Leaves2
    {
		public override string Name => "minecraft:leaves2";

		[StateEnum("dark_oak","acacia")]
        public  string NewLeafType { get; set; } = "acacia";
        [StateBit] public  bool PersistentBit { get; set; } = false;
        [StateBit] public  bool UpdateBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "new_leaf_type":
                        NewLeafType = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "persistent_bit":
                        PersistentBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "update_bit":
                        UpdateBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:leaves2";
            record.Id = 161;
            record.States.Add(new BlockStateString {Name = "new_leaf_type", Value = NewLeafType});
            record.States.Add(new BlockStateByte {Name = "persistent_bit", Value = Convert.ToByte(PersistentBit)});
            record.States.Add(new BlockStateByte {Name = "update_bit", Value = Convert.ToByte(UpdateBit)});
            return record;
        } // method
    } // class

    public partial class Lectern : Block // 449 typeof=Lectern
    {
		public override string Name => "minecraft:lectern";
		[StateRange(0, 3)] public int Direction { get; set; } = 0;
		public  bool PoweredBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
					case BlockStateInt s when s.Name == "direction":
						Direction = s.Value;
						break;
				} // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:lectern";
            record.Id = 449;
			record.States.Add(new BlockStateInt { Name = "direction", Value = Direction });
			record.States.Add(new BlockStateByte {Name = "powered_bit", Value = Convert.ToByte(PoweredBit)});
            return record;
        } // method
    } // class

    public partial class Lever  // 69 typeof=Lever
    {
		public override string Name => "minecraft:lever";
		public string LeverDirection { get; set; } = "down_east_west";
		public bool OpenBit { get; set; } = false;

		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "lever_direction":
                        LeverDirection = s.Value;
						Direction = s.Value;
						break;
                    case BlockStateByte s when s.Name == "open_bit":
                        OpenBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:lever";
            record.Id = 69;
            record.States.Add(new BlockStateString {Name = "lever_direction", Value = LeverDirection});
            record.States.Add(new BlockStateByte {Name = "open_bit", Value = Convert.ToByte(OpenBit)});
            return record;
        } // method
    } // class

    public partial class LightBlueGlazedTerracotta  // 223 typeof=LightBlueGlazedTerracotta
    {
		public override string Name => "minecraft:light_blue_glazed_terracotta";
		[StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:light_blue_glazed_terracotta";
            record.Id = 223;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class LightWeightedPressurePlate  // 147 typeof=LightWeightedPressurePlate
    {
		public override string Name => "minecraft:light_weighted_pressure_plate";
		[StateRange(0, 15)] public override int RedstoneSignal { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "redstone_signal":
                        RedstoneSignal = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:light_weighted_pressure_plate";
            record.Id = 147;
            record.States.Add(new BlockStateInt {Name = "redstone_signal", Value = RedstoneSignal});
            return record;
        } // method
    } // class

    public partial class LimeGlazedTerracotta  // 225 typeof=LimeGlazedTerracotta
    {
		public override string Name => "minecraft:lime_glazed_terracotta";
		[StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:lime_glazed_terracotta";
            record.Id = 225;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class LitBlastFurnace  // 469 typeof=LitBlastFurnace
    {
		public override string Name => "minecraft:lit_blast_furnace";
		[StateRange(0, 5)] public int Direction { get; set; } = 2;

		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
					case BlockStateInt s when s.Name == "facing_direction":
						Direction = s.Value;
						break;
				} // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:lit_blast_furnace";
            record.Id = 469;
			record.States.Add(new BlockStateInt { Name = "facing_direction", Value = Direction });
			return record;
        } // method
    } // class

    public partial class LitFurnace  // 62 typeof=LitFurnace
    {
		public override string Name => "minecraft:lit_furnace";
		[StateRange(0, 5)] public int Direction { get; set; } = 2;

		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
					case BlockStateInt s when s.Name == "facing_direction":
						Direction = s.Value;
						break;
				} // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:lit_furnace";
            record.Id = 62;
			record.States.Add(new BlockStateInt { Name = "facing_direction", Value = Direction });
			return record;
        } // method
    } // class

    public partial class LitPumpkin  // 91 typeof=LitPumpkin
    {
		public override string Name => "minecraft:lit_pumpkin";
		[StateRange(0, 3)] public int Direction { get; set; } = 0;

		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
					case BlockStateInt s when s.Name == "direction":
						Direction = s.Value;
						break;
				} // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:lit_pumpkin";
            record.Id = 91;
			record.States.Add(new BlockStateInt { Name = "direction", Value = Direction });
			return record;
        } // method
    } // class

    public partial class LitRedstoneLamp  // 124 typeof=LitRedstoneLamp
    {
		public override string Name => "minecraft:lit_redstone_lamp";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:lit_redstone_lamp";
            record.Id = 124;
            return record;
        } // method
    } // class

    public partial class LitRedstoneOre  // 74 typeof=LitRedstoneOre
    {
		public override string Name => "minecraft:lit_redstone_ore";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:lit_redstone_ore";
            record.Id = 74;
            return record;
        } // method
    } // class

    public partial class LitSmoker : Block // 454 typeof=LitSmoker
    {
		public override string Name => "minecraft:lit_smoker";
		[StateRange(0, 3)] public int Direction { get; set; } = 0;

		public LitSmoker() : base(454)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
					case BlockStateInt s when s.Name == "direction":
						Direction = s.Value;
						break;
				} // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:lit_smoker";
            record.Id = 454;
			record.States.Add(new BlockStateInt { Name = "direction", Value = Direction });
			return record;
        } // method
    } // class

    public partial class Loom  // 459 typeof=Loom
    {
		public override string Name => "minecraft:loom";
		[StateRange(0, 3)] public  int Direction { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:loom";
            record.Id = 459;
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            return record;
        } // method
    } // class

    public partial class MagentaGlazedTerracotta  // 222 typeof=MagentaGlazedTerracotta
    {
		public override string Name => "minecraft:magenta_glazed_terracotta";
		[StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:magenta_glazed_terracotta";
            record.Id = 222;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class Magma : Block // 213 typeof=Magma
    {
		public override string Name => "minecraft:magma";

		public Magma() : base(213)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:magma";
            record.Id = 213;
            return record;
        } // method
    } // class

    public partial class MelonBlock  // 103 typeof=MelonBlock
    {
		public override string Name => "minecraft:melon_block";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:melon_block";
            record.Id = 103;
            return record;
        } // method
    } // class

    public partial class MelonStem  // 105 typeof=MelonStem
    {
		public override string Name => "minecraft:melon_stem";
		[StateRange(0, 5)] public  int FacingDirection { get; set; } = 2;
        [StateRange(0, 7)] public  int Growth { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                    case BlockStateInt s when s.Name == "growth":
                        Growth = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:melon_stem";
            record.Id = 105;
            record.States.Add(new BlockStateInt {Name = "growth", Value = Growth});
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class MobSpawner  // 52 typeof=MobSpawner
    {
		public override string Name => "minecraft:mob_spawner";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:mob_spawner";
            record.Id = 52;
            return record;
        } // method
    } // class

    public partial class MonsterEgg  // 97 typeof=MonsterEgg
    {
		public override string Name => "minecraft:monster_egg";
		[StateEnum("cobblestone","stone_brick","mossy_stone_brick","cracked_stone_brick","chiseled_stone_brick","stone")]
        public  string MonsterEggStoneType { get; set; } = "stone";

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "monster_egg_stone_type":
                        MonsterEggStoneType = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:monster_egg";
            record.Id = 97;
            record.States.Add(new BlockStateString {Name = "monster_egg_stone_type", Value = MonsterEggStoneType});
            return record;
        } // method
    } // class

    public partial class MossyCobblestone  // 48 typeof=MossyCobblestone
    {
		public override string Name => "minecraft:mossy_cobblestone";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:mossy_cobblestone";
            record.Id = 48;
            return record;
        } // method
    } // class

    public partial class MossyCobblestoneStairs  // 434 typeof=MossyCobblestoneStairs
    {
		public override string Name => "minecraft:mossy_cobblestone_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:mossy_cobblestone_stairs";
            record.Id = 434;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class MossyStoneBrickStairs  // 430 typeof=MossyStoneBrickStairs
    {
		public override string Name => "minecraft:mossy_stone_brick_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:mossy_stone_brick_stairs";
            record.Id = 430;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class Mycelium  // 110 typeof=Mycelium
    {
		public override string Name => "minecraft:mycelium";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:mycelium";
            record.Id = 110;
            return record;
        } // method
    } // class

    public partial class NetherBrick  // 112 typeof=NetherBrick
    {
		public override string Name => "minecraft:nether_brick";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:nether_brick";
            record.Id = 112;
            return record;
        } // method
    } // class

    public partial class NetherBrickFence  // 113 typeof=NetherBrickFence
    {
		public override string Name => "minecraft:nether_brick_fence";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:nether_brick_fence";
            record.Id = 113;
            return record;
        } // method
    } // class

    public partial class NetherBrickStairs  // 114 typeof=NetherBrickStairs
    {
		public override string Name => "minecraft:nether_brick_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:nether_brick_stairs";
            record.Id = 114;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class


    public partial class NetherWart  // 115 typeof=NetherWart
    {
		public override string Name => "minecraft:nether_wart";
		[StateRange(0, 3)] public  int Age { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "age":
                        Age = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:nether_wart";
            record.Id = 115;
            record.States.Add(new BlockStateInt {Name = "age", Value = Age});
            return record;
        } // method
    } // class

    public partial class NetherWartBlock : Block // 214 typeof=NetherWartBlock
    {
		public override string Name => "minecraft:nether_wart_block";
		public NetherWartBlock() : base(214)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:nether_wart_block";
            record.Id = 214;
            return record;
        } // method
    } // class


    public partial class Netherrack  // 87 typeof=Netherrack
    {
		public override string Name => "minecraft:netherrack";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:netherrack";
            record.Id = 87;
            return record;
        } // method
    } // class

    public partial class NormalStoneStairs  // 435 typeof=NormalStoneStairs
    {
		public override string Name => "minecraft:normal_stone_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:normal_stone_stairs";
            record.Id = 435;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class Noteblock  // 25 typeof=Noteblock
    {
		public override string Name => "minecraft:noteblock";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:noteblock";
            record.Id = 25;
            return record;
        } // method
    } // class

    public partial class OakStairs  // 53 typeof=OakStairs
    {
		public override string Name => "minecraft:oak_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:oak_stairs";
            record.Id = 53;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

	public partial class Observer // 251 typeof=Observer
	{
		public override string Name => "minecraft:observer";

		[StateRange(0, 5)] public int FacingDirection { get; set; } = 2;
		[StateBit] public bool PoweredBit { get; set; } = false;

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateInt s when s.Name == "facing_direction":
						FacingDirection = s.Value;
						break;
					case BlockStateByte s when s.Name == "powered_bit":
						PoweredBit = Convert.ToBoolean(s.Value);
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:observer";
			record.Id = 251;
			record.States.Add(new BlockStateInt { Name = "facing_direction", Value = FacingDirection });
			record.States.Add(new BlockStateByte { Name = "powered_bit", Value = Convert.ToByte(PoweredBit) });
			return record;
		} // method
	} // class

	public partial class Obsidian  // 49 typeof=Obsidian
    {
		public override string Name => "minecraft:obsidian";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:obsidian";
            record.Id = 49;
            return record;
        } // method
    } // class

    public partial class OrangeGlazedTerracotta  // 221 typeof=OrangeGlazedTerracotta
    {
		public override string Name => "minecraft:orange_glazed_terracotta";
		[StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:orange_glazed_terracotta";
            record.Id = 221;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class PackedIce  // 174 typeof=PackedIce
    {
		public override string Name => "minecraft:packed_ice";

		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:packed_ice";
            record.Id = 174;
            return record;
        } // method
    } // class

    public partial class PinkGlazedTerracotta  // 226 typeof=PinkGlazedTerracotta
    {
		public override string Name => "minecraft:pink_glazed_terracotta";
		[StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:pink_glazed_terracotta";
            record.Id = 226;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class Piston  // 33 typeof=Piston
    {
		public override string Name => "minecraft:piston";
		public int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:piston";
            record.Id = 33;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class PistonArmCollision  // 34 typeof=PistonArmCollision
    {
		public override string Name => "minecraft:piston_arm_collision";
		[StateRange(0, 5)] public  int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:piston_arm_collision";
            record.Id = 34;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class Planks // 5 typeof=Planks
    {
        public override string Name => "minecraft:planks";

        [StateEnum("birch","acacia","spruce","oak","jungle","dark_oak")]
        public string WoodType { get; set; } = "oak";

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "wood_type":
                        WoodType = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:planks";
            record.Id = 5;
            record.States.Add(new BlockStateString {Name = "wood_type", Value = WoodType});
            return record;
        } // method
    }

    public partial class Podzol  // 243 typeof=Podzol
    {
		public override string Name => "minecraft:podzol";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:podzol";
            record.Id = 243;
            return record;
        } // method
    } // class

    public partial class PolishedAndesiteStairs  // 429 typeof=PolishedAndesiteStairs
    {
		public override string Name => "minecraft:polished_andesite_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:polished_andesite_stairs";
            record.Id = 429;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class


    public partial class PolishedDioriteStairs  // 428 typeof=PolishedDioriteStairs
    {
		public override string Name => "minecraft:polished_diorite_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:polished_diorite_stairs";
            record.Id = 428;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class PolishedGraniteStairs  // 427 typeof=PolishedGraniteStairs
    {
		public override string Name => "minecraft:polished_granite_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:polished_granite_stairs";
            record.Id = 427;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class Portal  // 90 typeof=Portal
    {
		public override string Name => "minecraft:portal";
		[StateEnum("x","z","unknown")]
        public  string PortalAxis { get; set; } = "x";

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "portal_axis":
                        PortalAxis = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:portal";
            record.Id = 90;
            record.States.Add(new BlockStateString {Name = "portal_axis", Value = PortalAxis});
            return record;
        } // method
    } // class

    public partial class Potatoes  // 142 typeof=Potatoes
    {
		public override string Name => "minecraft:potatoes";
		[StateRange(0, 7)] public override int Growth { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "growth":
                        Growth = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:potatoes";
            record.Id = 142;
            record.States.Add(new BlockStateInt {Name = "growth", Value = Growth});
            return record;
        } // method
    } // class

    public partial class PoweredComparator  // 150 typeof=PoweredComparator
    {
		public override string Name => "minecraft:powered_comparator";
		[StateRange(0, 3)] public int Direction { get; set; } = 0;
		[StateBit] public  bool OutputLitBit { get; set; } = false;
        [StateBit] public  bool OutputSubtractBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
					case BlockStateInt s when s.Name == "direction":
						Direction = s.Value;
						break;
					case BlockStateByte s when s.Name == "output_lit_bit":
                        OutputLitBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "output_subtract_bit":
                        OutputSubtractBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:powered_comparator";
            record.Id = 150;
			record.States.Add(new BlockStateInt { Name = "direction", Value = Direction });
			record.States.Add(new BlockStateByte {Name = "output_lit_bit", Value = Convert.ToByte(OutputLitBit)});
            record.States.Add(new BlockStateByte {Name = "output_subtract_bit", Value = Convert.ToByte(OutputSubtractBit)});
            return record;
        } // method
    } // class

    public partial class PoweredRepeater  // 94 typeof=PoweredRepeater
    {
		public override string Name => "minecraft:powered_repeater";
		[StateRange(0, 3)] public int Direction { get; set; } = 0;
		[StateRange(0, 3)] public  int RepeaterDelay { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
					case BlockStateInt s when s.Name == "direction":
						Direction = s.Value;
						break;
					case BlockStateInt s when s.Name == "repeater_delay":
                        RepeaterDelay = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:powered_repeater";
            record.Id = 94;
			record.States.Add(new BlockStateInt { Name = "direction", Value = Direction });
			record.States.Add(new BlockStateInt {Name = "repeater_delay", Value = RepeaterDelay});
            return record;
        } // method
    } // class

	public partial class Prismarine // 168 typeof=Prismarine
	{
		public override string Name => "minecraft:prismarine";
		[StateEnum("dark", "default", "bricks")]
		public string PrismarineBlockType { get; set; } = "default";

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "prismarine_block_type":
						PrismarineBlockType = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:prismarine";
			record.Id = 168;
			record.States.Add(new BlockStateString { Name = "prismarine_block_type", Value = PrismarineBlockType });
			return record;
		} // method
	} // class

	public partial class PrismarineBricksStairs  // 259 typeof=PrismarineBricksStairs
    {
		public override string Name => "minecraft:prismarine_bricks_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:prismarine_bricks_stairs";
            record.Id = 259;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class PrismarineStairs  // 257 typeof=PrismarineStairs
    {
		public override string Name => "minecraft:prismarine_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:prismarine_stairs";
            record.Id = 257;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class Pumpkin  // 86 typeof=Pumpkin
    {
		public override string Name => "minecraft:pumpkin";
		[StateRange(0, 3)] public int Direction { get; set; } = 0;

		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
					case BlockStateInt s when s.Name == "direction":
						Direction = s.Value;
						break;
				} // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:pumpkin";
            record.Id = 86;
			record.States.Add(new BlockStateInt { Name = "direction", Value = Direction });
			return record;
        } // method
    } // class

    public partial class PumpkinStem  // 104 typeof=PumpkinStem
    {
		public override string Name => "minecraft:pumpkin_stem";
		[StateRange(0, 5)] public  int FacingDirection { get; set; } = 2;
        [StateRange(0, 7)] public  int Growth { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                    case BlockStateInt s when s.Name == "growth":
                        Growth = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:pumpkin_stem";
            record.Id = 104;
            record.States.Add(new BlockStateInt {Name = "growth", Value = Growth});
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class PurpleGlazedTerracotta  // 219 typeof=PurpleGlazedTerracotta
    {
		public override string Name => "minecraft:purple_glazed_terracotta";
		[StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:purple_glazed_terracotta";
            record.Id = 219;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class PurpurBlock  // 201 typeof=PurpurBlock
    {
		public override string Name => "minecraft:purpur_block";
		[StateEnum("default","chiseled","lines","smooth")]
        public  string ChiselType { get; set; } = "";
        [StateEnum("x","z","y")]
        public  string PillarAxis { get; set; } = "";

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "chisel_type":
                        ChiselType = s.Value;
                        break;
                    case BlockStateString s when s.Name == "pillar_axis":
                        PillarAxis = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:purpur_block";
            record.Id = 201;
            record.States.Add(new BlockStateString {Name = "chisel_type", Value = ChiselType});
            record.States.Add(new BlockStateString {Name = "pillar_axis", Value = PillarAxis});
            return record;
        } // method
    } // class

    public partial class PurpurStairs  // 203 typeof=PurpurStairs
    {
		public override string Name => "minecraft:purpur_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:purpur_stairs";
            record.Id = 203;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

	public partial class QuartzBlock // 155 typeof=QuartzBlock
	{
		public override string Name => "minecraft:quartz_block";
		[StateEnum("smooth", "default", "lines", "chiseled")]
		public string ChiselType { get; set; } = "default";
		[StateEnum("x", "z", "y")]
		public string PillarAxis { get; set; } = "y";

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "chisel_type":
						ChiselType = s.Value;
						break;
					case BlockStateString s when s.Name == "pillar_axis":
						PillarAxis = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:quartz_block";
			record.Id = 155;
			record.States.Add(new BlockStateString { Name = "chisel_type", Value = ChiselType });
			record.States.Add(new BlockStateString { Name = "pillar_axis", Value = PillarAxis });
			return record;
		} // method
	} // class


	public partial class QuartzOre  // 153 typeof=QuartzOre
    {
		public override string Name => "minecraft:quartz_ore";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:quartz_ore";
            record.Id = 153;
            return record;
        } // method
    } // class

    public partial class QuartzStairs  // 156 typeof=QuartzStairs
    {
		public override string Name => "minecraft:quartz_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:quartz_stairs";
            record.Id = 156;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class Rail  // 66 typeof=Rail
    {
		public override string Name => "minecraft:rail";
		[StateRange(0, 9)] public  int RailDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "rail_direction":
                        RailDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:rail";
            record.Id = 66;
            record.States.Add(new BlockStateInt {Name = "rail_direction", Value = RailDirection});
            return record;
        } // method
    } // class

    public partial class RedFlower  // 38 typeof=RedFlower
    {
		public override string Name => "minecraft:red_flower";
		[StateEnum("orchid","allium","houstonia","tulip_red","tulip_orange","tulip_white","tulip_pink","oxeye","cornflower","lily_of_the_valley","poppy")]
        public  string FlowerType { get; set; } = "";

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "flower_type":
                        FlowerType = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:red_flower";
            record.Id = 38;
            record.States.Add(new BlockStateString {Name = "flower_type", Value = FlowerType});
            return record;
        } // method
    } // class

    public partial class RedGlazedTerracotta  // 234 typeof=RedGlazedTerracotta
    {
		public override string Name => "minecraft:red_glazed_terracotta";
		[StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:red_glazed_terracotta";
            record.Id = 234;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class RedMushroom  // 40 typeof=RedMushroom
    {
		public override string Name => "minecraft:red_mushroom";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:red_mushroom";
            record.Id = 40;
            return record;
        } // method
    } // class

    public partial class RedMushroomBlock  // 100 typeof=RedMushroomBlock
    {
		public override string Name => "minecraft:red_mushroom_block";
		[StateRange(0, 15)] public  int HugeMushroomBits { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "huge_mushroom_bits":
                        HugeMushroomBits = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:red_mushroom_block";
            record.Id = 100;
            record.States.Add(new BlockStateInt {Name = "huge_mushroom_bits", Value = HugeMushroomBits});
            return record;
        } // method
    } // class

    public partial class RedNetherBrick : Block // 215 typeof=RedNetherBrick
    {
		public override string Name => "minecraft:red_nether_brick";
		public RedNetherBrick() : base(215)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:red_nether_brick";
            record.Id = 215;
            return record;
        } // method
    } // class

    public partial class RedNetherBrickStairs  // 439 typeof=RedNetherBrickStairs
    {
		public override string Name => "minecraft:red_nether_brick_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:red_nether_brick_stairs";
            record.Id = 439;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class RedSandstone  // 179 typeof=RedSandstone
    {
		public override string Name => "minecraft:red_sandstone";
		[StateEnum("default","heiroglyphs","cut","smooth")]
        public  string SandStoneType { get; set; } = "default";

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "sand_stone_type":
                        SandStoneType = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:red_sandstone";
            record.Id = 179;
            record.States.Add(new BlockStateString {Name = "sand_stone_type", Value = SandStoneType});
            return record;
        } // method
    } // class

    public partial class RedSandstoneStairs  // 180 typeof=RedSandstoneStairs
    {
		public override string Name => "minecraft:red_sandstone_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:red_sandstone_stairs";
            record.Id = 180;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class RedstoneBlock  // 152 typeof=RedstoneBlock
    {
		public override string Name => "minecraft:redstone_block";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:redstone_block";
            record.Id = 152;
            return record;
        } // method
    } // class

    public partial class RedstoneLamp  // 123 typeof=RedstoneLamp
    {
		public override string Name => "minecraft:redstone_lamp";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:redstone_lamp";
            record.Id = 123;
            return record;
        } // method
    } // class

    public partial class RedstoneOre  // 73 typeof=RedstoneOre
    {
		public override string Name => "minecraft:redstone_ore";

		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:redstone_ore";
            record.Id = 73;
            return record;
        } // method
    } // class

    public partial class RedstoneTorch  // 76 typeof=RedstoneTorch
    {
		public override string Name => "minecraft:redstone_torch";
		public string TorchFacingDirection { get; set; } = "top";

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "torch_facing_direction":
                        TorchFacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:redstone_torch";
            record.Id = 76;
            record.States.Add(new BlockStateString {Name = "torch_facing_direction", Value = TorchFacingDirection});
            return record;
        } // method
    } // class

    public partial class RedstoneWire  // 55 typeof=RedstoneWire
    {
		public override string Name => "minecraft:redstone_wire";
		[StateRange(0, 15)] public  int RedstoneSignal { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "redstone_signal":
                        RedstoneSignal = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:redstone_wire";
            record.Id = 55;
            record.States.Add(new BlockStateInt {Name = "redstone_signal", Value = RedstoneSignal});
            return record;
        } // method
    } // class

    public partial class Reeds  // 83 typeof=Reeds
    {
		public override string Name => "minecraft:reeds";
		[StateRange(0, 15)] public  int Age { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "age":
                        Age = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:reeds";
            record.Id = 83;
            record.States.Add(new BlockStateInt {Name = "age", Value = Age});
            return record;
        } // method
    } // class

    public partial class RepeatingCommandBlock : Block // 188 typeof=RepeatingCommandBlock
    {
		public override string Name => "minecraft:repeating_command_block";
		[StateBit] public  bool ConditionalBit { get; set; } = false;
        [StateRange(0, 5)] public  int FacingDirection { get; set; } = 2;
        
        public RepeatingCommandBlock() : base(188)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "conditional_bit":
                        ConditionalBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:repeating_command_block";
            record.Id = 188;
            record.States.Add(new BlockStateByte {Name = "conditional_bit", Value = Convert.ToByte(ConditionalBit)});
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class Reserved6 : Block // 255 typeof=Reserved6
    {
        
        public Reserved6() : base(255)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:reserved6";
            record.Id = 255;
            return record;
        } // method
    } // class


    public partial class Sand  // 12 typeof=Sand
    {
		public override string Name => "minecraft:sand";
		[StateEnum("normal","red")]
        public  string SandType { get; set; } = "normal";

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "sand_type":
                        SandType = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:sand";
            record.Id = 12;
            record.States.Add(new BlockStateString {Name = "sand_type", Value = SandType});
            return record;
        } // method
    } // class

	public partial class Sandstone // 24 typeof=Sandstone
	{
		public override string Name => "minecraft:sandstone";
		[StateEnum("default", "smooth", "cut", "heiroglyphs")]
		public string SandStoneType { get; set; } = "default";

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "sand_stone_type":
						SandStoneType = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:sandstone";
			record.Id = 24;
			record.States.Add(new BlockStateString { Name = "sand_stone_type", Value = SandStoneType });
			return record;
		} // method
	} // class

	public partial class SandstoneStairs  // 128 typeof=SandstoneStairs
    {
		public override string Name => "minecraft:sandstone_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:sandstone_stairs";
            record.Id = 128;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class Sapling  // 6 typeof=Sapling
    {
		public override string Name => "minecraft:sapling";
		[StateBit] public  bool AgeBit { get; set; } = false;
        [StateEnum("spruce","birch","jungle","acacia","dark_oak","oak")]
        public  string SaplingType { get; set; } = "oak";

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "age_bit":
                        AgeBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateString s when s.Name == "sapling_type":
                        SaplingType = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:sapling";
            record.Id = 6;
            record.States.Add(new BlockStateByte {Name = "age_bit", Value = Convert.ToByte(AgeBit)});
            record.States.Add(new BlockStateString {Name = "sapling_type", Value = SaplingType});
            return record;
        } // method
    } // class

    public partial class Scaffolding : Block // 420 typeof=Scaffolding
    {
		public override string Name => "minecraft:scaffolding";
		[StateRange(0, 7)] public  int Stability { get; set; } = 0;
        [StateBit] public  bool StabilityCheck { get; set; } = false;
        
        public Scaffolding() : base(420)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "stability":
                        Stability = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "stability_check":
                        StabilityCheck = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:scaffolding";
            record.Id = 420;
            record.States.Add(new BlockStateInt {Name = "stability", Value = Stability});
            record.States.Add(new BlockStateByte {Name = "stability_check", Value = Convert.ToByte(StabilityCheck)});
            return record;
        } // method
    } // class

    public partial class SeaLantern  // 169 typeof=SeaLantern
    {
		public override string Name => "minecraft:sea_lantern";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:sea_lantern";
            record.Id = 169;
            return record;
        } // method
    } // class

    public partial class SeaPickle : Block // 411 typeof=SeaPickle
    {
		public override string Name => "minecraft:sea_pickle";
		[StateRange(0, 3)] public  int ClusterCount { get; set; } = 0;
        [StateBit] public  bool DeadBit { get; set; } = false;
        
        public SeaPickle() : base(411)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "cluster_count":
                        ClusterCount = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "dead_bit":
                        DeadBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:sea_pickle";
            record.Id = 411;
            record.States.Add(new BlockStateInt {Name = "cluster_count", Value = ClusterCount});
            record.States.Add(new BlockStateByte {Name = "dead_bit", Value = Convert.ToByte(DeadBit)});
            return record;
        } // method
    } // class

    public partial class Seagrass : Block // 385 typeof=Seagrass
    {
		public override string Name => "minecraft:seagrass";
		[StateEnum("double_top","double_bot","default")]
        public  string SeaGrassType { get; set; } = "default";
        
        public Seagrass() : base(385)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "sea_grass_type":
                        SeaGrassType = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:seagrass";
            record.Id = 385;
            record.States.Add(new BlockStateString {Name = "sea_grass_type", Value = SeaGrassType});
            return record;
        } // method
    } // class


    public partial class SilverGlazedTerracotta  // 228 typeof=SilverGlazedTerracotta
    {
		public override string Name => "minecraft:silver_glazed_terracotta";
		[StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:silver_glazed_terracotta";
            record.Id = 228;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class Skull : SkullBase  // 144 typeof=Skull
    {
		public override string Name => "minecraft:skull";
		[StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

		public Skull() : base(144)
		{
		}

		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:skull";
            record.Id = 144;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

	public partial class WitherSkull : SkullBase  // 1220 typeof=WitherSkull
	{
		public override string Name => "minecraft:wither_skeleton_skull";
		[StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

		public WitherSkull() : base(1220)
		{
		}

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateInt s when s.Name == "facing_direction":
						FacingDirection = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:wither_skeleton_skull";
			record.Id = 1220;
			record.States.Add(new BlockStateInt { Name = "facing_direction", Value = FacingDirection });
			return record;
		} // method
	} // class

	public partial class ZombieHead : SkullBase  // 1221 typeof=ZombieHead
	{
		public override string Name => "minecraft:zombie_head";
		[StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

		public ZombieHead() : base(1221)
		{
		}

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateInt s when s.Name == "facing_direction":
						FacingDirection = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:zombie_head";
			record.Id = 1221;
			record.States.Add(new BlockStateInt { Name = "facing_direction", Value = FacingDirection });
			return record;
		} // method
	} // class

	public partial class PlayerHead : SkullBase  // 1222 typeof=PlayerHead
	{
		public override string Name => "minecraft:player_head";
		[StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

		public PlayerHead() : base(1222)
		{
		}

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateInt s when s.Name == "facing_direction":
						FacingDirection = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:player_head";
			record.Id = 1222;
			record.States.Add(new BlockStateInt { Name = "facing_direction", Value = FacingDirection });
			return record;
		} // method
	} // class

	public partial class CreeperHead : SkullBase  // 1223 typeof=CreeperHead
	{
		public override string Name => "minecraft:creeper_head";
		[StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

		public CreeperHead() : base(1223)
		{
		}

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateInt s when s.Name == "facing_direction":
						FacingDirection = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:creeper_head";
			record.Id = 1223;
			record.States.Add(new BlockStateInt { Name = "facing_direction", Value = FacingDirection });
			return record;
		} // method
	} // class

	public partial class DragonHead : SkullBase  // 1224 typeof=ZombieHead
	{
		public override string Name => "minecraft:dragon_head";
		[StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

		public DragonHead() : base(1224)
		{
		}

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateInt s when s.Name == "facing_direction":
						FacingDirection = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:dragon_head";
			record.Id = 1224;
			record.States.Add(new BlockStateInt { Name = "facing_direction", Value = FacingDirection });
			return record;
		} // method
	} // class

	public partial class Slime  // 165 typeof=Slime
	{
		public override string Name => "minecraft:slime";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:slime";
            record.Id = 165;
            return record;
        } // method
    } // class

    public partial class SmithingTable : Block // 457 typeof=SmithingTable
    {
		public override string Name => "minecraft:smithing_table";
		public SmithingTable() : base(457)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:smithing_table";
            record.Id = 457;
            return record;
        } // method
    } // class

    public partial class Smoker : Block // 453 typeof=Smoker
    {
		public override string Name => "minecraft:smoker";
		[StateRange(0, 3)] public int Direction { get; set; } = 0;

		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
					case BlockStateInt s when s.Name == "direction":
						Direction = s.Value;
						break;
				} // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:smoker";
            record.Id = 453;
			record.States.Add(new BlockStateInt { Name = "direction", Value = Direction });
			return record;
        } // method
    } // class

    public partial class SmoothQuartzStairs  // 440 typeof=SmoothQuartzStairs
    {
		public override string Name => "minecraft:smooth_quartz_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:smooth_quartz_stairs";
            record.Id = 440;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class SmoothRedSandstoneStairs  // 431 typeof=SmoothRedSandstoneStairs
    {
		public override string Name => "minecraft:smooth_red_sandstone_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:smooth_red_sandstone_stairs";
            record.Id = 431;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class SmoothSandstoneStairs  // 432 typeof=SmoothSandstoneStairs
    {
		public override string Name => "minecraft:smooth_sandstone_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:smooth_sandstone_stairs";
            record.Id = 432;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class SmoothStone : Block // 438 typeof=SmoothStone
    {
		public override string Name => "minecraft:smooth_stone";
		public SmoothStone() : base(438)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:smooth_stone";
            record.Id = 438;
            return record;
        } // method
    } // class

    public partial class Snow  // 80 typeof=Snow
    {
		public override string Name => "minecraft:snow";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:snow";
            record.Id = 80;
            return record;
        } // method
    } // class

    public partial class SnowLayer  // 78 typeof=SnowLayer
    {
		public override string Name => "minecraft:snow_layer";
		[StateBit] public  bool CoveredBit { get; set; } = false;
        [StateRange(0, 7)] public  int Height { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "covered_bit":
                        CoveredBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "height":
                        Height = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:snow_layer";
            record.Id = 78;
            record.States.Add(new BlockStateByte {Name = "covered_bit", Value = Convert.ToByte(CoveredBit)});
            record.States.Add(new BlockStateInt {Name = "height", Value = Height});
            return record;
        } // method
    } // class


    public partial class SoulSand  // 88 typeof=SoulSand
    {
		public override string Name => "minecraft:soul_sand";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:soul_sand";
            record.Id = 88;
            return record;
        } // method
    } // class


    public partial class Sponge  // 19 typeof=Sponge
    {
		public override string Name => "minecraft:sponge";
		[StateEnum("dry","wet")]
        public  string SpongeType { get; set; } = "dry";

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "sponge_type":
                        SpongeType = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:sponge";
            record.Id = 19;
            record.States.Add(new BlockStateString {Name = "sponge_type", Value = SpongeType});
            return record;
        } // method
    } // class

    public partial class SpruceButton  // 399 typeof=SpruceButton
    {
		public override string Name => "minecraft:spruce_button";
		[StateBit] public override bool ButtonPressedBit { get; set; } = false;
        [StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "button_pressed_bit":
                        ButtonPressedBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
						Direction = s.Value;
						break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:spruce_button";
            record.Id = 399;
            record.States.Add(new BlockStateByte {Name = "button_pressed_bit", Value = Convert.ToByte(ButtonPressedBit)});
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class SpruceDoor  // 193 typeof=SpruceDoor
    {
		public override string Name => "minecraft:spruce_door";
		[StateRange(0, 3)] public override int Direction { get; set; } = 0;
        [StateBit] public override bool DoorHingeBit { get; set; } = false;
        [StateBit] public override bool OpenBit { get; set; } = false;
        [StateBit] public override bool UpperBlockBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
						fDirection = s.Value;
						break;
                    case BlockStateByte s when s.Name == "door_hinge_bit":
                        DoorHingeBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "open_bit":
                        OpenBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "upper_block_bit":
                        UpperBlockBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:spruce_door";
            record.Id = 193;
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "door_hinge_bit", Value = Convert.ToByte(DoorHingeBit)});
            record.States.Add(new BlockStateByte {Name = "open_bit", Value = Convert.ToByte(OpenBit)});
            record.States.Add(new BlockStateByte {Name = "upper_block_bit", Value = Convert.ToByte(UpperBlockBit)});
            return record;
        } // method
    } // class

    public partial class SpruceFenceGate  // 183 typeof=SpruceFenceGate
    {
		public override string Name => "minecraft:spruce_fence_gate";
		[StateRange(0, 3)] public override int Direction { get; set; } = 0;
        [StateBit] public  bool InWallBit { get; set; } = false;
        [StateBit] public override bool OpenBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "in_wall_bit":
                        InWallBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "open_bit":
                        OpenBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:spruce_fence_gate";
            record.Id = 183;
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "in_wall_bit", Value = Convert.ToByte(InWallBit)});
            record.States.Add(new BlockStateByte {Name = "open_bit", Value = Convert.ToByte(OpenBit)});
            return record;
        } // method
    } // class

    public partial class SprucePressurePlate : PressurePlateBase // 409 typeof=SprucePressurePlate
	{
		public override string Name => "minecraft:spruce_pressure_plate";
		public override int RedstoneSignal { get; set; } = 0;
        
        public SprucePressurePlate() : base(409)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "redstone_signal":
                        RedstoneSignal = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:spruce_pressure_plate";
            record.Id = 409;
            record.States.Add(new BlockStateInt {Name = "redstone_signal", Value = RedstoneSignal});
            return record;
        } // method
    } // class

    public partial class SpruceStairs  // 134 typeof=SpruceStairs
    {
		public override string Name => "minecraft:spruce_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:spruce_stairs";
            record.Id = 134;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class SpruceStandingSign  // 436 typeof=SpruceStandingSign
    {
		public override string Name => "minecraft:spruce_standing_sign";
		[StateRange(0, 15)] public  int GroundSignDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "ground_sign_direction":
                        GroundSignDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:spruce_standing_sign";
            record.Id = 436;
            record.States.Add(new BlockStateInt {Name = "ground_sign_direction", Value = GroundSignDirection});
            return record;
        } // method
    } // class

    public partial class SpruceTrapdoor  // 404 typeof=SpruceTrapdoor
    {
		public override string Name => "minecraft:spruce_trapdoor";
		[StateRange(0, 3)] public override int Direction { get; set; } = 0;
        [StateBit] public override bool OpenBit { get; set; } = false;
        [StateBit] public override bool UpsideDownBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "open_bit":
                        OpenBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:spruce_trapdoor";
            record.Id = 404;
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "open_bit", Value = Convert.ToByte(OpenBit)});
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            return record;
        } // method
    } // class

    public partial class SpruceWallSign  // 437 typeof=SpruceWallSign
    {
		public override string Name => "minecraft:spruce_wall_sign";
		[StateRange(0, 5)] public  int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:spruce_wall_sign";
            record.Id = 437;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class StandingBanner  // 176 typeof=StandingBanner
    {
		public override string Name => "minecraft:standing_banner";
		[StateRange(0, 15)] public  int GroundSignDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "ground_sign_direction":
                        GroundSignDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:standing_banner";
            record.Id = 176;
            record.States.Add(new BlockStateInt {Name = "ground_sign_direction", Value = GroundSignDirection});
            return record;
        } // method
    } // class

    public partial class StandingSign  // 63 typeof=StandingSign
    {
		public override string Name => "minecraft:standing_sign";
		[StateRange(0, 15)] public  int GroundSignDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "ground_sign_direction":
                        GroundSignDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:standing_sign";
            record.Id = 63;
            record.States.Add(new BlockStateInt {Name = "ground_sign_direction", Value = GroundSignDirection});
            return record;
        } // method
    } // class

    public partial class StickyPiston  // 29 typeof=StickyPiston
	{
		public override string Name => "minecraft:sticky_piston";
		public int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:sticky_piston";
            record.Id = 29;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class StickyPistonArmCollision  // 472 typeof=StickyPistonArmCollision
	{
		public override string Name => "minecraft:sticky_piston_arm_collision";
		[StateRange(0, 5)] public  int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:sticky_piston_arm_collision";
            record.Id = 0;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

	public partial class Stone // 1 typeof=Stone
	{
		public override string Name => "minecraft:stone";
		[StateEnum("andesite_smooth", "diorite_smooth", "granite", "diorite", "stone", "granite_smooth", "andesite")]
		public string StoneType { get; set; } = "stone";

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "stone_type":
						StoneType = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:stone";
			record.Id = 1;
			record.States.Add(new BlockStateString { Name = "stone_type", Value = StoneType });
			return record;
		} // method
	} // class

	public partial class StoneBrickStairs  // 109 typeof=StoneBrickStairs
    {
		public override string Name => "minecraft:stone_brick_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:stone_brick_stairs";
            record.Id = 109;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class StoneButton  // 77 typeof=StoneButton
    {
		public override string Name => "minecraft:stone_button";
		[StateBit] public override bool ButtonPressedBit { get; set; } = false;
        [StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "button_pressed_bit":
                        ButtonPressedBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
						Direction = s.Value;
						break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:stone_button";
            record.Id = 77;
            record.States.Add(new BlockStateByte {Name = "button_pressed_bit", Value = Convert.ToByte(ButtonPressedBit)});
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class StonePressurePlate  // 70 typeof=StonePressurePlate
    {
		public override string Name => "minecraft:stone_pressure_plate";
		public int RedstoneSignal { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "redstone_signal":
                        RedstoneSignal = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:stone_pressure_plate";
            record.Id = 70;
            record.States.Add(new BlockStateInt {Name = "redstone_signal", Value = RedstoneSignal});
            return record;
        } // method
    } // class

    public partial class StoneStairs  // 67 typeof=StoneStairs
    {
		public override string Name => "minecraft:stone_stairs";
		[StateBit] public override bool UpsideDownBit { get; set; } = false;
        [StateRange(0, 3)] public override int WeirdoDirection { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "weirdo_direction":
                        WeirdoDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:stone_stairs";
            record.Id = 67;
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            record.States.Add(new BlockStateInt {Name = "weirdo_direction", Value = WeirdoDirection});
            return record;
        } // method
    } // class

    public partial class Stonebrick // 98 typeof=Stonebrick
    {
        public override string Name => "minecraft:stonebrick";

        [StateEnum("smooth","default","chiseled","cracked","mossy")]
        public string StoneBrickType { get; set; } = "smooth";

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "stone_brick_type":
                        StoneBrickType = s.Value;
						if (s.Value == "default")
						{
							StoneBrickType = "smooth";
						}
						break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:stonebrick";
            record.Id = 98;
            record.States.Add(new BlockStateString {Name = "stone_brick_type", Value = StoneBrickType});
            return record;
        } // method
    } // class

	public partial class Stonecutter  // 245 typeof=Stonecutter
    {
		public override string Name => "minecraft:stonecutter";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:stonecutter";
            record.Id = 245;
            return record;
        } // method
    } // class

    public partial class StonecutterBlock : Block // 452 typeof=StonecutterBlock
    {
		public override string Name => "minecraft:stonecutter_block";
		[StateRange(0, 5)] public int Direction { get; set; } = 2;

		public StonecutterBlock() : base(452)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
					case BlockStateInt s when s.Name == "facing_direction":
						Direction = s.Value;
						break;
				} // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:stonecutter_block";
            record.Id = 452;
			record.States.Add(new BlockStateInt { Name = "facing_direction", Value = Direction });
			return record;
        } // method
    } // class

    public partial class StrippedAcaciaLog : Block // 263 typeof=StrippedAcaciaLog
    {
		public override string Name => "minecraft:stripped_acacia_log";
		[StateEnum("x","z","y")]
        public  string PillarAxis { get; set; } = "y";
        
        public StrippedAcaciaLog() : base(263)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "pillar_axis":
                        PillarAxis = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:stripped_acacia_log";
            record.Id = 263;
            record.States.Add(new BlockStateString {Name = "pillar_axis", Value = PillarAxis});
            return record;
        } // method
    } // class

    public partial class StrippedBirchLog : Block // 261 typeof=StrippedBirchLog
    {
		public override string Name => "minecraft:stripped_birch_log";
		[StateEnum("x","z","y")]
        public  string PillarAxis { get; set; } = "y";
        
        public StrippedBirchLog() : base(261)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "pillar_axis":
                        PillarAxis = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:stripped_birch_log";
            record.Id = 261;
            record.States.Add(new BlockStateString {Name = "pillar_axis", Value = PillarAxis});
            return record;
        } // method
    } // class


    public partial class StrippedDarkOakLog : Block // 264 typeof=StrippedDarkOakLog
    {
		public override string Name => "minecraft:stripped_dark_oak_log";
		[StateEnum("x","z","y")]
        public  string PillarAxis { get; set; } = "y";
        
        public StrippedDarkOakLog() : base(264)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "pillar_axis":
                        PillarAxis = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:stripped_dark_oak_log";
            record.Id = 264;
            record.States.Add(new BlockStateString {Name = "pillar_axis", Value = PillarAxis});
            return record;
        } // method
    } // class

    public partial class StrippedJungleLog : Block // 262 typeof=StrippedJungleLog
    {
		public override string Name => "minecraft:stripped_jungle_log";
		[StateEnum("x","z","y")]
        public  string PillarAxis { get; set; } = "y";
        
        public StrippedJungleLog() : base(262)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "pillar_axis":
                        PillarAxis = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:stripped_jungle_log";
            record.Id = 262;
            record.States.Add(new BlockStateString {Name = "pillar_axis", Value = PillarAxis});
            return record;
        } // method
    } // class

    public partial class StrippedOakLog : Block // 265 typeof=StrippedOakLog
    {
		public override string Name => "minecraft:stripped_oak_log";
		[StateEnum("x","z","y")]
        public  string PillarAxis { get; set; } = "y";
        
        public StrippedOakLog() : base(265)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "pillar_axis":
                        PillarAxis = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:stripped_oak_log";
            record.Id = 265;
            record.States.Add(new BlockStateString {Name = "pillar_axis", Value = PillarAxis});
            return record;
        } // method
    } // class

    public partial class StrippedSpruceLog : Block // 260 typeof=StrippedSpruceLog
    {
		public override string Name => "minecraft:stripped_spruce_log";
		[StateEnum("x","z","y")]
        public  string PillarAxis { get; set; } = "y";
        
        public StrippedSpruceLog() : base(260)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "pillar_axis":
                        PillarAxis = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:stripped_spruce_log";
            record.Id = 260;
            record.States.Add(new BlockStateString {Name = "pillar_axis", Value = PillarAxis});
            return record;
        } // method
    } // class

    public partial class StructureBlock  // 252 typeof=StructureBlock
    {
		public override string Name => "minecraft:structure_block";
		[StateEnum("save","load","corner","invalid","export","data")]
        public  string StructureBlockType { get; set; } = "";

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "structure_block_type":
                        StructureBlockType = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:structure_block";
            record.Id = 252;
            record.States.Add(new BlockStateString {Name = "structure_block_type", Value = StructureBlockType});
            return record;
        } // method
    } // class

    public partial class StructureVoid  // 217 typeof=StructureVoid
	{
		public override string Name => "minecraft:structure_void";
		[StateEnum("void","air")]
        public  string StructureVoidType { get; set; } = "void";

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "structure_void_type":
                        StructureVoidType = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:structure_void";
            record.Id = 0;
            record.States.Add(new BlockStateString {Name = "structure_void_type", Value = StructureVoidType});
            return record;
        } // method
    } // class

    public partial class SweetBerryBush : Block // 462 typeof=SweetBerryBush
    {
		public override string Name => "minecraft:sweet_berry_bush";
		[StateRange(0, 7)] public  int Growth { get; set; } = 0;
        
        public SweetBerryBush() : base(462)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "growth":
                        Growth = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:sweet_berry_bush";
            record.Id = 462;
            record.States.Add(new BlockStateInt {Name = "growth", Value = Growth});
            return record;
        } // method
    } // class

    public partial class Tallgrass  // 31 typeof=Tallgrass
    {
		public override string Name => "minecraft:tallgrass";
		[StateEnum("default","tall","fern","snow")]
        public  string TallGrassType { get; set; } = "default";

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "tall_grass_type":
						if (s.Value == "tall")
						{
							TallGrassType = "default";
						}
						else
						{
							TallGrassType = s.Value;
						}
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:tallgrass";
            record.Id = 31;
            record.States.Add(new BlockStateString {Name = "tall_grass_type", Value = TallGrassType});
            return record;
        } // method
    } // class


    public partial class Tnt  // 46 typeof=Tnt
    {
		public override string Name => "minecraft:tnt";
		[StateBit] public  bool AllowUnderwaterBit { get; set; } = false;
        [StateBit] public  bool ExplodeBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "allow_underwater_bit":
                        AllowUnderwaterBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "explode_bit":
                        ExplodeBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:tnt";
            record.Id = 46;
            record.States.Add(new BlockStateByte {Name = "allow_underwater_bit", Value = Convert.ToByte(AllowUnderwaterBit)});
            record.States.Add(new BlockStateByte {Name = "explode_bit", Value = Convert.ToByte(ExplodeBit)});
            return record;
        } // method
    } // class

    public partial class Torch  // 50 typeof=Torch
    {
		public override string Name => "minecraft:torch";
		[StateEnum("west","east","north","south","top","unknown")]
        public  string TorchFacingDirection { get; set; } = "";

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "torch_facing_direction":
                        TorchFacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:torch";
            record.Id = 50;
            record.States.Add(new BlockStateString {Name = "torch_facing_direction", Value = TorchFacingDirection});
            return record;
        } // method
    } // class

    public partial class Trapdoor  // 96 typeof=Trapdoor
    {
		public override string Name => "minecraft:trapdoor";
		[StateRange(0, 3)] public override int Direction { get; set; } = 0;
        [StateBit] public override bool OpenBit { get; set; } = false;
        [StateBit] public override bool UpsideDownBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "open_bit":
                        OpenBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "upside_down_bit":
                        UpsideDownBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:trapdoor";
            record.Id = 96;
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "open_bit", Value = Convert.ToByte(OpenBit)});
            record.States.Add(new BlockStateByte {Name = "upside_down_bit", Value = Convert.ToByte(UpsideDownBit)});
            return record;
        } // method
    } // class

    public partial class TrappedChest  // 146 typeof=TrappedChest
    {
		public override string Name => "minecraft:trapped_chest";
		[StateRange(0, 5)] public int FacingDirection { get; set; } = 2;

		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
					case BlockStateInt s when s.Name == "facing_direction":
						FacingDirection = s.Value;
						break;
				} // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:trapped_chest";
            record.Id = 146;
			record.States.Add(new BlockStateInt { Name = "facing_direction", Value = FacingDirection });
			return record;
        } // method
    } // class

    public partial class TripWire  // 132 typeof=TripWire
    {
		public override string Name => "minecraft:trip_wire";
		[StateBit] public  bool AttachedBit { get; set; } = false;
        [StateBit] public  bool DisarmedBit { get; set; } = false;
        [StateBit] public  bool PoweredBit { get; set; } = false;
        [StateBit] public  bool SuspendedBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "attached_bit":
                        AttachedBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "disarmed_bit":
                        DisarmedBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "powered_bit":
                        PoweredBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "suspended_bit":
                        SuspendedBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:trip_wire";
            record.Id = 132;
            record.States.Add(new BlockStateByte {Name = "attached_bit", Value = Convert.ToByte(AttachedBit)});
            record.States.Add(new BlockStateByte {Name = "disarmed_bit", Value = Convert.ToByte(DisarmedBit)});
            record.States.Add(new BlockStateByte {Name = "powered_bit", Value = Convert.ToByte(PoweredBit)});
            record.States.Add(new BlockStateByte {Name = "suspended_bit", Value = Convert.ToByte(SuspendedBit)});
            return record;
        } // method
    } // class

    public partial class TripwireHook  // 131 typeof=TripwireHook
    {
		public override string Name => "minecraft:tripwire_hook";
		[StateBit] public  bool AttachedBit { get; set; } = false;
        [StateRange(0, 3)] public  int Direction { get; set; } = 0;
        [StateBit] public  bool PoweredBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "attached_bit":
                        AttachedBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
                        break;
                    case BlockStateByte s when s.Name == "powered_bit":
                        PoweredBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:tripwire_hook";
            record.Id = 131;
            record.States.Add(new BlockStateByte {Name = "attached_bit", Value = Convert.ToByte(AttachedBit)});
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "powered_bit", Value = Convert.ToByte(PoweredBit)});
            return record;
        } // method
    } // class

    public partial class TurtleEgg : Block // 414 typeof=TurtleEgg
    {
		public override string Name => "minecraft:turtle_egg";
		[StateEnum("cracked","max_cracked","no_cracks")]
        public  string CrackedState { get; set; } = "";
        [StateEnum("one_egg","two_egg","three_egg","four_egg")]
        public  string TurtleEggCount { get; set; } = "";
        
        public TurtleEgg() : base(414)
        {
            IsGenerated = true;
        }

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "cracked_state":
                        CrackedState = s.Value;
                        break;
                    case BlockStateString s when s.Name == "turtle_egg_count":
                        TurtleEggCount = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:turtle_egg";
            record.Id = 414;
            record.States.Add(new BlockStateString {Name = "cracked_state", Value = CrackedState});
            record.States.Add(new BlockStateString {Name = "turtle_egg_count", Value = TurtleEggCount});
            return record;
        } // method
    } // class

    public partial class UnlitRedstoneTorch  // 75 typeof=UnlitRedstoneTorch
    {
		public override string Name => "minecraft:unlit_redstone_torch";
		public string TorchFacingDirection { get; set; } = "top";

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateString s when s.Name == "torch_facing_direction":
                        TorchFacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:unlit_redstone_torch";
            record.Id = 75;
            record.States.Add(new BlockStateString {Name = "torch_facing_direction", Value = TorchFacingDirection});
            return record;
        } // method
    } // class

    public partial class UnpoweredComparator  // 149 typeof=UnpoweredComparator
    {
		public override string Name => "minecraft:unpowered_comparator";
		[StateRange(0, 3)] public int Direction { get; set; } = 0;
		[StateBit] public  bool OutputLitBit { get; set; } = false;
        [StateBit] public  bool OutputSubtractBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
					case BlockStateInt s when s.Name == "direction":
						Direction = s.Value;
						break;
					case BlockStateByte s when s.Name == "output_lit_bit":
                        OutputLitBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "output_subtract_bit":
                        OutputSubtractBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:unpowered_comparator";
            record.Id = 149;
			record.States.Add(new BlockStateInt { Name = "direction", Value = Direction });
			record.States.Add(new BlockStateByte {Name = "output_lit_bit", Value = Convert.ToByte(OutputLitBit)});
            record.States.Add(new BlockStateByte {Name = "output_subtract_bit", Value = Convert.ToByte(OutputSubtractBit)});
            return record;
        } // method
    } // class

    public partial class UnpoweredRepeater  // 93 typeof=UnpoweredRepeater
    {
		public override string Name => "minecraft:unpowered_repeater";
		[StateRange(0, 3)] public int Direction { get; set; } = 0;
		[StateRange(0, 3)] public  int RepeaterDelay { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
					case BlockStateInt s when s.Name == "direction":
						Direction = s.Value;
						break;
					case BlockStateInt s when s.Name == "repeater_delay":
                        RepeaterDelay = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:unpowered_repeater";
            record.Id = 93;
			record.States.Add(new BlockStateInt { Name = "direction", Value = Direction });
			record.States.Add(new BlockStateInt {Name = "repeater_delay", Value = RepeaterDelay});
            return record;
        } // method
    } // class

    public partial class Vine  // 106 typeof=Vine
    {
		public override string Name => "minecraft:vine";
		[StateRange(0, 15)] public  int VineDirectionBits { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "vine_direction_bits":
                        VineDirectionBits = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:vine";
            record.Id = 106;
            record.States.Add(new BlockStateInt {Name = "vine_direction_bits", Value = VineDirectionBits});
            return record;
        } // method
    } // class

    public partial class WallBanner  // 177 typeof=WallBanner
    {
		public override string Name => "minecraft:wall_banner";
		[StateRange(0, 5)] public  int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:wall_banner";
            record.Id = 177;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class WallSign  // 68 typeof=WallSign
    {
		public override string Name => "minecraft:wall_sign";
		[StateRange(0, 5)] public  int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:wall_sign";
            record.Id = 68;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class Water  // 9 typeof=Water
    {
		public override string Name => "minecraft:water";
		[StateRange(0, 15)] public override int LiquidDepth { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "liquid_depth":
                        LiquidDepth = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:water";
            record.Id = 9;
            record.States.Add(new BlockStateInt {Name = "liquid_depth", Value = LiquidDepth});
            return record;
        } // method
    } // class

    public partial class Waterlily  // 111 typeof=Waterlily
    {
		public override string Name => "minecraft:waterlily";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:waterlily";
            record.Id = 111;
            return record;
        } // method
    } // class

    public partial class Web  // 30 typeof=Web
    {
		public override string Name => "minecraft:web";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:web";
            record.Id = 30;
            return record;
        } // method
    } // class


    public partial class Wheat  // 59 typeof=Wheat
    {
		public override string Name => "minecraft:wheat";
		[StateRange(0, 7)] public override int Growth { get; set; } = 0;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "growth":
                        Growth = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:wheat";
            record.Id = 59;
            record.States.Add(new BlockStateInt {Name = "growth", Value = Growth});
            return record;
        } // method
    } // class

    public partial class WhiteGlazedTerracotta  // 220 typeof=WhiteGlazedTerracotta
    {
		public override string Name => "minecraft:white_glazed_terracotta";
		[StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:white_glazed_terracotta";
            record.Id = 220;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class WitherRose  // 471 typeof=WitherRose
	{
		public override string Name => "minecraft:wither_rose";
		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:wither_rose";
            record.Id = 471;
            return record;
        } // method
    } // class


    public partial class WoodenButton  // 143 typeof=WoodenButton
    {
		public override string Name => "minecraft:wooden_button";
		[StateBit] public override bool ButtonPressedBit { get; set; } = false;
        [StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateByte s when s.Name == "button_pressed_bit":
                        ButtonPressedBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
						Direction = s.Value;
						break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:wooden_button";
            record.Id = 143;
            record.States.Add(new BlockStateByte {Name = "button_pressed_bit", Value = Convert.ToByte(ButtonPressedBit)});
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

    public partial class WoodenDoor  // 64 typeof=WoodenDoor
    {
		public override string Name => "minecraft:wooden_door";
		[StateRange(0, 3)] public override int Direction { get; set; } = 0;
        [StateBit] public override bool DoorHingeBit { get; set; } = false;
        [StateBit] public override bool OpenBit { get; set; } = false;
        [StateBit] public override bool UpperBlockBit { get; set; } = false;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "direction":
                        Direction = s.Value;
						fDirection = s.Value;
						break;
                    case BlockStateByte s when s.Name == "door_hinge_bit":
                        DoorHingeBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "open_bit":
                        OpenBit = Convert.ToBoolean(s.Value);
                        break;
                    case BlockStateByte s when s.Name == "upper_block_bit":
                        UpperBlockBit = Convert.ToBoolean(s.Value);
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:wooden_door";
            record.Id = 64;
            record.States.Add(new BlockStateInt {Name = "direction", Value = Direction});
            record.States.Add(new BlockStateByte {Name = "door_hinge_bit", Value = Convert.ToByte(DoorHingeBit)});
            record.States.Add(new BlockStateByte {Name = "open_bit", Value = Convert.ToByte(OpenBit)});
            record.States.Add(new BlockStateByte {Name = "upper_block_bit", Value = Convert.ToByte(UpperBlockBit)});
            return record;
        } // method
    } // class

    public partial class WoodenPressurePlate : PressurePlateBase  // 72 typeof=WoodenPressurePlate
    {
		public override string Name => "minecraft:wooden_pressure_plate";
		public override int RedstoneSignal { get; set; } = 0;

		public WoodenPressurePlate() : base(72)
		{
			IsGenerated = true;
		}

		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "redstone_signal":
                        RedstoneSignal = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:wooden_pressure_plate";
            record.Id = 72;
            record.States.Add(new BlockStateInt {Name = "redstone_signal", Value = RedstoneSignal});
            return record;
        } // method
    } // class

	public partial class WoodenSlab // 158 typeof=WoodenSlab
	{
		public override string Name => "minecraft:wooden_slab";

		[StateBit] public bool TopSlotBit { get; set; } = false;
		[StateEnum("spruce", "jungle", "birch", "dark_oak", "acacia")]
		public string WoodType { get; set; } = "spruce";

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateByte s when s.Name == "top_slot_bit":
						TopSlotBit = Convert.ToBoolean(s.Value);
						break;
					case BlockStateString s when s.Name == "wood_type":
						WoodType = s.Value;
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:wooden_slab";
			record.Id = 158;
			record.States.Add(new BlockStateByte { Name = "top_slot_bit", Value = Convert.ToByte(TopSlotBit) });
			record.States.Add(new BlockStateString { Name = "wood_type", Value = WoodType });
			return record;
		} // method
	} // class

	public partial class YellowFlower  // 37 typeof=YellowFlower
    {
		public override string Name => "minecraft:yellow_flower";

		public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:yellow_flower";
            record.Id = 37;
            return record;
        } // method
    } // class

    public partial class YellowGlazedTerracotta  // 224 typeof=YellowGlazedTerracotta
    {
		public override string Name => "minecraft:yellow_glazed_terracotta";
		[StateRange(0, 5)] public override int FacingDirection { get; set; } = 2;

        public override void SetState(List<IBlockState> states)
        {
            foreach (var state in states)
            {
                switch(state)
                {
                    case BlockStateInt s when s.Name == "facing_direction":
                        FacingDirection = s.Value;
                        break;
                } // switch
            } // foreach
        } // method

        public override BlockStateContainer GetState()
        {
            var record = new BlockStateContainer();
            record.Name = "minecraft:yellow_glazed_terracotta";
            record.Id = 224;
            record.States.Add(new BlockStateInt {Name = "facing_direction", Value = FacingDirection});
            return record;
        } // method
    } // class

	public partial class Coral // 387 typeof=CoralBlock
	{
		public override string Name => "minecraft:coral_block";
		[StateEnum("pink", "purple", "red", "yellow", "blue")]
		public string CoralColor { get; set; } = "";
		[StateBit] public bool DeadBit { get; set; } = false;

		public override void SetState(List<IBlockState> states)
		{
			foreach (var state in states)
			{
				switch (state)
				{
					case BlockStateString s when s.Name == "coral_color":
						CoralColor = s.Value;
						break;
					case BlockStateByte s when s.Name == "dead_bit":
						DeadBit = Convert.ToBoolean(s.Value);
						break;
				} // switch
			} // foreach
		} // method

		public override BlockStateContainer GetState()
		{
			var record = new BlockStateContainer();
			record.Name = "minecraft:coral_block";
			record.Id = 387;
			record.States.Add(new BlockStateString { Name = "coral_color", Value = CoralColor });
			record.States.Add(new BlockStateByte { Name = "dead_bit", Value = Convert.ToByte(DeadBit) });
			return record;
		} // method
	} // class

	public partial class Allow : Block { public Allow() : base(210) { IsGenerated = true; } }
	public partial class StructureVoid : Block { public StructureVoid() : base(217) { IsGenerated = true; } }
	public partial class BorderBlock : Block { public BorderBlock() : base(212) { IsGenerated = true; } }
	public partial class StickyPistonArmCollision : Block { public StickyPistonArmCollision() : base(472) { IsGenerated = true; } }
	public partial class Chain : Block { public Chain() : base(541) { IsGenerated = true; } }

}

