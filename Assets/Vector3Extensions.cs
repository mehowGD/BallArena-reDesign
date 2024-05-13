using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public static class Vector3Extensions
    {
        public static Vector2 GroundVector(this Vector3 vector) => new Vector2(vector.x, vector.z);
        public static Vector3 GroundVector(this Vector3 vector, Vector3 upVec) => new Plane(upVec, Vector3.zero).ClosestPointOnPlane(vector);
        public static Vector2 GroundVector(this Vector4 vector) => new Vector2(vector.x, vector.z);
        public static Vector3 GroundVector(this Vector4 vector, Vector3 upVec) => new Plane(upVec, Vector3.zero).ClosestPointOnPlane(vector);
        public static Vector3 ProjectVertically(this Vector2 vector, Plane plane) => new Vector3(vector.x, (-plane.distance - plane.normal.x * vector.x - plane.normal.z * vector.y) / plane.normal.y, vector.y);
        public static Vector3 GroundTo3D(this Vector2 vector) => new Vector3(vector.x, 0f, vector.y);
        public static Vector3 GroundTo3D(this Vector2 vector, float height) => new Vector3(vector.x, height, vector.y);
        public static Vector3Int Int(this Vector3 vector) => new Vector3Int(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y), Mathf.RoundToInt(vector.z));
        public static Vector2Int Int(this Vector2 vector) => new Vector2Int(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y));
        public static Vector2 Float(this Vector2Int vector) => new Vector2(vector.x, vector.y);
        public static Vector3 Float(this Vector3Int vector) => new Vector3(vector.x, vector.y, vector.z);
        public static Vector2 ToVector2(this Vector3 vector) => new Vector2(vector.x, vector.y);
        public static Vector3 ToVector3(this Vector2 vector) => new Vector3(vector.x, vector.y, 0f);
        public static Vector3 ToVector3(this Vector2 vector, float depth) => new Vector3(vector.x, vector.y, depth);
        public static Vector4 ToVector4(this Vector2 vector) => new Vector4(vector.x, vector.y, 0f, 1f);
        public static Vector4 ToVector4(this Vector3 vector) => new Vector4(vector.x, vector.y, vector.z, 1f);
        public static Vector4 ToVector4(this Vector3 vector, float w) => new Vector4(vector.x, vector.y, vector.z, w);
        public static Vector3 ToVector3(this Vector4 vector) => new Vector3(vector.x, vector.y, vector.z);
        public static float Max(this Vector3 vector) => Mathf.Max(vector.x, vector.y, vector.z);
        public static float Max(this Vector2 vector) => Mathf.Max(vector.x, vector.y);
        public static float Min(this Vector3 vector) => Mathf.Min(vector.x, vector.y, vector.z);
        public static float Min(this Vector2 vector) => Mathf.Min(vector.x, vector.y);
        public static int Max(this Vector3Int vector) => Mathf.Max(vector.x, vector.y, vector.z);
        public static int Max(this Vector2Int vector) => Mathf.Max(vector.x, vector.y);
        public static int Min(this Vector3Int vector) => Mathf.Min(vector.x, vector.y, vector.z);
        public static int Min(this Vector2Int vector) => Mathf.Min(vector.x, vector.y);
        public static Vector3Int Abs(this Vector3Int vector) => new Vector3Int(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
        public static Vector2Int Abs(this Vector2Int vector) => new Vector2Int(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
        public static Vector3 Abs(this Vector3 vector) => new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
        public static Vector2 Abs(this Vector2 vector) => new Vector2(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
        public static Vector2 Select(this Vector2 vector, Func<float, float> func) => new Vector2(func(vector.x), func(vector.y));
        public static Vector3 Select(this Vector3 vector, Func<float, float> func) => new Vector3(func(vector.x), func(vector.y), func(vector.z));
        public static Vector2 Sign(this Vector2 vector) => new Vector2(Mathf.Sign(vector.x), Mathf.Sign(vector.y));
        public static Vector3 Sign(this Vector3 vector) => new Vector3(Mathf.Sign(vector.x), Mathf.Sign(vector.y), Mathf.Sign(vector.z));
        public static Vector2 Pow(this Vector2 vector, float exp) => new Vector2(Mathf.Pow(vector.x, exp), Mathf.Pow(vector.y, exp));
        public static Vector3 Pow(this Vector3 vector, float exp) => new Vector3(Mathf.Pow(vector.x, exp), Mathf.Pow(vector.y, exp), Mathf.Pow(vector.z, exp));
        public static Vector3 Reciprocal(this Vector3 vector) => new Vector3(1f / vector.x, 1f / vector.y, 1f / vector.z);
        public static Vector2 Reciprocal(this Vector2 vector) => new Vector2(1f / vector.x, 1f / vector.y);
        public static Vector3 Clamp(this Vector3 vector, Vector3 min, Vector3 max) => new Vector3(Mathf.Clamp(vector.x, min.x, max.x), Mathf.Clamp(vector.y, min.y, max.y), Mathf.Clamp(vector.z, min.z, max.z));
        public static Vector3 Clamp(this Vector3 vector, float min, float max) => vector.Clamp(Vector3.one * min, Vector3.one * max);
        public static Vector3 Clamp01(this Vector3 vector) => vector.Clamp(Vector3.zero, Vector3.one);
        public static Vector2 Mod(this Vector2 vector, float value) => new Vector2(vector.x % value, vector.y % value);
        public static bool InBetween(this Vector2 input, Vector2 min, Vector2 max) => input.x >= min.x && input.y >= min.y && input.x <= max.x && input.y <= max.y;
        public static bool InBetween(this Vector3 input, Vector3 min, Vector3 max) => input.x >= min.x && input.y >= min.y && input.z >= min.z && input.x <= max.x && input.y <= max.y && input.z <= max.z;
        public static float Sum(this Vector2 input) => input.x + input.y;
        public static float Sum(this Vector3 input) => input.x + input.y + input.z;
        public static bool Any(this Vector3 input, Func<float, bool> func) => func(input.x) || func(input.y) || func(input.z);
        public static bool All(this Vector3 input, Func<float, bool> func) => func(input.x) && func(input.y) && func(input.z);

        public static Vector2 LoopRad(this Vector2 vector) => vector.Select(FloatExtensions.LoopRad);
        public static Vector2 LoopDeg(this Vector2 vector) => vector.Select(FloatExtensions.LoopDeg);
        public static Vector2 LoopRad(this Vector3 vector) => vector.Select(FloatExtensions.LoopRad);
        public static Vector2 LoopDeg(this Vector3 vector) => vector.Select(FloatExtensions.LoopDeg);
    }

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Fill<T>(this IEnumerable<T> collection, int count) => Fill(collection, count, default(T));

        public static IEnumerable<T> Fill<T>(this IEnumerable<T> collection, int count, T filler) => Fill(collection, count, () => filler);

        public static IEnumerable<T> Fill<T>(this IEnumerable<T> collection, int count, Func<T> filler)
        {
            foreach (var item in collection)
            {
                count--;
                yield return item;
            }

            foreach (var item in Enumerable.Range(0, Math.Max(count, 0)))
                yield return filler();
        }
    }

    public static class BoundsExtensions
    {
        public static IEnumerable<Vector3> GetCorners(this Bounds bounds)
        {
            var min = bounds.min;
            var max = bounds.max;
            var size = bounds.size;

            yield return min;
            yield return min + new Vector3(size.x, 0f, 0f);
            yield return min + new Vector3(0f, size.y, 0f);
            yield return min + new Vector3(0f, 0f, size.z);
            yield return min + new Vector3(size.x, size.y, 0f);
            yield return min + new Vector3(size.x, 0f, size.z);
            yield return min + new Vector3(0f, size.y, size.z);
            yield return max;
        }
    }

    public static class ColorExtensions 
    {
        public static Color WithAlpha(this Color input, float alpha) => new Color(input.r, input.g, input.b, alpha);
        public static Color WithAlpha(this Color input, Func<float, float> alpha) => new Color(input.r, input.g, input.b, alpha(input.a));
    }

    public static class FloatExtensions
    {
        public static float Mod(this float input, float mod) => input - mod * Mathf.Floor(input / mod);
        public static bool InBetween(this float input, float min, float max) => input >= min && input <= max;
        public static float NonZero(this float input, float epsilon) => Mathf.Sign(input) * Mathf.Max(Mathf.Abs(input), epsilon); 
        public static float DistanceTo(this float input, float target) => Mathf.Abs(target - input);
        public static float DistanceTo(this float input, float start, float end) => input < start ? (start - input) : (input > end ? input - end : 0f);
        public static float RelativeDistanceTo(this float input, float target, float scale) => Mathf.Abs(target - input) / scale;
        public static float RelativeDistanceTo(this float input, float start, float startScale, float end, float endScale) => input < start ? (start - input) / startScale : (input > end ? (input - end) / endScale : 0f);
        public static float EaseInOut(this float input) => Mathf.Cos((input + 1f) * Mathf.PI) * 0.5f + 0.5f;
        public static float ParametricBlend(this float input) => ParametricBlend(input, 2.0f);
        public static float ParametricBlend(this float input, float alpha) => Mathf.Pow(input, alpha) / (Mathf.Pow(input, alpha) + Mathf.Pow(1 - input, alpha));
        public static float EaseIn(this float input) => Mathf.Pow(input, 2f);
        public static float EaseOut(this float input) => Mathf.Pow(input, 0.5f);
        public static float LoopRad(this float angle)
        {
            while (angle > Mathf.PI)
                angle -= Mathf.PI * 2f;
            while (angle < -Mathf.PI)
                angle += Mathf.PI * 2f;

            return angle;
        }
        public static float LoopDeg(this float angle)
        {
            while (angle > 180f)
                angle -= 360f;
            while (angle < -180f)
                angle += 360f;

            return angle;
        }
    }
    
    public static class IntExtensions
    {
        public static int Mod(this int input, int mod)  
        {
            var t = input % mod;
            return t < 0 ? t + mod : t;
        }
        
        public static int Factorial(this int number)
        {
            return number <= 1 ? 1 : number * Factorial(number - 1);
        }
        
        public static int CombinationsWhenPicking(this int number, int pickCount)
        {
            return number.Factorial() / (pickCount.Factorial() * (number - pickCount).Factorial());
        }
    }
    
    public static class GradientExtensions
    {
        public static Gradient Scale(this Gradient gradient, float scale)
        {
            var newGradient = new Gradient();
            newGradient.SetKeys(gradient.colorKeys, gradient.alphaKeys.Select(x => new GradientAlphaKey(x.alpha * scale, x.time)).ToArray());
            return newGradient;
        }
    }
}
