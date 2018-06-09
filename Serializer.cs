using System;

namespace Wander.NeST
{
  /// A serialization helper that given a byte array allows you to serialize
  /// objects from it until the end of the array.
  public class Serializer
  {
    // Kind of unsafe but good enough for now.
    public bool HasData { get { return array.HasNext(); } }
    public byte[] Internal { get { return array.Array; } }

    ByteArray array;

    public Serializer(ByteArray array)
    {
      this.array = array;
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
      writer(value, array);
    }

    /* ***AUTO-GENERATED***
     * Use these methods to quickly serialize a bunch of values at once. */
    public void SerializeUsing<A, B>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB
    )
    {
      writerA(valueA, array);
      writerB(valueB, array);
    }

    public void SerializeUsing<A, B, C>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB,
      C valueC, Writers.Writer<C> writerC
    )
    {
      writerA(valueA, array);
      writerB(valueB, array);
      writerC(valueC, array);
    }

    public void SerializeUsing<A, B, C, D>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB,
      C valueC, Writers.Writer<C> writerC,
      D valueD, Writers.Writer<D> writerD
    )
    {
      writerA(valueA, array);
      writerB(valueB, array);
      writerC(valueC, array);
      writerD(valueD, array);
    }

    public void SerializeUsing<A, B, C, D, E>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB,
      C valueC, Writers.Writer<C> writerC,
      D valueD, Writers.Writer<D> writerD,
      E valueE, Writers.Writer<E> writerE
    )
    {
      writerA(valueA, array);
      writerB(valueB, array);
      writerC(valueC, array);
      writerD(valueD, array);
      writerE(valueE, array);
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
      writerA(valueA, array);
      writerB(valueB, array);
      writerC(valueC, array);
      writerD(valueD, array);
      writerE(valueE, array);
      writerF(valueF, array);
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
      writerA(valueA, array);
      writerB(valueB, array);
      writerC(valueC, array);
      writerD(valueD, array);
      writerE(valueE, array);
      writerF(valueF, array);
      writerG(valueG, array);
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
      writerA(valueA, array);
      writerB(valueB, array);
      writerC(valueC, array);
      writerD(valueD, array);
      writerE(valueE, array);
      writerF(valueF, array);
      writerG(valueG, array);
      writerH(valueH, array);
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
      writerA(valueA, array);
      writerB(valueB, array);
      writerC(valueC, array);
      writerD(valueD, array);
      writerE(valueE, array);
      writerF(valueF, array);
      writerG(valueG, array);
      writerH(valueH, array);
      writerI(valueI, array);
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
      writerA(valueA, array);
      writerB(valueB, array);
      writerC(valueC, array);
      writerD(valueD, array);
      writerE(valueE, array);
      writerF(valueF, array);
      writerG(valueG, array);
      writerH(valueH, array);
      writerI(valueI, array);
      writerJ(valueJ, array);
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
      writerA(valueA, array);
      writerB(valueB, array);
      writerC(valueC, array);
      writerD(valueD, array);
      writerE(valueE, array);
      writerF(valueF, array);
      writerG(valueG, array);
      writerH(valueH, array);
      writerI(valueI, array);
      writerJ(valueJ, array);
      writerK(valueK, array);
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
      writerA(valueA, array);
      writerB(valueB, array);
      writerC(valueC, array);
      writerD(valueD, array);
      writerE(valueE, array);
      writerF(valueF, array);
      writerG(valueG, array);
      writerH(valueH, array);
      writerI(valueI, array);
      writerJ(valueJ, array);
      writerK(valueK, array);
      writerL(valueL, array);
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
      writerA(valueA, array);
      writerB(valueB, array);
      writerC(valueC, array);
      writerD(valueD, array);
      writerE(valueE, array);
      writerF(valueF, array);
      writerG(valueG, array);
      writerH(valueH, array);
      writerI(valueI, array);
      writerJ(valueJ, array);
      writerK(valueK, array);
      writerL(valueL, array);
      writerM(valueM, array);
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
      writerA(valueA, array);
      writerB(valueB, array);
      writerC(valueC, array);
      writerD(valueD, array);
      writerE(valueE, array);
      writerF(valueF, array);
      writerG(valueG, array);
      writerH(valueH, array);
      writerI(valueI, array);
      writerJ(valueJ, array);
      writerK(valueK, array);
      writerL(valueL, array);
      writerM(valueM, array);
      writerN(valueN, array);
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
      writerA(valueA, array);
      writerB(valueB, array);
      writerC(valueC, array);
      writerD(valueD, array);
      writerE(valueE, array);
      writerF(valueF, array);
      writerG(valueG, array);
      writerH(valueH, array);
      writerI(valueI, array);
      writerJ(valueJ, array);
      writerK(valueK, array);
      writerL(valueL, array);
      writerM(valueM, array);
      writerN(valueN, array);
      writerO(valueO, array);
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
      writerA(valueA, array);
      writerB(valueB, array);
      writerC(valueC, array);
      writerD(valueD, array);
      writerE(valueE, array);
      writerF(valueF, array);
      writerG(valueG, array);
      writerH(valueH, array);
      writerI(valueI, array);
      writerJ(valueJ, array);
      writerK(valueK, array);
      writerL(valueL, array);
      writerM(valueM, array);
      writerN(valueN, array);
      writerO(valueO, array);
      writerP(valueP, array);
    }
  }
}