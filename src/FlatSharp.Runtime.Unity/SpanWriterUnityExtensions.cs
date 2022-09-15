/*
 * Copyright 2022 Unity Technologies
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace FlatSharp.Internal;

/// <summary>
/// Extension methods that apply to all <see cref="ISpanWriter"/> implementations to support Unity
/// Native Collections types.
/// </summary>
public static class SpanWriterUnityExtensions
{
    public static unsafe void WriteNativeArrayBlock<TElement, TSpanWriter>(
        this TSpanWriter spanWriter,
        Span<byte> span,
        NativeArray<TElement> buffer,
        int offset,
        SerializationContext ctx)
        where TElement : struct
        where TSpanWriter : ISpanWriter
    {
        int numberOfItems = buffer.Length;
        int vectorStartOffset = ctx.AllocateVector(itemAlignment: UnsafeUtility.AlignOf<TElement>(),
            numberOfItems,
            sizePerItem: UnsafeUtility.SizeOf<TElement>());

        spanWriter.WriteUOffset(span, offset, vectorStartOffset);
        spanWriter.WriteInt(span, numberOfItems, vectorStartOffset);

        ref var writeDstStart = ref span.Slice(vectorStartOffset + sizeof(uint)).GetPinnableReference();
        var dstPtr = UnsafeUtility.AddressOf(ref writeDstStart);

        UnsafeUtility.MemCpy(dstPtr, buffer.GetUnsafeReadOnlyPtr(), buffer.Length * UnsafeUtility.SizeOf<TElement>());
    }
}
