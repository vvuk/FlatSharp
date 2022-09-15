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

namespace FlatSharp.TypeModel;

#if NETSTANDARD2_1 || NET5_0_OR_GREATER
/// <summary>
/// Defines a vector type model for a Unity NativeArray collection.
/// </summary>
public class UnityNativeArrayVectorTypeModel : BaseVectorTypeModel
{
    internal UnityNativeArrayVectorTypeModel(Type vectorType, TypeModelContainer provider) : base(vectorType, provider)
    {
    }

    public override string LengthPropertyName => nameof(Memory<byte>.Length);

    public override Type OnInitialize()
    {
        return this.ClrType.GetGenericArguments()[0];
    }

    protected override string CreateLoop(FlatBufferSerializerOptions options, string vectorVariableName, string numberOfItemsVariableName, string expectedVariableName, string body)
    {
        FlatSharpInternal.Assert(false, "Not expecting to do loop get max size for memory vector");
        throw new Exception();
    }

    public override CodeGeneratedMethod CreateParseMethodBody(ParserCodeGenContext context)
    {
        ValidateWriteThrough(
            writeThroughSupported: false,
            this,
            context.AllFieldContexts,
            context.Options);

        // can't use nameof() here -- we can't reference the assembly that has this in it, to avoid dragging in UnityEngine
        string method = "ReadNativeArrayBlock"; // nameof(InputBufferUnityExtensions.ReadNativeArrayBlock);

        string memoryVectorRead = $"{context.InputBufferVariableName}.{method}<{this.ItemTypeModel.GetGlobalCompilableTypeName()}, {context.InputBufferTypeName}>({context.OffsetVariableName})";

        string body;
        body = $"return {memoryVectorRead};";

        return new CodeGeneratedMethod(body);
    }

    public override CodeGeneratedMethod CreateSerializeMethodBody(SerializationCodeGenContext context)
    {
        // can't use nameof() here -- we can't reference the assembly that has this in it, to avoid dragging in UnityEngine
        var method = "WriteNativeArrayBlock"; // nameof(SpanWriterUnityExtensions.WriteNativeArrayBlock);
        
        string body =
            $"{context.SpanWriterVariableName}.{method}({context.SpanVariableName}, {context.ValueVariableName}, {context.OffsetVariableName}, {context.SerializationContextVariableName});";

        return new CodeGeneratedMethod(body);
    }

    public override CodeGeneratedMethod CreateCloneMethodBody(CloneCodeGenContext context)
    {
        string body = $"throw new InvalidOperationException(\"todo clone\");";
        return new CodeGeneratedMethod(body)
        {
            IsMethodInline = true,
        };
    }
}
#endif
