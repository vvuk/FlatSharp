//
// This provides a simple implementation of NativeArray, for compiler
// and unit test usage.
//

using System;
using System.Collections;
using System.Collections.Generic;
using FlatSharp.Unity;

namespace Unity.Collections
{
    public enum NativeArrayOptions
    {
        UninitializedMemory = 0,
        ClearMemory = 1
    }

    public enum Allocator
    {
        Invalid = 0,
        None = 1,
        Temp = 2,
        TempJob = 3,
        Persistent = 4,
    }

    public unsafe struct NativeArray<T> : IDisposable, IEnumerable<T>, IEquatable<NativeArray<T>> where T : unmanaged
    {
        internal Memory<T> m_Buffer;
        internal int m_Length;

        internal Allocator m_AllocatorLabel;

        public NativeArray(int length, Allocator allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory)
        {
            Allocate(length, allocator, out this);
        }

        static void Allocate<T>(int length, Allocator allocator, out NativeArray<T> nativeArray) where T : unmanaged
        {
            var backing = new T[length];
            nativeArray = new NativeArray<T>()
            {
                m_Buffer = new Memory<T>(backing),
                m_Length = length,
                m_AllocatorLabel = Allocator.Persistent
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Equals(NativeArray<T> other)
        {
            throw new NotImplementedException();
        }
    }
}

namespace Unity.Collections.LowLevel.Unsafe
{
    public static unsafe class UnsafeUtility
    {
        public static int SizeOf<T>() where T : unmanaged
        {
            return sizeof(T);
        }
    }

    public static unsafe class NativeArrayUnsafeUtility
    {
        public static NativeArray<T> ConvertExistingDataToNativeArray<T>(void* dataPointer, int length, Allocator allocator) where T : unmanaged
        {
            var newArray = new NativeArray<T>
            {
                m_Buffer = new UnmanagedMemoryManager<T>((T*) dataPointer, sizeof(T) * length).Memory,
                m_Length = length,
                m_AllocatorLabel = allocator,
            };

            return newArray;
        }

        public static void* GetUnsafeReadOnlyPtr<T>(this NativeArray<T> nativeArray) where T : unmanaged
        {
            return nativeArray.m_Buffer.Pin().Pointer;
        }
    }
}