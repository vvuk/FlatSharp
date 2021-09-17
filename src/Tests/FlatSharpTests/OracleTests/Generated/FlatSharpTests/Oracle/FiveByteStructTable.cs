// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace FlatSharpTests.Oracle
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct FiveByteStructTable : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_2_0_0(); }
  public static FiveByteStructTable GetRootAsFiveByteStructTable(ByteBuffer _bb) { return GetRootAsFiveByteStructTable(_bb, new FiveByteStructTable()); }
  public static FiveByteStructTable GetRootAsFiveByteStructTable(ByteBuffer _bb, FiveByteStructTable obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public FiveByteStructTable __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public FlatSharpTests.Oracle.FiveByteStruct? Vector(int j) { int o = __p.__offset(4); return o != 0 ? (FlatSharpTests.Oracle.FiveByteStruct?)(new FlatSharpTests.Oracle.FiveByteStruct()).__assign(__p.__vector(o) + j * 8, __p.bb) : null; }
  public int VectorLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<FlatSharpTests.Oracle.FiveByteStructTable> CreateFiveByteStructTable(FlatBufferBuilder builder,
      VectorOffset VectorOffset = default(VectorOffset)) {
    builder.StartTable(1);
    FiveByteStructTable.AddVector(builder, VectorOffset);
    return FiveByteStructTable.EndFiveByteStructTable(builder);
  }

  public static void StartFiveByteStructTable(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddVector(FlatBufferBuilder builder, VectorOffset VectorOffset) { builder.AddOffset(0, VectorOffset.Value, 0); }
  public static void StartVectorVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(8, numElems, 4); }
  public static Offset<FlatSharpTests.Oracle.FiveByteStructTable> EndFiveByteStructTable(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<FlatSharpTests.Oracle.FiveByteStructTable>(o);
  }
  public FiveByteStructTableT UnPack() {
    var _o = new FiveByteStructTableT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(FiveByteStructTableT _o) {
    _o.Vector = new List<FlatSharpTests.Oracle.FiveByteStructT>();
    for (var _j = 0; _j < this.VectorLength; ++_j) {_o.Vector.Add(this.Vector(_j).HasValue ? this.Vector(_j).Value.UnPack() : null);}
  }
  public static Offset<FlatSharpTests.Oracle.FiveByteStructTable> Pack(FlatBufferBuilder builder, FiveByteStructTableT _o) {
    if (_o == null) return default(Offset<FlatSharpTests.Oracle.FiveByteStructTable>);
    var _Vector = default(VectorOffset);
    if (_o.Vector != null) {
      StartVectorVector(builder, _o.Vector.Count);
      for (var _j = _o.Vector.Count - 1; _j >= 0; --_j) { FlatSharpTests.Oracle.FiveByteStruct.Pack(builder, _o.Vector[_j]); }
      _Vector = builder.EndVector();
    }
    return CreateFiveByteStructTable(
      builder,
      _Vector);
  }
}

public class FiveByteStructTableT
{
  public List<FlatSharpTests.Oracle.FiveByteStructT> Vector { get; set; }

  public FiveByteStructTableT() {
    this.Vector = null;
  }
}


}
