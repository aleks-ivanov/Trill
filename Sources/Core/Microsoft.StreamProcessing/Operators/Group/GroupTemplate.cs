﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Microsoft.StreamProcessing
{
    using System.Linq;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    internal partial class GroupTemplate : CommonPipeTemplate
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n");
            this.Write(@"// *********************************************************************
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License
// *********************************************************************
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Microsoft.StreamProcessing;
using Microsoft.StreamProcessing.Internal;
using Microsoft.StreamProcessing.Internal.Collections;
[assembly: IgnoresAccessChecksTo(""Microsoft.StreamProcessing"")]

");

    List<string> genericParamList = new List<string>();
    var TOuterKey = outerKeyType.GetCSharpSourceSyntax(ref genericParamList);
    var outerKeyGenericParameterCount = genericParamList.Count;
    var TSource = sourceType.GetCSharpSourceSyntax(ref genericParamList);
    var sourceGenericParameterCount = genericParamList.Count;
    var sourceGenericParameters = 0 < genericParamList.Count ? "<" + String.Join(",", genericParamList) + ">" : string.Empty;
    var TInnerKey = innerKeyType.GetCSharpSourceSyntax(ref genericParamList);
    var genericParameters = 0 < genericParamList.Count ? "<" + String.Join(",", genericParamList) + ">" : string.Empty;

    var outKeyInnerKeyGenericParameterList = genericParamList.Take(outerKeyGenericParameterCount).Concat(genericParamList.Skip(sourceGenericParameterCount));
    var TOuterKeyTInnerKeyGenericParameters = 0 < outKeyInnerKeyGenericParameterList.Count() ? "<" + String.Join(",", outKeyInnerKeyGenericParameterList) + ">" : string.Empty;

    var resultBatchGenericParameters = genericParameters;
    var resultBatchClassType = isFirstLevelGroup
        ? Transformer.GetBatchClassName(innerKeyType, sourceType)
        : Transformer.GetBatchClassName(typeof(CompoundGroupKey<,>).MakeGenericType(outerKeyType, innerKeyType), sourceType);
    var sourceBatchClassType = Transformer.GetBatchClassName(outerKeyType, sourceType);

    var innerKeyIsAnonymous = innerKeyType.IsAnonymousTypeName();
    if (innerKeyIsAnonymous) {
      transformedKeySelectorAsString = string.Format("({0})Activator.CreateInstance(typeof({0}), {1} )", TInnerKey, transformedKeySelectorAsString);
    }

    var outputKey = !isFirstLevelGroup ? "CompoundGroupKey<" + TOuterKey + ", " + TInnerKey + ">" : TInnerKey;
    var nestedInfix = !isFirstLevelGroup ? "Nested" : string.Empty;
    var ungroupingToUnit = isFirstLevelGroup && innerKeyType == typeof(Empty);
    var swingingKeyFromField = isFirstLevelGroup && !this.swingingField.Equals(default(MyFieldInfo));

            this.Write("\r\n// TOuterKey: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TOuterKey));
            this.Write("\r\n// TInnerKey: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TInnerKey));
            this.Write("\r\n// TSource: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write("\r\n\r\n[DataContract]\r\ninternal sealed class ");
            this.Write(this.ToStringHelper.ToStringWithCulture(className));
            this.Write(this.ToStringHelper.ToStringWithCulture(genericParameters));
            this.Write(" :\r\n                       Pipe<");
            this.Write(this.ToStringHelper.ToStringWithCulture(outputKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write(">, IStreamObserver<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TOuterKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write(">\r\n{\r\n");
 if (innerKeyIsAnonymous) { 
            this.Write("    [SchemaSerialization]\r\n    private readonly Expression<Func<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TInnerKey));
            this.Write(", int>> keyComparer;\r\n    private readonly Func<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TInnerKey));
            this.Write(", int> innerHashCode;\r\n");
 } 
            this.Write("    private readonly MemoryPool<");
            this.Write(this.ToStringHelper.ToStringWithCulture(outputKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write("> l1Pool;\r\n    private readonly Func<PlanNode, IQueryObject, PlanNode> queryPlanG" +
                    "enerator;\r\n\r\n");
 if (ungroupingToUnit) { 
            this.Write("\r\n    private readonly ColumnBatch<Microsoft.StreamProcessing.Empty> unitColumn;\r" +
                    "\n    private readonly ColumnBatch<int> unitHashColumn;\r\n");
 } 
            this.Write("\r\n    ");
            this.Write(this.ToStringHelper.ToStringWithCulture(staticCtor));
            this.Write("\r\n\r\n    public ");
            this.Write(this.ToStringHelper.ToStringWithCulture(className));
            this.Write("() { }\r\n\r\n    public ");
            this.Write(this.ToStringHelper.ToStringWithCulture(className));
            this.Write("(\r\n        IStreamable<");
            this.Write(this.ToStringHelper.ToStringWithCulture(outputKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write("> stream,\r\n        IStreamObserver<");
            this.Write(this.ToStringHelper.ToStringWithCulture(outputKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write("> observer,\r\n        Expression<Func<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TInnerKey));
            this.Write(", int>> keyComparer,\r\n        Expression<Func<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TInnerKey));
            this.Write(">> keySelector,\r\n        Func<PlanNode, IQueryObject, PlanNode> queryPlanGenerato" +
                    "r)\r\n        : base(stream, observer)\r\n    {\r\n");
 if (innerKeyIsAnonymous) { 
     if (isFirstLevelGroup) { 
            this.Write("        var _keySelector = keySelector.Compile();\r\n");
     } 
            this.Write("        this.keyComparer = keyComparer;\r\n        this.innerHashCode = keyComparer" +
                    ".Compile();\r\n");
 } 
            this.Write("        this.l1Pool = MemoryManager.GetMemoryPool<");
            this.Write(this.ToStringHelper.ToStringWithCulture(outputKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write(">(true);\r\n        this.queryPlanGenerator = queryPlanGenerator;\r\n");
 if (ungroupingToUnit) { 
            this.Write("\r\n        this.l1Pool.GetKey(out this.unitColumn);\r\n        this.l1Pool.Get(out t" +
                    "his.unitHashColumn);\r\n        Array.Clear(this.unitHashColumn.col, 0, this.unitH" +
                    "ashColumn.col.Length);\r\n");
 } 
            this.Write(@"    }

    public override void ProduceQueryPlan(PlanNode previous)
    {
        Observer.ProduceQueryPlan(queryPlanGenerator(previous, this));
    }

    protected override void FlushContents() { }

    public override int CurrentlyBufferedOutputCount => 0;

    public override int CurrentlyBufferedInputCount => 0;

    protected override void DisposeState()
    {
");
 if (ungroupingToUnit) { 
            this.Write("        this.unitColumn.Return();\r\n        this.unitHashColumn.Return();\r\n");
 } 
            this.Write("    }\r\n\r\n    public unsafe void OnNext(StreamMessage<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TOuterKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write("> batch)\r\n    {\r\n        StreamMessage<");
            this.Write(this.ToStringHelper.ToStringWithCulture(outputKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write("> resultBatchUncast; // Need this type to call Get with so the right subtype will" +
                    " be returned\r\n        this.l1Pool.Get(out resultBatchUncast);\r\n\r\n        ");
            this.Write(this.ToStringHelper.ToStringWithCulture(resultBatchClassType));
            this.Write(this.ToStringHelper.ToStringWithCulture(resultBatchGenericParameters));
            this.Write(" resultBatch = resultBatchUncast as ");
            this.Write(this.ToStringHelper.ToStringWithCulture(resultBatchClassType));
            this.Write(this.ToStringHelper.ToStringWithCulture(resultBatchGenericParameters));
            this.Write(";\r\n        ");
            this.Write(this.ToStringHelper.ToStringWithCulture(sourceBatchClassType));
            this.Write(this.ToStringHelper.ToStringWithCulture(sourceGenericParameters));
            this.Write(" inputBatch = batch as ");
            this.Write(this.ToStringHelper.ToStringWithCulture(sourceBatchClassType));
            this.Write(this.ToStringHelper.ToStringWithCulture(sourceGenericParameters));
            this.Write(";\r\n\r\n        resultBatch.vsync = batch.vsync;\r\n        resultBatch.vother = batch" +
                    ".vother;\r\n");
 foreach (var f in this.fields) { 
            this.Write("        resultBatch.");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(" = inputBatch.");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(";\r\n");
 } 
 if (this.payloadMightBeNull) { 
            this.Write("        resultBatch._nullnessvector = inputBatch._nullnessvector;\r\n");
 } 
            this.Write("\r\n");
 if (!ungroupingToUnit && !swingingHashColumn) { 
            this.Write("\r\n        resultBatch.hash = batch.hash.MakeWritable(this.l1Pool.intPool);\r\n");
 } 
            this.Write("        resultBatch.bitvector = batch.bitvector;\r\n\r\n");
 if (!ungroupingToUnit && (!isFirstLevelGroup || this.swingingField.Equals(default(MyFieldInfo)))) { 
            this.Write("        this.l1Pool.GetKey(out resultBatchUncast.key);\r\n");
 } 
            this.Write("\r\n        resultBatch.Count = batch.Count;\r\n\r\n        var count = batch.Count;\r\n\r" +
                    "\n");
 if (ungroupingToUnit) { 
            this.Write("        this.unitColumn.IncrementRefCount(1);\r\n        resultBatch.key = unitColu" +
                    "mn;\r\n        this.unitHashColumn.IncrementRefCount(1);\r\n        resultBatch.hash" +
                    " = unitHashColumn;\r\n");
 } else { 
            this.Write("\r\n        var src_key = batch.key.col;\r\n");
 if (!isFirstLevelGroup || this.swingingField.Equals(default(MyFieldInfo))) { 
            this.Write("\r\n        var dest_key = resultBatch.key.col;\r\n");
 } 
            this.Write("        var dest_payload = resultBatch;\r\n\r\n");
 if (swingingKeyFromField) { 
            this.Write("        // The key selector was just e => e.f *and* isFirstLevelGroup so just swi" +
                    "ng the key field\r\n");
 if (this.swingingField.OptimizeString()) { 
            this.Write("\r\n        resultBatch.key = resultBatch.");
            this.Write(this.ToStringHelper.ToStringWithCulture(this.swingingField.Name));
            this.Write(".ToColumnBatch(this.l1Pool.stringPool, resultBatch.bitvector);\r\n");
 } else { 
            this.Write("\r\n        resultBatch.key = resultBatch.");
            this.Write(this.ToStringHelper.ToStringWithCulture(this.swingingField.Name));
            this.Write(";\r\n        resultBatch.key.IncrementRefCount(1);\r\n");
 } 
 } 
            this.Write("\r\n\r\n");
 foreach (var f in this.fields) { 
            this.Write("\r\n");
     if (f.canBeFixed) { 
            this.Write("        fixed (");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.TypeName));
            this.Write("* ");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write("_col = resultBatch.");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(".col)\r\n        {\r\n");
     } else { 
            this.Write("\r\n");
         if (f.OptimizeString()) { 
            this.Write("        var ");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write("_col = resultBatch.");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(";\r\n");
         } else { 
            this.Write("        var ");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write("_col = resultBatch.");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(".col;\r\n");
         } 
     } 
 } 
            this.Write("\r\n        ");
            this.Write(this.ToStringHelper.ToStringWithCulture(vectorHashCodeInitialization));
            this.Write("\r\n\r\n");
 if (!swingingKeyFromField || !swingingHashColumn) { 
            this.Write("\r\n        fixed (long* src_bv = batch.bitvector.col) {\r\n");
 if (!ungroupingToUnit) { 
            this.Write("        fixed (int* dest_hash = resultBatch.hash.col) {\r\n");
 } 
            this.Write("            for (int i = 0; i < count; i++)\r\n            {\r\n                if ((" +
                    "src_bv[i >> 6] & (1L << (i & 0x3f))) != 0) continue;\r\n\r\n");
 if (!swingingKeyFromField || !this.swingingField.OptimizeString()) { 
            this.Write("\r\n                var key = ");
            this.Write(this.ToStringHelper.ToStringWithCulture(this.transformedKeySelectorAsString));
            this.Write(";\r\n");
 } 
 if (innerKeyIsAnonymous) { 
            this.Write("                var innerHash = this.innerHashCode(key);\r\n");
 } else if (swingingHashColumn) { 
            this.Write("\r\n                // don\'t compute hash because that was done by calling MultiStr" +
                    "ing.GetHashCode\r\n");
 } else { 
            this.Write("                var innerHash = ");
            this.Write(this.ToStringHelper.ToStringWithCulture(inlinedHashCodeComputation));
            this.Write(";\r\n");
 } 
            this.Write("\r\n");
 if (isFirstLevelGroup) { 
     if (!this.swingingField.Equals(default(MyFieldInfo))) { 
            this.Write("                // no assignment to key, pointer was swung!\r\n");
     } else { 
            this.Write("                dest_key[i] = key;\r\n");
     } 
 if (!swingingHashColumn) { 
            this.Write("\r\n                dest_hash[i] = innerHash;\r\n");
 } 
 } else { 
            this.Write("                var hash = dest_hash[i] ^ innerHash;\r\n                dest_key[i]" +
                    ".outerGroup = src_key[i];\r\n                dest_key[i].innerGroup = key;\r\n      " +
                    "          dest_key[i].hashCode = hash;\r\n                dest_hash[i] = hash;\r\n");
 } 
            this.Write("            }\r\n");
 if (!ungroupingToUnit) { 
            this.Write("        } // end of fixed for dest_hash\r\n");
 } 
            this.Write("        } // end of fixed for src_bv\r\n");
 } 
            this.Write("\r\n        ");
 if (!String.IsNullOrWhiteSpace(vectorHashCodeInitialization) && !swingingHashColumn) { 
            this.Write("\r\n        this.hashCodeVector.Return();\r\n        ");
 } 
            this.Write("\r\n");
 foreach (var f in this.fields.Where(fld => fld.canBeFixed)) { 
            this.Write("\r\n        }\r\n");
 } 
            this.Write("\r\n");
 } 
            this.Write("        batch.ReleaseKey();\r\n");
 if (ungroupingToUnit || swingingHashColumn) { 
            this.Write("\r\n        batch.hash.Return();\r\n");
 } 
            this.Write("\r\n        batch.Return();\r\n\r\n        this.Observer.OnNext(resultBatch);\r\n    }\r\n\r" +
                    "\n    public void OnError(Exception error)\r\n    {\r\n        Observer.OnError(error" +
                    ");\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
}
