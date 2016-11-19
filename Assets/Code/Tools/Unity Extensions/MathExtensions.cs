using UnityEngine;

namespace UnityEngine
{
    public static class MathExtensions
    {
        /// <summary>
        /// Casts a Vector2 to a Vector2Int
        /// </summary>
        /// <param name="v">Vector2 to cast</param>
        /// <returns>Vector2Int</returns>
        public static Vector2Int ToVector2Int(this Vector2 v)
        {
            return new Vector2Int(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y));

        }

        /// <summary>
        /// Casts a Vector3 to a Vector2Int
        /// </summary>
        /// <param name="v">Vector 3 to cast</param>
        /// <returns>Vector2Int</returns>
        public static Vector2Int ToVector2Int(this Vector3 v)
        {
            return new Vector2Int(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y));

        }
    }
}
