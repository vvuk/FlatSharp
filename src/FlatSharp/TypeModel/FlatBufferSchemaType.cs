﻿/*
 * Copyright 2018 James Courtney
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

namespace FlatSharp.TypeModel;

/// <summary>
/// Defines flat buffer schema type elements.
/// </summary>
public enum FlatBufferSchemaType
{
    /// <summary>
    /// A flat buffer table.
    /// </summary>
    Table = 1,

    /// <summary>
    /// A flat buffer struct.
    /// </summary>
    Struct = 2,

    /// <summary>
    /// A vector.
    /// </summary>
    Vector = 3,

    /// <summary>
    /// A scalar.
    /// </summary>
    Scalar = 4,

    /// <summary>
    /// A string.
    /// </summary>
    String = 5,

    /// <summary>
    /// A union.
    /// </summary>
    Union = 6,
}
