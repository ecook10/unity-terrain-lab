# Unity Terrain Lab

collection of scripts for generating terrain meshes


## Subdirectories

## Terrain
a mess of old code ultimately intended to generate a heightmap via instances of `HeightFilter` and apply it to the linked `Terrain` object

almost entirely copied from Sebastian's earlier videos liked below, w/ a few slight tweaks for applying the texture to a `Terrain` instead of a `Renderer`

## Filter
classes + instances of filters for generating heightmaps

## Mesh
old stuff from a couple other tutorials - leaving around just for shits


## TODO
1. get heightmap affecting the terrain heights (might just be able to simply use `Terrain.terrainData.SetHeight` - https://docs.unity3d.com/ScriptReference/TerrainData.SetHeights.html)
2. get `HeightFilter` and `PeakFilter` working really nicely + use on a few different terrains 
3. new `SlopeFilter` for directional slopes - use for coast and/or cliffs
4. model river / stream erosion (maybe determine path by pre-generated noisy sloping terrain?)


## Resources
* Brackeys procedural terrain generation - https://www.youtube.com/watch?v=64NblGkAabk&ab_channel=Brackeys
* Sebastian procedural terrain generation - https://www.youtube.com/playlist?list=PLFt_AvWsXl0eBW2EiBtl_sxmDtSgZBxB3
* ScriptableObjects inheritance demo (for `HeightFilter` stuff) - https://www.youtube.com/watch?v=0hwDgq9i7aw&ab_channel=Datprayincajun
