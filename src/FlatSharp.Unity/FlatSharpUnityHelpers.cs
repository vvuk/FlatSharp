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

using System;
using Microsoft.CodeAnalysis;
using Unity.Collections;

namespace FlatSharp;

public static class FlatSharpUnityHelpers
{
    public static PortableExecutableReference AssemblyReferenceUnityNativeArray()
    {
        return MetadataReference.CreateFromFile(typeof(NativeArray<>).Assembly.Location);
    }

    public static Type NativeArrayType => typeof(NativeArray<>);
}