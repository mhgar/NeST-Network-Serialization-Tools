namespace Wander.NeST
{
  /// Information class that stores the size of primitives values in bytes.
  public static class Sizes
  {
    public const int BoolLength = 1;
    public const int ByteLength = 1;
    public const int SByteLength = 1;

    public const int ShortLength = 2;
    public const int UShortLength = 2;
    public const int CharLength = 2;

    public const int IntLength = 4;
    public const int UIntLength = 4;
    public const int FloatLength = 4;

    public const int LongLength = 8;
    public const int ULongLength = 8;
    public const int DoubleLength = 8;

    // Unused for now.
    // public const int DecimalLength = 16;
  }
}