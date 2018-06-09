using System;

namespace Wander.NeST
{
  /// A serialization helper that given a byte array allows you to serialize
  /// objects from it until the end of the array.
  public class Serializer
  {
    public byte[] Array { get { return data; } }
    public int Length { get { return dataLength; } }
    public int Position
    {
      get { return writeHead; }
      set
      {
        if (value > dataLength)
          throw new IndexOutOfRangeException();
        else
          writeHead = value;
      }
    }

    // Kind of unsafe but good enough for now.
    public bool HasEnded { get { return Position == dataLength; }}

    byte[] data;
    int writeHead = 0;
    int dataLength;

    public Serializer(byte[] array, int startIndex = 0, int length = -1)
    {
      if (array == null)
        throw new ArgumentNullException("array");

      if (length > array.Length)
        throw new ArgumentOutOfRangeException("length");

      // If length is default value, use size of the array instead.
      dataLength = (length < 0 ? array.Length : length);

      // Check if start index is greater than the array length, or if 'length'
      // has been set, check against that instead.
      if (startIndex > dataLength - 1)
        throw new ArgumentOutOfRangeException("startIndex");

      writeHead = startIndex;
      data = array;
    }

    // Don't need new() here; just for parity with Deserialize()
    /// Serialize an ISerializable to this object's internal byte array.
    public void Serialize<T>(T structure) where T : ISerializable, new()
    {
      structure.SerializeTo(this);
    }

    /// Serialize an object using a writer function that implements how the
    /// object should be serialized.
    public void SerializeUsing<T>(T value, Writers.Writer<T> writer)
    {
      // Allow thrown exceptions to fall through into the caller.
      writeHead += writer(value, data, writeHead);
    }

    /* ***AUTO-GENERATED***
     * Use these methods to quickly serialize a bunch of values at once. */
    public void SerializeUsing<A, B>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB
    )
    {
      Position += writerA(valueA, data, Position);
      Position += writerB(valueB, data, Position);
    }

    public void SerializeUsing<A, B, C>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB,
      C valueC, Writers.Writer<C> writerC
    )
    {
      Position += writerA(valueA, data, Position);
      Position += writerB(valueB, data, Position);
      Position += writerC(valueC, data, Position);
    }

    public void SerializeUsing<A, B, C, D>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB,
      C valueC, Writers.Writer<C> writerC,
      D valueD, Writers.Writer<D> writerD
    )
    {
      Position += writerA(valueA, data, Position);
      Position += writerB(valueB, data, Position);
      Position += writerC(valueC, data, Position);
      Position += writerD(valueD, data, Position);
    }

    public void SerializeUsing<A, B, C, D, E>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB,
      C valueC, Writers.Writer<C> writerC,
      D valueD, Writers.Writer<D> writerD,
      E valueE, Writers.Writer<E> writerE
    )
    {
      Position += writerA(valueA, data, Position);
      Position += writerB(valueB, data, Position);
      Position += writerC(valueC, data, Position);
      Position += writerD(valueD, data, Position);
      Position += writerE(valueE, data, Position);
    }

    public void SerializeUsing<A, B, C, D, E, F>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB,
      C valueC, Writers.Writer<C> writerC,
      D valueD, Writers.Writer<D> writerD,
      E valueE, Writers.Writer<E> writerE,
      F valueF, Writers.Writer<F> writerF
    )
    {
      Position += writerA(valueA, data, Position);
      Position += writerB(valueB, data, Position);
      Position += writerC(valueC, data, Position);
      Position += writerD(valueD, data, Position);
      Position += writerE(valueE, data, Position);
      Position += writerF(valueF, data, Position);
    }

    public void SerializeUsing<A, B, C, D, E, F, G>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB,
      C valueC, Writers.Writer<C> writerC,
      D valueD, Writers.Writer<D> writerD,
      E valueE, Writers.Writer<E> writerE,
      F valueF, Writers.Writer<F> writerF,
      G valueG, Writers.Writer<G> writerG
    )
    {
      Position += writerA(valueA, data, Position);
      Position += writerB(valueB, data, Position);
      Position += writerC(valueC, data, Position);
      Position += writerD(valueD, data, Position);
      Position += writerE(valueE, data, Position);
      Position += writerF(valueF, data, Position);
      Position += writerG(valueG, data, Position);
    }

    public void SerializeUsing<A, B, C, D, E, F, G, H>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB,
      C valueC, Writers.Writer<C> writerC,
      D valueD, Writers.Writer<D> writerD,
      E valueE, Writers.Writer<E> writerE,
      F valueF, Writers.Writer<F> writerF,
      G valueG, Writers.Writer<G> writerG,
      H valueH, Writers.Writer<H> writerH
    )
    {
      Position += writerA(valueA, data, Position);
      Position += writerB(valueB, data, Position);
      Position += writerC(valueC, data, Position);
      Position += writerD(valueD, data, Position);
      Position += writerE(valueE, data, Position);
      Position += writerF(valueF, data, Position);
      Position += writerG(valueG, data, Position);
      Position += writerH(valueH, data, Position);
    }

    public void SerializeUsing<A, B, C, D, E, F, G, H, I>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB,
      C valueC, Writers.Writer<C> writerC,
      D valueD, Writers.Writer<D> writerD,
      E valueE, Writers.Writer<E> writerE,
      F valueF, Writers.Writer<F> writerF,
      G valueG, Writers.Writer<G> writerG,
      H valueH, Writers.Writer<H> writerH,
      I valueI, Writers.Writer<I> writerI
    )
    {
      Position += writerA(valueA, data, Position);
      Position += writerB(valueB, data, Position);
      Position += writerC(valueC, data, Position);
      Position += writerD(valueD, data, Position);
      Position += writerE(valueE, data, Position);
      Position += writerF(valueF, data, Position);
      Position += writerG(valueG, data, Position);
      Position += writerH(valueH, data, Position);
      Position += writerI(valueI, data, Position);
    }

    public void SerializeUsing<A, B, C, D, E, F, G, H, I, J>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB,
      C valueC, Writers.Writer<C> writerC,
      D valueD, Writers.Writer<D> writerD,
      E valueE, Writers.Writer<E> writerE,
      F valueF, Writers.Writer<F> writerF,
      G valueG, Writers.Writer<G> writerG,
      H valueH, Writers.Writer<H> writerH,
      I valueI, Writers.Writer<I> writerI,
      J valueJ, Writers.Writer<J> writerJ
    )
    {
      Position += writerA(valueA, data, Position);
      Position += writerB(valueB, data, Position);
      Position += writerC(valueC, data, Position);
      Position += writerD(valueD, data, Position);
      Position += writerE(valueE, data, Position);
      Position += writerF(valueF, data, Position);
      Position += writerG(valueG, data, Position);
      Position += writerH(valueH, data, Position);
      Position += writerI(valueI, data, Position);
      Position += writerJ(valueJ, data, Position);
    }

    public void SerializeUsing<A, B, C, D, E, F, G, H, I, J, K>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB,
      C valueC, Writers.Writer<C> writerC,
      D valueD, Writers.Writer<D> writerD,
      E valueE, Writers.Writer<E> writerE,
      F valueF, Writers.Writer<F> writerF,
      G valueG, Writers.Writer<G> writerG,
      H valueH, Writers.Writer<H> writerH,
      I valueI, Writers.Writer<I> writerI,
      J valueJ, Writers.Writer<J> writerJ,
      K valueK, Writers.Writer<K> writerK
    )
    {
      Position += writerA(valueA, data, Position);
      Position += writerB(valueB, data, Position);
      Position += writerC(valueC, data, Position);
      Position += writerD(valueD, data, Position);
      Position += writerE(valueE, data, Position);
      Position += writerF(valueF, data, Position);
      Position += writerG(valueG, data, Position);
      Position += writerH(valueH, data, Position);
      Position += writerI(valueI, data, Position);
      Position += writerJ(valueJ, data, Position);
      Position += writerK(valueK, data, Position);
    }

    public void SerializeUsing<A, B, C, D, E, F, G, H, I, J, K, L>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB,
      C valueC, Writers.Writer<C> writerC,
      D valueD, Writers.Writer<D> writerD,
      E valueE, Writers.Writer<E> writerE,
      F valueF, Writers.Writer<F> writerF,
      G valueG, Writers.Writer<G> writerG,
      H valueH, Writers.Writer<H> writerH,
      I valueI, Writers.Writer<I> writerI,
      J valueJ, Writers.Writer<J> writerJ,
      K valueK, Writers.Writer<K> writerK,
      L valueL, Writers.Writer<L> writerL
    )
    {
      Position += writerA(valueA, data, Position);
      Position += writerB(valueB, data, Position);
      Position += writerC(valueC, data, Position);
      Position += writerD(valueD, data, Position);
      Position += writerE(valueE, data, Position);
      Position += writerF(valueF, data, Position);
      Position += writerG(valueG, data, Position);
      Position += writerH(valueH, data, Position);
      Position += writerI(valueI, data, Position);
      Position += writerJ(valueJ, data, Position);
      Position += writerK(valueK, data, Position);
      Position += writerL(valueL, data, Position);
    }

    public void SerializeUsing<A, B, C, D, E, F, G, H, I, J, K, L, M>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB,
      C valueC, Writers.Writer<C> writerC,
      D valueD, Writers.Writer<D> writerD,
      E valueE, Writers.Writer<E> writerE,
      F valueF, Writers.Writer<F> writerF,
      G valueG, Writers.Writer<G> writerG,
      H valueH, Writers.Writer<H> writerH,
      I valueI, Writers.Writer<I> writerI,
      J valueJ, Writers.Writer<J> writerJ,
      K valueK, Writers.Writer<K> writerK,
      L valueL, Writers.Writer<L> writerL,
      M valueM, Writers.Writer<M> writerM
    )
    {
      Position += writerA(valueA, data, Position);
      Position += writerB(valueB, data, Position);
      Position += writerC(valueC, data, Position);
      Position += writerD(valueD, data, Position);
      Position += writerE(valueE, data, Position);
      Position += writerF(valueF, data, Position);
      Position += writerG(valueG, data, Position);
      Position += writerH(valueH, data, Position);
      Position += writerI(valueI, data, Position);
      Position += writerJ(valueJ, data, Position);
      Position += writerK(valueK, data, Position);
      Position += writerL(valueL, data, Position);
      Position += writerM(valueM, data, Position);
    }

    public void SerializeUsing<A, B, C, D, E, F, G, H, I, J, K, L, M, N>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB,
      C valueC, Writers.Writer<C> writerC,
      D valueD, Writers.Writer<D> writerD,
      E valueE, Writers.Writer<E> writerE,
      F valueF, Writers.Writer<F> writerF,
      G valueG, Writers.Writer<G> writerG,
      H valueH, Writers.Writer<H> writerH,
      I valueI, Writers.Writer<I> writerI,
      J valueJ, Writers.Writer<J> writerJ,
      K valueK, Writers.Writer<K> writerK,
      L valueL, Writers.Writer<L> writerL,
      M valueM, Writers.Writer<M> writerM,
      N valueN, Writers.Writer<N> writerN
    )
    {
      Position += writerA(valueA, data, Position);
      Position += writerB(valueB, data, Position);
      Position += writerC(valueC, data, Position);
      Position += writerD(valueD, data, Position);
      Position += writerE(valueE, data, Position);
      Position += writerF(valueF, data, Position);
      Position += writerG(valueG, data, Position);
      Position += writerH(valueH, data, Position);
      Position += writerI(valueI, data, Position);
      Position += writerJ(valueJ, data, Position);
      Position += writerK(valueK, data, Position);
      Position += writerL(valueL, data, Position);
      Position += writerM(valueM, data, Position);
      Position += writerN(valueN, data, Position);
    }

    public void SerializeUsing<A, B, C, D, E, F, G, H, I, J, K, L, M, N, O>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB,
      C valueC, Writers.Writer<C> writerC,
      D valueD, Writers.Writer<D> writerD,
      E valueE, Writers.Writer<E> writerE,
      F valueF, Writers.Writer<F> writerF,
      G valueG, Writers.Writer<G> writerG,
      H valueH, Writers.Writer<H> writerH,
      I valueI, Writers.Writer<I> writerI,
      J valueJ, Writers.Writer<J> writerJ,
      K valueK, Writers.Writer<K> writerK,
      L valueL, Writers.Writer<L> writerL,
      M valueM, Writers.Writer<M> writerM,
      N valueN, Writers.Writer<N> writerN,
      O valueO, Writers.Writer<O> writerO
    )
    {
      Position += writerA(valueA, data, Position);
      Position += writerB(valueB, data, Position);
      Position += writerC(valueC, data, Position);
      Position += writerD(valueD, data, Position);
      Position += writerE(valueE, data, Position);
      Position += writerF(valueF, data, Position);
      Position += writerG(valueG, data, Position);
      Position += writerH(valueH, data, Position);
      Position += writerI(valueI, data, Position);
      Position += writerJ(valueJ, data, Position);
      Position += writerK(valueK, data, Position);
      Position += writerL(valueL, data, Position);
      Position += writerM(valueM, data, Position);
      Position += writerN(valueN, data, Position);
      Position += writerO(valueO, data, Position);
    }

    public void SerializeUsing<A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB,
      C valueC, Writers.Writer<C> writerC,
      D valueD, Writers.Writer<D> writerD,
      E valueE, Writers.Writer<E> writerE,
      F valueF, Writers.Writer<F> writerF,
      G valueG, Writers.Writer<G> writerG,
      H valueH, Writers.Writer<H> writerH,
      I valueI, Writers.Writer<I> writerI,
      J valueJ, Writers.Writer<J> writerJ,
      K valueK, Writers.Writer<K> writerK,
      L valueL, Writers.Writer<L> writerL,
      M valueM, Writers.Writer<M> writerM,
      N valueN, Writers.Writer<N> writerN,
      O valueO, Writers.Writer<O> writerO,
      P valueP, Writers.Writer<P> writerP
    )
    {
      Position += writerA(valueA, data, Position);
      Position += writerB(valueB, data, Position);
      Position += writerC(valueC, data, Position);
      Position += writerD(valueD, data, Position);
      Position += writerE(valueE, data, Position);
      Position += writerF(valueF, data, Position);
      Position += writerG(valueG, data, Position);
      Position += writerH(valueH, data, Position);
      Position += writerI(valueI, data, Position);
      Position += writerJ(valueJ, data, Position);
      Position += writerK(valueK, data, Position);
      Position += writerL(valueL, data, Position);
      Position += writerM(valueM, data, Position);
      Position += writerN(valueN, data, Position);
      Position += writerO(valueO, data, Position);
      Position += writerP(valueP, data, Position);
    }
  }
}