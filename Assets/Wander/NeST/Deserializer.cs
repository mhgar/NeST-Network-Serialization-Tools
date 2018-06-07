using System;

namespace Wander.NeST
{
  /// A deserialization helper that given a byte array allows you to deserialize
  /// objects from it until the end of the array.
  public class Deserializer
  {
    public byte[] Array { get { return data; } }
    public int Length { get { return dataLength; } }
    public int Position
    {
      get { return readHead; }
      set
      {
        if (value > dataLength)
          throw new IndexOutOfRangeException();
        else
          readHead = value;
      }
    }

    // Kind of unsafe but good enough for now.
    public bool HasEnded { get { return Position == dataLength; }}

    byte[] data;
    int readHead = 0;
    int dataLength;

    public Deserializer(byte[] array, int startIndex = 0, int length = -1)
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

      data = array;
      readHead = startIndex;      
    }

    /// Deserialize an ISerializable from this object's internal byte array.
    public T Deserialize<T>() where T : ISerializable, new()
    {
      T t = new T();
      t.DeserializeFrom(this);
      return t;
    }

    /// Deserialize an object using a reader function that implements how the
    /// object should be serialized.
    public T DeserializeUsing<T>(Readers.Reader<T> reader)
    {
      T value;
      Position += reader(out value, data, readHead);
      return value;
    }

    /* ***AUTO-GENERATED*** 
     * Generic deserialized structures. */
    public
    Deserialized<A, B>
    DeserializeUsing<A, B>(
      Readers.Reader<A> readerA, Readers.Reader<B> readerB
    )
    {
      var v =
        new Deserialized<A, B>();
      Position += readerA(out v.a, data, Position);
      Position += readerB(out v.b, data, Position);
      return v;
    }

    public
    Deserialized<A, B, C>
    DeserializeUsing<A, B, C>(
      Readers.Reader<A> readerA, Readers.Reader<B> readerB, 
      Readers.Reader<C> readerC
    )
    {
      var v =
        new Deserialized<A, B, C>();
      Position += readerA(out v.a, data, Position);
      Position += readerB(out v.b, data, Position);
      Position += readerC(out v.c, data, Position);
      return v;
    }

    public
    Deserialized<A, B, C, D>
    DeserializeUsing<A, B, C, D>(
      Readers.Reader<A> readerA, Readers.Reader<B> readerB, 
      Readers.Reader<C> readerC, Readers.Reader<D> readerD
    )
    {
      var v =
        new Deserialized<A, B, C, D>();
      Position += readerA(out v.a, data, Position);
      Position += readerB(out v.b, data, Position);
      Position += readerC(out v.c, data, Position);
      Position += readerD(out v.d, data, Position);
      return v;
    }

    public
    Deserialized<A, B, C, D, E>
    DeserializeUsing<A, B, C, D, E>(
      Readers.Reader<A> readerA, Readers.Reader<B> readerB, 
      Readers.Reader<C> readerC, Readers.Reader<D> readerD, 
      Readers.Reader<E> readerE
    )
    {
      var v =
        new Deserialized<A, B, C, D, E>();
      Position += readerA(out v.a, data, Position);
      Position += readerB(out v.b, data, Position);
      Position += readerC(out v.c, data, Position);
      Position += readerD(out v.d, data, Position);
      Position += readerE(out v.e, data, Position);
      return v;
    }

    public
    Deserialized<A, B, C, D, E, F>
    DeserializeUsing<A, B, C, D, E, F>(
      Readers.Reader<A> readerA, Readers.Reader<B> readerB, 
      Readers.Reader<C> readerC, Readers.Reader<D> readerD, 
      Readers.Reader<E> readerE, Readers.Reader<F> readerF
    )
    {
      var v =
        new Deserialized<A, B, C, D, E, F>();
      Position += readerA(out v.a, data, Position);
      Position += readerB(out v.b, data, Position);
      Position += readerC(out v.c, data, Position);
      Position += readerD(out v.d, data, Position);
      Position += readerE(out v.e, data, Position);
      Position += readerF(out v.f, data, Position);
      return v;
    }

    public
    Deserialized<A, B, C, D, E, F, G>
    DeserializeUsing<A, B, C, D, E, F, G>(
      Readers.Reader<A> readerA, Readers.Reader<B> readerB, 
      Readers.Reader<C> readerC, Readers.Reader<D> readerD, 
      Readers.Reader<E> readerE, Readers.Reader<F> readerF, 
      Readers.Reader<G> readerG
    )
    {
      var v =
        new Deserialized<A, B, C, D, E, F, G>();
      Position += readerA(out v.a, data, Position);
      Position += readerB(out v.b, data, Position);
      Position += readerC(out v.c, data, Position);
      Position += readerD(out v.d, data, Position);
      Position += readerE(out v.e, data, Position);
      Position += readerF(out v.f, data, Position);
      Position += readerG(out v.g, data, Position);
      return v;
    }

    public
    Deserialized<A, B, C, D, E, F, G, H>
    DeserializeUsing<A, B, C, D, E, F, G, H>(
      Readers.Reader<A> readerA, Readers.Reader<B> readerB, 
      Readers.Reader<C> readerC, Readers.Reader<D> readerD, 
      Readers.Reader<E> readerE, Readers.Reader<F> readerF, 
      Readers.Reader<G> readerG, Readers.Reader<H> readerH
    )
    {
      var v =
        new Deserialized<A, B, C, D, E, F, G, H>();
      Position += readerA(out v.a, data, Position);
      Position += readerB(out v.b, data, Position);
      Position += readerC(out v.c, data, Position);
      Position += readerD(out v.d, data, Position);
      Position += readerE(out v.e, data, Position);
      Position += readerF(out v.f, data, Position);
      Position += readerG(out v.g, data, Position);
      Position += readerH(out v.h, data, Position);
      return v;
    }

    public
    Deserialized<A, B, C, D, E, F, G, H, I>
    DeserializeUsing<A, B, C, D, E, F, G, H, I>(
      Readers.Reader<A> readerA, Readers.Reader<B> readerB, 
      Readers.Reader<C> readerC, Readers.Reader<D> readerD, 
      Readers.Reader<E> readerE, Readers.Reader<F> readerF, 
      Readers.Reader<G> readerG, Readers.Reader<H> readerH, 
      Readers.Reader<I> readerI
    )
    {
      var v =
        new Deserialized<A, B, C, D, E, F, G, H, I>();
      Position += readerA(out v.a, data, Position);
      Position += readerB(out v.b, data, Position);
      Position += readerC(out v.c, data, Position);
      Position += readerD(out v.d, data, Position);
      Position += readerE(out v.e, data, Position);
      Position += readerF(out v.f, data, Position);
      Position += readerG(out v.g, data, Position);
      Position += readerH(out v.h, data, Position);
      Position += readerI(out v.i, data, Position);
      return v;
    }

    public
    Deserialized<A, B, C, D, E, F, G, H, I, J>
    DeserializeUsing<A, B, C, D, E, F, G, H, I, J>(
      Readers.Reader<A> readerA, Readers.Reader<B> readerB, 
      Readers.Reader<C> readerC, Readers.Reader<D> readerD, 
      Readers.Reader<E> readerE, Readers.Reader<F> readerF, 
      Readers.Reader<G> readerG, Readers.Reader<H> readerH, 
      Readers.Reader<I> readerI, Readers.Reader<J> readerJ
    )
    {
      var v =
        new Deserialized<A, B, C, D, E, F, G, H, I, J>();
      Position += readerA(out v.a, data, Position);
      Position += readerB(out v.b, data, Position);
      Position += readerC(out v.c, data, Position);
      Position += readerD(out v.d, data, Position);
      Position += readerE(out v.e, data, Position);
      Position += readerF(out v.f, data, Position);
      Position += readerG(out v.g, data, Position);
      Position += readerH(out v.h, data, Position);
      Position += readerI(out v.i, data, Position);
      Position += readerJ(out v.j, data, Position);
      return v;
    }

    public
    Deserialized<A, B, C, D, E, F, G, H, I, J, K>
    DeserializeUsing<A, B, C, D, E, F, G, H, I, J, K>(
      Readers.Reader<A> readerA, Readers.Reader<B> readerB, 
      Readers.Reader<C> readerC, Readers.Reader<D> readerD, 
      Readers.Reader<E> readerE, Readers.Reader<F> readerF, 
      Readers.Reader<G> readerG, Readers.Reader<H> readerH, 
      Readers.Reader<I> readerI, Readers.Reader<J> readerJ, 
      Readers.Reader<K> readerK
    )
    {
      var v =
        new Deserialized<A, B, C, D, E, F, G, H, I, J, K>();
      Position += readerA(out v.a, data, Position);
      Position += readerB(out v.b, data, Position);
      Position += readerC(out v.c, data, Position);
      Position += readerD(out v.d, data, Position);
      Position += readerE(out v.e, data, Position);
      Position += readerF(out v.f, data, Position);
      Position += readerG(out v.g, data, Position);
      Position += readerH(out v.h, data, Position);
      Position += readerI(out v.i, data, Position);
      Position += readerJ(out v.j, data, Position);
      Position += readerK(out v.k, data, Position);
      return v;
    }

    public
    Deserialized<A, B, C, D, E, F, G, H, I, J, K, L>
    DeserializeUsing<A, B, C, D, E, F, G, H, I, J, K, L>(
      Readers.Reader<A> readerA, Readers.Reader<B> readerB, 
      Readers.Reader<C> readerC, Readers.Reader<D> readerD, 
      Readers.Reader<E> readerE, Readers.Reader<F> readerF, 
      Readers.Reader<G> readerG, Readers.Reader<H> readerH, 
      Readers.Reader<I> readerI, Readers.Reader<J> readerJ, 
      Readers.Reader<K> readerK, Readers.Reader<L> readerL
    )
    {
      var v =
        new Deserialized<A, B, C, D, E, F, G, H, I, J, K, L>();
      Position += readerA(out v.a, data, Position);
      Position += readerB(out v.b, data, Position);
      Position += readerC(out v.c, data, Position);
      Position += readerD(out v.d, data, Position);
      Position += readerE(out v.e, data, Position);
      Position += readerF(out v.f, data, Position);
      Position += readerG(out v.g, data, Position);
      Position += readerH(out v.h, data, Position);
      Position += readerI(out v.i, data, Position);
      Position += readerJ(out v.j, data, Position);
      Position += readerK(out v.k, data, Position);
      Position += readerL(out v.l, data, Position);
      return v;
    }

    public
    Deserialized<A, B, C, D, E, F, G, H, I, J, K, L, M>
    DeserializeUsing<A, B, C, D, E, F, G, H, I, J, K, L, M>(
      Readers.Reader<A> readerA, Readers.Reader<B> readerB, 
      Readers.Reader<C> readerC, Readers.Reader<D> readerD, 
      Readers.Reader<E> readerE, Readers.Reader<F> readerF, 
      Readers.Reader<G> readerG, Readers.Reader<H> readerH, 
      Readers.Reader<I> readerI, Readers.Reader<J> readerJ, 
      Readers.Reader<K> readerK, Readers.Reader<L> readerL, 
      Readers.Reader<M> readerM
    )
    {
      var v =
        new Deserialized<A, B, C, D, E, F, G, H, I, J, K, L, M>();
      Position += readerA(out v.a, data, Position);
      Position += readerB(out v.b, data, Position);
      Position += readerC(out v.c, data, Position);
      Position += readerD(out v.d, data, Position);
      Position += readerE(out v.e, data, Position);
      Position += readerF(out v.f, data, Position);
      Position += readerG(out v.g, data, Position);
      Position += readerH(out v.h, data, Position);
      Position += readerI(out v.i, data, Position);
      Position += readerJ(out v.j, data, Position);
      Position += readerK(out v.k, data, Position);
      Position += readerL(out v.l, data, Position);
      Position += readerM(out v.m, data, Position);
      return v;
    }

    public
    Deserialized<A, B, C, D, E, F, G, H, I, J, K, L, M, N>
    DeserializeUsing<A, B, C, D, E, F, G, H, I, J, K, L, M, N>(
      Readers.Reader<A> readerA, Readers.Reader<B> readerB, 
      Readers.Reader<C> readerC, Readers.Reader<D> readerD, 
      Readers.Reader<E> readerE, Readers.Reader<F> readerF, 
      Readers.Reader<G> readerG, Readers.Reader<H> readerH, 
      Readers.Reader<I> readerI, Readers.Reader<J> readerJ, 
      Readers.Reader<K> readerK, Readers.Reader<L> readerL, 
      Readers.Reader<M> readerM, Readers.Reader<N> readerN
    )
    {
      var v =
        new Deserialized<A, B, C, D, E, F, G, H, I, J, K, L, M, N>();
      Position += readerA(out v.a, data, Position);
      Position += readerB(out v.b, data, Position);
      Position += readerC(out v.c, data, Position);
      Position += readerD(out v.d, data, Position);
      Position += readerE(out v.e, data, Position);
      Position += readerF(out v.f, data, Position);
      Position += readerG(out v.g, data, Position);
      Position += readerH(out v.h, data, Position);
      Position += readerI(out v.i, data, Position);
      Position += readerJ(out v.j, data, Position);
      Position += readerK(out v.k, data, Position);
      Position += readerL(out v.l, data, Position);
      Position += readerM(out v.m, data, Position);
      Position += readerN(out v.n, data, Position);
      return v;
    }

    public
    Deserialized<A, B, C, D, E, F, G, H, I, J, K, L, M, N, O>
    DeserializeUsing<A, B, C, D, E, F, G, H, I, J, K, L, M, N, O>(
      Readers.Reader<A> readerA, Readers.Reader<B> readerB, 
      Readers.Reader<C> readerC, Readers.Reader<D> readerD, 
      Readers.Reader<E> readerE, Readers.Reader<F> readerF, 
      Readers.Reader<G> readerG, Readers.Reader<H> readerH, 
      Readers.Reader<I> readerI, Readers.Reader<J> readerJ, 
      Readers.Reader<K> readerK, Readers.Reader<L> readerL, 
      Readers.Reader<M> readerM, Readers.Reader<N> readerN, 
      Readers.Reader<O> readerO
    )
    {
      var v =
        new Deserialized<A, B, C, D, E, F, G, H, I, J, K, L, M, N, O>();
      Position += readerA(out v.a, data, Position);
      Position += readerB(out v.b, data, Position);
      Position += readerC(out v.c, data, Position);
      Position += readerD(out v.d, data, Position);
      Position += readerE(out v.e, data, Position);
      Position += readerF(out v.f, data, Position);
      Position += readerG(out v.g, data, Position);
      Position += readerH(out v.h, data, Position);
      Position += readerI(out v.i, data, Position);
      Position += readerJ(out v.j, data, Position);
      Position += readerK(out v.k, data, Position);
      Position += readerL(out v.l, data, Position);
      Position += readerM(out v.m, data, Position);
      Position += readerN(out v.n, data, Position);
      Position += readerO(out v.o, data, Position);
      return v;
    }

    public
    Deserialized<A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P>
    DeserializeUsing<A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P>(
      Readers.Reader<A> readerA, Readers.Reader<B> readerB, 
      Readers.Reader<C> readerC, Readers.Reader<D> readerD, 
      Readers.Reader<E> readerE, Readers.Reader<F> readerF, 
      Readers.Reader<G> readerG, Readers.Reader<H> readerH, 
      Readers.Reader<I> readerI, Readers.Reader<J> readerJ, 
      Readers.Reader<K> readerK, Readers.Reader<L> readerL, 
      Readers.Reader<M> readerM, Readers.Reader<N> readerN, 
      Readers.Reader<O> readerO, Readers.Reader<P> readerP
    )
    {
      var v =
        new Deserialized<A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P>();
      Position += readerA(out v.a, data, Position);
      Position += readerB(out v.b, data, Position);
      Position += readerC(out v.c, data, Position);
      Position += readerD(out v.d, data, Position);
      Position += readerE(out v.e, data, Position);
      Position += readerF(out v.f, data, Position);
      Position += readerG(out v.g, data, Position);
      Position += readerH(out v.h, data, Position);
      Position += readerI(out v.i, data, Position);
      Position += readerJ(out v.j, data, Position);
      Position += readerK(out v.k, data, Position);
      Position += readerL(out v.l, data, Position);
      Position += readerM(out v.m, data, Position);
      Position += readerN(out v.n, data, Position);
      Position += readerO(out v.o, data, Position);
      Position += readerP(out v.p, data, Position);
      return v;
    }


  }
}