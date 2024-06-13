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
// All portions of the code written by Niclas Olofsson are Copyright (c) 2014-2020 Niclas Olofsson.
// All Rights Reserved.

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using MiNET.Plugins;

namespace MiNET.Net
{
	public class EnumData
	{
		public string Name { get; set; }
		public string[] Values { get; set; }
		public EnumData(string name, string[] values)
		{
			Name = name;
			Values = values;
		}
	}
	public partial class McpeAvailableCommands
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(McpeAvailableCommands));

		public CommandSet CommandSet { get; set; }

		public List<Command> CommandList { get; set; } = new List<Command>();

		partial void AfterDecode()
		{
			uint enumValueCount = ReadUnsignedVarInt();
			for (int i = 0; i < enumValueCount; i++)
			{
				string str = ReadString();
			}

			uint chainedValueCount = ReadUnsignedVarInt();
			for (int i = 0; i < chainedValueCount; i++)
			{
				string str = ReadString();
			}

			uint postfixCount = ReadUnsignedVarInt();
			for (int i = 0; i < postfixCount; i++)
			{
				string str = ReadString();
			}

			uint enumDataCount = ReadUnsignedVarInt();
			for (int i = 0; i < enumDataCount; i++)
			{
				string str = ReadString();
				uint valuesCount = ReadUnsignedVarInt();
				int enumValue = 0;
				for (int a = 0; a < valuesCount; a++)
				{
					if (enumValueCount <= byte.MaxValue)
					{
						enumValue = ReadByte();
					}
					else if (enumValueCount <= short.MaxValue)
					{
						enumValue = ReadShort();
					}
					else
					{
						enumValue = ReadInt();
					}
				}
			}

			uint chainedValueData = ReadUnsignedVarInt();
			for (int i = 0; i < chainedValueData; i++)
			{
				string str = ReadString();
				uint valuesCount = ReadUnsignedVarInt();
				for (int a = 0; a < valuesCount; a++)
				{
					short subcommandData1 = ReadShort();
					short subcommandData2 = ReadShort();
				}
			}

			uint commandCount = ReadUnsignedVarInt();
			for (int i = 0; i < commandCount; i++)
			{
				string name = ReadString();
				string description = ReadString();
				short flags = ReadShort();
				byte permission = ReadByte();
				int alias = ReadInt();

				uint subcmdIndex = ReadUnsignedVarInt();
				for (int a = 0; a < subcmdIndex; a++)
				{
					short index = ReadShort();
				}

				uint overloads = ReadUnsignedVarInt();
				for (int a = 0; a < overloads; a++)
				{
					bool changing = ReadBool();
					uint parametrs = ReadUnsignedVarInt();
					for (int b = 0; b < parametrs; b++)
					{
						string prameterName = ReadString();
						int symbol = ReadInt();
						bool optional = ReadBool();
						byte options = ReadByte();
					}
				}

				Plugins.Version data = new Plugins.Version();
				data.Description = description;

				Command command = new Command();
				command.Name = name;
				command.Versions = [data];

				CommandList.Add(command);
			}

			uint softEnumCount = ReadUnsignedVarInt();
			for (int a = 0; a < softEnumCount; a++)
			{
				string enumName = ReadString();
				uint optionCount = ReadUnsignedVarInt();
				for (int b = 0; b < optionCount; b++)
				{
					string value = ReadString();
				}
			}

			uint constraintsCount = ReadUnsignedVarInt();
			for (int a = 0; a < constraintsCount; a++)
			{
				int symbol = ReadInt();
				int symbolValue = ReadInt();
				uint constraintIndices = ReadUnsignedVarInt();
				for (int b = 0; b < constraintIndices; b++)
				{
					byte index = ReadByte();
				}
			}
		}

		partial void AfterEncode()
		{
			try
			{
				if (CommandSet == null || CommandSet.Count == 0)
				{
					Log.Warn("No commands to send");
					WriteUnsignedVarInt(0); // enum value size
					WriteUnsignedVarInt(0); // ch subcom value
					WriteUnsignedVarInt(0); // postfix size
					WriteUnsignedVarInt(0); // enums size
					WriteUnsignedVarInt(0); // subcom data
					WriteUnsignedVarInt(0); // command size
					WriteUnsignedVarInt(0); // soft enum size
					WriteUnsignedVarInt(0); // enum constraints
					return;
				}

				var commands = CommandSet;

				List<string> stringList = new List<string>();
				{
					foreach (var command in commands.Values)
					{
						var aliases = command.Versions[0].Aliases.Concat(new string[] {command.Name}).ToArray();
						foreach (var alias in aliases)
						{
							if (!stringList.Contains(alias))
							{
								stringList.Add(alias);
							}
						}

						var overloads = command.Versions[0].Overloads;
						foreach (var overload in overloads.Values)
						{
							var parameters = overload.Input.Parameters;
							if (parameters == null) continue;
							foreach (var parameter in parameters)
							{
								if (parameter.Type == "stringenum")
								{
									if (parameter.EnumValues == null) continue;
									foreach (var enumValue in parameter.EnumValues)
									{
										if (!stringList.Contains(enumValue))
										{
											stringList.Add(enumValue);
										}
									}
								}
							}
						}
					}

					WriteUnsignedVarInt((uint) stringList.Count); // Enum values
					foreach (var s in stringList)
					{
						Write(s);
						//Log.Debug($"String: {s}, {(short) stringList.IndexOf(s)} ");
					}
				}
				
				WriteUnsignedVarInt(0); // subcommand values
				WriteUnsignedVarInt(0); // Postfixes

				List<string> enumList = new List<string>();
				foreach (var command in commands.Values)
				{
					if (command.Versions[0].Aliases.Length > 0)
					{
						string aliasEnum = command.Name + "CommandAliases";
						if (!enumList.Contains(aliasEnum))
						{
							enumList.Add(aliasEnum);
						}
					}

					var overloads = command.Versions[0].Overloads;
					foreach (var overload in overloads.Values)
					{
						var parameters = overload.Input.Parameters;
						if (parameters == null) continue;
						foreach (var parameter in parameters)
						{
							if (parameter.Type == "stringenum")
							{
								if (parameter.EnumValues == null) continue;

								if (!enumList.Contains(parameter.EnumType))
								{
									enumList.Add(parameter.EnumType);
								}
							}
						}
					}
				}

				//WriteUnsignedVarInt(0); // Enum indexes
				WriteUnsignedVarInt((uint) enumList.Count); // Enum indexes
				List<string> writtenEnumList = new List<string>();
				foreach (var command in commands.Values)
				{
					if (command.Versions[0].Aliases.Length > 0)
					{
						var aliases = command.Versions[0].Aliases.Concat(new string[] {command.Name}).ToArray();
						string aliasEnum = command.Name + "CommandAliases";
						if (!enumList.Contains(aliasEnum)) continue;
						if (writtenEnumList.Contains(aliasEnum)) continue;

						Write(aliasEnum);
						WriteUnsignedVarInt((uint) aliases.Length);
						foreach (var enumValue in aliases)
						{
							if (!stringList.Contains(enumValue)) Log.Error($"Expected enum value: {enumValue} in string list, but didn't find it.");
							if (stringList.Count <= byte.MaxValue)
							{
								Write((byte) stringList.IndexOf(enumValue));
							}
							else if (stringList.Count <= short.MaxValue)
							{
								Write((short) stringList.IndexOf(enumValue));
							}
							else
							{
								Write((int) stringList.IndexOf(enumValue));
							}

							//Log.Debug($"EnumType: {aliasEnum}, {enumValue}, {stringList.IndexOf(enumValue)} ");
						}
					}
					
					var overloads = command.Versions[0].Overloads;
					foreach (var overload in overloads.Values)
					{
						var parameters = overload.Input.Parameters;
						if (parameters == null) continue;
						foreach (var parameter in parameters)
						{
							if (parameter.Type == "stringenum")
							{
								if (parameter.EnumValues == null) continue;

								if (!enumList.Contains(parameter.EnumType)) continue;
								if (writtenEnumList.Contains(parameter.EnumType)) continue;

								writtenEnumList.Add(parameter.EnumType);

								Write(parameter.EnumType);
								WriteUnsignedVarInt((uint) parameter.EnumValues.Length);
								foreach (var enumValue in parameter.EnumValues)
								{
									if (!stringList.Contains(enumValue)) Log.Error($"Expected enum value: {enumValue} in string list, but didn't find it.");
									if (stringList.Count <= byte.MaxValue)
									{
										Write((byte) stringList.IndexOf(enumValue));
									}
									else if (stringList.Count <= short.MaxValue)
									{
										Write((short) stringList.IndexOf(enumValue));
									}
									else
									{
										Write((int) stringList.IndexOf(enumValue));
									}

									//Log.Debug($"EnumType: {parameter.EnumType}, {enumValue}, {stringList.IndexOf(enumValue)} ");
								}
							}
						}
					}
				}
				
				WriteUnsignedVarInt(0);  // chained subcommands

				WriteUnsignedVarInt((uint) commands.Count);
				foreach (var command in commands.Values)
				{
					Write(command.Name);
					Write(command.Versions[0].Description);
					Write((short) 0); // flags
					Write((byte) command.Versions[0].CommandPermission); // permissions

					if (command.Versions[0].Aliases.Length > 0)
					{
						string aliasEnum = command.Name + "CommandAliases";
						Write((int) enumList.IndexOf(aliasEnum));
					}
					else
					{
						Write((int) -1); // Enum index
					}

					//Log.Warn($"Writing command {command.Name}");

					WriteUnsignedVarInt(0);
					var overloads = command.Versions[0].Overloads;
					WriteUnsignedVarInt((uint) overloads.Count); // Overloads
					foreach (var overload in overloads.Values)
					{
						Write(false);
						//Log.Warn($"Writing command: {command.Name}");

						var parameters = overload.Input.Parameters;
						if (parameters != null)
						{
							foreach (var parameter in parameters)
							{
								if (parameter.Type == "softenum" || parameter.Type == "value" || parameter.Type == "blockpos" || parameter.Type == "entitypos")
								{
									parameters = null;
								}
							}

						}
						if (parameters == null)
						{
							WriteUnsignedVarInt(0); // Parameter count
							continue;
						}
						WriteUnsignedVarInt((uint) parameters.Length);
						foreach (var parameter in parameters)
						{
							//Log.Debug($"Writing command overload parameter {command.Name}, {parameter.Name}, {parameter.Type}");
							if (parameter.Type == "stringenum" && parameter.EnumValues != null)
							{
								Write(parameter.Name); // parameter name
								Write(0x200000 | enumList.IndexOf(parameter.EnumType));
								Write(parameter.Optional); // optional
								Write((byte) 0); // unknown
							}
							else if (parameter.Type == "softenum" && parameter.EnumValues != null)
							{
								//todo
							}
							else
							{
								Write(parameter.Name); // parameter name
								Write(0x100000 | GetParameterTypeId(parameter.Type)); // param type
								Write(parameter.Optional); // optional
								Write((byte) 0); // unknown
							}
						}
					}
				}

				WriteUnsignedVarInt(0); //TODO: soft enums

				WriteUnsignedVarInt(0); //TODO: constraints
			}
			catch (Exception e)
			{
				Log.Error("Sending commands", e);
				//throw;
			}
		}

		private int GetParameterTypeId(string type)
		{
			return type switch
			{
				"enum" => -1,
				"unknown" => 0,
				"int" => 0x01,
				"float" => 0x03,
				"mixed" => 0x04,
				"wildcardint" => 0x05,
				"operator" => 0x06,
				"operatorcompare" => 0x06,
				"target" => 0x08,
				"wildcardtarget" => 0x0A,
				"filename" => 0x11,
				"fullintrange" => 0x17,
				"equipmentslot" => 0x2B,
				"string" => 0x2C,
				"blockpositon" => 0x34,
				"pos" => 0x35,
				"message" => 0x37,
				"rawtext" => 0x3A,
				"json" => 0x3E,
				"blockstates" => 0x47,
				"command" => 0x4A,
				_ => 0
			};
		}

		private string GetParameterTypeName(int type)
		{

			return type switch
			{
				-1   => "enum",
				0    => "unknown",
				0x01 => "int",
				0x03 => "float",
				0x04 => "mixed",
				0x05 => "wildcardint",
				0x06 => "operator",
				0x07 => "operatorcompare",
				0x08 => "target",
				0x0A => "wildcardtarget",
				0x11 => "filename",
				0x17 => "fullintrange",
				0x2B => "equipmentslot",
				0x2C => "string",
				0x34 => "blockpositon",
				0x35 => "pos",
				0x37 => "message", // kick, me, etc
				0x3A => "rawtext", // kick, me, etc
				0x3E => "json", // give, replace
				0x47 => "blockstates",
				0x4A => "command",
				_    => $"undefined({type})"
			};
		}
	}
}