#include "pch-c.h"
#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include "codegen/il2cpp-codegen-metadata.h"





// 0x00000001 System.Exception System.Linq.Error::ArgumentNull(System.String)
extern void Error_ArgumentNull_m0EDA0D46D72CA692518E3E2EB75B48044D8FD41E (void);
// 0x00000002 System.Exception System.Linq.Error::MoreThanOneMatch()
extern void Error_MoreThanOneMatch_m4C4756AF34A76EF12F3B2B6D8C78DE547F0FBCF8 (void);
// 0x00000003 System.Exception System.Linq.Error::NoElements()
extern void Error_NoElements_mB89E91246572F009281D79730950808F17C3F353 (void);
// 0x00000004 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::Where(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000005 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::Select(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TResult>)
// 0x00000006 System.Func`2<TSource,System.Boolean> System.Linq.Enumerable::CombinePredicates(System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,System.Boolean>)
// 0x00000007 System.Func`2<TSource,TResult> System.Linq.Enumerable::CombineSelectors(System.Func`2<TSource,TMiddle>,System.Func`2<TMiddle,TResult>)
// 0x00000008 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::SelectMany(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Collections.Generic.IEnumerable`1<TResult>>)
// 0x00000009 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::SelectManyIterator(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Collections.Generic.IEnumerable`1<TResult>>)
// 0x0000000A System.Linq.IOrderedEnumerable`1<TSource> System.Linq.Enumerable::OrderBy(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TKey>)
// 0x0000000B System.Linq.IOrderedEnumerable`1<TSource> System.Linq.Enumerable::ThenBy(System.Linq.IOrderedEnumerable`1<TSource>,System.Func`2<TSource,TKey>)
// 0x0000000C System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::Concat(System.Collections.Generic.IEnumerable`1<TSource>,System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000D System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::ConcatIterator(System.Collections.Generic.IEnumerable`1<TSource>,System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000E System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::Union(System.Collections.Generic.IEnumerable`1<TSource>,System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000F System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::UnionIterator(System.Collections.Generic.IEnumerable`1<TSource>,System.Collections.Generic.IEnumerable`1<TSource>,System.Collections.Generic.IEqualityComparer`1<TSource>)
// 0x00000010 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::Intersect(System.Collections.Generic.IEnumerable`1<TSource>,System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000011 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::IntersectIterator(System.Collections.Generic.IEnumerable`1<TSource>,System.Collections.Generic.IEnumerable`1<TSource>,System.Collections.Generic.IEqualityComparer`1<TSource>)
// 0x00000012 TSource[] System.Linq.Enumerable::ToArray(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000013 System.Collections.Generic.List`1<TSource> System.Linq.Enumerable::ToList(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000014 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::Cast(System.Collections.IEnumerable)
// 0x00000015 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::CastIterator(System.Collections.IEnumerable)
// 0x00000016 TSource System.Linq.Enumerable::First(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000017 TSource System.Linq.Enumerable::Last(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000018 TSource System.Linq.Enumerable::SingleOrDefault(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000019 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::Empty()
// 0x0000001A System.Boolean System.Linq.Enumerable::Any(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000001B System.Boolean System.Linq.Enumerable::Any(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x0000001C System.Int32 System.Linq.Enumerable::Count(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000001D System.Boolean System.Linq.Enumerable::Contains(System.Collections.Generic.IEnumerable`1<TSource>,TSource)
// 0x0000001E System.Boolean System.Linq.Enumerable::Contains(System.Collections.Generic.IEnumerable`1<TSource>,TSource,System.Collections.Generic.IEqualityComparer`1<TSource>)
// 0x0000001F System.Void System.Linq.Enumerable/Iterator`1::.ctor()
// 0x00000020 TSource System.Linq.Enumerable/Iterator`1::get_Current()
// 0x00000021 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/Iterator`1::Clone()
// 0x00000022 System.Void System.Linq.Enumerable/Iterator`1::Dispose()
// 0x00000023 System.Collections.Generic.IEnumerator`1<TSource> System.Linq.Enumerable/Iterator`1::GetEnumerator()
// 0x00000024 System.Boolean System.Linq.Enumerable/Iterator`1::MoveNext()
// 0x00000025 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/Iterator`1::Select(System.Func`2<TSource,TResult>)
// 0x00000026 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/Iterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x00000027 System.Object System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerator.get_Current()
// 0x00000028 System.Collections.IEnumerator System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerable.GetEnumerator()
// 0x00000029 System.Void System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerator.Reset()
// 0x0000002A System.Void System.Linq.Enumerable/WhereEnumerableIterator`1::.ctor(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x0000002B System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereEnumerableIterator`1::Clone()
// 0x0000002C System.Void System.Linq.Enumerable/WhereEnumerableIterator`1::Dispose()
// 0x0000002D System.Boolean System.Linq.Enumerable/WhereEnumerableIterator`1::MoveNext()
// 0x0000002E System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereEnumerableIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x0000002F System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereEnumerableIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x00000030 System.Void System.Linq.Enumerable/WhereArrayIterator`1::.ctor(TSource[],System.Func`2<TSource,System.Boolean>)
// 0x00000031 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereArrayIterator`1::Clone()
// 0x00000032 System.Boolean System.Linq.Enumerable/WhereArrayIterator`1::MoveNext()
// 0x00000033 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereArrayIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x00000034 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereArrayIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x00000035 System.Void System.Linq.Enumerable/WhereListIterator`1::.ctor(System.Collections.Generic.List`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000036 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereListIterator`1::Clone()
// 0x00000037 System.Boolean System.Linq.Enumerable/WhereListIterator`1::MoveNext()
// 0x00000038 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereListIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x00000039 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereListIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x0000003A System.Void System.Linq.Enumerable/WhereSelectEnumerableIterator`2::.ctor(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x0000003B System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Clone()
// 0x0000003C System.Void System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Dispose()
// 0x0000003D System.Boolean System.Linq.Enumerable/WhereSelectEnumerableIterator`2::MoveNext()
// 0x0000003E System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x0000003F System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x00000040 System.Void System.Linq.Enumerable/WhereSelectArrayIterator`2::.ctor(TSource[],System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x00000041 System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectArrayIterator`2::Clone()
// 0x00000042 System.Boolean System.Linq.Enumerable/WhereSelectArrayIterator`2::MoveNext()
// 0x00000043 System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectArrayIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x00000044 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectArrayIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x00000045 System.Void System.Linq.Enumerable/WhereSelectListIterator`2::.ctor(System.Collections.Generic.List`1<TSource>,System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x00000046 System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectListIterator`2::Clone()
// 0x00000047 System.Boolean System.Linq.Enumerable/WhereSelectListIterator`2::MoveNext()
// 0x00000048 System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectListIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x00000049 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectListIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x0000004A System.Void System.Linq.Enumerable/<>c__DisplayClass6_0`1::.ctor()
// 0x0000004B System.Boolean System.Linq.Enumerable/<>c__DisplayClass6_0`1::<CombinePredicates>b__0(TSource)
// 0x0000004C System.Void System.Linq.Enumerable/<>c__DisplayClass7_0`3::.ctor()
// 0x0000004D TResult System.Linq.Enumerable/<>c__DisplayClass7_0`3::<CombineSelectors>b__0(TSource)
// 0x0000004E System.Void System.Linq.Enumerable/<SelectManyIterator>d__17`2::.ctor(System.Int32)
// 0x0000004F System.Void System.Linq.Enumerable/<SelectManyIterator>d__17`2::System.IDisposable.Dispose()
// 0x00000050 System.Boolean System.Linq.Enumerable/<SelectManyIterator>d__17`2::MoveNext()
// 0x00000051 System.Void System.Linq.Enumerable/<SelectManyIterator>d__17`2::<>m__Finally1()
// 0x00000052 System.Void System.Linq.Enumerable/<SelectManyIterator>d__17`2::<>m__Finally2()
// 0x00000053 TResult System.Linq.Enumerable/<SelectManyIterator>d__17`2::System.Collections.Generic.IEnumerator<TResult>.get_Current()
// 0x00000054 System.Void System.Linq.Enumerable/<SelectManyIterator>d__17`2::System.Collections.IEnumerator.Reset()
// 0x00000055 System.Object System.Linq.Enumerable/<SelectManyIterator>d__17`2::System.Collections.IEnumerator.get_Current()
// 0x00000056 System.Collections.Generic.IEnumerator`1<TResult> System.Linq.Enumerable/<SelectManyIterator>d__17`2::System.Collections.Generic.IEnumerable<TResult>.GetEnumerator()
// 0x00000057 System.Collections.IEnumerator System.Linq.Enumerable/<SelectManyIterator>d__17`2::System.Collections.IEnumerable.GetEnumerator()
// 0x00000058 System.Void System.Linq.Enumerable/<ConcatIterator>d__59`1::.ctor(System.Int32)
// 0x00000059 System.Void System.Linq.Enumerable/<ConcatIterator>d__59`1::System.IDisposable.Dispose()
// 0x0000005A System.Boolean System.Linq.Enumerable/<ConcatIterator>d__59`1::MoveNext()
// 0x0000005B System.Void System.Linq.Enumerable/<ConcatIterator>d__59`1::<>m__Finally1()
// 0x0000005C System.Void System.Linq.Enumerable/<ConcatIterator>d__59`1::<>m__Finally2()
// 0x0000005D TSource System.Linq.Enumerable/<ConcatIterator>d__59`1::System.Collections.Generic.IEnumerator<TSource>.get_Current()
// 0x0000005E System.Void System.Linq.Enumerable/<ConcatIterator>d__59`1::System.Collections.IEnumerator.Reset()
// 0x0000005F System.Object System.Linq.Enumerable/<ConcatIterator>d__59`1::System.Collections.IEnumerator.get_Current()
// 0x00000060 System.Collections.Generic.IEnumerator`1<TSource> System.Linq.Enumerable/<ConcatIterator>d__59`1::System.Collections.Generic.IEnumerable<TSource>.GetEnumerator()
// 0x00000061 System.Collections.IEnumerator System.Linq.Enumerable/<ConcatIterator>d__59`1::System.Collections.IEnumerable.GetEnumerator()
// 0x00000062 System.Void System.Linq.Enumerable/<UnionIterator>d__71`1::.ctor(System.Int32)
// 0x00000063 System.Void System.Linq.Enumerable/<UnionIterator>d__71`1::System.IDisposable.Dispose()
// 0x00000064 System.Boolean System.Linq.Enumerable/<UnionIterator>d__71`1::MoveNext()
// 0x00000065 System.Void System.Linq.Enumerable/<UnionIterator>d__71`1::<>m__Finally1()
// 0x00000066 System.Void System.Linq.Enumerable/<UnionIterator>d__71`1::<>m__Finally2()
// 0x00000067 TSource System.Linq.Enumerable/<UnionIterator>d__71`1::System.Collections.Generic.IEnumerator<TSource>.get_Current()
// 0x00000068 System.Void System.Linq.Enumerable/<UnionIterator>d__71`1::System.Collections.IEnumerator.Reset()
// 0x00000069 System.Object System.Linq.Enumerable/<UnionIterator>d__71`1::System.Collections.IEnumerator.get_Current()
// 0x0000006A System.Collections.Generic.IEnumerator`1<TSource> System.Linq.Enumerable/<UnionIterator>d__71`1::System.Collections.Generic.IEnumerable<TSource>.GetEnumerator()
// 0x0000006B System.Collections.IEnumerator System.Linq.Enumerable/<UnionIterator>d__71`1::System.Collections.IEnumerable.GetEnumerator()
// 0x0000006C System.Void System.Linq.Enumerable/<IntersectIterator>d__74`1::.ctor(System.Int32)
// 0x0000006D System.Void System.Linq.Enumerable/<IntersectIterator>d__74`1::System.IDisposable.Dispose()
// 0x0000006E System.Boolean System.Linq.Enumerable/<IntersectIterator>d__74`1::MoveNext()
// 0x0000006F System.Void System.Linq.Enumerable/<IntersectIterator>d__74`1::<>m__Finally1()
// 0x00000070 TSource System.Linq.Enumerable/<IntersectIterator>d__74`1::System.Collections.Generic.IEnumerator<TSource>.get_Current()
// 0x00000071 System.Void System.Linq.Enumerable/<IntersectIterator>d__74`1::System.Collections.IEnumerator.Reset()
// 0x00000072 System.Object System.Linq.Enumerable/<IntersectIterator>d__74`1::System.Collections.IEnumerator.get_Current()
// 0x00000073 System.Collections.Generic.IEnumerator`1<TSource> System.Linq.Enumerable/<IntersectIterator>d__74`1::System.Collections.Generic.IEnumerable<TSource>.GetEnumerator()
// 0x00000074 System.Collections.IEnumerator System.Linq.Enumerable/<IntersectIterator>d__74`1::System.Collections.IEnumerable.GetEnumerator()
// 0x00000075 System.Void System.Linq.Enumerable/<CastIterator>d__99`1::.ctor(System.Int32)
// 0x00000076 System.Void System.Linq.Enumerable/<CastIterator>d__99`1::System.IDisposable.Dispose()
// 0x00000077 System.Boolean System.Linq.Enumerable/<CastIterator>d__99`1::MoveNext()
// 0x00000078 System.Void System.Linq.Enumerable/<CastIterator>d__99`1::<>m__Finally1()
// 0x00000079 TResult System.Linq.Enumerable/<CastIterator>d__99`1::System.Collections.Generic.IEnumerator<TResult>.get_Current()
// 0x0000007A System.Void System.Linq.Enumerable/<CastIterator>d__99`1::System.Collections.IEnumerator.Reset()
// 0x0000007B System.Object System.Linq.Enumerable/<CastIterator>d__99`1::System.Collections.IEnumerator.get_Current()
// 0x0000007C System.Collections.Generic.IEnumerator`1<TResult> System.Linq.Enumerable/<CastIterator>d__99`1::System.Collections.Generic.IEnumerable<TResult>.GetEnumerator()
// 0x0000007D System.Collections.IEnumerator System.Linq.Enumerable/<CastIterator>d__99`1::System.Collections.IEnumerable.GetEnumerator()
// 0x0000007E System.Void System.Linq.EmptyEnumerable`1::.cctor()
// 0x0000007F System.Linq.IOrderedEnumerable`1<TElement> System.Linq.IOrderedEnumerable`1::CreateOrderedEnumerable(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x00000080 System.Void System.Linq.Set`1::.ctor(System.Collections.Generic.IEqualityComparer`1<TElement>)
// 0x00000081 System.Boolean System.Linq.Set`1::Add(TElement)
// 0x00000082 System.Boolean System.Linq.Set`1::Remove(TElement)
// 0x00000083 System.Boolean System.Linq.Set`1::Find(TElement,System.Boolean)
// 0x00000084 System.Void System.Linq.Set`1::Resize()
// 0x00000085 System.Int32 System.Linq.Set`1::InternalGetHashCode(TElement)
// 0x00000086 System.Collections.Generic.IEnumerator`1<TElement> System.Linq.OrderedEnumerable`1::GetEnumerator()
// 0x00000087 System.Linq.EnumerableSorter`1<TElement> System.Linq.OrderedEnumerable`1::GetEnumerableSorter(System.Linq.EnumerableSorter`1<TElement>)
// 0x00000088 System.Collections.IEnumerator System.Linq.OrderedEnumerable`1::System.Collections.IEnumerable.GetEnumerator()
// 0x00000089 System.Linq.IOrderedEnumerable`1<TElement> System.Linq.OrderedEnumerable`1::System.Linq.IOrderedEnumerable<TElement>.CreateOrderedEnumerable(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x0000008A System.Void System.Linq.OrderedEnumerable`1::.ctor()
// 0x0000008B System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::.ctor(System.Int32)
// 0x0000008C System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.IDisposable.Dispose()
// 0x0000008D System.Boolean System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::MoveNext()
// 0x0000008E TElement System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.Generic.IEnumerator<TElement>.get_Current()
// 0x0000008F System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.IEnumerator.Reset()
// 0x00000090 System.Object System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.IEnumerator.get_Current()
// 0x00000091 System.Void System.Linq.OrderedEnumerable`2::.ctor(System.Collections.Generic.IEnumerable`1<TElement>,System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x00000092 System.Linq.EnumerableSorter`1<TElement> System.Linq.OrderedEnumerable`2::GetEnumerableSorter(System.Linq.EnumerableSorter`1<TElement>)
// 0x00000093 System.Void System.Linq.EnumerableSorter`1::ComputeKeys(TElement[],System.Int32)
// 0x00000094 System.Int32 System.Linq.EnumerableSorter`1::CompareKeys(System.Int32,System.Int32)
// 0x00000095 System.Int32[] System.Linq.EnumerableSorter`1::Sort(TElement[],System.Int32)
// 0x00000096 System.Void System.Linq.EnumerableSorter`1::QuickSort(System.Int32[],System.Int32,System.Int32)
// 0x00000097 System.Void System.Linq.EnumerableSorter`1::.ctor()
// 0x00000098 System.Void System.Linq.EnumerableSorter`2::.ctor(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean,System.Linq.EnumerableSorter`1<TElement>)
// 0x00000099 System.Void System.Linq.EnumerableSorter`2::ComputeKeys(TElement[],System.Int32)
// 0x0000009A System.Int32 System.Linq.EnumerableSorter`2::CompareKeys(System.Int32,System.Int32)
// 0x0000009B System.Void System.Linq.Buffer`1::.ctor(System.Collections.Generic.IEnumerable`1<TElement>)
// 0x0000009C TElement[] System.Linq.Buffer`1::ToArray()
// 0x0000009D System.Void System.Collections.Generic.BitHelper::.ctor(System.Int32*,System.Int32)
extern void BitHelper__ctor_m2770BB414919277B2CF522840B54819F5082CD80 (void);
// 0x0000009E System.Void System.Collections.Generic.BitHelper::.ctor(System.Int32[],System.Int32)
extern void BitHelper__ctor_m7A8E43BE1D2A4ED086E708B6FFE693322FC9D2EB (void);
// 0x0000009F System.Void System.Collections.Generic.BitHelper::MarkBit(System.Int32)
extern void BitHelper_MarkBit_m1C6D787021BEA9D02DCA0762C09E5D443E04A86B (void);
// 0x000000A0 System.Boolean System.Collections.Generic.BitHelper::IsMarked(System.Int32)
extern void BitHelper_IsMarked_m6036A81F50D820045D3F62E52D57098A332AB608 (void);
// 0x000000A1 System.Int32 System.Collections.Generic.BitHelper::ToIntArrayLength(System.Int32)
extern void BitHelper_ToIntArrayLength_m32A0B1B014CB81891165AC325514784171C8E7B3 (void);
// 0x000000A2 System.Void System.Collections.Generic.HashSet`1::.ctor()
// 0x000000A3 System.Void System.Collections.Generic.HashSet`1::.ctor(System.Collections.Generic.IEqualityComparer`1<T>)
// 0x000000A4 System.Void System.Collections.Generic.HashSet`1::.ctor(System.Collections.Generic.IEnumerable`1<T>)
// 0x000000A5 System.Void System.Collections.Generic.HashSet`1::.ctor(System.Collections.Generic.IEnumerable`1<T>,System.Collections.Generic.IEqualityComparer`1<T>)
// 0x000000A6 System.Void System.Collections.Generic.HashSet`1::.ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
// 0x000000A7 System.Void System.Collections.Generic.HashSet`1::CopyFrom(System.Collections.Generic.HashSet`1<T>)
// 0x000000A8 System.Void System.Collections.Generic.HashSet`1::System.Collections.Generic.ICollection<T>.Add(T)
// 0x000000A9 System.Void System.Collections.Generic.HashSet`1::Clear()
// 0x000000AA System.Boolean System.Collections.Generic.HashSet`1::Contains(T)
// 0x000000AB System.Void System.Collections.Generic.HashSet`1::CopyTo(T[],System.Int32)
// 0x000000AC System.Boolean System.Collections.Generic.HashSet`1::Remove(T)
// 0x000000AD System.Int32 System.Collections.Generic.HashSet`1::get_Count()
// 0x000000AE System.Boolean System.Collections.Generic.HashSet`1::System.Collections.Generic.ICollection<T>.get_IsReadOnly()
// 0x000000AF System.Collections.Generic.HashSet`1/Enumerator<T> System.Collections.Generic.HashSet`1::GetEnumerator()
// 0x000000B0 System.Collections.Generic.IEnumerator`1<T> System.Collections.Generic.HashSet`1::System.Collections.Generic.IEnumerable<T>.GetEnumerator()
// 0x000000B1 System.Collections.IEnumerator System.Collections.Generic.HashSet`1::System.Collections.IEnumerable.GetEnumerator()
// 0x000000B2 System.Void System.Collections.Generic.HashSet`1::GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
// 0x000000B3 System.Void System.Collections.Generic.HashSet`1::OnDeserialization(System.Object)
// 0x000000B4 System.Boolean System.Collections.Generic.HashSet`1::Add(T)
// 0x000000B5 System.Void System.Collections.Generic.HashSet`1::UnionWith(System.Collections.Generic.IEnumerable`1<T>)
// 0x000000B6 System.Void System.Collections.Generic.HashSet`1::IntersectWith(System.Collections.Generic.IEnumerable`1<T>)
// 0x000000B7 System.Void System.Collections.Generic.HashSet`1::ExceptWith(System.Collections.Generic.IEnumerable`1<T>)
// 0x000000B8 System.Boolean System.Collections.Generic.HashSet`1::SetEquals(System.Collections.Generic.IEnumerable`1<T>)
// 0x000000B9 System.Void System.Collections.Generic.HashSet`1::CopyTo(T[])
// 0x000000BA System.Void System.Collections.Generic.HashSet`1::CopyTo(T[],System.Int32,System.Int32)
// 0x000000BB System.Collections.Generic.IEqualityComparer`1<T> System.Collections.Generic.HashSet`1::get_Comparer()
// 0x000000BC System.Void System.Collections.Generic.HashSet`1::TrimExcess()
// 0x000000BD System.Void System.Collections.Generic.HashSet`1::Initialize(System.Int32)
// 0x000000BE System.Void System.Collections.Generic.HashSet`1::IncreaseCapacity()
// 0x000000BF System.Void System.Collections.Generic.HashSet`1::SetCapacity(System.Int32)
// 0x000000C0 System.Boolean System.Collections.Generic.HashSet`1::AddIfNotPresent(T)
// 0x000000C1 System.Void System.Collections.Generic.HashSet`1::AddValue(System.Int32,System.Int32,T)
// 0x000000C2 System.Boolean System.Collections.Generic.HashSet`1::ContainsAllElements(System.Collections.Generic.IEnumerable`1<T>)
// 0x000000C3 System.Void System.Collections.Generic.HashSet`1::IntersectWithHashSetWithSameEC(System.Collections.Generic.HashSet`1<T>)
// 0x000000C4 System.Void System.Collections.Generic.HashSet`1::IntersectWithEnumerable(System.Collections.Generic.IEnumerable`1<T>)
// 0x000000C5 System.Int32 System.Collections.Generic.HashSet`1::InternalIndexOf(T)
// 0x000000C6 System.Collections.Generic.HashSet`1/ElementCount<T> System.Collections.Generic.HashSet`1::CheckUniqueAndUnfoundElements(System.Collections.Generic.IEnumerable`1<T>,System.Boolean)
// 0x000000C7 System.Boolean System.Collections.Generic.HashSet`1::AreEqualityComparersEqual(System.Collections.Generic.HashSet`1<T>,System.Collections.Generic.HashSet`1<T>)
// 0x000000C8 System.Int32 System.Collections.Generic.HashSet`1::InternalGetHashCode(T)
// 0x000000C9 System.Void System.Collections.Generic.HashSet`1/Enumerator::.ctor(System.Collections.Generic.HashSet`1<T>)
// 0x000000CA System.Void System.Collections.Generic.HashSet`1/Enumerator::Dispose()
// 0x000000CB System.Boolean System.Collections.Generic.HashSet`1/Enumerator::MoveNext()
// 0x000000CC T System.Collections.Generic.HashSet`1/Enumerator::get_Current()
// 0x000000CD System.Object System.Collections.Generic.HashSet`1/Enumerator::System.Collections.IEnumerator.get_Current()
// 0x000000CE System.Void System.Collections.Generic.HashSet`1/Enumerator::System.Collections.IEnumerator.Reset()
static Il2CppMethodPointer s_methodPointers[206] = 
{
	Error_ArgumentNull_m0EDA0D46D72CA692518E3E2EB75B48044D8FD41E,
	Error_MoreThanOneMatch_m4C4756AF34A76EF12F3B2B6D8C78DE547F0FBCF8,
	Error_NoElements_mB89E91246572F009281D79730950808F17C3F353,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	BitHelper__ctor_m2770BB414919277B2CF522840B54819F5082CD80,
	BitHelper__ctor_m7A8E43BE1D2A4ED086E708B6FFE693322FC9D2EB,
	BitHelper_MarkBit_m1C6D787021BEA9D02DCA0762C09E5D443E04A86B,
	BitHelper_IsMarked_m6036A81F50D820045D3F62E52D57098A332AB608,
	BitHelper_ToIntArrayLength_m32A0B1B014CB81891165AC325514784171C8E7B3,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
};
static const int32_t s_InvokerIndices[206] = 
{
	6530,
	6722,
	6722,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	1477,
	1868,
	3580,
	3041,
	6420,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
};
static const Il2CppTokenRangePair s_rgctxIndices[58] = 
{
	{ 0x02000004, { 79, 4 } },
	{ 0x02000005, { 83, 9 } },
	{ 0x02000006, { 94, 7 } },
	{ 0x02000007, { 103, 10 } },
	{ 0x02000008, { 115, 11 } },
	{ 0x02000009, { 129, 9 } },
	{ 0x0200000A, { 141, 12 } },
	{ 0x0200000B, { 156, 1 } },
	{ 0x0200000C, { 157, 2 } },
	{ 0x0200000D, { 159, 12 } },
	{ 0x0200000E, { 171, 9 } },
	{ 0x0200000F, { 180, 12 } },
	{ 0x02000010, { 192, 12 } },
	{ 0x02000011, { 204, 6 } },
	{ 0x02000012, { 210, 2 } },
	{ 0x02000014, { 212, 8 } },
	{ 0x02000016, { 220, 3 } },
	{ 0x02000017, { 225, 5 } },
	{ 0x02000018, { 230, 7 } },
	{ 0x02000019, { 237, 3 } },
	{ 0x0200001A, { 240, 7 } },
	{ 0x0200001B, { 247, 4 } },
	{ 0x0200001D, { 251, 43 } },
	{ 0x02000020, { 294, 2 } },
	{ 0x06000004, { 0, 10 } },
	{ 0x06000005, { 10, 10 } },
	{ 0x06000006, { 20, 5 } },
	{ 0x06000007, { 25, 5 } },
	{ 0x06000008, { 30, 1 } },
	{ 0x06000009, { 31, 2 } },
	{ 0x0600000A, { 33, 2 } },
	{ 0x0600000B, { 35, 1 } },
	{ 0x0600000C, { 36, 1 } },
	{ 0x0600000D, { 37, 2 } },
	{ 0x0600000E, { 39, 1 } },
	{ 0x0600000F, { 40, 2 } },
	{ 0x06000010, { 42, 1 } },
	{ 0x06000011, { 43, 2 } },
	{ 0x06000012, { 45, 3 } },
	{ 0x06000013, { 48, 2 } },
	{ 0x06000014, { 50, 2 } },
	{ 0x06000015, { 52, 2 } },
	{ 0x06000016, { 54, 4 } },
	{ 0x06000017, { 58, 4 } },
	{ 0x06000018, { 62, 3 } },
	{ 0x06000019, { 65, 1 } },
	{ 0x0600001A, { 66, 1 } },
	{ 0x0600001B, { 67, 3 } },
	{ 0x0600001C, { 70, 2 } },
	{ 0x0600001D, { 72, 2 } },
	{ 0x0600001E, { 74, 5 } },
	{ 0x0600002E, { 92, 2 } },
	{ 0x06000033, { 101, 2 } },
	{ 0x06000038, { 113, 2 } },
	{ 0x0600003E, { 126, 3 } },
	{ 0x06000043, { 138, 3 } },
	{ 0x06000048, { 153, 3 } },
	{ 0x06000089, { 223, 2 } },
};
static const Il2CppRGCTXDefinition s_rgctxValues[296] = 
{
	{ (Il2CppRGCTXDataType)2, 5265 },
	{ (Il2CppRGCTXDataType)3, 17421 },
	{ (Il2CppRGCTXDataType)2, 8036 },
	{ (Il2CppRGCTXDataType)2, 7220 },
	{ (Il2CppRGCTXDataType)3, 33560 },
	{ (Il2CppRGCTXDataType)2, 5459 },
	{ (Il2CppRGCTXDataType)2, 7227 },
	{ (Il2CppRGCTXDataType)3, 33578 },
	{ (Il2CppRGCTXDataType)2, 7222 },
	{ (Il2CppRGCTXDataType)3, 33567 },
	{ (Il2CppRGCTXDataType)2, 5266 },
	{ (Il2CppRGCTXDataType)3, 17422 },
	{ (Il2CppRGCTXDataType)2, 8066 },
	{ (Il2CppRGCTXDataType)2, 7229 },
	{ (Il2CppRGCTXDataType)3, 33585 },
	{ (Il2CppRGCTXDataType)2, 5493 },
	{ (Il2CppRGCTXDataType)2, 7237 },
	{ (Il2CppRGCTXDataType)3, 33604 },
	{ (Il2CppRGCTXDataType)2, 7233 },
	{ (Il2CppRGCTXDataType)3, 33594 },
	{ (Il2CppRGCTXDataType)2, 1597 },
	{ (Il2CppRGCTXDataType)3, 117 },
	{ (Il2CppRGCTXDataType)3, 118 },
	{ (Il2CppRGCTXDataType)2, 3456 },
	{ (Il2CppRGCTXDataType)3, 13943 },
	{ (Il2CppRGCTXDataType)2, 1598 },
	{ (Il2CppRGCTXDataType)3, 121 },
	{ (Il2CppRGCTXDataType)3, 122 },
	{ (Il2CppRGCTXDataType)2, 3464 },
	{ (Il2CppRGCTXDataType)3, 13945 },
	{ (Il2CppRGCTXDataType)3, 37979 },
	{ (Il2CppRGCTXDataType)2, 1614 },
	{ (Il2CppRGCTXDataType)3, 473 },
	{ (Il2CppRGCTXDataType)2, 6387 },
	{ (Il2CppRGCTXDataType)3, 26202 },
	{ (Il2CppRGCTXDataType)3, 15130 },
	{ (Il2CppRGCTXDataType)3, 37939 },
	{ (Il2CppRGCTXDataType)2, 1602 },
	{ (Il2CppRGCTXDataType)3, 143 },
	{ (Il2CppRGCTXDataType)3, 38007 },
	{ (Il2CppRGCTXDataType)2, 1618 },
	{ (Il2CppRGCTXDataType)3, 509 },
	{ (Il2CppRGCTXDataType)3, 37959 },
	{ (Il2CppRGCTXDataType)2, 1612 },
	{ (Il2CppRGCTXDataType)3, 459 },
	{ (Il2CppRGCTXDataType)2, 1981 },
	{ (Il2CppRGCTXDataType)3, 2420 },
	{ (Il2CppRGCTXDataType)3, 2421 },
	{ (Il2CppRGCTXDataType)2, 5460 },
	{ (Il2CppRGCTXDataType)3, 18840 },
	{ (Il2CppRGCTXDataType)2, 3981 },
	{ (Il2CppRGCTXDataType)3, 37927 },
	{ (Il2CppRGCTXDataType)2, 1600 },
	{ (Il2CppRGCTXDataType)3, 129 },
	{ (Il2CppRGCTXDataType)2, 4588 },
	{ (Il2CppRGCTXDataType)2, 3738 },
	{ (Il2CppRGCTXDataType)2, 3993 },
	{ (Il2CppRGCTXDataType)2, 4154 },
	{ (Il2CppRGCTXDataType)2, 4589 },
	{ (Il2CppRGCTXDataType)2, 3739 },
	{ (Il2CppRGCTXDataType)2, 3994 },
	{ (Il2CppRGCTXDataType)2, 4155 },
	{ (Il2CppRGCTXDataType)2, 3995 },
	{ (Il2CppRGCTXDataType)2, 4156 },
	{ (Il2CppRGCTXDataType)3, 13944 },
	{ (Il2CppRGCTXDataType)2, 3177 },
	{ (Il2CppRGCTXDataType)2, 3977 },
	{ (Il2CppRGCTXDataType)2, 3978 },
	{ (Il2CppRGCTXDataType)2, 4152 },
	{ (Il2CppRGCTXDataType)3, 13942 },
	{ (Il2CppRGCTXDataType)2, 3737 },
	{ (Il2CppRGCTXDataType)2, 3992 },
	{ (Il2CppRGCTXDataType)2, 3736 },
	{ (Il2CppRGCTXDataType)3, 37947 },
	{ (Il2CppRGCTXDataType)3, 12905 },
	{ (Il2CppRGCTXDataType)2, 3335 },
	{ (Il2CppRGCTXDataType)2, 3980 },
	{ (Il2CppRGCTXDataType)2, 4153 },
	{ (Il2CppRGCTXDataType)2, 4294 },
	{ (Il2CppRGCTXDataType)3, 17423 },
	{ (Il2CppRGCTXDataType)3, 17425 },
	{ (Il2CppRGCTXDataType)2, 962 },
	{ (Il2CppRGCTXDataType)3, 17424 },
	{ (Il2CppRGCTXDataType)3, 17433 },
	{ (Il2CppRGCTXDataType)2, 5269 },
	{ (Il2CppRGCTXDataType)2, 7223 },
	{ (Il2CppRGCTXDataType)3, 33568 },
	{ (Il2CppRGCTXDataType)3, 17434 },
	{ (Il2CppRGCTXDataType)2, 4049 },
	{ (Il2CppRGCTXDataType)2, 4187 },
	{ (Il2CppRGCTXDataType)3, 13953 },
	{ (Il2CppRGCTXDataType)3, 37930 },
	{ (Il2CppRGCTXDataType)2, 7234 },
	{ (Il2CppRGCTXDataType)3, 33595 },
	{ (Il2CppRGCTXDataType)3, 17426 },
	{ (Il2CppRGCTXDataType)2, 5268 },
	{ (Il2CppRGCTXDataType)2, 7221 },
	{ (Il2CppRGCTXDataType)3, 33561 },
	{ (Il2CppRGCTXDataType)3, 13952 },
	{ (Il2CppRGCTXDataType)3, 17427 },
	{ (Il2CppRGCTXDataType)3, 37929 },
	{ (Il2CppRGCTXDataType)2, 7230 },
	{ (Il2CppRGCTXDataType)3, 33586 },
	{ (Il2CppRGCTXDataType)3, 17440 },
	{ (Il2CppRGCTXDataType)2, 5270 },
	{ (Il2CppRGCTXDataType)2, 7228 },
	{ (Il2CppRGCTXDataType)3, 33579 },
	{ (Il2CppRGCTXDataType)3, 18927 },
	{ (Il2CppRGCTXDataType)3, 10284 },
	{ (Il2CppRGCTXDataType)3, 13954 },
	{ (Il2CppRGCTXDataType)3, 10283 },
	{ (Il2CppRGCTXDataType)3, 17441 },
	{ (Il2CppRGCTXDataType)3, 37931 },
	{ (Il2CppRGCTXDataType)2, 7238 },
	{ (Il2CppRGCTXDataType)3, 33605 },
	{ (Il2CppRGCTXDataType)3, 17454 },
	{ (Il2CppRGCTXDataType)2, 5272 },
	{ (Il2CppRGCTXDataType)2, 7236 },
	{ (Il2CppRGCTXDataType)3, 33597 },
	{ (Il2CppRGCTXDataType)3, 17455 },
	{ (Il2CppRGCTXDataType)2, 4052 },
	{ (Il2CppRGCTXDataType)2, 4190 },
	{ (Il2CppRGCTXDataType)3, 13958 },
	{ (Il2CppRGCTXDataType)3, 13957 },
	{ (Il2CppRGCTXDataType)2, 7225 },
	{ (Il2CppRGCTXDataType)3, 33570 },
	{ (Il2CppRGCTXDataType)3, 37934 },
	{ (Il2CppRGCTXDataType)2, 7235 },
	{ (Il2CppRGCTXDataType)3, 33596 },
	{ (Il2CppRGCTXDataType)3, 17447 },
	{ (Il2CppRGCTXDataType)2, 5271 },
	{ (Il2CppRGCTXDataType)2, 7232 },
	{ (Il2CppRGCTXDataType)3, 33588 },
	{ (Il2CppRGCTXDataType)3, 13956 },
	{ (Il2CppRGCTXDataType)3, 13955 },
	{ (Il2CppRGCTXDataType)3, 17448 },
	{ (Il2CppRGCTXDataType)2, 7224 },
	{ (Il2CppRGCTXDataType)3, 33569 },
	{ (Il2CppRGCTXDataType)3, 37933 },
	{ (Il2CppRGCTXDataType)2, 7231 },
	{ (Il2CppRGCTXDataType)3, 33587 },
	{ (Il2CppRGCTXDataType)3, 17461 },
	{ (Il2CppRGCTXDataType)2, 5273 },
	{ (Il2CppRGCTXDataType)2, 7240 },
	{ (Il2CppRGCTXDataType)3, 33607 },
	{ (Il2CppRGCTXDataType)3, 18928 },
	{ (Il2CppRGCTXDataType)3, 10286 },
	{ (Il2CppRGCTXDataType)3, 13960 },
	{ (Il2CppRGCTXDataType)3, 13959 },
	{ (Il2CppRGCTXDataType)3, 10285 },
	{ (Il2CppRGCTXDataType)3, 17462 },
	{ (Il2CppRGCTXDataType)2, 7226 },
	{ (Il2CppRGCTXDataType)3, 33571 },
	{ (Il2CppRGCTXDataType)3, 37935 },
	{ (Il2CppRGCTXDataType)2, 7239 },
	{ (Il2CppRGCTXDataType)3, 33606 },
	{ (Il2CppRGCTXDataType)3, 13949 },
	{ (Il2CppRGCTXDataType)3, 13950 },
	{ (Il2CppRGCTXDataType)3, 13961 },
	{ (Il2CppRGCTXDataType)3, 476 },
	{ (Il2CppRGCTXDataType)3, 475 },
	{ (Il2CppRGCTXDataType)2, 4041 },
	{ (Il2CppRGCTXDataType)2, 4181 },
	{ (Il2CppRGCTXDataType)3, 13951 },
	{ (Il2CppRGCTXDataType)2, 4060 },
	{ (Il2CppRGCTXDataType)2, 4204 },
	{ (Il2CppRGCTXDataType)3, 478 },
	{ (Il2CppRGCTXDataType)2, 1327 },
	{ (Il2CppRGCTXDataType)2, 1615 },
	{ (Il2CppRGCTXDataType)3, 474 },
	{ (Il2CppRGCTXDataType)3, 477 },
	{ (Il2CppRGCTXDataType)3, 145 },
	{ (Il2CppRGCTXDataType)3, 146 },
	{ (Il2CppRGCTXDataType)2, 4035 },
	{ (Il2CppRGCTXDataType)2, 4177 },
	{ (Il2CppRGCTXDataType)3, 148 },
	{ (Il2CppRGCTXDataType)2, 955 },
	{ (Il2CppRGCTXDataType)2, 1603 },
	{ (Il2CppRGCTXDataType)3, 144 },
	{ (Il2CppRGCTXDataType)3, 147 },
	{ (Il2CppRGCTXDataType)3, 511 },
	{ (Il2CppRGCTXDataType)3, 512 },
	{ (Il2CppRGCTXDataType)2, 6908 },
	{ (Il2CppRGCTXDataType)3, 31327 },
	{ (Il2CppRGCTXDataType)2, 4044 },
	{ (Il2CppRGCTXDataType)2, 4183 },
	{ (Il2CppRGCTXDataType)3, 31328 },
	{ (Il2CppRGCTXDataType)3, 514 },
	{ (Il2CppRGCTXDataType)2, 960 },
	{ (Il2CppRGCTXDataType)2, 1619 },
	{ (Il2CppRGCTXDataType)3, 510 },
	{ (Il2CppRGCTXDataType)3, 513 },
	{ (Il2CppRGCTXDataType)3, 461 },
	{ (Il2CppRGCTXDataType)2, 6906 },
	{ (Il2CppRGCTXDataType)3, 31324 },
	{ (Il2CppRGCTXDataType)2, 4038 },
	{ (Il2CppRGCTXDataType)2, 4179 },
	{ (Il2CppRGCTXDataType)3, 31325 },
	{ (Il2CppRGCTXDataType)3, 31326 },
	{ (Il2CppRGCTXDataType)3, 463 },
	{ (Il2CppRGCTXDataType)2, 957 },
	{ (Il2CppRGCTXDataType)2, 1613 },
	{ (Il2CppRGCTXDataType)3, 460 },
	{ (Il2CppRGCTXDataType)3, 462 },
	{ (Il2CppRGCTXDataType)3, 131 },
	{ (Il2CppRGCTXDataType)2, 953 },
	{ (Il2CppRGCTXDataType)3, 133 },
	{ (Il2CppRGCTXDataType)2, 1601 },
	{ (Il2CppRGCTXDataType)3, 130 },
	{ (Il2CppRGCTXDataType)3, 132 },
	{ (Il2CppRGCTXDataType)2, 8075 },
	{ (Il2CppRGCTXDataType)2, 3178 },
	{ (Il2CppRGCTXDataType)3, 12946 },
	{ (Il2CppRGCTXDataType)2, 3353 },
	{ (Il2CppRGCTXDataType)2, 8196 },
	{ (Il2CppRGCTXDataType)3, 31321 },
	{ (Il2CppRGCTXDataType)3, 31322 },
	{ (Il2CppRGCTXDataType)2, 4309 },
	{ (Il2CppRGCTXDataType)3, 31323 },
	{ (Il2CppRGCTXDataType)2, 854 },
	{ (Il2CppRGCTXDataType)2, 1606 },
	{ (Il2CppRGCTXDataType)3, 420 },
	{ (Il2CppRGCTXDataType)3, 26189 },
	{ (Il2CppRGCTXDataType)2, 6388 },
	{ (Il2CppRGCTXDataType)3, 26203 },
	{ (Il2CppRGCTXDataType)2, 1982 },
	{ (Il2CppRGCTXDataType)3, 2422 },
	{ (Il2CppRGCTXDataType)3, 26195 },
	{ (Il2CppRGCTXDataType)3, 10241 },
	{ (Il2CppRGCTXDataType)2, 990 },
	{ (Il2CppRGCTXDataType)3, 26190 },
	{ (Il2CppRGCTXDataType)2, 6384 },
	{ (Il2CppRGCTXDataType)3, 2553 },
	{ (Il2CppRGCTXDataType)2, 2019 },
	{ (Il2CppRGCTXDataType)2, 3250 },
	{ (Il2CppRGCTXDataType)3, 10247 },
	{ (Il2CppRGCTXDataType)3, 26191 },
	{ (Il2CppRGCTXDataType)3, 10236 },
	{ (Il2CppRGCTXDataType)3, 10237 },
	{ (Il2CppRGCTXDataType)3, 10235 },
	{ (Il2CppRGCTXDataType)3, 10238 },
	{ (Il2CppRGCTXDataType)2, 3246 },
	{ (Il2CppRGCTXDataType)2, 8122 },
	{ (Il2CppRGCTXDataType)3, 13947 },
	{ (Il2CppRGCTXDataType)3, 10240 },
	{ (Il2CppRGCTXDataType)2, 3875 },
	{ (Il2CppRGCTXDataType)3, 10239 },
	{ (Il2CppRGCTXDataType)2, 3741 },
	{ (Il2CppRGCTXDataType)2, 8070 },
	{ (Il2CppRGCTXDataType)2, 4011 },
	{ (Il2CppRGCTXDataType)2, 4158 },
	{ (Il2CppRGCTXDataType)3, 12929 },
	{ (Il2CppRGCTXDataType)2, 3347 },
	{ (Il2CppRGCTXDataType)3, 14609 },
	{ (Il2CppRGCTXDataType)3, 14610 },
	{ (Il2CppRGCTXDataType)2, 3633 },
	{ (Il2CppRGCTXDataType)3, 14613 },
	{ (Il2CppRGCTXDataType)2, 3633 },
	{ (Il2CppRGCTXDataType)3, 14618 },
	{ (Il2CppRGCTXDataType)2, 3744 },
	{ (Il2CppRGCTXDataType)3, 14622 },
	{ (Il2CppRGCTXDataType)3, 14630 },
	{ (Il2CppRGCTXDataType)3, 14629 },
	{ (Il2CppRGCTXDataType)2, 8194 },
	{ (Il2CppRGCTXDataType)3, 14612 },
	{ (Il2CppRGCTXDataType)3, 14611 },
	{ (Il2CppRGCTXDataType)3, 14623 },
	{ (Il2CppRGCTXDataType)2, 4304 },
	{ (Il2CppRGCTXDataType)3, 14620 },
	{ (Il2CppRGCTXDataType)3, 40109 },
	{ (Il2CppRGCTXDataType)2, 3257 },
	{ (Il2CppRGCTXDataType)3, 10269 },
	{ (Il2CppRGCTXDataType)1, 3872 },
	{ (Il2CppRGCTXDataType)2, 8083 },
	{ (Il2CppRGCTXDataType)3, 14619 },
	{ (Il2CppRGCTXDataType)1, 8083 },
	{ (Il2CppRGCTXDataType)1, 4304 },
	{ (Il2CppRGCTXDataType)2, 8194 },
	{ (Il2CppRGCTXDataType)2, 8083 },
	{ (Il2CppRGCTXDataType)2, 4013 },
	{ (Il2CppRGCTXDataType)2, 4160 },
	{ (Il2CppRGCTXDataType)3, 14615 },
	{ (Il2CppRGCTXDataType)3, 14626 },
	{ (Il2CppRGCTXDataType)3, 14625 },
	{ (Il2CppRGCTXDataType)3, 14627 },
	{ (Il2CppRGCTXDataType)3, 14632 },
	{ (Il2CppRGCTXDataType)3, 14617 },
	{ (Il2CppRGCTXDataType)3, 14614 },
	{ (Il2CppRGCTXDataType)3, 14628 },
	{ (Il2CppRGCTXDataType)3, 14621 },
	{ (Il2CppRGCTXDataType)3, 14616 },
	{ (Il2CppRGCTXDataType)3, 14624 },
	{ (Il2CppRGCTXDataType)3, 14631 },
	{ (Il2CppRGCTXDataType)2, 702 },
	{ (Il2CppRGCTXDataType)3, 10287 },
	{ (Il2CppRGCTXDataType)2, 971 },
};
extern const CustomAttributesCacheGenerator g_System_Core_AttributeGenerators[];
IL2CPP_EXTERN_C const Il2CppCodeGenModule g_System_Core_CodeGenModule;
const Il2CppCodeGenModule g_System_Core_CodeGenModule = 
{
	"System.Core.dll",
	206,
	s_methodPointers,
	0,
	NULL,
	s_InvokerIndices,
	0,
	NULL,
	58,
	s_rgctxIndices,
	296,
	s_rgctxValues,
	NULL,
	g_System_Core_AttributeGenerators,
	NULL, // module initializer,
	NULL,
	NULL,
	NULL,
};
