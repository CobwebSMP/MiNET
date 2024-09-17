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
// All portions of the code written by Niclas Olofsson are Copyright (c) 2014-2018 Niclas Olofsson. 
// All Rights Reserved.

#endregion

using System.ComponentModel;

namespace MiNET.Items
{
	public class ItemDye : Item
	{
		public ItemDye() : base("minecraft:dye", 351)
		{
		}

		public static byte toColorCode(int metadata)
		{
			switch (metadata)
			{
				case 1: //red
					return 14;
				case 2: //green
					return 13;
				case 5: //purple
					return 10;
				case 6: //cyan
					return 9;
				case 7: //light_gray
					return 8;
				case 8: //gray
					return 7;
				case 9: //pink
					return 6;
				case 10: //lime
					return 5;
				case 11: //yellow
					return 4;
				case 12: //ligh_blue
					return 3;
				case 13: //magenta
					return 2;
				case 14: //orange
					return 1;
				case 16: //black
					return 15;
				case 17: //brown
					return 12;
				case 18: //blue
					return 11;
				case 19: //white
					return 0;
				default:
					return 255;
			}
		}
	}
}