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
      array.Increment(writer(value, array.Array, array.Position));
    }

    /* ***AUTO-GENERATED***
     * Use these methods to quickly serialize a bunch of values at once. */
    public void SerializeUsing<A, B>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB
    )
    {
      array.Increment(writerA(valueA, array.Array, array.Position));
      array.Increment(writerB(valueB, array.Array, array.Position));
    }

    public void SerializeUsing<A, B, C>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB,
      C valueC, Writers.Writer<C> writerC
    )
    {
      array.Increment(writerA(valueA, array.Array, array.Position));
      array.Increment(writerB(valueB, array.Array, array.Position));
      array.Increment(writerC(valueC, array.Array, array.Position));
    }

    public void SerializeUsing<A, B, C, D>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB,
      C valueC, Writers.Writer<C> writerC,
      D valueD, Writers.Writer<D> writerD
    )
    {
      array.Increment(writerA(valueA, array.Array, array.Position));
      array.Increment(writerB(valueB, array.Array, array.Position));
      array.Increment(writerC(valueC, array.Array, array.Position));
      array.Increment(writerD(valueD, array.Array, array.Position));
    }

    public void SerializeUsing<A, B, C, D, E>(
      A valueA, Writers.Writer<A> writerA,
      B valueB, Writers.Writer<B> writerB,
      C valueC, Writers.Writer<C> writerC,
      D valueD, Writers.Writer<D> writerD,
      E valueE, Writers.Writer<E> writerE
    )
    {
      array.Increment(writerA(valueA, array.Array, array.Position));
      array.Increment(writerB(valueB, array.Array, array.Position));
      array.Increment(writerC(valueC, array.Array, array.Position));
      array.Increment(writerD(valueD, array.Array, array.Position));
      array.Increment(writerE(valueE, array.Array, array.Position));
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
      array.Increment(writerA(valueA, array.Array, array.Position));
      array.Increment(writerB(valueB, array.Array, array.Position));
      array.Increment(writerC(valueC, array.Array, array.Position));
      array.Increment(writerD(valueD, array.Array, array.Position));
      array.Increment(writerE(valueE, array.Array, array.Position));
      array.Increment(writerF(valueF, array.Array, array.Position));
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
      array.Increment(writerA(valueA, array.Array, array.Position));
      array.Increment(writerB(valueB, array.Array, array.Position));
      array.Increment(writerC(valueC, array.Array, array.Position));
      array.Increment(writerD(valueD, array.Array, array.Position));
      array.Increment(writerE(valueE, array.Array, array.Position));
      array.Increment(writerF(valueF, array.Array, array.Position));
      array.Increment(writerG(valueG, array.Array, array.Position));
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
      array.Increment(writerA(valueA, array.Array, array.Position));
      array.Increment(writerB(valueB, array.Array, array.Position));
      array.Increment(writerC(valueC, array.Array, array.Position));
      array.Increment(writerD(valueD, array.Array, array.Position));
      array.Increment(writerE(valueE, array.Array, array.Position));
      array.Increment(writerF(valueF, array.Array, array.Position));
      array.Increment(writerG(valueG, array.Array, array.Position));
      array.Increment(writerH(valueH, array.Array, array.Position));
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
      array.Increment(writerA(valueA, array.Array, array.Position));
      array.Increment(writerB(valueB, array.Array, array.Position));
      array.Increment(writerC(valueC, array.Array, array.Position));
      array.Increment(writerD(valueD, array.Array, array.Position));
      array.Increment(writerE(valueE, array.Array, array.Position));
      array.Increment(writerF(valueF, array.Array, array.Position));
      array.Increment(writerG(valueG, array.Array, array.Position));
      array.Increment(writerH(valueH, array.Array, array.Position));
      array.Increment(writerI(valueI, array.Array, array.Position));
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
      array.Increment(writerA(valueA, array.Array, array.Position));
      array.Increment(writerB(valueB, array.Array, array.Position));
      array.Increment(writerC(valueC, array.Array, array.Position));
      array.Increment(writerD(valueD, array.Array, array.Position));
      array.Increment(writerE(valueE, array.Array, array.Position));
      array.Increment(writerF(valueF, array.Array, array.Position));
      array.Increment(writerG(valueG, array.Array, array.Position));
      array.Increment(writerH(valueH, array.Array, array.Position));
      array.Increment(writerI(valueI, array.Array, array.Position));
      array.Increment(writerJ(valueJ, array.Array, array.Position));
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
      array.Increment(writerA(valueA, array.Array, array.Position));
      array.Increment(writerB(valueB, array.Array, array.Position));
      array.Increment(writerC(valueC, array.Array, array.Position));
      array.Increment(writerD(valueD, array.Array, array.Position));
      array.Increment(writerE(valueE, array.Array, array.Position));
      array.Increment(writerF(valueF, array.Array, array.Position));
      array.Increment(writerG(valueG, array.Array, array.Position));
      array.Increment(writerH(valueH, array.Array, array.Position));
      array.Increment(writerI(valueI, array.Array, array.Position));
      array.Increment(writerJ(valueJ, array.Array, array.Position));
      array.Increment(writerK(valueK, array.Array, array.Position));
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
      array.Increment(writerA(valueA, array.Array, array.Position));
      array.Increment(writerB(valueB, array.Array, array.Position));
      array.Increment(writerC(valueC, array.Array, array.Position));
      array.Increment(writerD(valueD, array.Array, array.Position));
      array.Increment(writerE(valueE, array.Array, array.Position));
      array.Increment(writerF(valueF, array.Array, array.Position));
      array.Increment(writerG(valueG, array.Array, array.Position));
      array.Increment(writerH(valueH, array.Array, array.Position));
      array.Increment(writerI(valueI, array.Array, array.Position));
      array.Increment(writerJ(valueJ, array.Array, array.Position));
      array.Increment(writerK(valueK, array.Array, array.Position));
      array.Increment(writerL(valueL, array.Array, array.Position));
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
      array.Increment(writerA(valueA, array.Array, array.Position));
      array.Increment(writerB(valueB, array.Array, array.Position));
      array.Increment(writerC(valueC, array.Array, array.Position));
      array.Increment(writerD(valueD, array.Array, array.Position));
      array.Increment(writerE(valueE, array.Array, array.Position));
      array.Increment(writerF(valueF, array.Array, array.Position));
      array.Increment(writerG(valueG, array.Array, array.Position));
      array.Increment(writerH(valueH, array.Array, array.Position));
      array.Increment(writerI(valueI, array.Array, array.Position));
      array.Increment(writerJ(valueJ, array.Array, array.Position));
      array.Increment(writerK(valueK, array.Array, array.Position));
      array.Increment(writerL(valueL, array.Array, array.Position));
      array.Increment(writerM(valueM, array.Array, array.Position));
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
      array.Increment(writerA(valueA, array.Array, array.Position));
      array.Increment(writerB(valueB, array.Array, array.Position));
      array.Increment(writerC(valueC, array.Array, array.Position));
      array.Increment(writerD(valueD, array.Array, array.Position));
      array.Increment(writerE(valueE, array.Array, array.Position));
      array.Increment(writerF(valueF, array.Array, array.Position));
      array.Increment(writerG(valueG, array.Array, array.Position));
      array.Increment(writerH(valueH, array.Array, array.Position));
      array.Increment(writerI(valueI, array.Array, array.Position));
      array.Increment(writerJ(valueJ, array.Array, array.Position));
      array.Increment(writerK(valueK, array.Array, array.Position));
      array.Increment(writerL(valueL, array.Array, array.Position));
      array.Increment(writerM(valueM, array.Array, array.Position));
      array.Increment(writerN(valueN, array.Array, array.Position));
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
      array.Increment(writerA(valueA, array.Array, array.Position));
      array.Increment(writerB(valueB, array.Array, array.Position));
      array.Increment(writerC(valueC, array.Array, array.Position));
      array.Increment(writerD(valueD, array.Array, array.Position));
      array.Increment(writerE(valueE, array.Array, array.Position));
      array.Increment(writerF(valueF, array.Array, array.Position));
      array.Increment(writerG(valueG, array.Array, array.Position));
      array.Increment(writerH(valueH, array.Array, array.Position));
      array.Increment(writerI(valueI, array.Array, array.Position));
      array.Increment(writerJ(valueJ, array.Array, array.Position));
      array.Increment(writerK(valueK, array.Array, array.Position));
      array.Increment(writerL(valueL, array.Array, array.Position));
      array.Increment(writerM(valueM, array.Array, array.Position));
      array.Increment(writerN(valueN, array.Array, array.Position));
      array.Increment(writerO(valueO, array.Array, array.Position));
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
      array.Increment(writerA(valueA, array.Array, array.Position));
      array.Increment(writerB(valueB, array.Array, array.Position));
      array.Increment(writerC(valueC, array.Array, array.Position));
      array.Increment(writerD(valueD, array.Array, array.Position));
      array.Increment(writerE(valueE, array.Array, array.Position));
      array.Increment(writerF(valueF, array.Array, array.Position));
      array.Increment(writerG(valueG, array.Array, array.Position));
      array.Increment(writerH(valueH, array.Array, array.Position));
      array.Increment(writerI(valueI, array.Array, array.Position));
      array.Increment(writerJ(valueJ, array.Array, array.Position));
      array.Increment(writerK(valueK, array.Array, array.Position));
      array.Increment(writerL(valueL, array.Array, array.Position));
      array.Increment(writerM(valueM, array.Array, array.Position));
      array.Increment(writerN(valueN, array.Array, array.Position));
      array.Increment(writerO(valueO, array.Array, array.Position));
      array.Increment(writerP(valueP, array.Array, array.Position));
    }

  }
}