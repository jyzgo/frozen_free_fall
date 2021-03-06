using UnityEngine;
using System.Collections;

/// <summary>
/// LockedTile
/// 
/// This tile is not moveable and can only be destroyed by doing a match with other pieces around it that have the same color
/// like this one.
/// Upon destruction this tile will turn into a <see cref="NormalTile"/> with the same color.
/// </summary>
public class LockedTile : NormalTile
{
	public static event System.Action<LockedTile> OnLockedTileDestroyed;
		
	public GameObject prefabIceDestroyEffect;
			
	/// <summary>
	/// Does the actual destroying of the tile game object. Replaces the locked tile with a normal tile of the same color.
	/// </summary>
	protected override void TileDestroy(bool useEffect) 
	{
		if (OnLockedTileDestroyed != null) {
			OnLockedTileDestroyed(this);
		}
		
		if(!CheckForSpawnPatterns())
		{
			BoardPiece.Tile = (BoardRenderer as Match3BoardRenderer).SpawnSpecificTileAt(BoardPiece.BoardPosition.row, 
							BoardPiece.BoardPosition.col, typeof(NormalTile), TileColor);
		}
		
		base.TileDestroy(false);

		if (useDestroyEffect && useEffect) {
			Transform effectInstance = (Instantiate(prefabIceDestroyEffect) as GameObject).transform;
			effectInstance.position = WorldPosition;
		}
	}
}
