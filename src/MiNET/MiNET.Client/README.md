MiNET Client
=====

Client used for debugging, tests and resource generation.

## How to generate blockstates.json?

 1. Download official [Minecraft Bedrock Edition server software](https://www.minecraft.net/en-us/download/server/bedrock)
 2. Open `server.properties` and set `online-mode=false`
 3. Run official Minecraft Bedrock Edition server software and MiNET client.
 4. When MiNET client say `... spawned`, in MiNET client console type `/blockstates`

After couple of minutes you should see `Completed successfully. All blockstates exported to 'newResources/blockstates.json`
