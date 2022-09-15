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

using System.IO;

namespace FlatSharp.Internal;

/// <summary>
/// Extensions for input buffers to support Unity Native Collections types.
/// </summary>
public static class InputBufferUnityExtensions
{
    public static unsafe NativeArray<TElement> ReadNativeArrayBlock<TElement, TBuffer>(this TBuffer buffer, int uoffset)
        where TElement : struct
        where TBuffer : IInputBuffer
    {
        // The local value stores a uoffset_t, so follow that now.
        uoffset = uoffset + buffer.ReadUOffset(uoffset);
        int length = (int)buffer.ReadUInt(uoffset);

        var mem = buffer.GetReadOnlyByteMemory(uoffset + sizeof(uint), (int)buffer.ReadUInt(uoffset));

        // convert to NativeArray... is this safe?  Assumption is underlying buffer is already pinnned I guess?
        using (var pin = mem.Pin())
        {
            var na = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<TElement>(pin.Pointer, length, Allocator.None);
            return na;
        }
    }
}
